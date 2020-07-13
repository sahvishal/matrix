using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations.Impl
{
    [DefaultImplementation]
    public class PodStaffEditModelFactory : IPodStaffEditModelFactory
    {
        public IEnumerable<PodStaffEditModel> Create(long podId, IEnumerable<PodStaff> podStaff, IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<StaffEventRole> eventRoles)
        {
            var models = new PodStaffEditModel[podStaff.Count()];
            var index = 0;
            foreach (var staff in podStaff)
            {
                models[index++] = new PodStaffEditModel()
                                      {
                                          EventRoleId = staff.EventRoleId,
                                          EventRoleName = eventRoles.Where(er => er.Id == staff.EventRoleId).FirstOrDefault().Name,
                                          Name = idNamePairs.Where(op => op.FirstValue == staff.OrganizationRoleUserId).First().SecondValue,
                                          OrganizationRoleUserId = staff.OrganizationRoleUserId,
                                          PodId = podId,
                                          Id = staff.Id
                                      };
            }

            return models;
        }
    }
}