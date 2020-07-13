using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianTestReviewListModel : ListModelBase<PhysicianTestReviewViewModel, PhysicianTestReviewListModelFilter>
    {
        public override IEnumerable<PhysicianTestReviewViewModel> Collection { get; set; }

        public override PhysicianTestReviewListModelFilter Filter { get; set; }
    }
}
