using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class PayPeriodCriteriaEditModel : ViewModelBase
    {
        public long PayPeriodCriteriaId { get; set; }
        public long PayPeriodId { get; set; }
        public long? MinCustomer { get; set; }
        public long? MaxCustomer { get; set; }
        public long TypeId { get; set; }
        public decimal? Amount { get; set; }
        public int Index { get; set; }
    }
}
