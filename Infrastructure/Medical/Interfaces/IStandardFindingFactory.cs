using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Interfaces
{
    public interface IStandardFindingFactory
    {
        StandardFindingEntity CreateStandardFinding<T>(StandardFinding<T> standardFinding);
        StandardFinding<T> CreateStandardFinding<T>(StandardFindingEntity standardFindingEntity);
        List<StandardFinding<T>> CreateStandardFindings<T>(List<StandardFindingEntity> standardFindingEntities);
    }
}
