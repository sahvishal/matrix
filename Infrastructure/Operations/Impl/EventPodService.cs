using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class EventPodService : IEventPodService
    {
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IEventPodRoomRepository _eventPodRoomRepository;
        private readonly IPodRepository _podRepository;
        private readonly IPodRoomRepository _podRoomRepository;
        private readonly ITestRepository _testRepository;
        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;

        public EventPodService(IEventPodRepository eventPodRepository, IEventPodRoomRepository eventPodRoomRepository, IPodRepository podRepository, IPodRoomRepository podRoomRepository,
            ITestRepository testRepository, IEventSchedulingSlotRepository eventSchedulingSlotRepository)
        {
            _eventPodRepository = eventPodRepository;
            _eventPodRoomRepository = eventPodRoomRepository;
            _podRepository = podRepository;
            _podRoomRepository = podRoomRepository;
            _testRepository = testRepository;
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
        }

        public void SaveEventPod(IEnumerable<EventPodEditModel> models, long eventId)
        {
            var eventPodsInDb = _eventPodRepository.GetByEventId(eventId);

            if (eventPodsInDb != null && eventPodsInDb.Any())
            {
                var currentPodIds = models.Select(m => m.PodId).ToArray();
                var eventPodIdsToBeDeleted = eventPodsInDb.Where(ep => !currentPodIds.Contains(ep.PodId)).Select(ep => ep.PodId).ToArray();

                if (eventPodIdsToBeDeleted.Any())
                {
                    _eventPodRepository.DeactivateEventPod(eventId, eventPodIdsToBeDeleted);

                    var eventPodRooms = _eventPodRoomRepository.GetByEventIdAndPodIds(eventId, eventPodIdsToBeDeleted);

                    if (eventPodRooms != null && eventPodRooms.Any())
                    {
                        var eventPodRoomIds = eventPodRooms.Select(epr => epr.Id).ToArray();
                        DeleteEventPodRooms(eventPodRoomIds);
                    }
                }
            }

            foreach (var eventPodEditModel in models)
            {
                var existingEventPodRooms = _eventPodRoomRepository.GetByEventIdAndPodIds(eventId, new[] { eventPodEditModel.PodId });
                if (existingEventPodRooms != null && existingEventPodRooms.Any())
                {
                    if (eventPodEditModel.EventPodRooms != null && eventPodEditModel.EventPodRooms.Any())
                    {
                        var rooms = eventPodEditModel.EventPodRooms.Select(p => p.RoomNo);
                        var eventPodRoomsToBeDeleted = existingEventPodRooms.Where(m => !rooms.Contains(m.RoomNo)).Select(m => m).ToArray();
                        if (eventPodRoomsToBeDeleted.Any())
                        {
                            var eventPodRoomIds = eventPodRoomsToBeDeleted.Select(epr => epr.Id).ToArray();
                            DeleteEventPodRooms(eventPodRoomIds);
                        }
                    }
                    else
                    {
                        var eventPodRoomIds = existingEventPodRooms.Select(epr => epr.Id).ToArray();
                        DeleteEventPodRooms(eventPodRoomIds);
                    }
                }

                SaveEventPod(eventId, eventPodEditModel);
            }
        }

        private void DeleteEventPodRooms(IEnumerable<long> eventPodRoomIds)
        {
            _eventSchedulingSlotRepository.DeleteByEventPodRoomIds(eventPodRoomIds);
            _eventPodRoomRepository.DeleteEventPodRooms(eventPodRoomIds);
        }

        private void SaveEventPod(long eventId, EventPodEditModel eventPodEditModel)
        {
            var pod = ((IUniqueItemRepository<Pod>)_podRepository).GetById(eventPodEditModel.PodId);
            var eventPod = new EventPod
                {
                    Id = eventPodEditModel.EventPodId,
                    EventId = eventId,
                    PodId = eventPodEditModel.PodId,
                    TerritoryId = eventPodEditModel.TerritoryId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true,
                    EnableKynIntegration = pod.EnableKynIntegration,
                    IsBloodworkFormAttached = pod.IsBloodworkFormAttached
                };
            eventPod = _eventPodRepository.Save(eventPod);

            eventPodEditModel.EventPodId = eventPod.Id;

            if (eventPodEditModel.EventPodRooms != null && eventPodEditModel.EventPodRooms.Any())
            {
                foreach (var eventPodRoomEditModel in eventPodEditModel.EventPodRooms)
                {
                    eventPodRoomEditModel.EventPodId = eventPodEditModel.EventPodId;
                    SaveEventPodRoom(eventPodRoomEditModel);
                }
            }
        }

        private void SaveEventPodRoom(EventPodRoomEditModel eventPodRoomEditModel)
        {
            var eventPodRoom = new EventPodRoom
                {
                    Duration = eventPodRoomEditModel.Duration,
                    EventPodId = eventPodRoomEditModel.EventPodId,
                    RoomNo = eventPodRoomEditModel.RoomNo
                };

            eventPodRoom = _eventPodRoomRepository.Save(eventPodRoom);

            eventPodRoomEditModel.EventPodRoomId = eventPodRoom.Id;

            var testIds = eventPodRoomEditModel.EventPodRoomTests.Where(rt => rt.IsSelected).Select(rt => rt.TestId);
            _eventPodRoomRepository.SaveEventPodRoomTests(testIds, eventPodRoom.Id);
        }

        public IEnumerable<EventPodEditModel> GetEventPodEditModels(long eventId, IEnumerable<long> podIds)
        {
            var eventPodEditModels = new List<EventPodEditModel>();
            var pods = ((IUniqueItemRepository<Pod>)_podRepository).GetByIds(podIds);

            foreach (var pod in pods)
            {
                var eventPodEditModel = new EventPodEditModel
                    {
                        PodId = pod.Id,
                        Name = pod.Name
                    };

                EventPod eventPod = null;
                if (eventId > 0)
                {
                    eventPod = _eventPodRepository.GetByEventIdPodId(eventId, pod.Id);
                    if (eventPod != null)
                    {
                        eventPodEditModel.EventPodId = eventPod.Id;
                        eventPodEditModel.EventId = eventPod.EventId;
                        eventPodEditModel.TerritoryId = eventPod.TerritoryId;
                    }
                }


                //pod rooms
                var podRooms = _podRoomRepository.GetByPodId(eventPodEditModel.PodId);

                if (eventId > 0)
                {
                    var eventPodRooms = _eventPodRoomRepository.GetByEventId(eventId);

                    if (!eventPodRooms.IsNullOrEmpty())
                    {
                       var rooms= eventPodRooms.Select(x => x.RoomNo);
                        podRooms = podRooms.Where(x => rooms.Contains(x.RoomNo));
                    }
                }

                if (podRooms != null && podRooms.Any())
                {
                    var eventPodRoomEditModels = new List<EventPodRoomEditModel>();

                    var podRoomTests = _podRoomRepository.GetPodRoomTestsByPodId(eventPodEditModel.PodId);

                    var tests = _testRepository.GetAll();

                    IEnumerable<EventPodRoom> eventPodRooms = null;
                    IEnumerable<EventPodRoomTest> eventPodRoomTests = null;
                    if (eventPod != null)
                    {
                        eventPodRooms = _eventPodRoomRepository.GetByEventIdAndPodIds(eventPod.EventId, new[] { eventPod.PodId });
                        eventPodRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsByEventId(eventPod.EventId);
                    }

                    foreach (var podRoom in podRooms)
                    {
                        var eventPodRoomTestEditModels = tests.Select(t => new EventPodRoomTestEditModel { Name = t.Alias, TestId = t.Id }).ToList();
                        var eventPodRoomEditModel = new EventPodRoomEditModel
                            {
                                EventPodRoomTests = eventPodRoomTestEditModels
                            };

                        EventPodRoom eventPodRoom = null;

                        if (eventPodRooms != null && eventPodRooms.Any())
                            eventPodRoom = eventPodRooms.SingleOrDefault(epr => epr.RoomNo == podRoom.RoomNo);

                        if (eventPodRoom != null)
                        {
                            eventPodRoomEditModel.EventPodRoomId = eventPodRoom.Id;
                            eventPodRoomEditModel.EventPodId = eventPodRoom.EventPodId;
                            eventPodRoomEditModel.RoomNo = eventPodRoom.RoomNo;
                            eventPodRoomEditModel.Duration = eventPodRoom.Duration;

                            var eventPodRoomTestIds = eventPodRoomTests.Where(eprt => eprt.EventPodRoomId == eventPodRoom.Id).Select(eprt => eprt.TestId).ToArray();
                            foreach (var eventPodRoomTestEditModel in eventPodRoomEditModel.EventPodRoomTests)
                            {
                                if (eventPodRoomTestIds.Contains(eventPodRoomTestEditModel.TestId))
                                    eventPodRoomTestEditModel.IsSelected = true;
                            }
                        }
                        else
                        {
                            eventPodRoomEditModel.RoomNo = podRoom.RoomNo;
                            eventPodRoomEditModel.Duration = podRoom.Duration;

                            var podRoomTestIds = podRoomTests.Where(eprt => eprt.PodRoomId == podRoom.Id).Select(eprt => eprt.TestId).ToArray();
                            foreach (var eventPodRoomTestEditModel in eventPodRoomEditModel.EventPodRoomTests)
                            {
                                if (podRoomTestIds.Contains(eventPodRoomTestEditModel.TestId))
                                    eventPodRoomTestEditModel.IsSelected = true;
                            }
                        }

                        eventPodRoomEditModels.Add(eventPodRoomEditModel);
                    }
                    eventPodEditModel.EventPodRooms = eventPodRoomEditModels;
                }

                eventPodEditModels.Add(eventPodEditModel);
            }

            return eventPodEditModels;
        }
    }
}
