using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class OnlineAppointmentService : IOnlineAppointmentService
    {
        private readonly IEventPackageSelectorService _eventPackageSelectorService;
        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;
        private readonly EventPackageRepository _eventPackageRepository;
        private readonly IEventSchedulingSlotService _eventSchedulingSlotService;
        private readonly ITempcartService _tempcartService;
        private readonly IEventRepository _eventRepository;
        private readonly IEventAppointmentOnlineListModelFactory _eventAppointmentOnlineListModelFactory;
        private readonly IEventTestRepository _eventTestRepository;
        public OnlineAppointmentService(IEventPackageSelectorService eventPackageSelectorService, IEventSchedulingSlotRepository eventSchedulingSlotRepository, EventPackageRepository eventPackageRepository,
            IEventSchedulingSlotService eventSchedulingSlotService, ITempcartService tempcartService, IEventRepository eventRepository, IEventAppointmentOnlineListModelFactory eventAppointmentOnlineListModelFactory,
            IEventTestRepository eventTestRepository,IOnlineShippingService onlineShippingService)
        {
            _eventPackageSelectorService = eventPackageSelectorService;
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventSchedulingSlotService = eventSchedulingSlotService;
            _tempcartService = tempcartService;
            _eventRepository = eventRepository;
            _eventAppointmentOnlineListModelFactory = eventAppointmentOnlineListModelFactory;
            _eventTestRepository = eventTestRepository;
        }

        public EventAppointmentOnlineListModel SaveEventAppointmentSlotOnline(TempCart tempCart)
        {
            if (tempCart.EventPackageId == null || tempCart.AppointmentId == null)
                return GetEventAppointmentSlotOnline(tempCart);


            var selectedAppointmentId = tempCart.AppointmentId.Value;
            if (tempCart.InChainAppointmentSlotIds != null && tempCart.InChainAppointmentSlotIds.Any())
            {
                _eventSchedulingSlotRepository.ReleaseSlots(tempCart.InChainAppointmentSlotIds);
                tempCart.AppointmentId = null;
                tempCart.InChainAppointmentSlots = null;
                tempCart.PreliminarySelectedTime = null;
            }


            var eventTestIds = new List<long>();
            var testIds = new List<long>();

            if (!string.IsNullOrEmpty(tempCart.TestId))
            {
                tempCart.TestId.Split(',').ForEach(x => eventTestIds.Add(Convert.ToInt64(x)));
                var eventTests = _eventTestRepository.GetbyIds(eventTestIds).ToList();
                if (eventTests != null && !eventTests.IsNullOrEmpty())
                    eventTests.ForEach(et => testIds.Add(et.TestId));
            }

            var eventPackage = _eventPackageRepository.GetById(tempCart.EventPackageId.Value);


            var screeningTime = _eventPackageSelectorService.GetScreeningTime(tempCart.EventPackageId.Value, eventTestIds);
            var result = _eventSchedulingSlotService.BookSlotTemporarily(selectedAppointmentId, screeningTime, eventPackage.PackageId, testIds);

            if (result == null)
                throw new Exception("The slot selected by you is no longer available as it is booked for another customer. Please Choose another slot or select any other preferable hour.");

            var eventSchedulingSlots = result as EventSchedulingSlot[] ?? result.ToArray();
            var selectedSlotIds = eventSchedulingSlots.Select(x => x.Id).ToList();

            if (!selectedSlotIds.Any())
            {
                tempCart.AppointmentId = null;
                tempCart.InChainAppointmentSlots = string.Empty;
                tempCart.IsUsedAppointmentSlotExpiryExtension = null;
                return GetEventAppointmentSlotOnline(tempCart);
            }


            var slotFirst = eventSchedulingSlots.OrderBy(s => s.StartTime).First();
            tempCart.AppointmentId = slotFirst.Id;
            tempCart.PreliminarySelectedTime = slotFirst.StartTime;
            tempCart.InChainAppointmentSlots = string.Join(",", selectedSlotIds);
            tempCart.IsUsedAppointmentSlotExpiryExtension = null;
            _tempcartService.SaveTempCart(tempCart);

            return GetEventAppointmentSlotOnline(tempCart);
        }
        
        public EventAppointmentOnlineListModel GetEventAppointmentSlotOnline(TempCart tempCart)
        {
            if (tempCart.EventPackageId == null || tempCart.EventId == null)
                return null;

            var eventTestIds = new List<long>();
            var testIds = new List<long>();

            if (!string.IsNullOrEmpty(tempCart.TestId))
            {
                tempCart.TestId.Split(',').ForEach(x => eventTestIds.Add(Convert.ToInt64(x)));
                var eventTests = _eventTestRepository.GetbyIds(eventTestIds);
                if (!eventTests.IsNullOrEmpty())
                    eventTests.ForEach(et => testIds.Add(et.TestId));
            }

            var eventPackage = _eventPackageRepository.GetById(tempCart.EventPackageId.Value);
            var screeningTime = _eventPackageSelectorService.GetScreeningTime(tempCart.EventPackageId.Value, eventTestIds);
            var theEvent = _eventRepository.GetById(tempCart.EventId.Value);

            var fromTime = theEvent.EventDate.Date;
            var toTime = fromTime.AddDays(1);

            var allSlots = _eventSchedulingSlotRepository.GetbyEventId(tempCart.EventId.Value);

            IEnumerable<EventSchedulingSlot> temproraryBookedSlots = null;
            if (tempCart.InChainAppointmentSlotIds != null && tempCart.InChainAppointmentSlotIds.Any())
            {
                temproraryBookedSlots = allSlots.Where(x => tempCart.InChainAppointmentSlotIds.Contains(x.Id));
            }

            var availableSlots = _eventSchedulingSlotService.GetSlotsforaGivenTimeRange(tempCart.EventId.Value, fromTime, toTime, screeningTime, eventPackage.PackageId, testIds, temproraryBookedSlots);
            List<long> availableSlotIds = null;
            if (availableSlots != null && availableSlots.Any())
                availableSlotIds = availableSlots.Select(x => x.Id).ToList();

            if (tempCart.AppointmentId > 0)
            {
                allSlots = allSlots.Where(x => (availableSlotIds != null && availableSlotIds.Contains(x.Id))).ToArray();//|| tempCart.InChainAppointmentSlotIds.Contains(x.Id)

                var slotSelectedByUser = allSlots.Where(x => tempCart.InChainAppointmentSlotIds.Contains(x.Id));
                slotSelectedByUser.ForEach(x => x.Status = AppointmentStatus.Free);
            }
            else
            {
                allSlots = allSlots.Where(x => availableSlotIds != null && availableSlotIds.Contains(x.Id)).ToArray();
            }

            var model= _eventAppointmentOnlineListModelFactory.Create(allSlots);

           
            return model;
        }
    }
}