using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class ChaseCampaignType : DomainObjectBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }

        public ChaseCampaignType(long chaseCampaignTypeId)
            : base(chaseCampaignTypeId)
        {

        }

        public ChaseCampaignType()
        {
            
        }
    }
}
