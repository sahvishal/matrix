using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Interfaces
{
    public interface  IIncidentalFindingRepository
    {
        IEnumerable<IncidentalFinding> GetAllIncidentalFinding();
        List<IncidentalFinding> GetAllIncidentalFinding(long testId);
        List<IncidentalFindingGroup> GetAllIncidentalFindingGroup();
    }
}
