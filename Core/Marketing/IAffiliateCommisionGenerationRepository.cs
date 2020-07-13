namespace Falcon.App.Core.Marketing
{
    public interface IAffiliateCommisionGenerationRepository
    {
        bool SaveEventAffiliate(long eventCustomerId, long? callId);
    }
}