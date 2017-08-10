using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using log4net;
using Oracle.ManagedDataAccess.Client;
using static Betting.Spikes.DataReader.FixedOddsAccountMapper;


namespace Betting.Spikes.DataReader.Builders
{
    public class AccountBuilder : IAccountBuilder
    {
        private readonly ILog logger;

        public AccountBuilder()
        {
            logger = LogManager.GetLogger(GetType());
        }

        public Account CreateAccount(DataRow row)
        {
            Account account = new Account
            {
                AccountId = int.Parse(Convert.ToString(row["ACCOUNTS_ID"])),
                AccountNumber = Convert.ToString(row["ACCOUNT_NUMBER"]),
                Email = Convert.ToString(row["EMAIL"]),
                Title = Convert.ToString(row["TITLE"]),
                FirstName = Convert.ToString(row["FIRST_NAME"]),
                LastName = Convert.ToString(row["LAST_NAME"]),

                AddressLine1 = Convert.ToString(row["LINE1"]),
                AddressLine2 = Convert.ToString(row["LINE2"]),
                County = Convert.ToString(row["COUNTY"]),
                PostCode = Convert.ToString(row["POSTCODE"]),
                City = Convert.ToString(row["TOWN_CITY"]),
                Country = Convert.ToString(row["COUNTRY_ID"]),
                MobilePhone = GetPhoneNumber(row),
                RingFencedFunds = true // true by deafult to enable accounts on GPP              
            };


            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(row["DATE_OF_BIRTH"])) == false)
                {
                    account.DateOfBirth = DateTime.Parse(Convert.ToString(row["DATE_OF_BIRTH"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'DATE_OF_BIRTH' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(row["TIMEOUT_START_DATE"])) == false)
                {
                    account.PlayBreakRequestDate = DateTime.Parse(Convert.ToString(row["TIMEOUT_START_DATE"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'TIMEOUT_START_DATE' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(row["TIMEOUT_END_DATE"])) == false)
                {
                    account.PlayBreakExpiry = DateTime.Parse(Convert.ToString(row["TIMEOUT_END_DATE"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'TIMEOUT_END_DATE' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(row["TIMEOUT_DURATION"])) == false)
                {
                    account.PlayBreakDuration = GetPlayBreakDuration(account);
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'TIMEOUT_DURATION' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(row["SELF_EXCLUDE_START_DATE"])) == false)
                {
                    account.SelfExclusionDate = DateTime.Parse(Convert.ToString(row["SELF_EXCLUDE_START_DATE"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'SELF_EXCLUDE_START_DATE' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(row["SELF_EXCLUDE_END_DATE"])) == false)
                {
                    account.SelfExclusionExpiry = DateTime.Parse(Convert.ToString(row["SELF_EXCLUDE_END_DATE"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'SELF_EXCLUDE_END_DATE' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(row["SELF_EXCLUDE_DURATION"])) == false)
                {
                    account.SelfExclusionDuration = GetSelfExclusionDuration(account);
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'SELF_EXCLUDE_DURATION' Error Message: - {e.Message}", e);
            }

            return account;
        }

        public Account CreateAccount(IDataReader reader)
        {
            Account account = new Account
            {
                AccountId = int.Parse(Convert.ToString(reader["ACCOUNTS_ID"])),
                AccountNumber = Convert.ToString(reader["ACCOUNT_NUMBER"]),
                Email = Convert.ToString(reader["EMAIL"]),
                Title = Convert.ToString(reader["TITLE"]),
                FirstName = Convert.ToString(reader["FIRST_NAME"]),
                LastName = Convert.ToString(reader["LAST_NAME"]),

                AddressLine1 = Convert.ToString(reader["LINE1"]),
                AddressLine2 = Convert.ToString(reader["LINE2"]),
                County = Convert.ToString(reader["COUNTY"]),
                PostCode = Convert.ToString(reader["POSTCODE"]),
                City = Convert.ToString(reader["TOWN_CITY"]),
                Country = Convert.ToString(reader["COUNTRY_ID"]),
                MobilePhone = GetPhoneNumber(reader),
                RingFencedFunds = true // true by deafult to enable accounts on GPP              
            };

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(reader["DATE_OF_BIRTH"])) == false)
                {
                    account.DateOfBirth = DateTime.Parse(Convert.ToString(reader["DATE_OF_BIRTH"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'DATE_OF_BIRTH' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(reader["TIMEOUT_START_DATE"])) == false)
                {
                    account.PlayBreakRequestDate = DateTime.Parse(Convert.ToString(reader["TIMEOUT_START_DATE"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'TIMEOUT_START_DATE' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(reader["TIMEOUT_END_DATE"])) == false)
                {
                    account.PlayBreakExpiry = DateTime.Parse(Convert.ToString(reader["TIMEOUT_END_DATE"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'TIMEOUT_END_DATE' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(reader["TIMEOUT_DURATION"])) == false)
                {
                    account.PlayBreakDuration = GetPlayBreakDuration(account);
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'TIMEOUT_DURATION' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(reader["SELF_EXCLUDE_START_DATE"])) == false)
                {
                    account.SelfExclusionDate = DateTime.Parse(Convert.ToString(reader["SELF_EXCLUDE_START_DATE"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'SELF_EXCLUDE_START_DATE' Error Message: - {e.Message}", e);
            }

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(reader["SELF_EXCLUDE_END_DATE"])) == false)
                {
                    account.SelfExclusionExpiry = DateTime.Parse(Convert.ToString(reader["SELF_EXCLUDE_END_DATE"]));
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'SELF_EXCLUDE_END_DATE' Error Message: - {e.Message}", e);
            }

            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(reader["SELF_EXCLUDE_DURATION"])))
                {
                    account.SelfExclusionDuration = GetSelfExclusionDuration(account);
                }
            }
            catch (Exception e)
            {
                logger.Error($"Populate Account parsing failed 'SELF_EXCLUDE_DURATION' Error Message: - {e.Message}", e);
            }

            return account;
        }
    }
}
