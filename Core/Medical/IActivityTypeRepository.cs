using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IActivityTypeRepository
    {
        ActivityType Save(ActivityType domainObject);
        ActivityType GetByAlias(string alias);
        IEnumerable<ActivityType> GetAll();
        ActivityType GetById(long id);
        IEnumerable<ActivityType> GetByIds(long[] ids);
    }
}
