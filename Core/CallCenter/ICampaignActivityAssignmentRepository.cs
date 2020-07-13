using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICampaignActivityAssignmentRepository
    {
        IEnumerable<CampaignActivityAssignment> GetByCampaignActivityId(long campaignActivityId);
        IEnumerable<CampaignActivityAssignment> GetByCampaignId(long campaignId);
        bool DeleteByCampaignId(long campaignActivityId);
        void Save(long campaignActivityId, IEnumerable<long> assignedtoIds);
        IEnumerable<CampaignActivityAssignment> GetByCampaignActivityIds(long[] campaignActivityIds);
    }
}