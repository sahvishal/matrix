using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class ChaseChannelLevel : DomainObjectBase
    {
        public string ChannelName { get; set; }
        public long ChannelLevel { get; set; }

        public ChaseChannelLevel(long chaseChannelLevelId)
            : base(chaseChannelLevelId)
        {

        }

        public ChaseChannelLevel()
        {
            
        }
    }
}
