using System;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using System.Collections.Generic;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface ICampaignRepository
    {
        Campaign GetById(long id);
        Campaign Save(Campaign domainObject);
        IEnumerable<Campaign> GetCampaignDetails(int pageNumber, int pageSize, CampaignListModelFilter filter, out int totalRecords);
        IEnumerable<Campaign> GeCotporateCampaignForCallQueue(DateTime callDate);
        IEnumerable<Campaign> GetCampaignIdsForCallQueue(CampaignCallQueueFilter filter, int pageSize, out int totalRecords);
        bool IsCampaignCodeUnique(string campaignCode, long campaignId);
        bool IsCampaignNameUnique(string campaignName, long campaignId);
        Campaign GetCampaignByName(string campaignName);
        IEnumerable<Campaign> GetByIds(IEnumerable<long> campaignIds);
        IEnumerable<Campaign> GetCampaignsByHealthPlanId(long healthPlanId);
        IEnumerable<OrderedPair<long?, long>> GetCriteriaIdsForCampaigns(IEnumerable<long> campaignIds);
        IEnumerable<Campaign> GetCotporateCampaignForNotGenerated();
        bool IsCampaignAlreadyPublished(long campaignId);
    }
}
