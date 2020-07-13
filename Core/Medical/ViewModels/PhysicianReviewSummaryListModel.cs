using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianReviewSummaryListModel : ListModelBase<PhysicianReviewSummaryViewModel, PhysicianReviewSummaryListModelFilter>
    {
        public override IEnumerable<PhysicianReviewSummaryViewModel> Collection { get; set; }

        public override PhysicianReviewSummaryListModelFilter Filter { get; set; }

    }
}
