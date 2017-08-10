using Betting.Spikes.DataReader.Builders;
using log4net;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Spikes.DataReader.Readers
{
    public class NewReader : IAccountReader
    {
        private readonly ILog logger;
        private readonly ISourceConnection connectionData;
        private IAccountBuilder accountBuilder;
        private string commandText;

        public NewReader(ISourceConnection connection, IAccountBuilder accountBuilder)
        {
            logger = LogManager.GetLogger(GetType());
            this.connectionData = connection;
            this.accountBuilder = accountBuilder;

            int numberOfAccounts = int.Parse(ConfigurationManager.AppSettings["numberOfAccounts"]);
            commandText = ConfigurationManager.AppSettings["commandString"];

            if (numberOfAccounts > 0)
                commandText += $" where rownum <= {numberOfAccounts}";

            commandText += " order by a.ACCOUNT_NUMBER";
        }

        public IList<Account> Read()
        {
            var accounts = new List<Account>();

            try
            {
                using (var connection = new OracleConnection(connectionData.ConnectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = commandText;
                    command.CommandType = System.Data.CommandType.Text;

                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (accountBuilder is NewAccountBuilderUsingOrdinals)
                        ((NewAccountBuilderUsingOrdinals)accountBuilder).CreateMapping(reader);

                    while (reader.Read())
                    {
                        Account account = accountBuilder.CreateAccount(reader);
                        accounts.Add(account);
                        logger.Info($"Account No: {account.AccountNumber} created.");
                    }                    
                }

                logger.Info($"Total created Accounts: - {accounts.Count}");
            }
            catch (Exception exc)
            {
                logger.Error($"Error creating Accounts. {exc}");
                throw;
            }

            return accounts;
        }
    }
}
