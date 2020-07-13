using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Application;

namespace Falcon.App.Infrastructure.Scheduling.Services
{
    [DefaultImplementation]
    public class EventAppointmentService : IEventAppointmentService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _testRepository;
        private readonly IEventAppointmentBasicInfoModelFactory _eventAppointmentBasicInfoModelFactory;
        private readonly IEventRepository _eventRepository;
        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;
        private readonly IEventAppointmentChangeLogRepository _eventAppointmentChangeLogRepository;
        private readonly IEventPodRoomRepository _eventPodRoomRepository;

        private readonly int _maxScreeningTime;
        private readonly int _minScreeningTime;

        public EventAppointmentService(IEventCustomerRepository eventCustomerRepository, IAppointmentRepository appointmentRepository, ICustomerRepository customerRepository, IEventPackageRepository eventPackageRepository,
            IEventTestRepository testRepository, IEventAppointmentBasicInfoModelFactory eventAppointmentBasicInfoModelFactory, IEventRepository eventRepository, IOrderRepository orderRepository,
            IEventSchedulingSlotRepository eventSchedulingSlotRepository, IEventAppointmentChangeLogRepository eventAppointmentChangeLogRepository, IEventPodRoomRepository eventPodRoomRepository,
            ISettings settings)
        {
            _maxScreeningTime = settings.DynamicSchedulingMaximumScreeningTime;
            _minScreeningTime = settings.DynamicSchedulingMinimumScreeningTime;

            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _customerRepository = customerRepository;
            _eventPackageRepository = eventPackageRepository;
            _testRepository = testRepository;
            _eventAppointmentBasicInfoModelFactory = eventAppointmentBasicInfoModelFactory;
            _eventRepository = eventRepository;
            _orderRepository = orderRepository;
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
            _eventAppointmentChangeLogRepository = eventAppointmentChangeLogRepository;
            _eventPodRoomRepository = eventPodRoomRepository;
        }

        public EventAppointmentListModel GetAppointmentSlotsByEventId(long eventId)
        {
            var appointments = _eventSchedulingSlotRepository.GetbyEventId(eventId);
            //appointments = appointments.Where(ap => ap.Status != AppointmentStatus.Booked);
            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);
            var eventData = _eventRepository.GetById(eventId);
            var eventPodRooms = eventData.IsDynamicScheduling ? _eventPodRoomRepository.GetByEventId(eventId) : null;

            if (eventCustomers == null || eventCustomers.Count() < 1) return _eventAppointmentBasicInfoModelFactory.Create(appointments, eventData, eventPodRooms);

            var bookedAppointments = _appointmentRepository.GetAllAppointmentsForEvent(eventId);

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();

            var orderEventCustomrIdpairs = _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomerIds);
            var orderIds = orderEventCustomrIdpairs.Select(o => o.FirstValue).ToArray();

            var orderAndPackageNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var packageAndEcidpair = (from oep in orderEventCustomrIdpairs
                                      join op in orderAndPackageNamePair on oep.FirstValue equals op.FirstValue
                                      select new OrderedPair<long, string>(oep.SecondValue, op.SecondValue)).ToArray();

            var orderAndTestNamePair = _testRepository.GetTestNamesForOrders(orderIds);
            var testAndEcidpair = (from oep in orderEventCustomrIdpairs
                                   join op in orderAndTestNamePair on oep.FirstValue equals op.FirstValue
                                   select new OrderedPair<long, string>(oep.SecondValue, op.SecondValue)).ToArray();

            return _eventAppointmentBasicInfoModelFactory.Create(eventCustomers, appointments, customers, packageAndEcidpair, testAndEcidpair, eventData, bookedAppointments, eventPodRooms);
        }

        public EventAppointSlotSummaryViewModel GetEventAppointmentSlotSummary(long eventId)
        {
            var eventData = _eventRepository.GetById(eventId);

            return GetEventAppointmentSlotSummary(eventId, eventData.IsDynamicScheduling);
            //var model = new EventAppointSlotSummaryViewModel();
            //var appointmentModels = new List<EventAppointmentBasicInfoModel>();
            //model.IsDynamicScheduling = eventData.IsDynamicScheduling;
            //var eventPodRooms = eventData.IsDynamicScheduling ? _eventPodRoomRepository.GetByEventId(eventId) : null;
            //model.EventPodRooms = eventPodRooms;

            //var appointments = _eventSchedulingSlotRepository.GetbyEventId(eventId);
            //var notBookedAppointments = appointments.Where(ap => ap.Status != AppointmentStatus.Booked).Select(ap => ap).ToArray();
            //if (!notBookedAppointments.IsNullOrEmpty())
            //{
            //    var appointmentBasicInfoModels = _eventAppointmentBasicInfoModelFactory.Create(notBookedAppointments);
            //    appointmentModels.AddRange(appointmentBasicInfoModels);
            //}

            //var bookedAppointments = _appointmentRepository.GetAllAppointmentsForEvent(eventId);
            //if (!bookedAppointments.IsNullOrEmpty())
            //{
            //    appointmentModels.AddRange(from bookedAppointment in bookedAppointments
            //                               let roomSlots = GetRoomSlots(appointments, bookedAppointment, eventPodRooms)
            //                               select new EventAppointmentBasicInfoModel
            //                                   {
            //                                       AppointmentId = bookedAppointment.Id,
            //                                       StartTime = bookedAppointment.StartTime,
            //                                       EndTime = bookedAppointment.EndTime,
            //                                       AppointmentStatus = AppointmentStatus.Booked,
            //                                       CheckInTime = bookedAppointment.CheckInTime,
            //                                       CheckOutTime = bookedAppointment.CheckOutTime,
            //                                       RoomSlots = roomSlots
            //                                   });
            //}
            //model.AppointmentSlots = appointmentModels.OrderBy(m => m.StartTime);
            //return model;
        }

        public EventAppointSlotSummaryViewModel GetEventAppointmentSlotSummary(long eventId, bool isDynamicScheduling)
        {
            var model = new EventAppointSlotSummaryViewModel();
            var appointmentModels = new List<EventAppointmentBasicInfoModel>();

            model.IsDynamicScheduling = isDynamicScheduling;
            var eventPodRooms = isDynamicScheduling ? _eventPodRoomRepository.GetByEventId(eventId) : null;
            model.EventPodRooms = eventPodRooms;

            var appointments = _eventSchedulingSlotRepository.GetbyEventId(eventId);
            var notBookedAppointments = appointments.Where(ap => ap.Status != AppointmentStatus.Booked).Select(ap => ap).ToArray();
            if (!notBookedAppointments.IsNullOrEmpty())
            {
                var appointmentBasicInfoModels = _eventAppointmentBasicInfoModelFactory.Create(notBookedAppointments);
                appointmentModels.AddRange(appointmentBasicInfoModels);
            }

            var bookedAppointments = _appointmentRepository.GetAllAppointmentsForEvent(eventId);
            if (!bookedAppointments.IsNullOrEmpty())
            {
                appointmentModels.AddRange(from bookedAppointment in bookedAppointments
                                           let roomSlots = GetRoomSlots(appointments, bookedAppointment, eventPodRooms)
                                           select new EventAppointmentBasicInfoModel
                                           {
                                               AppointmentId = bookedAppointment.Id,
                                               StartTime = bookedAppointment.StartTime,
                                               EndTime = bookedAppointment.EndTime,
                                               AppointmentStatus = AppointmentStatus.Booked,
                                               CheckInTime = bookedAppointment.CheckInTime,
                                               CheckOutTime = bookedAppointment.CheckOutTime,
                                               RoomSlots = roomSlots
                                           });
            }
            model.AppointmentSlots = appointmentModels.OrderBy(m => m.StartTime);
            return model;
        }

        public IEnumerable<OrderedPair<string, DateTime>> GetRoomSlots(IEnumerable<EventSchedulingSlot> slots, Appointment bookedAppointment, IEnumerable<EventPodRoom> eventPodRooms)
        {
            if (bookedAppointment == null)
                return null;

            var bookedSlots = slots.Where(s => bookedAppointment.SlotIds.Contains(s.Id)).Select(s => s).OrderBy(s => s.StartTime).ToArray();
            var eventPodRoomIds = bookedSlots.Where(s => s.EventPodRoomId.HasValue).Select(s => s.EventPodRoomId.Value).Distinct().ToArray();
            var roomSlots = new List<OrderedPair<string, DateTime>>();
            if (!eventPodRoomIds.IsNullOrEmpty())
            {
                //foreach (var eventPodRoomId in eventPodRoomIds)
                //{
                //    var slot = bookedSlots.First(s => s.EventPodRoomId == eventPodRoomId);
                //    var eventPodRoom = eventPodRooms.Single(m => m.Id == eventPodRoomId);
                //    roomSlots.Add(new OrderedPair<string, DateTime>("Room " + eventPodRoom.RoomNo, slot.StartTime));
                //}

                var eventPodRoom = eventPodRooms.Single(m => m.Id == bookedSlots[0].EventPodRoomId);
                roomSlots.Add(new OrderedPair<string, DateTime>("Room " + eventPodRoom.RoomNo, bookedSlots[0].StartTime));

                for (int i = 0; i < bookedSlots.Length - 1; i++)
                {
                    if (((bookedSlots[i + 1].StartTime - bookedSlots[i].EndTime).TotalMinutes) > 0 || (bookedSlots[i + 1].EventPodRoomId != bookedSlots[i].EventPodRoomId))
                    {
                        eventPodRoom = eventPodRooms.Single(m => m.Id == bookedSlots[i + 1].EventPodRoomId);
                        roomSlots.Add(new OrderedPair<string, DateTime>("Room " + eventPodRoom.RoomNo, bookedSlots[i + 1].StartTime));
                    }
                }
            }
            return roomSlots;
        }

        public Appointment CreateAppointment(IEnumerable<long> slotIds, long orgRoleUserId)
        {
            using (var scope = new TransactionScope())
            {
                var slots = _eventSchedulingSlotRepository.GetbyIds(slotIds);

                if (slots.Any(s => s.Status != AppointmentStatus.TemporarilyBooked))
                {
                    throw new InvalidOperationException("Slots are not temporarily booked.");
                }

                var appointment = new Appointment
                    {
                        EventId = slots.First().EventId,
                        DateCreated = DateTime.Now,
                        SlotIds = slots.Select(s => s.Id),
                        StartTime = slots.First().StartTime,
                        EndTime = slots.Last().EndTime,
                        ScheduledById = orgRoleUserId
                    };

                appointment = _appointmentRepository.Save(appointment);

                foreach (var eventSchedulingSlot in slots)
                {
                    eventSchedulingSlot.Status = AppointmentStatus.Booked;
                    eventSchedulingSlot.DateModified = DateTime.Now;

                    _eventSchedulingSlotRepository.Save(eventSchedulingSlot);
                }

                scope.Complete();

                return appointment;
            }
        }

        public void DeleteAppointment(long appointmentId)
        {
            using (var scope = new TransactionScope())
            {
                var appointment = _appointmentRepository.GetById(appointmentId);
                var slots = _eventSchedulingSlotRepository.GetbyIds(appointment.SlotIds);

                _appointmentRepository.Delete(appointment);

                foreach (var eventSchedulingSlot in slots)
                {
                    eventSchedulingSlot.Status = AppointmentStatus.Free;
                    eventSchedulingSlot.DateModified = DateTime.Now;

                    _eventSchedulingSlotRepository.Save(eventSchedulingSlot);
                }

                scope.Complete();
            }
        }

        public Appointment AdjustAppointment(long eventCustomerId, int screeningTime, IEnumerable<long> temporaryBookedSlotIds, bool isNewAppointmentSelected = false)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            if (!eventCustomer.AppointmentId.HasValue)
                return null;

            var appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

            var theEvent = _eventRepository.GetById(eventCustomer.EventId);

            if (!theEvent.IsDynamicScheduling)
                return appointment;

            var bookedSlots = _eventSchedulingSlotRepository.GetbyIds(appointment.SlotIds);

            var getSlotsOnRoomBasis = ShouldGetSlotsOnRoomBasis(theEvent.Id);
            if (getSlotsOnRoomBasis)
            {
                var temporaryBookedSlots = _eventSchedulingSlotRepository.GetbyIds(temporaryBookedSlotIds);
                var slotIdsToBeReleased = appointment.SlotIds.Where(si => !temporaryBookedSlotIds.Contains(si));
                if (!slotIdsToBeReleased.IsNullOrEmpty())
                    _eventSchedulingSlotRepository.ReleaseBookedSlots(slotIdsToBeReleased);

                foreach (var eventSchedulingSlot in temporaryBookedSlots)
                {
                    eventSchedulingSlot.Status = AppointmentStatus.Booked;
                    eventSchedulingSlot.DateModified = DateTime.Now;

                    _eventSchedulingSlotRepository.Save(eventSchedulingSlot);
                }

                appointment.StartTime = temporaryBookedSlots.First().StartTime;
                appointment.EndTime = temporaryBookedSlots.Last().EndTime;
                appointment.SlotIds = temporaryBookedSlots.Select(s => s.Id);
                appointment.DateModified = DateTime.Now;

                appointment = _appointmentRepository.Save(appointment);
                return appointment;
            }

            if (screeningTime > _maxScreeningTime)
                screeningTime = _maxScreeningTime;
            else if (screeningTime < _minScreeningTime)
                screeningTime = _minScreeningTime;

            //var length = (bookedSlots.Last().EndTime - bookedSlots.First().StartTime).TotalMinutes;
            var length = bookedSlots.Sum(s => (s.EndTime - s.StartTime).TotalMinutes);

            if (length > screeningTime)
            {
                //var requiredEndTime = bookedSlots.First().StartTime.AddMinutes(screeningTime);

                //var slot = bookedSlots.FirstOrDefault(s => s.StartTime >= requiredEndTime);

                //if (slot != null)
                //    bookedSlots = bookedSlots.TakeWhile(s => s != slot);

                var tempSlots = new List<EventSchedulingSlot>();
                long duration = 0;
                foreach (var eventSchedulingSlot in bookedSlots)
                {
                    duration = duration + (long)(eventSchedulingSlot.EndTime - eventSchedulingSlot.StartTime).TotalMinutes;
                    tempSlots.Add(eventSchedulingSlot);
                    if (duration >= screeningTime)
                        break;
                }
                bookedSlots = tempSlots;

                var slotIdsToBeReleased = appointment.SlotIds.Where(si => !bookedSlots.Select(s => s.Id).Contains(si));
                if (!slotIdsToBeReleased.IsNullOrEmpty())
                    _eventSchedulingSlotRepository.ReleaseBookedSlots(slotIdsToBeReleased);

                appointment.StartTime = bookedSlots.First().StartTime;
                appointment.EndTime = bookedSlots.Last().EndTime;
                appointment.SlotIds = bookedSlots.Select(s => s.Id);
                appointment.DateModified = DateTime.Now;

                appointment = _appointmentRepository.Save(appointment);

            }
            else if (length < screeningTime)
            {
                var temporaryBookedSlots = _eventSchedulingSlotRepository.GetbyIds(temporaryBookedSlotIds);

                foreach (var eventSchedulingSlot in temporaryBookedSlots)
                {
                    eventSchedulingSlot.Status = AppointmentStatus.Booked;
                    eventSchedulingSlot.DateModified = DateTime.Now;

                    _eventSchedulingSlotRepository.Save(eventSchedulingSlot);
                }

                var slotIdsToBeReleased = appointment.SlotIds.Where(si => !temporaryBookedSlotIds.Contains(si));

                if (isNewAppointmentSelected)
                {
                    if (!slotIdsToBeReleased.IsNullOrEmpty())
                        _eventSchedulingSlotRepository.ReleaseBookedSlots(slotIdsToBeReleased);

                    appointment.StartTime = temporaryBookedSlots.First().StartTime;
                    appointment.EndTime = temporaryBookedSlots.Last().EndTime;
                    appointment.SlotIds = temporaryBookedSlots.Select(s => s.Id);
                    appointment.DateModified = DateTime.Now;
                }
                else
                {
                    bookedSlots = bookedSlots.Concat(temporaryBookedSlots).OrderBy(s => s.StartTime).Distinct();

                    appointment.StartTime = bookedSlots.First().StartTime;
                    appointment.EndTime = bookedSlots.Last().EndTime;
                    appointment.SlotIds = bookedSlots.Select(s => s.Id).Distinct();
                    appointment.DateModified = DateTime.Now;

                }
                appointment = _appointmentRepository.Save(appointment);
            }

            return appointment;
        }

        public void SaveChangeAppointmentLog(long eventCustomerId, long oldEventId, long oldAppointmentId, long newEventId, long newAppointmentId, long createdByOrgRoleUserId, long reasonId, string notes, long? subReasonId)
        {
            DateTime? oldAppointmentTime = null;

            if (oldAppointmentId > 0)
            {
                var oldAppointment = _appointmentRepository.GetById(oldAppointmentId);
                oldAppointmentTime = oldAppointment.StartTime;
            }

            var newAppointment = _appointmentRepository.GetById(newAppointmentId);

            var eventAppointmentChangeLog = new EventAppointmentChangeLog
            {
                EventCustomerId = eventCustomerId,
                OldEventId = oldEventId,
                OldAppointmentTime = oldAppointmentTime,
                NewEventId = newEventId,
                NewAppointmentTime = newAppointment.StartTime,
                DateCreated = DateTime.Now,
                CreatedByOrgRoleUserId = createdByOrgRoleUserId,
                ReasonId = reasonId,
                Notes = notes,
                SubReasonId = subReasonId
            };


            _eventAppointmentChangeLogRepository.Save(eventAppointmentChangeLog);
        }

        private bool ShouldGetSlotsOnRoomBasis(long eventId)
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

    }
}
