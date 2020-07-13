using Falcon.App.Core.Marketing.Enum;

namespace Falcon.App.Core.Marketing.Domain
{
    public class SourceCodeItemWiseDiscount
    {
        public long Id { get; set; }
        public decimal DiscountAmount { get; set; }
        public DiscountValueType DiscountValueType { get; set; }
    }
}