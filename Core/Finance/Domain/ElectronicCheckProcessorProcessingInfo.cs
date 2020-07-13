using System;
namespace Falcon.App.Core.Finance.Domain
{
    public class ElectronicCheckProcessorProcessingInfo : PaymentProcessorCommonInfo
    {
        public String BankRoutingNumber { get; set; }
        public String BankAccountType { get; set; }
        public String BankName { get; set; }
        public String BankAccountName { get; set; }
        public String CheckType { get; set; }
        public String CheckNumber { get; set; }
        public String PhoneNumber { get; set; }
        public String BankAccountNumber { get; set; }

    }
}