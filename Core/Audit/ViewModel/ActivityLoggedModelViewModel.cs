using System.Collections.Generic;

namespace Falcon.App.Core.Audit.ViewModel
{
    public class ActivityLoggedModelViewModel
    {
        public IEnumerable<KeyValuePair<string,string>> Simple { get; set; }
        public IEnumerable<KeyValuePair<string, ActivityLoggedModelViewModel>> Complex { get; set; }

        public IEnumerable<ActivityLoggedModelViewModel> Collections { get; set; }

        public ActivityLoggedModelViewModel()
        {
            Collections = new List<ActivityLoggedModelViewModel>();
            Simple = new List<KeyValuePair<string, string>>();
            Complex = new List<KeyValuePair<string, ActivityLoggedModelViewModel>>();
        }
    }
}
