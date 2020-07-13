
using Falcon.App.Core.Application.ViewModels;
namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class BarrierEditModel : ViewModelBase
    {
        public long EventCustomerId { get; set; }
        public long BarrierId { get; set; }
        public string Reason { get; set; }
        public string Resolution { get; set; }
    }
}
