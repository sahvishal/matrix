using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IEventRoleRepository
    {
        IEnumerable<StaffEventRole> GetAll();
        StaffEventRole GetById(long id);
        StaffEventRole Save(StaffEventRole staffEventRole);
        IEnumerable<StaffEventRole> GetByIds(IEnumerable<long> ids);

        IEnumerable<StaffEventRole> GetByName(string roleName);

        IEnumerable<StaffEventRole> GetAllActiveRoles();
    }
}