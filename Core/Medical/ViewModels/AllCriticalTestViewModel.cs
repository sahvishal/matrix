using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class AllCriticalTestViewModel
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public IEnumerable<OrderedPair<Test, bool>> Tests { get; set; }
    }
}
