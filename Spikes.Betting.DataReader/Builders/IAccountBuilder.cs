using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Betting.Spikes.DataReader.Builders
{
    public interface IAccountBuilder
    {
        Account CreateAccount(DataRow row);
        Account CreateAccount(IDataReader reader);
    }
}