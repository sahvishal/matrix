using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.CallCenter
{
    public interface ICampaignListModelFactory
    {
        CampaignListModel Create(IEnumerable<Campaign> campaigns, IEnumerable<OrderedPair<long, string>> campaignCreatedByAgentNameIdPair, IEnumerable<CorporateAccount> corporateAccounts,
            IEnumerable<CampaignActivity> campaignActivitys, IEnumerable<CampaignActivityAssignment> campaignActivityAssignments, IEnumerable<DirectMailType> directMailTypes);

        List<CampaignActivityViewModel> GetCampaignActivityViewModel(long campaignId, IEnumerable<CampaignActivity> campaignActivity, IEnumerable<CampaignActivityAssignment> campaignActivityAssignments, IEnumerable<OrderedPair<long, string>> campaignCreatedByAgentNameIdPair, IEnumerable<DirectMailType> directMailTypes, bool isPublished);
    }
}
