using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianReviewListModel : ListModelBase<PhysicianReviewViewModel, PhysicianReviewListModelFilter>
    {
        public override IEnumerable<PhysicianReviewViewModel> Collection { get; set; }
        public override PhysicianReviewListModelFilter Filter { get; set; }
    }
}
