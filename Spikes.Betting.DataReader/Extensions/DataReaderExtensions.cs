using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace Betting.Spikes.DataReader.Extensions
{
    internal static class DataReaderExtensions
    {
        internal static T Get<T>(this IDataReader reader, string fieldName)
        {
            int fieldIndex = fieldIndex = reader.GetOrdinal(fieldName);    
            return !reader.IsDBNull(fieldIndex) ? (T)reader.GetValue(fieldIndex) : default(T);
        }

        internal static T Get<T>(this IDataReader reader, int fieldIndex)
        {
            return !reader.IsDBNull(fieldIndex) ? (T)reader.GetValue(fieldIndex) : default(T);
        }

        internal static T Get<T>(this OracleDataReader reader, string fieldName)
        {
            int fieldIndex = fieldIndex = reader.GetOrdinal(fieldName);
            return !reader.IsDBNull(fieldIndex) ? reader.GetFieldValue<T>(fieldIndex) : default(T);
        }
    }
}
