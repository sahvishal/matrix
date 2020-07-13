using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class SourceCodeItemWiseDiscountEditModel : ViewModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountAmount { get; set; }
        public int DiscountValueType { get; set; }
    }
}