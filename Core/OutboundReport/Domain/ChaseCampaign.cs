using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class ChaseCampaign : DomainObjectBase
    {
        public string CampaignId { get; set; }
        public string CampaignFileId { get; set; }
        public string CampaignName { get; set; }
        public string CampaignCode { get; set; }
        public string CampaignHouseholdId { get; set; }
        public long ChaseCampaignTypeId { get; set; }
        public string KeyCode { get; set; }

        public ChaseCampaign(long chaseCampaignId)
            : base(chaseCampaignId)
        {

        }

        public ChaseCampaign()
        {
            
        }
    }
}
