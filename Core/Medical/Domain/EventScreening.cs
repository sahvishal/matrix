using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class EventScreening : DomainObjectBase
    {
        public long EventPackageId { get; set; }
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}