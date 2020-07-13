using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class EventCustomerQuestionAnswer : DomainObjectBase
    {
        public long? EventCustomerId { get; set; }
        public long QuestionId { get; set; }
        public string Answer { get; set; }
        public long Version { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long CustomerId { get; set; }
        public long EventId { get; set; }
    }
}
