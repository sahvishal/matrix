using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventCustomerScreeningAggregate
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }

        public IEnumerable<TestResult> TestResults { get; set; }
    }
}