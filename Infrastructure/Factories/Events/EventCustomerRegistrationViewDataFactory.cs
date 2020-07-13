using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Factories.Events
{
    [DefaultImplementation]
    public class EventCustomerRegistrationViewDataFactory : IEventCustomerRegistrationViewDataFactory
    {
        private readonly IEventCustomerViewDataFactory _eventCustomerViewDataFactory;
        private readonly IEventPodRoomRepository _eventPodRoomRepository;
        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public EventCustomerRegistrationViewDataFactory()
            : this(new EventCustomerViewDataFactory(), new EventPodRoomRepository(), new EventSchedulingSlotRepository(), new AppointmentRepository())
        { }

        public EventCustomerRegistrationViewDataFactory(IEventCustomerViewDataFactory eventCustomerViewDataFactory, IEventPodRoomRepository eventPodRoomRepository, IEventSchedulingSlotRepository eventSchedulingSlotRepository,
            IAppointmentRepository appointmentRepository)
        {
            _eventCustomerViewDataFactory = eventCustomerViewDataFactory;
            _eventPodRoomRepository = eventPodRoomRepository;
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
            _appointmentRepository = appointmentRepository;
        }

        public List<EventCustomerRegistrationViewData> Create(IEnumerable<CustomerOrderBasicInfoRow> customerOrderBasicInfoTypedView, IEnumerable<AssignedPhysicianViewModel> assignedPhysicians)
        {
            var eventCustomerRegistrationViewData = new List<EventCustomerRegistrationViewData>();

            if (customerOrderBasicInfoTypedView.IsNullOrEmpty())
                return eventCustomerRegistrationViewData;

            var eventId = customerOrderBasicInfoTypedView.First().EventId;
            var slots = _eventSchedulingSlotRepository.GetbyEventId(eventId);
            var eventPodRooms = _eventPodRoomRepository.GetByEventId(eventId);

            foreach (var orderBasicInfoTypedView in customerOrderBasicInfoTypedView)
            {
                var eventCustomerRegistrationViewDatum = new EventCustomerRegistrationViewData();

                _eventCustomerViewDataFactory.Create(eventCustomerRegistrationViewDatum, orderBasicInfoTypedView);
                if (assignedPhysicians != null)
                {
                    var assignedPhysician = assignedPhysicians.Where(ap => ap.CustomerId == eventCustomerRegistrationViewDatum.CustomerId).SingleOrDefault();
                    eventCustomerRegistrationViewDatum.AssignedPhysicians = assignedPhysician;
                }

                eventCustomerRegistrationViewDatum.CashPayment = orderBasicInfoTypedView.Cash;
                eventCustomerRegistrationViewDatum.CheckPayment = orderBasicInfoTypedView.Check;
                eventCustomerRegistrationViewDatum.ChargeCardPayment = orderBasicInfoTypedView.CreditCard;
                eventCustomerRegistrationViewDatum.ECheckPayment = orderBasicInfoTypedView.Echeck;
                eventCustomerRegistrationViewDatum.GiftCertificatePayment = orderBasicInfoTypedView.Gc;
                eventCustomerRegistrationViewDatum.InsurancePayment = orderBasicInfoTypedView.InsurancePayment;
                eventCustomerRegistrationViewDatum.FirstName = orderBasicInfoTypedView.FirstName;
                eventCustomerRegistrationViewDatum.LastName = orderBasicInfoTypedView.LastName;
                eventCustomerRegistrationViewDatum.MiddleName = orderBasicInfoTypedView.MiddleName;
                eventCustomerRegistrationViewDatum.EventCount = orderBasicInfoTypedView.EventCount;
                eventCustomerRegistrationViewDatum.ScheduleById = orderBasicInfoTypedView.ScheduledByOrgRoleUserId;
                eventCustomerRegistrationViewDatum.AppointmentBlockReason = orderBasicInfoTypedView.AppointBlockReason;
                eventCustomerRegistrationViewDatum.UserCreatedOn = orderBasicInfoTypedView.UserCreatedOn;
                eventCustomerRegistrationViewDatum.CustomerHealthInfo = Convert.ToBoolean(orderBasicInfoTypedView.CustomerHealthInfo);
                eventCustomerRegistrationViewDatum.PhoneNumber = orderBasicInfoTypedView.Phone;
                eventCustomerRegistrationViewDatum.Email1 = orderBasicInfoTypedView.Email1;
                eventCustomerRegistrationViewDatum.AppointmentSlotStatus = AppointmentSlotStatus.Booked;
                var appointment = _appointmentRepository.GetById(orderBasicInfoTypedView.AppointmentId);
                eventCustomerRegistrationViewDatum.RoomSlots = GetRoomSlots(slots, appointment, eventPodRooms);

                eventCustomerRegistrationViewData.Add(eventCustomerRegistrationViewDatum);
            }
            return eventCustomerRegistrationViewData;
        }

        public List<EventCustomerRegistrationViewData> Create(IEnumerable<EventSchedulingSlot> appointments, AppointmentSlotStatus appointmentSlotStatus)
        {
            return appointments.Select(
                a =>
                new EventCustomerRegistrationViewData
                    {
                        AppointmentId = a.Id,
                        AppointmentStartTime = a.StartTime,
                        AppointmentEndTime = a.EndTime,
                        AppointmentSlotStatus = appointmentSlotStatus
                    }).ToList();
        }

        //TODO: This code is repeated exist in Eventappointment serive. because can not resolve event appointment service
        private IEnumerable<OrderedPair<string, DateTime>> GetRoomSlots(IEnumerable<EventSchedulingSlot> slots, Appointment bookedAppointment, IEnumerable<EventPodRoom> eventPodRooms)
        {
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
    }
}