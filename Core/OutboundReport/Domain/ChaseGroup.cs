using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class ChaseGroup : DomainObjectBase
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Division { get; set; }

        public ChaseGroup(long chaseGroupId)
            : base(chaseGroupId)
        {

        }

        public ChaseGroup()
        {
            
        }
    }
}
