using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IChaseCampaignTypeRepository
    {
        ChaseCampaignType GetById(long id);

        IEnumerable<ChaseCampaignType> GetByIds(IEnumerable<long> ids);

        ChaseCampaignType Save(ChaseCampaignType domain);

        ChaseCampaignType GetByName(string name);
    }
}
