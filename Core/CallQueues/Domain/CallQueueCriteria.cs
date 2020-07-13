using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class CallQueueCriteria : DomainObjectBase
    {
        public long CallQueueId { get; set; }
        public long CriteriaId { get; set; }
        public string Zipcode { get; set; }
        public int Radius { get; set; }
        public bool Condition { get; set; }
        public int Sequence { get; set; }
        public bool IsActive { get; set; }
        public string CallReason { get; set; }

        public CallQueueCriteria()
        { }

        public CallQueueCriteria(long id)
            : base(id)
        { }
    }
}
