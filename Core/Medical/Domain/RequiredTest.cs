using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class RequiredTest : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long TestId { get; set; }
        public long IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ForYear { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
