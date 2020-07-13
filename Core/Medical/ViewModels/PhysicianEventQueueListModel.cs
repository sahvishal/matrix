using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianEventQueueListModel:ListModelBase<PhysicianEventQueueViewModel,PhysicianEventQueueListModelFilter>
    {
        public override IEnumerable<PhysicianEventQueueViewModel> Collection { get; set; }

        public override PhysicianEventQueueListModelFilter Filter { get; set; }
    }
}
