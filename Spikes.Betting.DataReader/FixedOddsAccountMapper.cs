using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Spikes.DataReader
{
    public static class FixedOddsAccountMapper
    {
        public static string GetPhoneNumber(DataRow row)
        {
            var phoneNumber = Convert.ToString(row["MOBILE_PHONE_NUMBER"]);

            if (string.IsNullOrEmpty(phoneNumber))
                phoneNumber = Convert.ToString(row["HOME_PHONE_NUMBER"]);

            if (string.IsNullOrEmpty(phoneNumber))
                phoneNumber = Convert.ToString(row["WORK_PHONE_NUMBER"]);

            return phoneNumber;
        }

        public static string GetPhoneNumber(IDataReader reader)
        {
            var phoneNumber = Convert.ToString(reader["MOBILE_PHONE_NUMBER"]);

            if (string.IsNullOrEmpty(phoneNumber))
                phoneNumber = Convert.ToString(reader["HOME_PHONE_NUMBER"]);

            if (string.IsNullOrEmpty(phoneNumber))
                phoneNumber = Convert.ToString(reader["WORK_PHONE_NUMBER"]);

            return phoneNumber;
        }

        public static string GetPhoneNumber(string mobile, string home, string work)
        {
            return mobile ?? home ?? work;
        }

        public static int FindNearest(int[] values, int targetNumber)
        {
            var nearest = values.OrderBy(x => Math.Abs((long)x - targetNumber)).First();
            return nearest;
        }

        public static int GetSelfExclusionDuration(Account account)
        {
            int[] values = { 6, 12, 24, 36, 48, 60 };
            int differnceInDays = account.SelfExclusionExpiry.Value.Subtract(account.SelfExclusionDate.Value).Days;
            return FindNearest(values, differnceInDays);
        }

        public static int GetPlayBreakDuration(Account account)
        {
            int[] values = { 1, 7, 21, 28, 42 };
            int differnceInDays = account.PlayBreakExpiry.Value.Subtract(account.PlayBreakRequestDate.Value).Days;
            return FindNearest(values, differnceInDays);
        }

    }
}
