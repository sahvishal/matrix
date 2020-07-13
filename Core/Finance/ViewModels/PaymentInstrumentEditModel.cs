using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class PaymentInstrumentEditModel : ViewModelBase
    {
        public int PaymentType { get; set; }
        public decimal Amount { get; set; }

        public ChargeCardPaymentEditModel ChargeCard { get; set; }
        public CheckPaymentEditModel Check { get; set; }
        public ECheckPaymentEditModel ECheck { get; set; }
        public GiftCertificatePaymentEditModel GiftCertificate { get; set; }
        public InsurancePaymentEditModel Insurance { get; set; }

        public AddressEditModel BillingAddress { get; set; } // Needed in case of Charge Card and Echeck
        public bool IsProcessed { get; set; } // Whether the current mode was processed or not
    }
}