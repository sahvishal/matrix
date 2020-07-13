using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo.ViewModels;

namespace API.Areas.Finance.Models
{
    [NoValidationRequired]
    public class PaymentEditModel
    {
        public long EventId { get; set; }

        public long CustomerId { get; set; }

        public int PaymentMode { get; set; }

        public bool IsModeMultiple { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal UnPaidAmount { get; set; }

        public GiftCertificatPaymentModel GcPayment { get; set; }

        public PaymentFlow PaymentFlow { get; set; }

        public bool IsOnSitePayment { get; set; }

        public PaymentInstrumentEditModel Payments { get; set; }

        public AddressEditModel BillingAddress { get; set; }
    }
}