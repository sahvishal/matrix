using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface ICustomCampaignContentRepository
    {
        MarketingMaterial GetCustomContent(long campaignId, string tag);
    }
}