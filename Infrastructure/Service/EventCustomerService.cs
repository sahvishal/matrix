using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.Entity.Other;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class EventCustomerService : IEventCustomerService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventCustomerAggregateFactory _eventCustomerAggregateFactory;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventCustomerRegistrationViewDataFactory _eventCustomerRegistrationViewDataFactory;
        private readonly IEventCustomerRegistrationViewDataRepository _eventCustomerRegistrationViewDataRepository;
        private readonly IPaymentController _paymentController;
        private readonly IEventSchedulingSlotService _slotService;

        public EventCustomerService(IEventCustomerRepository eventCustomerRepository, IEventCustomerAggregateFactory eventCustomerAggregateFactory, IEventCustomerRegistrationViewDataRepository eventCustomerRegistrationViewDataRepository,
            IAppointmentRepository appointmentRepository, IEventCustomerRegistrationViewDataFactory eventCustomerRegistrationViewDataFactory, IPaymentController paymentController, IEventSchedulingSlotService slotService)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _eventCustomerAggregateFactory = eventCustomerAggregateFactory;
            _eventCustomerRegistrationViewDataFactory = eventCustomerRegistrationViewDataFactory;
            _eventCustomerRegistrationViewDataRepository = eventCustomerRegistrationViewDataRepository;
            _paymentController = paymentController;
            _slotService = slotService;
        }

        public EventCustomerAggregate GetEventCustomerAggregate(long eventCustomerId)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            return _eventCustomerAggregateFactory.CreateEventCustomerAggregate(eventCustomer);
        }

        public IEnumerable<EventCustomerAggregate> GetEventCustomerAggregates(IEnumerable<long> eventCustomerIds)
        {
            var eventCustomerAggregates = new List<EventCustomerAggregate>();
            foreach (var eventCustomerId in eventCustomerIds)
            {
                eventCustomerAggregates.Add(GetEventCustomerAggregate(eventCustomerId));
            }
            return eventCustomerAggregates;
        }

        public List<EventCustomerRegistrationViewData> GetEventCustomerRegistrationViewData(long eventId, EventCustomerFilterMode eventCustomerFilterMode)
        {
            switch (eventCustomerFilterMode)
            {
                case EventCustomerFilterMode.Actual:
                case EventCustomerFilterMode.Cash:
                case EventCustomerFilterMode.Check:
                case EventCustomerFilterMode.ECheck:
                case EventCustomerFilterMode.CreditCard:
                case EventCustomerFilterMode.NoShow:
                case EventCustomerFilterMode.Paid:
                case EventCustomerFilterMode.Registered:
                case EventCustomerFilterMode.UnPaid:
                case EventCustomerFilterMode.UnPaidNoShowExcluded:
                case EventCustomerFilterMode.LeftWithoutScreening:
                    return _eventCustomerRegistrationViewDataRepository.GetEventCustomerOrdersForEvent(eventCustomerFilterMode, eventId);
                case EventCustomerFilterMode.Filled:
                    return _eventCustomerRegistrationViewDataRepository.GetEventCustomerOrdersForEvent(eventId);
                case EventCustomerFilterMode.All:
                    {
                        var unBookedAppointments = _slotService.GetSlots(eventId, AppointmentStatus.Free);

                        var blockedAppointments = _slotService.GetSlots(eventId, AppointmentStatus.Blocked);

                        var unBookedEventCustomerRegistrationViewData = _eventCustomerRegistrationViewDataFactory.Create(unBookedAppointments, AppointmentSlotStatus.Open);
                        var blockedEventCustomerRegistrationViewData = _eventCustomerRegistrationViewDataFactory.Create(blockedAppointments, AppointmentSlotStatus.Blocked);
                        var bookedEventCustomerRegistrationViewData = _eventCustomerRegistrationViewDataRepository.GetEventCustomerOrdersForEvent(eventId);
                        bookedEventCustomerRegistrationViewData = bookedEventCustomerRegistrationViewData.Concat(unBookedEventCustomerRegistrationViewData).ToList();
                        bookedEventCustomerRegistrationViewData = bookedEventCustomerRegistrationViewData.Concat(blockedEventCustomerRegistrationViewData).ToList();
                        return bookedEventCustomerRegistrationViewData.OrderBy(ec => ec.AppointmentStartTime).ToList();
                    }
                case EventCustomerFilterMode.Open:
                    {
                        var unBookedAppointments = _slotService.GetSlots(eventId, AppointmentStatus.Free);
                        return _eventCustomerRegistrationViewDataFactory.Create(unBookedAppointments, AppointmentSlotStatus.Open);
                    }
                case EventCustomerFilterMode.Blocked:
                    {
                        var blockedAppointments = _slotService.GetSlots(eventId, AppointmentStatus.Blocked);
                        return _eventCustomerRegistrationViewDataFactory.Create(blockedAppointments, AppointmentSlotStatus.Blocked);
                    }
            }
            return null;
        }

        // Used by Win Service - Upload Result
        public bool IsCustomerRegisteredfortheGivenEvent(long customerId, long eventId)
        {
            try
            {
                var eventCustomer = new EventCustomerRepository().GetRegisteredEventForUser(customerId, eventId);

                if (eventCustomer != null)
                    return true;
            }
            catch (ObjectNotFoundInPersistenceException<EventCustomer>)
            {
                return false;
            }
            return true;
        }

        public void CancelAppointment(long eventId, long customerId, PaymentEditModel paymentEditModel, long dataRecorderOrgRoleUserId, bool chargeCancellation = true)
        {
            using (var scope = new TransactionScope())
            {
                //var eventCustomer = UpdateEventCustomerforCancelAppointment(eventId, customerId);
                //if (eventCustomer == null) return;

                var orderController = new OrderController();
                var order = orderController.CancelOrder(eventId, customerId, dataRecorderOrgRoleUserId,
                                                        chargeCancellation);
                if (order == null) return;

                long paymentId = _paymentController.SavePayment(paymentEditModel, dataRecorderOrgRoleUserId);
                if (paymentId > 0)
                {
                    var orderRepository = new OrderRepository();
                    orderRepository.ApplyPaymentToOrder(order.Id, paymentId);
                }
                scope.Complete();
            }
        }

        

    }
}