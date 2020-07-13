using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class PaymentInstructions: DomainObjectBase
    {
        public string BankName { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string Memo { get; set; }
        public string SpecialInsructions { get; set; }
        public AccountType AccountType { get; set; }
        public VendorPaymentMode PaymentMode { get; set; } 
        public PaymentFrequency Interval { get; set; }

        public PaymentInstructions(long id) : base(id) { }
        public PaymentInstructions() { }
    }
}
