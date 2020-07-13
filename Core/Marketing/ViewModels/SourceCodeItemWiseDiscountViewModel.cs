using Falcon.App.Core.Marketing.Enum;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class SourceCodeItemWiseDiscountViewModel
    {
        public string Name { get; set; }
        public decimal DiscountAmount { get; set; }
        public DiscountValueType DiscountValueType { get; set; }
    }
}