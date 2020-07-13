using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianQueueListModel : ListModelBase<PhysicianQueueViewModel, PhysicianQueueListModelFilter>
    {
        public override IEnumerable<PhysicianQueueViewModel> Collection { get; set; }
        public override PhysicianQueueListModelFilter Filter { get; set; }
    }
}