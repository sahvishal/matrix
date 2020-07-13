using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IChaseGroupRepository
    {
        ChaseGroup GetById(long id);

        IEnumerable<ChaseGroup> GetByIds(IEnumerable<long> ids);

        ChaseGroup Save(ChaseGroup domain);
        
        ChaseGroup GetByNameNumberAndDivision(string groupName, string groupNumber, string groupDivision);
    }
}
