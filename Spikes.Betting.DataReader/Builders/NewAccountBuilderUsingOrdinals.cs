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
    public class NewAccountBuilderUsingOrdinals : IAccountBuilder
    {
        private readonly ILog logger;
        private FieldIndexes mapping;

        public NewAccountBuilderUsingOrdinals()
        {
            logger = LogManager.GetLogger(GetType());
        }

        public Account CreateAccount(DataRow row)
        {
            throw new Exception("Not implemented. Use a DataReader instead of a DataRow");
        }

        public void CreateMapping(IDataReader reader)
        {
            //try
            //{
                mapping = new FieldIndexes()
                {
                    ACCOUNTS_ID = reader.GetOrdinal("ACCOUNTS_ID"),
                    ACCOUNT_NUMBER = reader.GetOrdinal("ACCOUNT_NUMBER"),
                    EMAIL = reader.GetOrdinal("EMAIL"),
                    TITLE = reader.GetOrdinal("TITLE"),
                    FIRST_NAME = reader.GetOrdinal("FIRST_NAME"),
                    LAST_NAME = reader.GetOrdinal("LAST_NAME"),
                    LINE1 = reader.GetOrdinal("LINE1"),
                    LINE2 = reader.GetOrdinal("LINE2"),
                    COUNTY = reader.GetOrdinal("COUNTY"),
                    POSTCODE = reader.GetOrdinal("POSTCODE"),
                    TOWN_CITY = reader.GetOrdinal("TOWN_CITY"),
                    COUNTRY_ID = reader.GetOrdinal("COUNTRY_ID"),
                    MOBILE_PHONE_NUMBER = reader.GetOrdinal("MOBILE_PHONE_NUMBER"),
                    HOME_PHONE_NUMBER = reader.GetOrdinal("HOME_PHONE_NUMBER"),
                    WORK_PHONE_NUMBER = reader.GetOrdinal("WORK_PHONE_NUMBER"),
                    DATE_OF_BIRTH = reader.GetOrdinal("DATE_OF_BIRTH"),
                    TIMEOUT_START_DATE = reader.GetOrdinal("TIMEOUT_START_DATE"),
                    TIMEOUT_END_DATE = reader.GetOrdinal("TIMEOUT_END_DATE"),
                    TIMEOUT_DURATION = reader.GetOrdinal("TIMEOUT_DURATION"),
                    SELF_EXCLUDE_START_DATE = reader.GetOrdinal("SELF_EXCLUDE_START_DATE"),
                    SELF_EXCLUDE_END_DATE = reader.GetOrdinal("SELF_EXCLUDE_END_DATE"),
                    SELF_EXCLUDE_DURATION = reader.GetOrdinal("SELF_EXCLUDE_DURATION"),
                };
            //}
            //catch (IndexOutOfRangeException exc)
            //{
            //    throw new IndexOutOfRangeException($"Fail to find some columns in the DataREader. Check the SQL field returned by the query.", exc);
            //}
        }

        public Account CreateAccount(IDataReader reader)
        {
            Account account = new Account
            {
                AccountId = reader.GetInt32(mapping.ACCOUNTS_ID),
                AccountNumber = reader.Get<string>(mapping.ACCOUNT_NUMBER),
                Email = reader.Get<string>(mapping.EMAIL),
                Title = reader.Get<string>(mapping.TITLE),
                FirstName = reader.Get<string>(mapping.FIRST_NAME),
                LastName = reader.Get<string>(mapping.LAST_NAME),

                AddressLine1 = reader.Get<string>(mapping.LINE1),
                AddressLine2 = reader.Get<string>(mapping.LINE2),
                County = reader.Get<string>(mapping.COUNTY),
                PostCode = reader.Get<string>(mapping.POSTCODE),
                City = reader.Get<string>(mapping.TOWN_CITY),
                Country = reader.Get<string>(mapping.COUNTRY_ID),
                //MobilePhone = GetPhoneNumber(reader),
                MobilePhone = reader.Get<string>(mapping.MOBILE_PHONE_NUMBER) ??
                    reader.Get<string>(mapping.HOME_PHONE_NUMBER) ??
                    reader.Get<string>(mapping.WORK_PHONE_NUMBER),

                RingFencedFunds = true // true by deafult to enable accounts on GPP              
            };

            account.DateOfBirth = reader.Get<DateTime>(mapping.DATE_OF_BIRTH);
            account.PlayBreakRequestDate = reader.Get<DateTime>(mapping.TIMEOUT_START_DATE);
            account.PlayBreakExpiry = reader.Get<DateTime>(mapping.TIMEOUT_END_DATE);
            account.PlayBreakDuration = (int?)reader.Get<decimal>(mapping.TIMEOUT_DURATION);
            account.SelfExclusionDate = reader.Get<DateTime>(mapping.SELF_EXCLUDE_START_DATE);
            account.SelfExclusionExpiry = reader.Get<DateTime>(mapping.SELF_EXCLUDE_END_DATE);
            
            if (account.SelfExclusionDate.HasValue && account.SelfExclusionExpiry.HasValue && reader.IsDBNull(mapping.SELF_EXCLUDE_DURATION))
            {
                account.SelfExclusionDuration = GetSelfExclusionDuration(account);
            }

            return account;
        }

        internal class FieldIndexes
        {
            internal int ACCOUNTS_ID;
            internal int ACCOUNT_NUMBER;
            internal int EMAIL;            
            internal int TITLE;
            internal int FIRST_NAME;
            internal int LAST_NAME;
            internal int LINE1;
            internal int LINE2;
            internal int COUNTY;
            internal int POSTCODE;
            internal int TOWN_CITY;
            internal int COUNTRY_ID;
            internal int MOBILE_PHONE_NUMBER;
            internal int HOME_PHONE_NUMBER;
            internal int WORK_PHONE_NUMBER;
            internal int DATE_OF_BIRTH;
            internal int TIMEOUT_START_DATE;
            internal int TIMEOUT_END_DATE;
            internal int TIMEOUT_DURATION;
            internal int SELF_EXCLUDE_START_DATE;
            internal int SELF_EXCLUDE_END_DATE;
            internal int SELF_EXCLUDE_DURATION;            
        }
    }
}
