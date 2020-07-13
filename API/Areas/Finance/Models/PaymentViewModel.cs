using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Finance.Enum;

namespace API.Areas.Finance.Models
{
    public class PaymentViewModel : ResponseBaseModel
    {
        public PaymentViewModel()
            : base(null)
        {
            AllowedPaymentTypes = new[] {
                                             new OrderedPair<long, string>(PaymentType.CreditCard.PersistenceLayerId, PaymentType.CreditCard.Name),
                                             new OrderedPair<long, string>(PaymentType.GiftCertificate.PersistenceLayerId, PaymentType.GiftCertificate.Name),
                                             new OrderedPair<long, string>(PaymentType.Check.PersistenceLayerId,PaymentType.Check.Name),
                                             new OrderedPair<long, string>(PaymentType.Cash.PersistenceLayerId, PaymentType.Cash.Name)
                                         };
        }

        public bool IsRefundEnabled { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal TotalAmount { get; set; }
        public long OrderId { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }

        public IEnumerable<OrderedPair<long, string>> AllowedPaymentTypes { get; set; }

    }
}