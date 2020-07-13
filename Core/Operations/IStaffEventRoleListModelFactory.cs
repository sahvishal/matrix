using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IStaffEventRoleListModelFactory
    {
        StaffEventRoleListModel Create(IEnumerable<StaffEventRole> staffEventRoles, IEnumerable<Test> tests);
    }
}