using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICampaignAssignmentRepository
    {
        IEnumerable<CampaignAssignment> GetByCampaignId(long campaignId);
        bool DeleteByCampaignId(long campaignId);
        void Save(long campaignId, IEnumerable<long> assignedtoIds);
        IEnumerable<CampaignAssignment> GetByCampaignIds(long[] campaignIds);
    }
}