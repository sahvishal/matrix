using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianTestReviewStats
    {
        public long PhysicianId { get; set; }

        public IEnumerable<OrderedPair<long, int>> TestCountPairs { get; set; }
    }
}
