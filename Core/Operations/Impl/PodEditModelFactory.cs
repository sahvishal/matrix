using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations.Impl
{
    [DefaultImplementation]
    public class PodEditModelFactory : IPodEditModelFactory
    {
        private readonly IPodStaffEditModelFactory _staffEditModelFactory;
        public PodEditModelFactory(IPodStaffEditModelFactory staffEditModelFactory)
        {
            _staffEditModelFactory = staffEditModelFactory;
        }

        public PodEditModel Create(Pod pod, IEnumerable<Territory> territories, IEnumerable<OrderedPair<long, string>> podTerritories, IEnumerable<PodStaff> podStaff, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<StaffEventRole> eventRoles, IEnumerable<PodRoom> podRooms, IEnumerable<PodRoomTest> podRoomTests, IEnumerable<Test> tests)
        {
            var model = new PodEditModel
                            {
                                AssignedToFranchiseeid = pod.AssignedToFranchiseeid,
                                DataRecoderMetaData = pod.DataRecorderMetaData,
                                Description = pod.Description,
                                Id = pod.Id,
                                Name = pod.Name,
                                ProcessingCapacity = pod.ProcessingCapacity,
                                VanId = pod.VanId,
                                AssignedTerritories = territories.Select(t => t.Id),
                                Territories = podTerritories,
                                DefaultStaffAssigned = _staffEditModelFactory.Create(pod.Id, podStaff, idNamePairs, eventRoles),
                                Tests = tests,
                                Rooms = GetPodRoomEditModels(podRooms,podRoomTests),
                                EnableKynIntegration = pod.EnableKynIntegration,
                                IsBloodworkFormAttached = pod.IsBloodworkFormAttached
                                
                            };

            return model;
        }

        private IList<PodRoomEditModel> GetPodRoomEditModels(IEnumerable<PodRoom> podRooms, IEnumerable<PodRoomTest> podRoomTests)
        {
            if (podRooms != null && podRooms.Any())
            {
                var models = new List<PodRoomEditModel>();
                foreach (var podRoom in podRooms)
                {
                    var roomTests = podRoomTests.Where(prt => prt.PodRoomId == podRoom.Id).Select(prt => new PodRoomTestEditModel { IsSelected = true, Test = prt.TestId }).ToArray();
                    var editModel = new PodRoomEditModel
                        {
                            PodRoomId = podRoom.Id,
                            Duration = podRoom.Duration,
                            RoomNo = podRoom.RoomNo,
                            RoomTests = roomTests
                        };

                    models.Add(editModel);
                }
                return models;
            }

            return new List<PodRoomEditModel> { new PodRoomEditModel() };
        }
    }
}