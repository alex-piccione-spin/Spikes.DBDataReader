using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using log4net;
using Oracle.ManagedDataAccess.Client;

using static Betting.Spikes.DataReader.FixedOddsAccountMapper;
using Betting.Spikes.DataReader.Extensions;

namespace Betting.Spikes.DataReader.Builders
{
    public class NewAccountBuilder : IAccountBuilder
    {
        private readonly ILog logger;

        public NewAccountBuilder()
        {
            logger = LogManager.GetLogger(GetType());
        }

        public Account CreateAccount(DataRow row)
        {
            throw new Exception("Not implemented. Use a DataReader instead of a DataRow");
        }

        public Account CreateAccount(IDataReader reader)
        {
            Account account = new Account
            {
                AccountId = reader.GetInt32(reader.GetOrdinal("ACCOUNTS_ID")),
                AccountNumber = reader.Get<string>("ACCOUNT_NUMBER"),
                Email = reader.Get<string>("EMAIL"),
                Title = reader.Get<string>("TITLE"),
                FirstName = reader.Get<string>("FIRST_NAME"),
                LastName = reader.Get<string>("LAST_NAME"),

                AddressLine1 = reader.Get<string>("LINE1"),
                AddressLine2 = reader.Get<string>("LINE2"),
                County = reader.Get<string>("COUNTY"),
                PostCode = reader.Get<string>("POSTCODE"),
                City = reader.Get<string>("TOWN_CITY"),
                Country = reader.Get<string>("COUNTRY_ID"),
                MobilePhone = GetPhoneNumber(reader),
                RingFencedFunds = true // true by deafult to enable accounts on GPP              
            };

            account.DateOfBirth = reader.Get<DateTime>("DATE_OF_BIRTH");
            account.PlayBreakRequestDate = reader.Get<DateTime>("TIMEOUT_START_DATE");
            account.PlayBreakExpiry = reader.Get<DateTime>("TIMEOUT_END_DATE");
            account.PlayBreakDuration = (int?)reader.Get<decimal>("TIMEOUT_DURATION");
            account.SelfExclusionDate = reader.Get<DateTime>("SELF_EXCLUDE_START_DATE");
            account.SelfExclusionExpiry = reader.Get<DateTime>("SELF_EXCLUDE_END_DATE");

            if (account.SelfExclusionDate.HasValue && account.SelfExclusionExpiry.HasValue)
            {
                account.SelfExclusionDuration = GetSelfExclusionDuration(account);
            }
            return account;
        }
    }
}
