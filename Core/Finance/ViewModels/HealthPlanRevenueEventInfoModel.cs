
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
namespace Falcon.App.Core.Finance.ViewModels
{
    public class HealthPlanRevenueEventInfoModel : ViewModelBase
    {
        public long EventId { get; set; }
        public Address Location { get; set; }
        public int ScreenedCustomers { get; set; }
    }
}
