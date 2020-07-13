using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Operations.Impl
{
    [DefaultImplementation]
    public class StaffEventRoleListModelFactory : IStaffEventRoleListModelFactory
    {
        public StaffEventRoleListModel Create(IEnumerable<StaffEventRole> staffEventRoles, IEnumerable<Test> tests)
        {
            var model = new StaffEventRoleListModel();
            var basicModels = new StaffEventRoleBasicModel[staffEventRoles.Count()];

            int index = 0;
            foreach (var role in staffEventRoles)
            {
                basicModels[index++] = new StaffEventRoleBasicModel
                                           {
                                               Description = role.Description,
                                               Id = role.Id,
                                               Name = role.Name,
                                               Tests = role.AllowedTestIds != null
                                                           ? tests.Where(t => role.AllowedTestIds.Contains(t.Id)).
                                                                 Select(t => t.Name).ToArray() : null
                                           };
            }
            model.StaffEventRoles = basicModels;
            return model;
        }
    }
}