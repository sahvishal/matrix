using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class SourceCodeApplyEditModel : ViewModelBase
    {
        public long SourceCodeId { get; set; }
        public string SourceCode { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public int SignUpMode { get; set; }
        public OrderedPair<long, decimal> Package { get; set; }
        public IEnumerable<OrderedPair<long, decimal>> SelectedTests { get; set; }

        public decimal ProductAmount { get; set; }
        public decimal ShippingAmount { get; set; }

        public IEnumerable<OrderedPair<long, decimal>> SelectedProducts { get; set; }
        public IEnumerable<OrderedPair<long, decimal>> SelectedShipping { get; set; }
        
        // The undiscounted one
        public decimal OrderTotal { get; set; }

        public decimal DiscountApplied { get; set; }

        public string SourceCodeHelpDescription { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
    }
}