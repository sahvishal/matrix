using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations.Impl
{
    [DefaultImplementation]
    public class PodListModelFactory : IPodListModelFactory
    {
        public PodListModel Create(IEnumerable<Pod> pods, IEnumerable<PodStaff> multiplePodStaff, IEnumerable<StaffEventRole> staffEventRoles, 
                    IEnumerable<OrderedPair<long, string>> podTerritoryNamePair, IEnumerable<OrderedPair<long, string>> organizationRoleUsers, IEnumerable<Organization> organizations)
        {
            var model = new PodListModel();
            var podBasicModels = new PodBasicModel[pods.Count()];
            var index = 0;

            foreach (var pod in pods)
            {
                var podStaffEventRolePair = new Func<IEnumerable<PodStaff>, IEnumerable<OrderedPair<string, string>>>(
                    podStaff => podStaff.Select(ps =>
                        new OrderedPair<string, string>(organizationRoleUsers.Where(oru => oru.FirstValue == ps.OrganizationRoleUserId).Single().SecondValue,
                            staffEventRoles.Where(er => er.Id == ps.EventRoleId).Single().Name)));

                var podBasicModel = new PodBasicModel()
                                        {
                                            AssignedTerritories =
                                                podTerritoryNamePair.Where(pt => pt.FirstValue == pod.Id).Select(
                                                    pt => pt.SecondValue),
                                            Description = pod.Description,
                                            PodName = pod.Name,
                                            PodStaff =
                                                podStaffEventRolePair(multiplePodStaff.Where(mps => mps.PodId == pod.Id).ToArray()),
                                            Id = pod.Id,
                                            AssignedToFranchisee = pod.AssignedToFranchiseeid > 0? organizations.Where(oru => oru.Id == pod.AssignedToFranchiseeid).Single().Name : string.Empty
                                        };

                podBasicModels[index++] = podBasicModel;
            }

            model.Pods = podBasicModels;
            return model;
        }

        
    }
}