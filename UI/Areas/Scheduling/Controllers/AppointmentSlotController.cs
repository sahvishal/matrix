using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.MobileControls;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    public class AppointmentSlotController : Controller
    {
        private readonly IEventSchedulingSlotService _eventSchedulingSlotService;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventAppointmentService _eventAppointmentService;
        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ISessionContext _sessionContext;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventPodRoomRepository _eventPodRoomRepository;
        private readonly IEventTestRepository _eventTestRepository;

        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IOrderRepository _orderRepository;

        public AppointmentSlotController(IAppointmentRepository appointmentRepository, IEventAppointmentService eventAppointmentService, ISessionContext sessionContext, IEventSchedulingSlotRepository eventSchedulingSlotRepository,
            IEventRepository eventRepository, IEventSchedulingSlotService eventSchedulingSlotService, IEventCustomerRepository eventCustomerRepository, IEventPodRoomRepository eventPodRoomRepository,
            IEventTestRepository eventTestRepository, IEventPackageRepository eventPackageRepository, IOrderRepository orderRepository)
        {
            _appointmentRepository = appointmentRepository;
            _eventSchedulingSlotService = eventSchedulingSlotService;
            _eventAppointmentService = eventAppointmentService;
            _sessionContext = sessionContext;
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
            _eventRepository = eventRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventPodRoomRepository = eventPodRoomRepository;
            _eventTestRepository = eventTestRepository;

            _eventPackageRepository = eventPackageRepository;
            _orderRepository = orderRepository;

            if (sessionContext == null || sessionContext.UserSession == null)
            {
                _eventSchedulingSlotService.LoggedinUserRole = Roles.Customer;
                _eventSchedulingSlotService.LoggedinUserParentRole = Roles.Customer;
            }
            else
            {
                _eventSchedulingSlotService.LoggedinUserRole = (Roles)sessionContext.UserSession.CurrentOrganizationRole.RoleId;
                _eventSchedulingSlotService.LoggedinUserParentRole = (Roles)sessionContext.UserSession.CurrentOrganizationRole.ParentRoleId;
            }
        }

        public ActionResult EventAppointmentSlotSummary(long id)
        {
            var model = _eventAppointmentService.GetEventAppointmentSlotSummary(id);
            return View(model);
        }

        public ActionResult ViewAppointment(long eventId)
        {
            var appointments = _eventAppointmentService.GetAppointmentSlotsByEventId(eventId);
            return View(appointments);
        }

        public bool DeleteAppointment(long appointmentId)
        {
            var appointmentSlot = _eventSchedulingSlotRepository.GetbyId(appointmentId);
            if (appointmentSlot.Status == AppointmentStatus.TemporarilyBooked)
                return false;

            return _eventSchedulingSlotRepository.Delete(appointmentSlot);
        }

        [HttpPost]
        public ActionResult BlockAppointmentSlot(long appointmentId, string blockText)
        {
            var appointmentSlot = _eventSchedulingSlotRepository.GetbyId(appointmentId);

            if (appointmentSlot.Status != AppointmentStatus.Free && appointmentSlot.Status != AppointmentStatus.Blocked)
                return Json(new { Message = "Slot cannot be blocked!", IsBlocked = false });

            appointmentSlot.Reason = blockText;
            appointmentSlot.Status = AppointmentStatus.Blocked;
            appointmentSlot.DateModified = DateTime.Now;

            _eventSchedulingSlotRepository.Save(appointmentSlot);

            return Json(new { Message = "Slot blocked succesfully!", IsBlocked = true });
        }

        public ActionResult AddAppointmentSlot(long eventId, bool viewSlotList = true, string message = "")
        {
            var model = new EventAppointmentEditModel { EventId = eventId, ViewSlotList = viewSlotList };
            var theEvent = _eventRepository.GetById(eventId);
            var eventPodRooms = _eventPodRoomRepository.GetByEventId(eventId);

            model.EventDate = theEvent.EventDate.Date;
            model.EventPodRoomIds = eventPodRooms != null && eventPodRooms.Any() ? eventPodRooms.Select(m => m.Id).ToArray() : null;

            if (!string.IsNullOrEmpty(message))
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(message);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAppointmentSlot(EventAppointmentEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appointmentSlot = Mapper.Map<EventAppointmentEditModel, EventSchedulingSlot>(model);
                    _eventSchedulingSlotRepository.Save(appointmentSlot);

                    return RedirectToAction("AddAppointmentSlot", new { eventId = model.EventId, viewSlotList = model.ViewSlotList, message = "Appointment Slot created succesfully" });

                }
                return View(model);
            }
            catch (Exception exception)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Select(long eventId, int screeningTime, IEnumerable<long> selectedSlotIds, long packageId, IEnumerable<long> testIds, IEnumerable<long> bookedSlotIds = null)
        {
            if (testIds != null && testIds.Any() && screeningTime > 0)
            {
                var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, testIds);
                //testIds = eventTests.Where(et => et.Test.ScreeningTime > 0).Select(et => et.TestId).ToArray();
                testIds = eventTests.Select(et => et.TestId).ToArray();
            }

            screeningTime = _eventSchedulingSlotService.GetScreeningTime(testIds, eventId, packageId);

            var model = _eventSchedulingSlotService.GetAppointmentSelectionModel(eventId, screeningTime, selectedSlotIds, packageId, testIds, bookedSlotIds);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AvailableSlots(long eventId, DateTime fromTime, DateTime toTime, int screeningTime, int numberOfSlotstoShow, long packageId, IEnumerable<long> testIds, IEnumerable<long> bookedSlotIds = null)
        {
            if (testIds != null && testIds.Any() && screeningTime > 0)
            {
                var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, testIds);
                //testIds = eventTests.Where(et => et.Test.ScreeningTime > 0).Select(et => et.TestId).ToArray();

                testIds = eventTests.Select(et => et.TestId).ToArray();
            }

            IEnumerable<EventSchedulingSlot> bookedSlots = null;
            if (!bookedSlotIds.IsNullOrEmpty())
                bookedSlots = _eventSchedulingSlotRepository.GetbyIds(bookedSlotIds);

            screeningTime = _eventSchedulingSlotService.GetScreeningTime(testIds, eventId, packageId);

            var model = _eventSchedulingSlotService.GetSlots(eventId, fromTime, toTime, screeningTime, numberOfSlotstoShow, packageId, testIds, bookedSlots);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult BookSlotTemporarily(long selectedSlotId, long screeningTime, long packageId, IEnumerable<long> testIds, IEnumerable<long> bookedSlotIds = null, bool isChangePackageRequest = false)
        {
            //if (testIds != null && testIds.Any() && screeningTime > 0)
            //{
            //    //var slot = _eventSchedulingSlotRepository.GetbyId(selectedSlotId);
            //    //var eventTests = _eventTestRepository.GetByEventAndTestIds(slot.EventId, testIds);
            //    //testIds = eventTests.Where(et => et.Test.ScreeningTime > 0).Select(et => et.TestId).ToArray();
            //}

            IEnumerable<EventSchedulingSlot> bookedSlots = null;
            if (!bookedSlotIds.IsNullOrEmpty())
                bookedSlots = _eventSchedulingSlotRepository.GetbyIds(bookedSlotIds);
            var result = _eventSchedulingSlotService.BookSlotTemporarily(selectedSlotId, screeningTime, packageId, testIds, bookedSlots, isChangePackageRequest);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ReleaseAppointment(IEnumerable<long> selectedSlotIds)
        {
            _eventSchedulingSlotRepository.ReleaseSlots(selectedSlotIds);
            return Content("");
        }

        [HttpPost]
        public ActionResult AdjustAppointment(long eventId, long eventCustomerId, int screeningTime, IEnumerable<long> selectedSlotIds, long packageId, IEnumerable<long> testIds)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);

            Appointment appointment = null;
            if (eventCustomer.AppointmentId.HasValue)
                appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

            IEnumerable<EventSchedulingSlot> slots = null;

            if (appointment == null)
            {
                return Json(new { IsAdjusted = false, IsSlotsAvailable = false, Slots = slots, Message = "Order has been cancelled." }, JsonRequestBehavior.AllowGet);
            }

            if (testIds != null && testIds.Any() && screeningTime > 0)
            {
                var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, testIds);
                testIds = eventTests.Select(et => et.TestId).ToArray();
            }

            var alreadyBookedSlotIds = appointment.SlotIds;

            if (!selectedSlotIds.IsNullOrEmpty())
                alreadyBookedSlotIds = alreadyBookedSlotIds.Concat(selectedSlotIds);

            var theEvent = _eventRepository.GetById(eventId);

            slots = _eventSchedulingSlotService.AdjustAppointmentSlot(eventId, screeningTime, alreadyBookedSlotIds, packageId, testIds, theEvent.LunchStartTime, theEvent.LunchDuration);

            if (slots.IsNullOrEmpty())
            {
                var bookedSlots = _eventSchedulingSlotRepository.GetbyIds(appointment.SlotIds);
                var timeFrames = _eventSchedulingSlotService.GetAvailableTimeFrames(eventId, screeningTime, null, packageId, testIds, bookedSlots);
                if (timeFrames.IsNullOrEmpty())
                {
                    return Json(new { IsAdjusted = false, IsSlotsAvailable = false, Slots = slots, Message = "No Slots Available." }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { IsAdjusted = false, IsSlotsAvailable = true, Slots = slots, Message = "Please select another appointment." }, JsonRequestBehavior.AllowGet);
            }

            //slots = slots.Where(s => !appointment.SlotIds.Contains(s.Id)).ToArray();

            return Json(new { IsAdjusted = true, IsSlotsAvailable = true, Slots = slots, Message = "Appointment Adjusted" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAll(long eventId)
        {
            var appointments = _eventAppointmentService.GetAppointmentSlotsByEventId(eventId);
            return View(appointments);
        }

        [HttpPost]
        public JsonResult CheckPackageAndTestHafTemplate(long eventId, long customerId, long packageId, IEnumerable<long> testIds)
        {
            string message = string.Empty;
            var currentOrder = _orderRepository.GetOrder(customerId, eventId);

            var packageOrderItem = currentOrder.OrderDetails.FirstOrDefault(od => od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted);
            var testOrderItems = currentOrder.OrderDetails.Where(od => od.DetailType == OrderItemType.EventTestItem && od.IsCompleted);

            var currentEventPackageId = (packageOrderItem != null) ? packageOrderItem.OrderItem.ItemId : 0;

            long currentPackageId = 0;
            EventPackage currentEventPackage = null;
            EventPackage eventPackage = null;

            if (currentEventPackageId > 0)
            {
                currentEventPackage = _eventPackageRepository.GetById(currentEventPackageId);
                currentPackageId = currentEventPackage.PackageId;
            }

            eventPackage = packageId > 0 ? _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId) : currentEventPackage;

            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);

            var testPackageName = new List<string>();

            if (packageId != currentPackageId)
            {
                if (eventPackage != null && eventPackage.HealthAssessmentTemplateId.HasValue)
                {
                    testPackageName.Add(eventPackage.Package.Name);
                }
            }
            var currentTestIds = new List<long>();

            if (currentEventPackage != null)
            {
                currentTestIds.AddRange(currentEventPackage.Tests.Select(x => x.TestId));
            }

            if (!testOrderItems.IsNullOrEmpty())
            {
                var orderIds = testOrderItems.Select(x => x.OrderItem.ItemId);
                var customerTests = eventTests.Where(x => orderIds.Contains(x.Id));
                currentTestIds.AddRange(customerTests.Select(x => x.TestId));
            }

            var missingTest = currentTestIds.Where(x => !testIds.Contains(x));
            if (!missingTest.IsNullOrEmpty())
            {
                var testNames = eventTests.Where(m => missingTest.Contains(m.TestId) && m.HealthAssessmentTemplateId.HasValue).Select(m => m.Test.Name);
                if (!testNames.IsNullOrEmpty())
                {
                    testPackageName.AddRange(testNames);
                }
            }

            var newTestIds = testIds.Where(x => !currentTestIds.Contains(x));
            if (!newTestIds.IsNullOrEmpty())
            {
                var testNames = eventTests.Where(m => newTestIds.Contains(m.TestId) && m.HealthAssessmentTemplateId.HasValue)
                    .Select(m => m.Test.Name);
                if (!testNames.IsNullOrEmpty())
                {
                    testPackageName.AddRange(testNames);
                }
            }

            return Json(testPackageName, JsonRequestBehavior.AllowGet);
        }
    }
}
