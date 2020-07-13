using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface ICampaignService
    {
        CampaignListModel GetCampaignDetails(int pageNumber, int pageSize, CampaignListModelFilter filter, out int totalRecords);
        void Save(CampaignEditModel model, long orgRoleId);
        CampaignEditModel GetEditModel(long campaignId);
        CampaignActivityEditModel GetActivityEditModel(long activityId,long campaignId);

        CallQueueCampaignListModel GetCampaignListModel(CampaignCallQueueFilter filter, int pageSize, out int totalRecords);

        string GetRandomUniqueCampaignCodeInstance();

        CampaignAcivityDetailViewModel GetCampaignActivity(long campaignId);
        void EditActivity(long orgRoleId, CampaignActivityEditModel model);
        UpdatePublishedCampaignEditModel GetPublishedCampaignEditModel(long campaignId);
        void EditPublishedCampaign(UpdatePublishedCampaignEditModel model);
    }
}
