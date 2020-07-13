using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EnableTextingEditModel : ViewModelBase
    {
        public bool EnableTexting { get; set; }
        public PhoneNumber PhoneCell { get; set; }
        public long CustomerId { get; set; }
        public long EventCustomerId { get; set; }
    }
}
