using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Spikes.DataReader
{
    public class Connection : ISourceConnection
    {
        //public string ConnectionString => return ConfigurationManager.AppSettings["AMSConnectionString"];
        public string ConnectionString { get { return ConfigurationManager.AppSettings["AMSConnectionString"]; } }

        IDbConnection ISourceConnection.Connection => throw new NotImplementedException();

        public bool TestConnection()
        {
            throw new NotImplementedException();
        }
    }
}
