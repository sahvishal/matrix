using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ManualRefundEditModel:ViewModelBase
    {
        [UIHint("Hidden")]
        public long EventId { get; set; }

        [UIHint("Hidden")]
        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public Order Order { get; set; }
        
        //public bool IsRefundRequest { get; set; }

        public decimal TotalRefundRequestAmount { get; set; }
        public decimal AmountToRefund { get; set; }

        public RefundRequestEditModel RefundRequest { get; set; }
        public PaymentEditModel Payments { get; set; }
    }
}
