using System;
using System.Collections.Generic;
using System.Linq;

namespace Betting.Spikes.DataReader.Readers
{
    public interface IAccountReader
    {
        IList<Account> Read();
    }
}
