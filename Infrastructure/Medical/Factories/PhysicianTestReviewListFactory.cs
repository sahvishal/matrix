using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PhysicianTestReviewListFactory : IPhysicianTestReviewListFactory
    {
        public PhysicianTestReviewListModel Create(IEnumerable<long> physicianIds, IEnumerable<OrderedPair<long, string>> physiciansIdNamePair, IEnumerable<PhysicianTestReviewStats> physicianTestReviewStatses)
        {
            var model = new PhysicianTestReviewListModel();

            var physicianTestReviews = new List<PhysicianTestReviewViewModel>();

            physicianIds.ToList().ForEach( pid =>
                                               {
                                                   var physicianName = physiciansIdNamePair.Where(p => p.FirstValue == pid).First().SecondValue;
                                                   var testCountPairs = physicianTestReviewStatses.Where(ptrs => ptrs.PhysicianId == pid).First().TestCountPairs;

                                                   physicianTestReviews.Add(new PhysicianTestReviewViewModel
                                                                                {
                                                                                    PhysicianId = pid,
                                                                                    PhysicianName = physicianName,
                                                                                    TestIdCountPairs = testCountPairs
                                                                                });
                                               });

            model.Collection = physicianTestReviews;

            return model;
        }
    }
}
