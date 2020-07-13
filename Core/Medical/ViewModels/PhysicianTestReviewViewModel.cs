using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianTestReviewViewModel : ViewModelBase
    {
        [DisplayName("Physician Name")]
        public string PhysicianName { get; set; }

        public IEnumerable<OrderedPair<long, int>> TestIdCountPairs { get; set; }

        [Hidden]
        public long PhysicianId { get; set; }
    }
}
