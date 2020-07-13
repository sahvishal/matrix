namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface ICampaignAccessControl
    {
        bool CanUserViewCampaign(long userId, long campaignId);
    }
}