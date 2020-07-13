using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICampaignActivityRepository
    {
        CampaignActivity GetById(long id);
        IEnumerable<CampaignActivity> GetByCampaignId(long campaignId);
        CampaignActivity Save(CampaignActivity domainObject);
        IEnumerable<CampaignActivity> GetByCampaignIds(long[] campaignIds);

        bool DeleteByCampaignActivityIds(long[] campaignActivities);
        IEnumerable<CampaignActivity> GetActivitiesByDateTypeId(DateTime activityDate, long activityTypeId);

        IEnumerable<DateTime> GetDirectMailActivityDates(long campaignId);

        IEnumerable<CampaignActivity> GetDirectMailActivitiesByCampaignId(long campaignId);
        IEnumerable<CampaignActivity> GetByIds(long[] ids);
        IEnumerable<CampaignActivity> GetDirectMailActivityByCampaignId(long campaignId);
    }
}