using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Spikes.DataReader
{
    public class Account
    {

        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string MobilePhone { get; set; }
        public bool RingFencedFunds { get; set; }

        //string
        public string LandlinePhone { get; set; }
        public string TelebettingId { get; set; }
        public string TelebettingPassword { get; set; }
        public string Currency { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountSortCode { get; set; }
        public string Status { get; set; }
        public string StatementFrequency { get; set; }
        public string CreditPaymentTerms { get; set; }
        public string AmlStatus { get; set; }
        public string KycStatus { get; set; }
        public string TradingNotes { get; set; }
        public string SecurityNotes { get; set; }
        public string OddsFormat { get; set; }

        //Bool
        public bool? CreditAccount { get; set; }
        public bool? PrintedStatement { get; set; }
        public bool? AmlWatchlist { get; set; }
        public bool? Commission { get; set; }
        public bool? Watchlist { get; set; }
        public bool? MailingEnabled { get; set; }
        public bool? BetReferralEnabled { get; set; }
        public bool? ChatEnabled { get; set; }
        public bool? IsIndustry { get; set; }
        public bool? IsArbitrage { get; set; }
        public bool? HasSpreads { get; set; }
        public bool? HasCasino { get; set; }
        public bool? IsHVC { get; set; }
        public bool? IsFastFinger { get; set; }
        public bool? IsSPOnly { get; set; }

        //Integer
        public int? CreditLimit { get; set; }
        public int? DailyDepositLimit { get; set; }
        public int? WeeklyDepositLimit { get; set; }
        public int? MonthlyDepositLimit { get; set; }
        public int? RequestedDailyDepositLimit { get; set; }
        public int? RequestedWeeklyDepositLimit { get; set; }
        public int? RequestedMonthlyDepositLimit { get; set; }
        public int? PlayBreakDuration { get; set; }
        public int? RealityCheckFrequency { get; set; }
        public int? RequestedRealityCheckFrequency { get; set; }
        public int? SelfExclusionDuration { get; set; }
        public int? FailedLoginAttempts { get; set; }

        //float
        public float StakeFactor { get; set; }

        //DateTime
        public DateTime? DailyDepositLimitDateSet { get; set; }
        public DateTime? WeeklyDepositLimitDateSet { get; set; }
        public DateTime? MonthlyDepositLimitDateSet { get; set; }
        public DateTime? DailyDepositLimitRequestDate { get; set; }
        public DateTime? WeeklyDepositLimitRequestDate { get; set; }
        public DateTime? MonthlyDepositLimitRequestDate { get; set; }
        public DateTime? PlayBreakExpiry { get; set; }
        public DateTime? PlayBreakRequestDate { get; set; }
        public DateTime? RealityCheckFrequencyDateSet { get; set; }
        public DateTime? RealityCheckFrequencyRequestDate { get; set; }
        public DateTime? SelfExclusionDate { get; set; }
        public DateTime? SelfExclusionExpiry { get; set; }

        //Array possible values from (email, sms, phone)
        public string[] ContactPreferences { get; set; }
    }

}