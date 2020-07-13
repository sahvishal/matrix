using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Users;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Operations.Impl
{
    [DefaultImplementation]
    public class PodService : IPodService
    {
        private readonly IPodRepository _podRepository;
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IPodStaffAssignmentRepository _podStaffAssignmentRepository;
        private readonly IUniqueItemRepository<StaffEventRole> _staffEventRoleRepository;
        private readonly IOrganizationRoleUserRepository _orgRoleUserrepository;
        private readonly IPodListModelFactory _podListModelFactory;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IPodEditModelFactory _podEditModelFactory;
        private readonly IPodRoomRepository _podRoomRepository;
        private readonly ITestRepository _testRepository;

        public PodService(IPodRepository podRepository, ITerritoryRepository territoryRepository, IPodStaffAssignmentRepository podStaffAssignmentRepository,
            IUniqueItemRepository<StaffEventRole> staffEventRoleRepository, IOrganizationRoleUserRepository orgRoleUserrepository, IPodListModelFactory podListModelFactory,
            IOrganizationRepository organizationRepository, IPodEditModelFactory podEditModelFactory, IPodRoomRepository podRoomRepository, ITestRepository testRepository)
        {
            _podRepository = podRepository;
            _territoryRepository = territoryRepository;
            _podStaffAssignmentRepository = podStaffAssignmentRepository;
            _staffEventRoleRepository = staffEventRoleRepository;
            _orgRoleUserrepository = orgRoleUserrepository;
            _podListModelFactory = podListModelFactory;
            _organizationRepository = organizationRepository;
            _podEditModelFactory = podEditModelFactory;
            _podRoomRepository = podRoomRepository;
            _testRepository = testRepository;
        }

        public PodListModel GetPodListModel(int pageNumber, int pageSize)
        {
            var pods = _podRepository.GetAllPods();
            var podIds = pods.Select(p => p.Id).ToArray();

            var multiplePodStaff = _podStaffAssignmentRepository.GetPodStaffforMultiplePods(podIds);
            var eventRoles = _staffEventRoleRepository.GetByIds(multiplePodStaff.Select(p => p.EventRoleId).Distinct()).ToArray();
            var territories = _territoryRepository.GetMultiplePodTerritoriesIdNamePair(podIds);

            var orgRoleUsers = _orgRoleUserrepository.GetNameIdPairofUsers(multiplePodStaff.Select(mps => mps.OrganizationRoleUserId).Distinct().ToArray());
            var organizations =
                _organizationRepository.GetOrganizationCollection(OrganizationType.Franchisee)
                    .Where(o => pods.Select(p => p.AssignedToFranchiseeid).Contains(o.Id));

            return _podListModelFactory.Create(pods, multiplePodStaff, eventRoles, territories, orgRoleUsers, organizations);
        }

        public PodEditModel GetPodEditModel(long podId)
        {
            var pod = ((IUniqueItemRepository<Pod>)_podRepository).GetById(podId);
            var territories = _territoryRepository.GetTerritoriesForPod(podId);
            var podTerritories = _territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.Pod);
            var podStaff = _podStaffAssignmentRepository.GetPodSatff(podId);
            var idNamePairforStaff = _orgRoleUserrepository.GetNameIdPairofUsers(podStaff.Select(ps => ps.OrganizationRoleUserId).ToArray());
            var staffEventRoles = _staffEventRoleRepository.GetByIds(podStaff.Select(ps => ps.EventRoleId));

            var podRooms = _podRoomRepository.GetByPodId(podId);
            var podRoomTests = _podRoomRepository.GetPodRoomTestsByPodId(podId);
            var tests = _testRepository.GetAll();

            return _podEditModelFactory.Create(pod, territories, podTerritories, podStaff, idNamePairforStaff, staffEventRoles, podRooms, podRoomTests, tests);
        }

        public void SavePodRooms(IEnumerable<PodRoomEditModel> podRoomEditModels, long podId)
        {
            var podRoomsInDb = _podRoomRepository.GetByPodId(podId);
            if (podRoomsInDb != null && podRoomsInDb.Any())
            {
                var currentPodRoomIds = podRoomEditModels.Select(pre => pre.PodRoomId).ToArray();
                var podRoomIdsToBeDeleted = podRoomsInDb.Where(pr => !currentPodRoomIds.Contains(pr.Id)).Select(pr => pr.Id).ToArray();

                if (podRoomIdsToBeDeleted.Any())
                    _podRoomRepository.DeletePodRooms(podRoomIdsToBeDeleted);
            }

            var index = 1;
            foreach (var podRoomEditModel in podRoomEditModels)
            {
                var podRoom = new PodRoom
                    {
                        Id = podRoomEditModel.PodRoomId,
                        PodId = podId,
                        Duration = podRoomEditModel.Duration,
                        RoomNo = index
                    };

                podRoom = _podRoomRepository.Save(podRoom);

                var testIds = podRoomEditModel.RoomTests.Where(rt => rt.IsSelected).Select(rt => rt.Test);
                _podRoomRepository.SavePodRoomTests(testIds, podRoom.Id);

                index++;
            }
        }

    }
}