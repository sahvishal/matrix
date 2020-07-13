using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Audit.ViewModel
{
    public class ActivityLoggedModelDetailsViewModel :ViewModelBase
    {
        public IEnumerable<ActivityLoggedModelViewModel> Collections { get; set; }
        public ActivityLoggedModelViewModel ModelDetails { get; set; }
        public ActivityLogViewModel ActivityLog { get; set; }
        
        public ActivityLoggedModelDetailsViewModel()
        {
            Collections = new List<ActivityLoggedModelViewModel>();
            ModelDetails = new ActivityLoggedModelViewModel();
            ActivityLog = new ActivityLogViewModel();
        }
    }
}
