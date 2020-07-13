using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class RefundRequestResultEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long RequestId { get; set; }

        [UIHint("Hidden")]
        public long OrderId { get; set; }
        [UIHint("Hidden")]
        public long EventId { get; set; }
        [UIHint("Hidden")]
        public long CustomerId { get; set; }

        [UIHint("Hidden")]
        public RefundRequestType RefundType { get; set; }

        public IEnumerable<ProductstoOfferModel> OfferFreeProduct { get; set; }
        public bool OfferDiscount { get; set; }
        public decimal DiscountAmount { get; set; }

        public decimal RequestedRefundAmount { get; set; }
        public decimal RefundAmount { get; set; }

        public string RefundRequestNotes { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedOn { get; set; }

        public string PreviousProcessingNotes { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public RequestResultType RequestResultType { get; set; }
        public bool ChargeCancellationFee { get; set; }

        [UIHint("Hidden")]
        public decimal CancellationFee { get; set; }

        public string CancellationReason { get; set; }
        public PaymentEditModel PaymentEditModel { get; set; }

        public RefundRequestResultEditModel()
        {

        }
    }

    public class ProductstoOfferModel
    {
        public long ProductId { get; set; }
        public string ProductDescription { get; set; }
        public bool ProductAvailed { get; set; }
        public decimal ProductPrice { get; set; }

        public long OrderItemId { get; set; }
        public decimal? ProductPriceinOrder { get; set; }
    }
}