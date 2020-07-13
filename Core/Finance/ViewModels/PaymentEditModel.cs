using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class PaymentEditModel
    {
        public decimal Amount { get; set; }
        public bool IsModeMultiple { get; set; }
        
        [UIHint("Hidden")]
        public PaymentFlow PaymentFlow { get; set; }
        public IEnumerable<OrderedPair<long, string>> AllowedPaymentTypes { get; set; }
        public IEnumerable<PaymentInstrumentEditModel> Payments { get; set; }
        public decimal AmountinProcess
        {
            get
            {
                if (Payments != null && Payments.Count() > 0)
                    return Payments.Where(p => p.PaymentType != PaymentType.Onsite_Value).Select(pi => pi.Amount).Sum();

                return 0;
            }
        }

        public decimal PendingAmount
        {
            get
            {
                return Amount - AmountinProcess;
            }
        }

        public ChargeCardPaymentEditModel ChargeCardonFile { get; set; }

        //TODO: Used to generate the Address View in Payment Edit model
        public AddressEditModel ExistingBillingAddress { get; set; }

        public AddressEditModel ExistingShippingAddress { get; set; }

        public bool ShippingAddressSameAsBillingAddress { get; set; }

        public bool IsTemporaryBookedSlotExpired { get; set; }
    }

    public enum PaymentFlow
    {
        In,
        Out
    }
}