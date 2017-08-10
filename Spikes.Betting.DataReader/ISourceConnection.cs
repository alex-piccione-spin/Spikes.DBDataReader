using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Betting.Spikes.DataReader
{
    public interface ISourceConnection
    {
        string ConnectionString { get; }
        IDbConnection Connection { get; }
        bool TestConnection();
    }
}
