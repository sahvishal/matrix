using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Audit.ViewModel
{
    public class ActivityLogListModel : ViewModelBase
    {
        public IEnumerable<ActivityLogViewModel> Collection { get; set; }
        public ActivityLogListFilter Filter { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }

        public ActivityLogListModel()
        {
            Collection = new List<ActivityLogViewModel>();
        }
    }
}
