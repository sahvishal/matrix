using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class MailRoundCallQueueCriteriaAssignment : DomainObjectBase
    {
        public long MailRoundCallQueueId { get; set; }
        public long CriteriaId { get; set; }
    }
}