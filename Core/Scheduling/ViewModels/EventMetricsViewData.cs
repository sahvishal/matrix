using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventMetricsViewData
    {
        // Customer Details
        public int RegisteredCustomersCount { get; set; }
        public int AttendedCustomersCount { get; set; }
        public int PaidCustomersCount { get; set; }
        public int NoShowCustomersCount { get; set; }
        public int CancelledCustomersCount { get; set; }
        public int LeftWithoutScreeningCustomersCount { get; set; }

        // Revenue Details
        public decimal ChargeCardRevenue { get; set; }
        public int ChargeCardCount { get; set; }
        public decimal CheckRevenue { get; set; }
        public int CheckCount { get; set; }
        public decimal ECheckRevenue { get; set; }
        public int ECheckCount { get; set; }
        public decimal CashRevenue { get; set; }
        public int CashCount { get; set; }
        public decimal GiftCertificateRevenue { get; set; }
        public int GiftCertificateCount { get; set; }
        public int UnPaidCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal UnPaidRevenue { get; set; }
        public int UnPaidExcluedeNoShowCount { get; set; }
        public decimal UnPaidExcluedeNoShowRevenue { get; set; }

        // Metrics Details
        public decimal PhonePayments { get; set; }
        public int PhonePaymentCount { get; set; }
        public decimal InternetPayments { get; set; }
        public int InternetPaymentCount { get; set; }
        public decimal OnsitePayments { get; set; }
        public int OnsitePaymentCount { get; set; }
        public decimal UpGradePayments { get; set; }
        public int UpGradePaymentCount { get; set; }
        public decimal DownGradePayments { get; set; }
        public int DownGradePaymentCount { get; set; }

        public decimal AverageRevenuePerClient
        {
            get
            {
                return PhonePaymentCount + InternetPaymentCount + OnsitePaymentCount > 0 ? ((PhonePayments + InternetPayments + OnsitePayments) /
                    (PhonePaymentCount + InternetPaymentCount + OnsitePaymentCount)) : 0.0m;
            }
        }

        public IEnumerable<OrderedPair<string, int>> TestOrderedPair { get; set; }

        //General
        public int HipaaSignedCount { get; set; }
        public int HipaaUnSignedCount { get; set; }
    }
}