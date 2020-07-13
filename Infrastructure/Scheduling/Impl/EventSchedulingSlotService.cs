using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    //TODO: Same Date Event Case
    //TODO: Release temporarily booked slots
    //TODO: Not to allow creating any time interval slot in for dynamic scheduling
    [DefaultImplementation]
    public class EventSchedulingSlotService : IEventSchedulingSlotService
    {
        public Roles LoggedinUserRole { private get; set; }
        public Roles LoggedinUserParentRole { private get; set; }

        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;
        private readonly IEventRepository _eventRepository;
        private IEnumerable<EventSchedulingSlot> _availableSlots;
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly IEventNotificationRepository _eventNotificationRepository;
        private readonly IEventPodRoomRepository _eventPodRoomRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly ITestRepository _testRepository;

        private const int LeadTimeForCustomer = 60;
        private const int LeadTimeForCallCenter = 1;

        private const int MaxWaitTime = 60;

        private readonly int _maxScreeningTime;
        private readonly int _minScreeningTime;
        private readonly int MinimumScreeningTime = 5;

        public EventSchedulingSlotService(IEventSchedulingSlotRepository eventSchedulingSlotRepository, IEventRepository eventRepository, INotificationTypeRepository notificationTypeRepository,
            IConfigurationSettingRepository configurationSettingRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier, IEventNotificationRepository eventNotificationRepository,
            IEventPodRoomRepository eventPodRoomRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, ITestRepository testRepository,
            ISettings settings)
        {
            _maxScreeningTime = settings.DynamicSchedulingMaximumScreeningTime;
            _minScreeningTime = settings.DynamicSchedulingMinimumScreeningTime;

            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
            _eventRepository = eventRepository;
            _notificationTypeRepository = notificationTypeRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _eventNotificationRepository = eventNotificationRepository;
            _eventPodRoomRepository = eventPodRoomRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _testRepository = testRepository;
        }

        public IEnumerable<EventSchedulingSlot> GetSlots(long eventId, AppointmentStatus appointmentStatus)
        {
            var slots = _eventSchedulingSlotRepository.GetbyEventId(eventId);
            return slots.Where(s => s.Status == appointmentStatus).ToArray();
        }

        private IEnumerable<EventSchedulingSlot> GetSlots(long eventId, AppointmentStatus appointmentStatus, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null)
        {
            var theEvent = _eventRepository.GetById(eventId);

            var getSlotsOnRoomBasis = false;

            if (theEvent.IsDynamicScheduling)
                getSlotsOnRoomBasis = ShouldGetSlotsOnRoomBasis(eventId);

            var slots = GetSlots(eventId, appointmentStatus);

            if (slots == null && !bookedSlots.IsNullOrEmpty())
                slots = bookedSlots;
            else if (slots != null && !bookedSlots.IsNullOrEmpty())
                slots = slots.Concat(bookedSlots);

            return getSlotsOnRoomBasis ? GetSlotsOnRoomBasis(eventId, packageId, testIds, slots) : slots;
        }

        private IEnumerable<EventSchedulingSlot> GetSlotsOnRoomBasis(long eventId, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> slots)
        {
            var screeingTestIds = new List<long>();
            EventPackage eventPackage = null;
            IEnumerable<EventPodRoomTest> podRoomTests = null;

            if (packageId > 0)
            {
                eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
                screeingTestIds.AddRange(eventPackage.Tests.Select(t => t.TestId));
            }

            if (eventPackage != null && eventPackage.PodRoomId != null)
            {
                podRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsForPackageTimeOnlyByEventId(eventId, eventPackage.PodRoomId.Value);
                var eventPodRoomIds = podRoomTests.Where(prt => screeingTestIds.Contains(prt.TestId)).Select(prt => prt.EventPodRoomId).Distinct().ToArray();

                var slotsAvailable = new List<EventSchedulingSlot>();
                foreach (var eventPodRoomId in eventPodRoomIds)
                {
                    var testIdsInAnotherRoom = podRoomTests.Where(prt => prt.EventPodRoomId != eventPodRoomId).Select(prt => prt.TestId).ToArray();
                    var tempSlots = slots.Where(s => s.EventPodRoomId == eventPodRoomId).Select(s => s);
                    if ((tempSlots == null || !tempSlots.Any()) && !screeingTestIds.All(testIdsInAnotherRoom.Contains))
                        return null;
                    if (tempSlots == null || !tempSlots.Any())
                        continue;

                    slotsAvailable.AddRange(tempSlots);
                }
                return slotsAvailable.OrderBy(es => es.StartTime).ToArray();
            }
            else
            {

                if (!testIds.IsNullOrEmpty())
                    screeingTestIds.AddRange(testIds);

                podRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsByEventId(eventId);

                var eventPodRoomIds = podRoomTests.Where(prt => screeingTestIds.Contains(prt.TestId)).Select(prt => prt.EventPodRoomId).Distinct().ToArray();

                var slotsAvailable = new List<EventSchedulingSlot>();
                foreach (var eventPodRoomId in eventPodRoomIds)
                {
                    var testIdsInAnotherRoom = podRoomTests.Where(prt => prt.EventPodRoomId != eventPodRoomId).Select(prt => prt.TestId).ToArray();
                    var tempSlots = slots.Where(s => s.EventPodRoomId == eventPodRoomId).Select(s => s);
                    if ((tempSlots == null || !tempSlots.Any()) && !screeingTestIds.All(testIdsInAnotherRoom.Contains))
                        return null;
                    if (tempSlots == null || !tempSlots.Any())
                        continue;

                    slotsAvailable.AddRange(tempSlots);
                }
                return slotsAvailable.OrderBy(es => es.StartTime).ToArray();
            }
        }

        public bool ShouldGetSlotsOnRoomBasis(long eventId)
        {
            var getSlotsOnRoomBasis = false;

            var eventPodRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsByEventId(eventId);

            if (eventPodRoomTests != null && eventPodRoomTests.Any() && eventPodRoomTests.Count() > 1)
            {
                var podRoomTests = eventPodRoomTests.ToArray();

                var eventPodRoomIds = podRoomTests.Select(prt => prt.EventPodRoomId).Distinct().ToArray();
                if (eventPodRoomIds.Length == 1)
                    return getSlotsOnRoomBasis;

                for (int i = 0; i < eventPodRoomIds.Length - 1; i++)
                {
                    var elementToCompare = podRoomTests.Where(x => x.EventPodRoomId == eventPodRoomIds[i]).Select(m => m.TestId).ToArray();

                    for (int j = i + 1; j < eventPodRoomIds.Length; j++)
                    {
                        var elementCompareFrom = podRoomTests.Where(x => x.EventPodRoomId == eventPodRoomIds[j]).Select(m => m.TestId).ToArray();

                        if (!(elementCompareFrom.Length == elementToCompare.Length && elementToCompare.All(elementCompareFrom.Contains)))
                        {
                            getSlotsOnRoomBasis = true;
                            break;
                        }
                    }

                    if (getSlotsOnRoomBasis)
                        break;
                }
            }
            return getSlotsOnRoomBasis;
        }

        public IEnumerable<SlotSelectionTimeFrameViewModel> GetAvailableTimeFrames(long eventId, int screeningTime, IEnumerable<long> selectedSlotIds, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null)
        {
            _availableSlots = GetSlots(eventId, AppointmentStatus.Free, packageId, testIds, bookedSlots);

            if (_availableSlots == null || !_availableSlots.Any()) return new SlotSelectionTimeFrameViewModel[0];

            //if (!bookedSlots.IsNullOrEmpty())
            //{
            //    _availableSlots = _availableSlots.Concat(bookedSlots).OrderBy(s => s.StartTime);
            //}

            var eventSChedulingSlots = GetSlotsForTimeFrame(eventId);
            if (eventSChedulingSlots.IsNullOrEmpty())
                return new SlotSelectionTimeFrameViewModel[0];

            DateTime fromTime, toTime;
            fromTime = eventSChedulingSlots.First().StartTime;
            fromTime = fromTime.AddMinutes(-1 * fromTime.Minute).AddSeconds(-1 * fromTime.Second);

            toTime = eventSChedulingSlots.Last().StartTime;
            toTime = toTime.AddMinutes(60 - toTime.Minute).AddSeconds(-1 * fromTime.Second);

            var slots = GetSlotsforaGivenTimeRange(eventId, _availableSlots, screeningTime, packageId, testIds, true);
            var timeFrames = new List<SlotSelectionTimeFrameViewModel>();

            var selectedSlot = !selectedSlotIds.IsNullOrEmpty() ? _eventSchedulingSlotRepository.GetbyId(GetHeadSlotintheChain(selectedSlotIds).Id) : null;

            while (fromTime < toTime)
            {
                var timeFrame = new SlotSelectionTimeFrameViewModel(fromTime, fromTime.AddHours(1));
                fromTime = fromTime.AddHours(1);

                if (selectedSlot != null && selectedSlot.StartTime >= timeFrame.FromTime && selectedSlot.StartTime <= timeFrame.ToTime)
                {
                    timeFrame.IsSelected = true;
                }

                if (slots.Any(s => s.StartTime >= timeFrame.FromTime && s.StartTime < timeFrame.ToTime))
                {
                    timeFrames.Add(timeFrame);
                }
            }

            return timeFrames;
        }

        private IEnumerable<EventSchedulingSlot> GetSlotsForTimeFrame(long eventId)
        {
            var theEvent = _eventRepository.GetById(eventId);
            var slots = _availableSlots;

            if (theEvent.EventDate.Date == DateTime.Now.Date)
            {
                if (LoggedinUserRole == Roles.Customer || LoggedinUserParentRole == Roles.Customer)
                {
                    slots = slots.Where(s => s.StartTime >= DateTime.Now.AddMinutes(LeadTimeForCustomer));
                }
                else if (LoggedinUserRole == Roles.CallCenterRep || LoggedinUserRole == Roles.CallCenterManager || LoggedinUserParentRole == Roles.CallCenterRep || LoggedinUserParentRole == Roles.CallCenterManager)
                {
                    slots = slots.Where(s => s.StartTime >= DateTime.Now.AddMinutes(LeadTimeForCallCenter));
                }
            }
            return slots;
            //fromTime = slots.First().StartTime;
            //fromTime = fromTime.AddMinutes(-1 * fromTime.Minute).AddSeconds(-1 * fromTime.Second);

            //toTime = slots.Last().StartTime;
            //toTime = toTime.AddMinutes(60 - toTime.Minute).AddSeconds(-1 * fromTime.Second);
        }

        public IEnumerable<EventSchedulingSlot> GetSlotsforaGivenTimeRange(long eventId, DateTime fromTime, DateTime toTime, int screeningTime, int numberofSlotstoOutput, long packageId, IEnumerable<long> testIds, out int totalSlots)
        {
            var slots = GetSlotsforaGivenTimeRange(eventId, fromTime, toTime, screeningTime, packageId, testIds);
            totalSlots = slots.Count();

            return slots.Take(numberofSlotstoOutput);
        }

        public IEnumerable<EventSchedulingSlot> GetSlotsforaGivenTimeRange(long eventId, DateTime fromTime, DateTime toTime, int screeningTime, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null)
        {
            _availableSlots = GetSlots(eventId, AppointmentStatus.Free, packageId, testIds, bookedSlots);
            //if (!bookedSlots.IsNullOrEmpty())
            //{
            //    _availableSlots = _availableSlots.Concat(bookedSlots).OrderBy(s => s.StartTime);
            //}
            return GetSlotsforaGivenTimeRange(eventId, _availableSlots.Where(s => s.StartTime >= fromTime && s.StartTime < toTime), screeningTime, packageId, testIds, (LoggedinUserRole == Roles.Customer || LoggedinUserParentRole == Roles.Customer));
        }

        private IEnumerable<EventSchedulingSlot> GetSlotsforaGivenTimeRange(long eventId, IEnumerable<EventSchedulingSlot> fromCollection, long screeningTime, long packageId, IEnumerable<long> testIds, bool getDistinct = false)
        {
            var theEvent = _eventRepository.GetById(eventId);
            IEnumerable<EventSchedulingSlot> slots = null;
            if (theEvent.IsDynamicScheduling)
            {
                var getSlotsOnRoomBasis = ShouldGetSlotsOnRoomBasis(eventId);
                if (getSlotsOnRoomBasis)
                {
                    var fixedGroupScreeningTime = theEvent.FixedGroupScreeningTime.HasValue ? theEvent.FixedGroupScreeningTime.Value : 0;
                    EventPackage eventPackage;
                    IEnumerable<EventTest> eventTests;
                    long[] selectedEventPodRoomIds;
                    var podRoomTests = GetRoomAndPackageTestDetail(eventId, packageId, testIds, out eventPackage, out eventTests, out selectedEventPodRoomIds);

                    var screeingTestIds = new List<long>();

                    if (packageId > 0 && eventPackage != null)
                    {
                        screeingTestIds.AddRange(eventPackage.Tests.Select(t => t.TestId));
                    }

                    if (!testIds.IsNullOrEmpty() && eventTests != null && eventTests.Any())
                    {
                        screeingTestIds.AddRange(testIds);
                    }


                    var slotsAvailable = new List<EventSchedulingSlot>();

                    for (int i = 0; i < selectedEventPodRoomIds.Length; i++)
                    {
                        var firstEventPodRoomId = selectedEventPodRoomIds[i];
                        var firstEventPodRoomSlots = fromCollection.Where(s => s.EventPodRoomId == firstEventPodRoomId).Select(s => s).ToArray();
                        if (firstEventPodRoomSlots == null || !firstEventPodRoomSlots.Any())
                            continue;

                        var testIdsInFirstRoom = podRoomTests.Where(prt => prt.EventPodRoomId == firstEventPodRoomId).Select(prt => prt.TestId).ToArray();

                        var testIdforCalculatingScreeningTime = testIdsInFirstRoom.Where(screeingTestIds.Contains).ToArray();

                        if (testIdforCalculatingScreeningTime.IsNullOrEmpty())
                            continue;

                        var firstRoomScreeningTime = CalculateScreeningTime(eventPackage, testIdforCalculatingScreeningTime, eventTests, fixedGroupScreeningTime);

                        foreach (var eventSchedulingSlot in firstEventPodRoomSlots)
                        {
                            var slotChain = GetSlotChainforaScreeningLength(eventSchedulingSlot, firstRoomScreeningTime, firstEventPodRoomId, false, theEvent.LunchStartTime, theEvent.LunchDuration);

                            if (slotChain != null && slotChain.Any())
                            {
                                var podRoomIds = selectedEventPodRoomIds.Where(m => m != firstEventPodRoomId).Select(m => m).ToArray();
                                var otherRoomScreeningTime = firstRoomScreeningTime;
                                var slotHasRequiredLength = false;
                                var testIdsAlreadyChecked = testIdsInFirstRoom;

                                foreach (var secondEventPodRoomId in podRoomIds)
                                {
                                    if (secondEventPodRoomId > 0 && !screeingTestIds.All(testIdsAlreadyChecked.Contains) && screeningTime > 0)
                                    {
                                        var testInSecondRoom = podRoomTests.Where(prt => prt.EventPodRoomId == secondEventPodRoomId).Select(prt => prt.TestId).ToArray();

                                        if (!testInSecondRoom.IsNullOrEmpty())
                                            testIdsAlreadyChecked = testIdsInFirstRoom.Concat(testInSecondRoom).ToArray();

                                        var firstRoomFirstSlot = slotChain.First();
                                        var secondEventPodRoomSlots = _availableSlots.Where(s => s.EventPodRoomId == secondEventPodRoomId && s.StartTime >= firstRoomFirstSlot.StartTime.AddMinutes(otherRoomScreeningTime)).Select(s => s).ToArray();

                                        if (secondEventPodRoomSlots != null && secondEventPodRoomSlots.Any())
                                        {
                                            var testIdsInSecondRoom = podRoomTests.Where(prt => prt.EventPodRoomId == secondEventPodRoomId && !testIdsAlreadyChecked.Contains(prt.TestId)).Select(prt => prt.TestId).ToArray();

                                            testIdforCalculatingScreeningTime = testIdsInSecondRoom.Where(screeingTestIds.Contains).ToArray();

                                            var secondRoomScreeningTime = CalculateScreeningTime(eventPackage, testIdforCalculatingScreeningTime, eventTests, fixedGroupScreeningTime);

                                            if (DoesSlothasaRequiredLength(secondEventPodRoomSlots.First(), secondRoomScreeningTime, secondEventPodRoomId, false, theEvent.LunchStartTime, theEvent.LunchDuration))
                                            {
                                                otherRoomScreeningTime += secondRoomScreeningTime;
                                                slotHasRequiredLength = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        slotHasRequiredLength = true;
                                    }
                                }

                                if (!slotHasRequiredLength && podRoomIds.Any())
                                    continue;
                            }
                            else
                                continue;

                            slotsAvailable.Add(eventSchedulingSlot);
                        }

                    }
                    slots = slotsAvailable.OrderBy(s => s.StartTime);
                }
                else
                {
                    if (screeningTime > _maxScreeningTime)
                        screeningTime = _maxScreeningTime;
                    else if (screeningTime < _minScreeningTime)
                        screeningTime = _minScreeningTime;
                    slots = fromCollection.Where(s => DoesSlothasaRequiredLength(s, screeningTime, theEvent.LunchStartTime, theEvent.LunchDuration)).ToArray();
                }

            }
            else
                slots = fromCollection;

            if (getDistinct)
            {
                var ids = slots.GroupBy(s => s.StartTime).Select(g => g.Min(s => s.Id)).ToArray();
                return slots.Where(s => ids.Contains(s.Id)).ToArray();
            }

            return slots;
        }

        private int CalculateScreeningTime(EventPackage eventPackage, IEnumerable<long> testIdsInRoom, IEnumerable<EventTest> eventTests, int fixedGropScreeningTime)
        {
            var screeningTime = 0;
            if (eventPackage != null)
            {
                if (eventPackage.Tests.All(m => testIdsInRoom.Contains(m.TestId)))
                {
                    screeningTime = eventPackage.Package.ScreeningTime;
                }
                else
                {
                    screeningTime = eventPackage.Tests.Where(et => testIdsInRoom.Contains(et.TestId)).Sum(et => et.Test.ScreeningTime);
                }
            }
            var hasAncillaryTests = false;
            if (!eventTests.IsNullOrEmpty())
            {
                hasAncillaryTests = eventTests.Any(et => testIdsInRoom.Contains(et.TestId) && et.Test.GroupId == (long)TestGroupType.Ancillary);
                if (hasAncillaryTests)
                    screeningTime += fixedGropScreeningTime;

                screeningTime += eventTests.Where(et => testIdsInRoom.Contains(et.TestId) && et.Test.GroupId == (long)TestGroupType.None).Sum(et => et.Test.ScreeningTime);
            }
            if (!hasAncillaryTests)//&& screeningTime > 0
            {
                if (screeningTime > _maxScreeningTime)
                    screeningTime = _maxScreeningTime;
                else if (screeningTime < _minScreeningTime)
                    screeningTime = _minScreeningTime;
            }

            return screeningTime;
        }

        private IEnumerable<EventPodRoomTest> GetRoomAndPackageTestDetail(long eventId, long packageId, IEnumerable<long> testIds, out EventPackage eventPackage, out IEnumerable<EventTest> eventTests, out long[] selectedEventPodRoomIds)
        {
            eventPackage = null;
            eventTests = null;
            IEnumerable<EventPodRoomTest> podRoomTests = null;
            long[] eventRoomIds = null;

            var screeingTestIds = new List<long>();

            if (packageId > 0)
            {
                eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
                screeingTestIds.AddRange(eventPackage.Tests.Select(t => t.TestId));
            }

            if (eventPackage != null && eventPackage.PodRoomId != null)
            {
                podRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsForPackageTimeOnlyByEventId(eventId, eventPackage.PodRoomId.Value);
                eventRoomIds = podRoomTests.Select(prt => prt.EventPodRoomId).Distinct().ToArray();
                selectedEventPodRoomIds = (from eventRoomId in eventRoomIds
                                           let roomTestIds = podRoomTests.Where(prt => prt.EventPodRoomId == eventRoomId).Select(prt => prt.TestId).ToArray()
                                           where screeingTestIds.All(roomTestIds.Contains)
                                           select eventRoomId).ToArray();

                if (selectedEventPodRoomIds.IsNullOrEmpty())
                    selectedEventPodRoomIds = podRoomTests.Where(prt => screeingTestIds.Contains(prt.TestId)).Select(prt => prt.EventPodRoomId).Distinct().ToArray();
                return podRoomTests;
            }

            if (!testIds.IsNullOrEmpty())
            {
                eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, testIds);
                screeingTestIds.AddRange(testIds);
            }

            podRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsByEventId(eventId);

            eventRoomIds = podRoomTests.Select(prt => prt.EventPodRoomId).Distinct().ToArray();
            selectedEventPodRoomIds = (from eventRoomId in eventRoomIds
                                       let roomTestIds = podRoomTests.Where(prt => prt.EventPodRoomId == eventRoomId).Select(prt => prt.TestId).ToArray()
                                       where screeingTestIds.All(roomTestIds.Contains)
                                       select eventRoomId).ToArray();

            if (selectedEventPodRoomIds.IsNullOrEmpty())
                selectedEventPodRoomIds = podRoomTests.Where(prt => screeingTestIds.Contains(prt.TestId)).Select(prt => prt.EventPodRoomId).Distinct().ToArray();
            return podRoomTests;
        }

        private bool DoesSlothasaRequiredLength(EventSchedulingSlot slot, long screeningTime, long eventPodRoomId, bool sameRoom, DateTime? lunchStartTime, int? lunchDuration)
        {
            var slotChain = GetSlotChainforaScreeningLength(slot, screeningTime, _availableSlots.Where(m => m.EventPodRoomId == eventPodRoomId), lunchStartTime, lunchDuration, sameRoom);
            return slotChain != null && slotChain.Any();
        }

        private IEnumerable<EventSchedulingSlot> GetSlotChainforaScreeningLength(EventSchedulingSlot slot, long screeningTime, long eventPodRoomId, bool sameRoom, DateTime? lunchStartTime, int? lunchDuration)
        {
            return GetSlotChainforaScreeningLength(slot, screeningTime, _availableSlots.Where(m => m.EventPodRoomId == eventPodRoomId), lunchStartTime, lunchDuration, sameRoom);
        }

        private bool DoesSlothasaRequiredLength(EventSchedulingSlot slot, long screeningTime, DateTime? lunchStartTime, int? lunchDuration)
        {
            var slotChain = GetSlotChainforaScreeningLength(slot, screeningTime, _availableSlots, lunchStartTime, lunchDuration);
            return slotChain != null && slotChain.Any();
        }

        private IEnumerable<EventSchedulingSlot> GetSlotChainforaScreeningLength(EventSchedulingSlot slot, long screeningTime, IEnumerable<EventSchedulingSlot> availableSlots, DateTime? lunchStartTime, int? lunchDuration, bool sameRoom = true)
        {
            var selectedSlot = slot;
            var length = (slot.EndTime - slot.StartTime).TotalMinutes;
            var slotChain = new List<EventSchedulingSlot> { slot };

            var slotRoomId = slot.EventPodRoomId;

            while (length < screeningTime)
            {
                var tempslot = availableSlots.FirstOrDefault(s => s.StartTime == slot.EndTime && (!slotRoomId.HasValue || slotRoomId.Value <= 0 || s.EventPodRoomId == slotRoomId));
                if (tempslot == null)
                {
                    tempslot = availableSlots.FirstOrDefault(s => s.StartTime == slot.EndTime);
                    if (tempslot == null)
                    {
                        slotChain = null;
                        break;
                    }

                }
                slot = tempslot;
                length += (slot.EndTime - slot.StartTime).TotalMinutes;
                slotChain.Add(slot);
            }

            if (slotChain == null && sameRoom)
            {
                slot = selectedSlot;
                length = (slot.EndTime - slot.StartTime).TotalMinutes;
                slotChain = new List<EventSchedulingSlot> { slot };

                while (length < screeningTime)
                {
                    var tempslot = availableSlots.FirstOrDefault(s =>
                        (s.StartTime == slot.EndTime || ((s.StartTime - slot.EndTime).TotalMinutes > 0 && (s.StartTime - slot.EndTime).TotalMinutes <= MaxWaitTime && (!lunchDuration.HasValue || !lunchStartTime.HasValue || lunchDuration.Value <= 45 || ((slot.StartTime <= lunchStartTime.Value && s.StartTime <= lunchStartTime.Value) || (slot.StartTime >= lunchStartTime.Value && s.StartTime >= lunchStartTime.Value)))))
                        && (!slotRoomId.HasValue || slotRoomId.Value <= 0 || s.EventPodRoomId == slotRoomId));
                    if (tempslot == null)
                    {
                        tempslot = availableSlots.FirstOrDefault(s => s.StartTime == slot.EndTime || ((s.StartTime - slot.EndTime).TotalMinutes > 0 && (s.StartTime - slot.EndTime).TotalMinutes <= MaxWaitTime && (!lunchDuration.HasValue || !lunchStartTime.HasValue || lunchDuration.Value <= 45 || ((slot.StartTime <= lunchStartTime.Value && s.StartTime <= lunchStartTime.Value) || (slot.StartTime >= lunchStartTime.Value && s.StartTime >= lunchStartTime.Value)))));
                        if (tempslot == null)
                            return null;
                    }
                    slot = tempslot;
                    length += (slot.EndTime - slot.StartTime).TotalMinutes;
                    slotChain.Add(slot);
                }
            }

            return slotChain;
        }

        public bool IsSlotBooked(IEnumerable<long> ids)
        {
            var slots = _eventSchedulingSlotRepository.GetbyIds(ids);
            return slots.Where(s => s.Status == AppointmentStatus.Booked).Any();
        }

        public bool IsSlotTemporarilyBooked(IEnumerable<long> ids)
        {
            var slots = _eventSchedulingSlotRepository.GetbyIds(ids);
            return slots.All(s => s.Status == AppointmentStatus.TemporarilyBooked);
        }

        public EventSchedulingSlot GetHeadSlotintheChain(IEnumerable<long> ids)
        {
            var slots = _eventSchedulingSlotRepository.GetbyIds(ids);
            return slots.OrderBy(s => s.StartTime).First();
        }

        private bool AllTestFallInSameRoom(long eventId, long packageId, IEnumerable<long> testIds, out List<long> selectedEventPodRoomIds)
        {
            var screeingTestIds = new List<long>();
            EventPackage eventPackage = null;
            IEnumerable<EventPodRoomTest> podRoomTests = null;

            if (packageId > 0)
            {
                eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
                screeingTestIds.AddRange(eventPackage.Tests.Select(t => t.TestId));
            }
            long[] eventRoomIds = null;

            if (eventPackage != null && eventPackage.PodRoomId != null)
            {
                podRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsForPackageTimeOnlyByEventId(eventId, eventPackage.PodRoomId.Value);


                eventRoomIds = podRoomTests.Select(prt => prt.EventPodRoomId).Distinct().ToArray();

                selectedEventPodRoomIds = (from eventRoomId in eventRoomIds
                                           let roomTestIds = podRoomTests.Where(prt => prt.EventPodRoomId == eventRoomId).Select(prt => prt.TestId).ToArray()
                                           where screeingTestIds.All(roomTestIds.Contains)
                                           select eventRoomId).ToList();
                return !selectedEventPodRoomIds.IsNullOrEmpty();
            }

            if (!testIds.IsNullOrEmpty())
            {
                screeingTestIds.AddRange(testIds);
            }

            podRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsByEventId(eventId);

            eventRoomIds = podRoomTests.Select(prt => prt.EventPodRoomId).Distinct().ToArray();

            selectedEventPodRoomIds = (from eventRoomId in eventRoomIds
                                       let roomTestIds = podRoomTests.Where(prt => prt.EventPodRoomId == eventRoomId).Select(prt => prt.TestId).ToArray()
                                       where screeingTestIds.All(roomTestIds.Contains)
                                       select eventRoomId).ToList();

            return !selectedEventPodRoomIds.IsNullOrEmpty();
        }

        public IEnumerable<EventSchedulingSlot> BookSlotTemporarily(long slotId, long screeningTime, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null, bool isChangePackageRequest = false)
        {
            using (var scope = new TransactionScope())
            {
                var slot = _eventSchedulingSlotRepository.GetbyId(slotId);
                var theEvent = _eventRepository.GetById(slot.EventId);

                var slots = new[] { slot };

                if (theEvent.IsDynamicScheduling)
                {
                    var fixedGroupScreeningTime = theEvent.FixedGroupScreeningTime.HasValue ? theEvent.FixedGroupScreeningTime.Value : 0;
                    _availableSlots = GetSlots(theEvent.Id, AppointmentStatus.Free, packageId, testIds, bookedSlots);

                    if (_availableSlots == null)
                        return null;
                    var getSlotsOnRoomBasis = ShouldGetSlotsOnRoomBasis(theEvent.Id);
                    if (getSlotsOnRoomBasis)
                    {

                        //****************/
                        var eventslotRoomIds = new List<long>();
                        if (AllTestFallInSameRoom(theEvent.Id, packageId, testIds, out eventslotRoomIds))
                        {
                            _availableSlots = _availableSlots.Where(x => eventslotRoomIds.Contains(x.EventPodRoomId.Value));
                            var selectSlotInOneRoom = GetSlotChainforaScreeningLength(slot, screeningTime, _availableSlots, theEvent.LunchStartTime, theEvent.LunchDuration);

                            if (selectSlotInOneRoom.IsNullOrEmpty())
                                return null;

                            var secondSlot = _availableSlots.FirstOrDefault(s => s.StartTime == slot.StartTime && s.EventPodRoomId != slot.EventPodRoomId);
                            if (secondSlot != null)
                            {
                                var secondSelectedSlots = GetSlotChainforaScreeningLength(secondSlot, screeningTime, _availableSlots, theEvent.LunchStartTime, theEvent.LunchDuration);
                                if (secondSelectedSlots != null)
                                {
                                    var firstWaitingTime = CalculateWaitingTime(selectSlotInOneRoom);
                                    var secondWaitingTime = CalculateWaitingTime(secondSelectedSlots);

                                    var firstRoomIdsCount =
                                        selectSlotInOneRoom.Select(ss => ss.EventPodRoomId).Distinct().Count();
                                    var secondRoomIdsCount =
                                        secondSelectedSlots.Select(ss => ss.EventPodRoomId).Distinct().Count();

                                    if (firstWaitingTime > secondWaitingTime)
                                        selectSlotInOneRoom = secondSelectedSlots.ToArray();
                                    else if (firstRoomIdsCount > secondRoomIdsCount)
                                        selectSlotInOneRoom = secondSelectedSlots.ToArray();
                                }
                            }

                            slots = selectSlotInOneRoom.ToArray();
                        }
                        else
                        {

                            EventPackage eventPackage;
                            IEnumerable<EventTest> eventTests;
                            long[] selectedEventPodRoomIds;
                            var podRoomTests = GetRoomAndPackageTestDetail(theEvent.Id, packageId, testIds,
                                out eventPackage, out eventTests, out selectedEventPodRoomIds);

                            var selectedSlots = GetSlotsToBeBooked(slot, podRoomTests, eventPackage, eventTests,
                                selectedEventPodRoomIds, screeningTime, fixedGroupScreeningTime, false,
                                theEvent.LunchStartTime, theEvent.LunchDuration);
                            if (selectedSlots == null)
                                return null;

                            var secondSlot = _availableSlots.FirstOrDefault(
                                     s => s.StartTime == slot.StartTime && s.EventPodRoomId != slot.EventPodRoomId);
                            if (secondSlot != null)
                            {
                                var secondSelectedSlots = GetSlotsToBeBooked(secondSlot, podRoomTests, eventPackage,
                                    eventTests, selectedEventPodRoomIds, screeningTime, fixedGroupScreeningTime, false,
                                    theEvent.LunchStartTime, theEvent.LunchDuration);
                                if (secondSelectedSlots != null)
                                {
                                    var firstWaitingTme = CalculateWaitingTime(selectedSlots);
                                    var secondWaitingTime = CalculateWaitingTime(secondSelectedSlots);

                                    if (firstWaitingTme > secondWaitingTime)
                                        selectedSlots = secondSelectedSlots;
                                }
                            }
                            slots = selectedSlots.ToArray();
                        }

                    }
                    else
                    {
                        if (screeningTime > _maxScreeningTime)
                            screeningTime = _maxScreeningTime;
                        else if (screeningTime < _minScreeningTime)
                            screeningTime = _minScreeningTime;

                        //if (!bookedSlots.IsNullOrEmpty())
                        //{
                        //    _availableSlots = _availableSlots.Concat(bookedSlots).OrderBy(s => s.StartTime);
                        //}

                        var selectedSlots = GetSlotChainforaScreeningLength(slot, screeningTime, _availableSlots, theEvent.LunchStartTime, theEvent.LunchDuration);
                        if (selectedSlots.IsNullOrEmpty())
                            return null;


                        var secondSlot = _availableSlots.FirstOrDefault(s => s.StartTime == slot.StartTime && s.EventPodRoomId != slot.EventPodRoomId);
                        if (secondSlot != null)
                        {
                            var secondSelectedSlots = GetSlotChainforaScreeningLength(secondSlot, screeningTime, _availableSlots, theEvent.LunchStartTime, theEvent.LunchDuration);
                            if (secondSelectedSlots != null)
                            {
                                var firstWaitingTme = CalculateWaitingTime(selectedSlots);
                                var secondWaitingTime = CalculateWaitingTime(secondSelectedSlots);

                                var firstRoomIdsCount = selectedSlots.Select(ss => ss.EventPodRoomId).Distinct().Count();
                                var secondRoomIdsCount = secondSelectedSlots.Select(ss => ss.EventPodRoomId).Distinct().Count();

                                if (firstWaitingTme > secondWaitingTime)
                                    selectedSlots = secondSelectedSlots.ToArray();
                                else if (firstRoomIdsCount > secondRoomIdsCount)
                                    selectedSlots = secondSelectedSlots.ToArray();
                            }
                        }

                        slots = selectedSlots.ToArray();
                    }
                }

                if (bookedSlots.IsNullOrEmpty())
                {
                    if (slots.Any(s => s.Status != AppointmentStatus.Free)) // Already being picked by someone else
                    {
                        return null;
                    }

                    foreach (var eventSchedulingSlot in slots)
                    {
                        eventSchedulingSlot.Status = AppointmentStatus.TemporarilyBooked;
                        eventSchedulingSlot.DateModified = DateTime.Now;
                        _eventSchedulingSlotRepository.Save(eventSchedulingSlot);
                    }
                }
                else
                {
                    var newSlots = slots.Where(s => !bookedSlots.Select(m => m.Id).Contains(s.Id)).Select(s => s).ToArray();
                    if (!newSlots.IsNullOrEmpty())
                    {
                        var firstBookedSlot = bookedSlots.First();
                        var firstNewSlot = slots.First();

                        var secondRoomBookedSlot = bookedSlots.Where(bs => bs.EventPodRoomId != firstBookedSlot.EventPodRoomId).Select(bs => bs).FirstOrDefault();
                        var secondRoomNewSlot = slots.Where(bs => bs.EventPodRoomId != firstNewSlot.EventPodRoomId).Select(bs => bs).FirstOrDefault();

                        if (secondRoomBookedSlot != null && secondRoomNewSlot != null && secondRoomBookedSlot.StartTime != secondRoomNewSlot.StartTime && !isChangePackageRequest)
                            return null;

                        if (secondRoomBookedSlot == null && secondRoomNewSlot != null && !isChangePackageRequest)
                            return null;

                        if (newSlots.Any(s => s.Status != AppointmentStatus.Free)) //Already being picked by someone else
                        {
                            return null;
                        }

                        foreach (var eventSchedulingSlot in newSlots)
                        {
                            eventSchedulingSlot.Status = AppointmentStatus.TemporarilyBooked;
                            eventSchedulingSlot.DateModified = DateTime.Now;
                            _eventSchedulingSlotRepository.Save(eventSchedulingSlot);
                        }
                    }
                }
                scope.Complete();
                return slots;
            }
        }

        private IEnumerable<EventSchedulingSlot> GetSlotsToBeBooked(EventSchedulingSlot slot, IEnumerable<EventPodRoomTest> podRoomTests, EventPackage eventPackage, IEnumerable<EventTest> eventTests, long[] selectedEventPodRoomIds, long screeningTime,
            int fixedGroupScreeningTime, bool sameRoom, DateTime? lunchStartTime, int? lunchDuration)
        {
            var firstEventPodRoomId = slot.EventPodRoomId.Value;
            var firstEventPodRoomSlots = _availableSlots.Where(s => s.EventPodRoomId == firstEventPodRoomId).Select(s => s).ToArray();
            if (firstEventPodRoomSlots == null || !firstEventPodRoomSlots.Any())
                return null;

            var testIdsInFirstRoom = podRoomTests.Where(prt => prt.EventPodRoomId == firstEventPodRoomId).Select(prt => prt.TestId).ToArray();

            var orderTestIds = new List<long>();
            if (eventPackage != null)
                orderTestIds.AddRange(eventPackage.Tests.Select(et => et.TestId));
            if (!eventTests.IsNullOrEmpty())
                orderTestIds.AddRange(eventTests.Select(et => et.TestId));

            if (!orderTestIds.Any(testIdsInFirstRoom.Contains))
                return null;

            var screeingTestIds = new List<long>();

            if (eventPackage != null)
            {
                screeingTestIds.AddRange(eventPackage.Tests.Select(t => t.TestId));
            }

            if (!eventTests.IsNullOrEmpty())
            {
                screeingTestIds.AddRange(eventTests.Select(et => et.TestId));
            }

            var testIdsForScreenTimeCalculation = testIdsInFirstRoom.Where(screeingTestIds.Contains);

            if (testIdsForScreenTimeCalculation.IsNullOrEmpty())
                return null;

            var firstRoomScreeningTime = CalculateScreeningTime(eventPackage, testIdsForScreenTimeCalculation, eventTests, fixedGroupScreeningTime);

            var slotChain = GetSlotChainforaScreeningLength(slot, firstRoomScreeningTime, firstEventPodRoomId, sameRoom, lunchStartTime, lunchDuration);
            if (slotChain == null || !slotChain.Any())
                return null;

            var selectedSlots = new List<EventSchedulingSlot>();
            selectedSlots.AddRange(slotChain);

            if (screeningTime == 0)
                return selectedSlots;

            if (screeningTime > _maxScreeningTime)
                screeningTime = _maxScreeningTime;
            else if (screeningTime < _minScreeningTime)
                screeningTime = _minScreeningTime;

            var allTestContainedInOneRoom = screeingTestIds.All(testIdsInFirstRoom.Contains);

            var adjustedInOneRoom = DoesSlothasaRequiredLength(slot, screeningTime, firstEventPodRoomId, sameRoom, lunchStartTime, lunchDuration);
            if (adjustedInOneRoom && allTestContainedInOneRoom)
                return selectedSlots;

            var roomPodIds = selectedEventPodRoomIds.Where(m => m != firstEventPodRoomId).Select(m => m);

            var testIdsInOtherRooms = podRoomTests.Where(prt => prt.EventPodRoomId == firstEventPodRoomId).Select(prt => prt.TestId).ToArray();

            var slotsFoundForTestIds = podRoomTests.Where(prt => prt.EventPodRoomId == firstEventPodRoomId && screeingTestIds.Contains(prt.TestId)).Select(prt => prt.TestId).ToArray();

            var firstRoomFirstSlot = slotChain.First();

            foreach (var secondEventPodRoomId in roomPodIds)
            {
                if (secondEventPodRoomId > 0)
                {
                    var secondEventPodRoomSlots = _availableSlots.Where(s => s.EventPodRoomId == secondEventPodRoomId && s.StartTime >= firstRoomFirstSlot.StartTime.AddMinutes(firstRoomScreeningTime)).Select(s => s).ToArray();

                    if (secondEventPodRoomSlots != null && secondEventPodRoomSlots.Any())
                    {
                        var testIdsInSecondRoom = podRoomTests.Where(prt => prt.EventPodRoomId == secondEventPodRoomId && !testIdsInOtherRooms.Contains(prt.TestId)).Select(prt => prt.TestId).ToArray();


                        testIdsForScreenTimeCalculation = testIdsInSecondRoom.Where(screeingTestIds.Contains);

                        if (!testIdsForScreenTimeCalculation.IsNullOrEmpty())
                        {
                            var secondRoomScreeningTime = CalculateScreeningTime(eventPackage, testIdsForScreenTimeCalculation, eventTests, fixedGroupScreeningTime);

                            var secondSlotChain = GetSlotChainforaScreeningLength(secondEventPodRoomSlots.First(), secondRoomScreeningTime, secondEventPodRoomId, sameRoom, lunchStartTime, lunchDuration);
                            if (secondSlotChain != null && secondSlotChain.Any())
                            {
                                selectedSlots.AddRange(secondSlotChain);

                                firstRoomFirstSlot = secondSlotChain.First();
                                firstRoomScreeningTime = secondRoomScreeningTime;

                                if (!testIdsInSecondRoom.IsNullOrEmpty())
                                    testIdsInOtherRooms = testIdsInOtherRooms.Concat(testIdsInSecondRoom).ToArray();

                                var testinCurrentRoom = testIdsInSecondRoom.Where(screeingTestIds.Contains).ToArray();

                                slotsFoundForTestIds = slotsFoundForTestIds.Concat(testinCurrentRoom).ToArray();
                            }
                        }
                    }

                }
            }

            if (screeingTestIds.Any(t => !slotsFoundForTestIds.Contains(t)))
                return null;

            return selectedSlots;
        }

        public AppointmentSlotListModel GetSlots(long eventId, DateTime fromTime, DateTime toTime, int screeningTime, int numberOfSlotstoShow, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null)
        {
            int totalSlots = 0;
            var slots = (LoggedinUserRole == Roles.Customer || LoggedinUserParentRole == Roles.Customer) ? GetSlotsforaGivenTimeRange(eventId, fromTime, toTime, screeningTime, numberOfSlotstoShow, packageId, testIds, out totalSlots)
                                                : GetSlotsforaGivenTimeRange(eventId, fromTime, toTime, screeningTime, packageId, testIds, bookedSlots);

            if (slots == null || !slots.Any()) return null;

            slots = slots.OrderBy(s => s.StartTime).ToArray();

            var model = new AppointmentSlotListModel
            {
                ScreeningTime = screeningTime,
                Slots = slots.Select(s => new AppointmentSlotViewModel { AppointmentId = s.Id, StartTime = s.StartTime }),
                TimeFrame = new SlotSelectionTimeFrameViewModel(fromTime, toTime),
                TotalSlots = totalSlots,
                PackageId = packageId,
                AddOnTestIds = testIds
            };

            return model;
        }

        public AppointmentSelectionEditModel GetAppointmentSelectionModel(long eventId, int screeningTime, IEnumerable<long> selectedSlotIds, long packageId, IEnumerable<long> testIds, IEnumerable<long> bookedSlotIds = null)
        {
            var selectedSlots = !selectedSlotIds.IsNullOrEmpty() ? _eventSchedulingSlotRepository.GetbyIds(selectedSlotIds).OrderBy(s => s.StartTime) : null;

            var model = new AppointmentSelectionEditModel { EventId = eventId, MaxNumberofSlots = 4, ScreeningTime = screeningTime, PackageId = packageId, AddOnTestIds = testIds };

            if (selectedSlots.IsNullOrEmpty())
            {
                IEnumerable<EventSchedulingSlot> bookedSlots = null;
                if (!bookedSlotIds.IsNullOrEmpty())
                    bookedSlots = _eventSchedulingSlotRepository.GetbyIds(bookedSlotIds);
                model.TimeFrames = GetAvailableTimeFrames(eventId, screeningTime, selectedSlotIds, packageId, testIds, bookedSlots).ToArray();
            }
            else
            {
                model.AppointmentTime = selectedSlots.First().StartTime;
                model.SelectedAppointmentIds = selectedSlotIds;
                var eventPodRoomIds = selectedSlots.Where(s => s.EventPodRoomId.HasValue).Select(s => s.EventPodRoomId.Value).Distinct().ToArray();
                if (!eventPodRoomIds.IsNullOrEmpty())//&& eventPodRoomIds.Length > 1
                {
                    var screeingTestIds = new List<long>();

                    if (packageId > 0)
                    {
                        var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
                        screeingTestIds.AddRange(eventPackage.Tests.Select(t => t.TestId));
                    }

                    if (!testIds.IsNullOrEmpty())
                        screeingTestIds.AddRange(testIds);

                    var eventPodRooms = _eventPodRoomRepository.GetByIds(eventPodRoomIds);
                    var eventPodRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsByEventRoomIds(eventPodRoomIds);
                    var tests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(screeingTestIds);

                    var roomAppointments = RoomAppointmentSelectionViewModels(eventPodRooms, eventPodRoomTests, screeingTestIds, tests, selectedSlots);

                    roomAppointments = SetTestAllowedOnRoom(roomAppointments, tests);
                    model.RoomAppointments = SetWaitingTimeBetweenTwoRoom(roomAppointments);

                    model.TotalWaitingTime = CalculateWaitingTime(roomAppointments);
                }
            }

            return model;
        }

        private IEnumerable<RoomAppointmentSelectionViewModel> SetTestAllowedOnRoom(IEnumerable<RoomAppointmentSelectionViewModel> roomAppointments, IEnumerable<Test> tests)
        {
            roomAppointments = roomAppointments.OrderBy(x => x.AppointmentTime);
            var testIdsInPrviousRoom = new List<long>();

            foreach (var item in roomAppointments)
            {
                var roomTests = tests.Where(t => !testIdsInPrviousRoom.Contains(t.Id) && item.ScreeningTestIds.Contains(t.Id)).Select(t => t.Name).ToArray();

                if (!item.ScreeningTestIds.IsNullOrEmpty())
                    testIdsInPrviousRoom = testIdsInPrviousRoom.Concat(item.ScreeningTestIds).ToList();


                item.ScreeningTests = string.Join(",", roomTests);
            }

            return roomAppointments;
        }

        private IEnumerable<RoomAppointmentSelectionViewModel> SetWaitingTimeBetweenTwoRoom(IEnumerable<RoomAppointmentSelectionViewModel> roomAppointments)
        {
            roomAppointments = roomAppointments.OrderBy(x => x.AppointmentTime);

            RoomAppointmentSelectionViewModel firstRoomAppointment = null;

            foreach (var item in roomAppointments)
            {
                if (firstRoomAppointment == null)
                {
                    firstRoomAppointment = item;
                    continue;
                }

                double waitingTime = 0;

                var tempSlots = firstRoomAppointment.Slots.ToArray();

                tempSlots = tempSlots.Concat(item.Slots).OrderBy(s => s.StartTime).ToArray();

                for (int i = 0; i < tempSlots.Length - 1; i++)
                {
                    waitingTime += (tempSlots[i + 1].StartTime - tempSlots[i].EndTime).TotalMinutes;
                }

                item.TotalWaitingTime = waitingTime;

                firstRoomAppointment = item;
            }

            return roomAppointments;
        }

        private double CalculateWaitingTime(IEnumerable<RoomAppointmentSelectionViewModel> roomAppointments)
        {
            if (roomAppointments.IsNullOrEmpty())
                return 0;

            double waitingTime = 0;

            var firstRoomAppointment = roomAppointments.ElementAt(0);

            var tempSlots = firstRoomAppointment.Slots.ToArray();

            if (roomAppointments.Count() > 1)
            {
                var secondRoomAppointment = roomAppointments.ElementAt(1);

                tempSlots = tempSlots.Concat(secondRoomAppointment.Slots).OrderBy(s => s.StartTime).ToArray();
            }

            for (int i = 0; i < tempSlots.Length - 1; i++)
            {
                waitingTime += (tempSlots[i + 1].StartTime - tempSlots[i].EndTime).TotalMinutes;
            }

            return waitingTime;

        }

        private double CalculateWaitingTime(IEnumerable<EventSchedulingSlot> slots)
        {
            if (slots.IsNullOrEmpty())
                return 0;

            double waitingTime = 0;

            var tempSlots = slots.ToArray();

            for (int i = 0; i < tempSlots.Length - 1; i++)
            {
                waitingTime += (tempSlots[i + 1].StartTime - tempSlots[i].EndTime).TotalMinutes;
            }

            return waitingTime;
        }

        public IEnumerable<RoomAppointmentSelectionViewModel> RoomAppointmentSelectionViewModels(IEnumerable<EventPodRoom> eventPodRooms, IEnumerable<EventPodRoomTest> eventPodRoomTests,
            List<long> screeingTestIds, IEnumerable<Test> tests, IEnumerable<EventSchedulingSlot> selectedSlots)
        {
            if (eventPodRooms.IsNullOrEmpty())
                return null;

            var roomAppointments = new List<RoomAppointmentSelectionViewModel>();

            var eventPodRoomIds = selectedSlots.Where(s => s.EventPodRoomId.HasValue).Select(s => s.EventPodRoomId.Value).Distinct().ToArray();

            foreach (var eventPodRoomId in eventPodRoomIds)
            {
                var eventPodRoom = eventPodRooms.First(m => m.Id == eventPodRoomId);
                var roomScreenedTestIds = eventPodRoomTests.Where(m => m.EventPodRoomId == eventPodRoomId && screeingTestIds.Contains(m.TestId)).Select(m => m.TestId).ToArray();
                var roomTests = tests.Where(t => roomScreenedTestIds.Contains(t.Id)).Select(t => t.Id).ToArray();
                var roomSlots = selectedSlots.Where(s => s.EventPodRoomId == eventPodRoomId).Select(s => s).OrderBy(s => s.StartTime).ToArray();

                roomAppointments.Add(new RoomAppointmentSelectionViewModel
                {
                    RoomNo = eventPodRoom.RoomNo,
                    ScreeningTestIds = roomTests,
                    AppointmentTime = roomSlots.First().StartTime,
                    SelectedAppointmentIds = roomSlots.Select(rs => rs.Id).ToArray(),
                    Slots = roomSlots
                });
            }

            return roomAppointments;
        }

        public IEnumerable<EventSchedulingSlot> AdjustAppointmentSlot(long eventId, int screeningTime, IEnumerable<long> slotIds, long packageId, IEnumerable<long> testIds, DateTime? lunchStartTime, int? lunchDuration)
        {
            var slots = _eventSchedulingSlotRepository.GetbyIds(slotIds);
            var theEvent = _eventRepository.GetById(eventId);

            if (!theEvent.IsDynamicScheduling)
                return slots;

            if (testIds != null && testIds.Any() && screeningTime > 0)
            {
                var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, testIds);
                testIds = eventTests.Select(et => et.TestId).ToArray();
            }

            var getSlotsOnRoomBasis = ShouldGetSlotsOnRoomBasis(theEvent.Id);

            if (getSlotsOnRoomBasis)
            {
                _eventSchedulingSlotRepository.ReleaseSlots(slotIds);

                var bookedSlots = slots.Where(s => s.Status == AppointmentStatus.Booked).Select(s => s).OrderBy(s => s.StartTime);

                var eventslotRoomIds = new List<long>();

                if (bookedSlots.IsNullOrEmpty())
                {
                    var slotBookedTemp = BookSlotTemporarily(slots.First().Id, screeningTime, packageId, testIds);

                    if (AllTestFallInSameRoom(eventId, packageId, testIds, out eventslotRoomIds))
                    {
                        return slotBookedTemp == null ? null : slotBookedTemp.Where(x => x.EventPodRoomId.HasValue && eventslotRoomIds.Contains(x.EventPodRoomId.Value)).OrderBy(s => s.StartTime);
                    }

                    return slotBookedTemp == null ? null : slotBookedTemp.OrderBy(s => s.StartTime);
                }
                else
                {
                    var slotBookedTemp = BookSlotTemporarily(bookedSlots.First().Id, screeningTime, packageId, testIds, bookedSlots);

                    if (AllTestFallInSameRoom(eventId, packageId, testIds, out eventslotRoomIds))
                    {
                        return slotBookedTemp == null ? null : slotBookedTemp.Where(x => x.EventPodRoomId.HasValue && eventslotRoomIds.Contains(x.EventPodRoomId.Value)).OrderBy(s => s.StartTime);
                    }

                    return slotBookedTemp == null ? null : slotBookedTemp.OrderBy(s => s.StartTime);
                }
            }

            if (screeningTime > _maxScreeningTime)
                screeningTime = _maxScreeningTime;
            else if (screeningTime < _minScreeningTime)
                screeningTime = _minScreeningTime;

            //var length = (long)((slots.Last().EndTime - slots.First().StartTime).TotalMinutes);
            var length = (long)slots.Sum(s => (s.EndTime - s.StartTime).TotalMinutes);

            if (length > screeningTime)
            {
                var tempSlots = new List<EventSchedulingSlot>();
                long duration = 0;
                foreach (var eventSchedulingSlot in slots)
                {
                    duration = duration + (long)(eventSchedulingSlot.EndTime - eventSchedulingSlot.StartTime).TotalMinutes;
                    tempSlots.Add(eventSchedulingSlot);
                    if (duration >= screeningTime)
                        break;
                }
                slots = tempSlots;

                var slotIdsToBeReleased = slotIds.Where(si => !slots.Select(s => s.Id).Contains(si));
                if (!slotIdsToBeReleased.IsNullOrEmpty())
                    _eventSchedulingSlotRepository.ReleaseSlots(slotIdsToBeReleased);
            }
            else if (length < screeningTime)
            {
                var availableSlots = GetSlots(eventId, AppointmentStatus.Free, packageId, testIds).ToList();

                var tempSlot = slots.Last();
                var slotRoomId = tempSlot.EventPodRoomId;
                var firstSlot = availableSlots.FirstOrDefault(s => (tempSlot.EndTime == s.StartTime || ((s.StartTime - tempSlot.EndTime).TotalMinutes > 0 && (s.StartTime - tempSlot.EndTime).TotalMinutes <= MaxWaitTime && (!lunchDuration.HasValue || !lunchStartTime.HasValue || lunchDuration.Value <= 45 || ((tempSlot.StartTime <= lunchStartTime.Value && s.StartTime <= lunchStartTime.Value) || (tempSlot.StartTime >= lunchStartTime.Value && s.StartTime >= lunchStartTime.Value))))) && (!slotRoomId.HasValue || slotRoomId.Value <= 0 || s.EventPodRoomId == slotRoomId));

                if (firstSlot == null)
                {
                    firstSlot = availableSlots.FirstOrDefault(s => s.StartTime == tempSlot.EndTime || ((s.StartTime - tempSlot.EndTime).TotalMinutes > 0 && (s.StartTime - tempSlot.EndTime).TotalMinutes <= MaxWaitTime && (!lunchDuration.HasValue || !lunchStartTime.HasValue || lunchDuration.Value <= 45 || ((tempSlot.StartTime <= lunchStartTime.Value && s.StartTime <= lunchStartTime.Value) || (tempSlot.StartTime >= lunchStartTime.Value && s.StartTime >= lunchStartTime.Value)))));
                    if (firstSlot == null)
                    {
                        _eventSchedulingSlotRepository.ReleaseSlots(slotIds);
                        return null;
                    }

                }

                var newSlots = GetSlotChainforaScreeningLength(firstSlot, screeningTime - length, availableSlots, lunchStartTime, lunchDuration);

                if (newSlots.IsNullOrEmpty())
                {
                    _eventSchedulingSlotRepository.ReleaseSlots(slotIds);
                    return null;
                }

                slots = slots.Concat(newSlots).OrderBy(s => s.StartTime);

                using (var scope = new TransactionScope())
                {
                    if (newSlots.Any(s => s.Status != AppointmentStatus.Free))
                    {
                        _eventSchedulingSlotRepository.ReleaseSlots(slotIds);
                        return null;
                    }

                    foreach (var eventSchedulingSlot in newSlots)
                    {
                        eventSchedulingSlot.Status = AppointmentStatus.TemporarilyBooked;
                        eventSchedulingSlot.DateModified = DateTime.Now;
                        _eventSchedulingSlotRepository.Save(eventSchedulingSlot);
                    }

                    scope.Complete();
                }
            }
            return slots;
        }

        public void SendEventFillingNotification(long eventId, long createdByOrgRoleUserId)
        {
            var notificationTypes = _notificationTypeRepository.GetAll();
            var eventFillingNotificationIsActive = notificationTypes.Any(nt => (nt.NotificationTypeAlias == NotificationTypeAlias.EventFillingNotification) && nt.IsActive);
            var eventFullNotificationIsActive = notificationTypes.Any(nt => (nt.NotificationTypeAlias == NotificationTypeAlias.EventFullNotification) && nt.IsActive);

            var eventFillingThreshold = Convert.ToInt32(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EventBookingThreshold));

            var notificationSent = _eventNotificationRepository.GetByEventId(eventId, NotificationTypeAlias.EventFillingNotification);
            var eventFullNotificationSent = _eventNotificationRepository.GetByEventId(eventId, NotificationTypeAlias.EventFullNotification);

            if ((eventFillingNotificationIsActive && eventFillingThreshold > 0 && notificationSent == null) || (eventFullNotificationIsActive && eventFullNotificationSent == null))
            {
                var slots = _eventSchedulingSlotRepository.GetbyEventId(eventId);

                var filledSlotsCount = slots.Count(s => s.Status == AppointmentStatus.Booked);
                var blockedSlotsCount = slots.Count(s => s.Status == AppointmentStatus.Blocked);
                var totalSlotsCount = slots.Count() - blockedSlotsCount;

                if (eventFillingNotificationIsActive && eventFillingThreshold > 0 && notificationSent == null)
                {
                    var bookingPercentage = ((filledSlotsCount * 100) / totalSlotsCount);

                    if (bookingPercentage >= eventFillingThreshold)
                    {
                        var model = _emailNotificationModelsFactory.GetEventFillingNotificationViewModel(eventId, totalSlotsCount, (totalSlotsCount - filledSlotsCount));
                        var notifications = _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EventFillingNotification, EmailTemplateAlias.EventFillingNotification, model, new string[0], 0, createdByOrgRoleUserId, "Event Filling Notification");
                        if (notifications != null && notifications.Any())
                        {
                            var eventNotification = new EventNotification { EventId = eventId, NotificationId = notifications.First().Id };
                            _eventNotificationRepository.Save(eventNotification);
                        }
                    }
                }

                if (eventFullNotificationIsActive && eventFullNotificationSent == null)
                {
                    if (filledSlotsCount == totalSlotsCount)
                    {
                        var model = _emailNotificationModelsFactory.GetEventFullNotificationViewModel(eventId, totalSlotsCount);
                        var notifications = _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EventFullNotification, EmailTemplateAlias.EventFullNotification, model, new string[0], 0, createdByOrgRoleUserId, "Event Full Notification");
                        if (notifications != null && notifications.Any())
                        {
                            var eventNotification = new EventNotification { EventId = eventId, NotificationId = notifications.First().Id };
                            _eventNotificationRepository.Save(eventNotification);
                        }
                    }
                }
            }
        }

        public void SaveEventSlot(long eventId, DateTime eventDate, DateTime eventStartTime, DateTime eventEndTime, DateTime? lunchStartTime, int? lunchDuration, IEnumerable<EventPodRoom> eventPodRooms)
        {
            _eventSchedulingSlotRepository.DeleteByEventId(eventId);

            AddEventSlots(eventId, eventDate, eventStartTime, eventEndTime, lunchStartTime, lunchDuration, eventPodRooms);
        }

        public void AddEventSlots(long eventId, DateTime eventDate, DateTime eventStartTime, DateTime eventEndTime, DateTime? lunchStartTime, int? lunchDuration, IEnumerable<EventPodRoom> eventPodRooms)
        {
            var slots = new List<EventSchedulingSlot>();
            foreach (var eventPodRoom in eventPodRooms)
            {
                var slotStartTime = eventDate.Date.AddHours(eventStartTime.Hour).AddMinutes(eventStartTime.Minute);
                var slotEndTime = eventDate.Date.AddHours(eventEndTime.Hour).AddMinutes(eventEndTime.Minute);

                while (slotStartTime < slotEndTime && slotStartTime.AddMinutes(eventPodRoom.Duration) <= slotEndTime)
                {
                    if (lunchStartTime.HasValue && lunchDuration.HasValue)
                    {
                        var lunchTime = eventDate.Date.AddHours(lunchStartTime.Value.Hour).AddMinutes(lunchStartTime.Value.Minute);
                        var lunchEndTime = lunchTime.AddMinutes(lunchDuration.Value);

                        if ((slotStartTime == lunchTime) || (slotStartTime < lunchTime && slotStartTime.AddMinutes(eventPodRoom.Duration) > lunchTime))
                        {
                            slotStartTime = lunchEndTime;
                            continue;
                        }

                    }

                    var slot = new EventSchedulingSlot
                    {
                        EventId = eventId,
                        StartTime = slotStartTime,
                        EndTime = slotStartTime.AddMinutes(eventPodRoom.Duration),
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        Status = AppointmentStatus.Free,
                        Reason = "",
                        EventPodRoomId = eventPodRoom.Id
                    };
                    slots.Add(slot);
                    slotStartTime = slotStartTime.AddMinutes(eventPodRoom.Duration);
                }
            }
            _eventSchedulingSlotRepository.SaveSlots(slots);
        }

        public int GetScreeningTime(IEnumerable<long> testIds, long eventId, long packageId)
        {
            int screeningTime = 0;

            var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
            var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, testIds);

            if (eventPackage != null)
            {
                screeningTime += eventPackage.Package.ScreeningTime;
            }

            if (!eventTests.IsNullOrEmpty())
            {
                screeningTime += eventTests.Sum(et => et.Test.ScreeningTime);
            }

            if (eventPackage != null || (eventTests != null && eventTests.Any()))
            {
                var eventData = _eventRepository.GetById(eventId);

                if (eventData.IsDynamicScheduling && screeningTime == 0)
                {
                    screeningTime = MinimumScreeningTime;
                }

                if (eventPackage != null && eventData.IsDynamicScheduling && eventData.IsPackageTimeOnly)
                {
                    screeningTime = eventPackage.Package.ScreeningTime > 0 ? eventPackage.Package.ScreeningTime : MinimumScreeningTime;
                }
            }

            return screeningTime;
        }

    }
}
