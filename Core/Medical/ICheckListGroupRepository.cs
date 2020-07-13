using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICheckListGroupRepository
    {
        IEnumerable<CheckListGroup> GetAllGroups();
        IEnumerable<CheckListGroup> GetAllGroupsByGroupIds(IEnumerable<long> groupIds);
    }
}