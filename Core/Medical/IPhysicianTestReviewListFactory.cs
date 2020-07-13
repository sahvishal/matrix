using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianTestReviewListFactory
    {
        PhysicianTestReviewListModel Create(IEnumerable<long> physicianIds, IEnumerable<OrderedPair<long, string>> physiciansIdNamePair, IEnumerable<PhysicianTestReviewStats> physicianTestReviewStatses);
    }
}
