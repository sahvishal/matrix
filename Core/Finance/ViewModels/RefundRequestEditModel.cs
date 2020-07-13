using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class RefundRequestEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long RequestId { get; set; }

        [UIHint("Hidden")]
        public long OrderId { get; set; }

        [DisplayName("Reason")]
        [DataType(DataType.MultilineText)]
        public string Reason { get; set; }
        
        [UIHint("Hidden")]
        [DisplayName("Refund Amount")]
        public decimal RequestedRefundAmount { get; set; }

        [DisplayName("Refund Type")]
        public int RefundType { get; set; }
    }
}