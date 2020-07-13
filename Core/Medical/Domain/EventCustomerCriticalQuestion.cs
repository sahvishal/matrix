using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class EventCustomerCriticalQuestion : DomainObjectBase
    {
        public long EventCustomerId { get; set; }

        public long QuestionId { get; set; }

        public string Answer { get; set; }

        public string Note { get; set; }
    }
}
