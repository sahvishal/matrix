using System;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;
using Falcon.DataAccess.Master;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    public class EventController : Controller
    {
        private readonly ICdContentGeneratorTrackingRepository _cdContentGeneratorTrackingRepository;
        private readonly int _pageSize;
        private readonly IEventService _eventService;
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventEndofDayService _eventEndofDayService;
        private readonly ISessionContext _sessionContext;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly ISettings _settings;

        public EventController(IEventService eventService, IEventCustomerReportingService eventCustomerReportingService, ISettings settings, IEventCustomerResultRepository eventCustomerResultRepository,
            IEventEndofDayService eventEndofDayService, IEventRepository eventRepository, ISessionContext sessionContext, IUserLoginRepository userLoginRepository, ICdContentGeneratorTrackingRepository cdContentGeneratorTrackingRepository,
            IPdfGenerator pdfGenerator)
        {
            _settings = settings;
            _eventService = eventService;
            _eventCustomerReportingService = eventCustomerReportingService;
            _pageSize = settings.DefaultPageSizeForReports;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _eventRepository = eventRepository;
            _eventEndofDayService = eventEndofDayService;
            _sessionContext = sessionContext;
            _userLoginRepository = userLoginRepository;
            _cdContentGeneratorTrackingRepository = cdContentGeneratorTrackingRepository;
            _pdfGenerator = pdfGenerator;
            _pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
        }

        public ActionResult EventNotes(long eventId)
        {
            var eventNotes = _eventService.GetAllEventNotes(eventId);
            return View(eventNotes);
        }

        public EventBasicInfoListModel GetModel(EventBasicInfoViewModelFilter filter, int pageNumber)
        {
            int totalRecords = 0;

            if (_sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterRep))
            {
                filter.AgentOrganizationId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            }

            var listModel = _eventService.GetEventBasicInfo(filter, pageNumber, _pageSize, out totalRecords) ??
                            new EventBasicInfoListModel();



            listModel.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new { pageNumber = pn, filter.DateFrom, filter.DateTo, filter.City, filter.EventId, filter.Name, filter.Pod, filter.Radius, filter.State, filter.ZipCode, filter.AccountId });
            listModel.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return listModel;
        }

        public ActionResult Index(bool showUpcoming = false, EventBasicInfoViewModelFilter filter = null, int pageNumber = 1)
        {
            if (filter == null)
                filter = new EventBasicInfoViewModelFilter();
            //if (_sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.NursePractitioner))
            //{
            //    filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            //}

            if (showUpcoming)
            {
                filter.DateFrom = DateTime.Now.Date;
                filter.DateTo = null;
            }
            return View(GetModel(filter, pageNumber));
        }

        public ActionResult GenerateRoster(long eventId)
        {
            var mediaLocation = IoC.Resolve<IMediaRepository>().GetTempMediaFileLocation();

            string newpdfpath = _settings.AppUrl + "/App/Franchisee/Technician/PrintRosterNew.aspx?EventId=" + eventId;

            var fileName = Guid.NewGuid() + ".pdf";

            _pdfGenerator.GeneratePdf(newpdfpath, mediaLocation.PhysicalPath + fileName);
            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;

        }

        public ActionResult GenerateSchedule(long eventId)
        {
            var mediaLocation = IoC.Resolve<IMediaRepository>().GetTempMediaFileLocation();

            string newpdfpath = _settings.AppUrl + "/App/Franchisee/Technician/PrintRosterNew.aspx?Type=Schedule&EventId=" + eventId;

            var fileName = Guid.NewGuid() + ".pdf";
            _pdfGenerator.GeneratePdf(newpdfpath, mediaLocation.PhysicalPath + fileName);
            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;

        }

        public ActionResult GenerateScheduleWithBarCode(long eventId, Boolean barCodeVersion)
        {
            var mediaLocation = IoC.Resolve<IMediaRepository>().GetTempMediaFileLocation();

            string newpdfpath = _settings.AppUrl + "/App/Franchisee/Technician/PrintRosterNew.aspx?Type=Schedule&EventId=" + eventId + "&barCodeVersion=True";

            var fileName = Guid.NewGuid() + ".pdf";
            _pdfGenerator.GeneratePdf(newpdfpath, mediaLocation.PhysicalPath + fileName);
            Response.RedirectUser(mediaLocation.Url + fileName);
            return null;
        }

        public ContentResult Delete(long eventId)
        {
            var masterDal = new MasterDAL();
            short returnresult = masterDal.RemoveEvent(eventId); // Need to replace with Repository method
            return Content(returnresult.ToString());
        }

        public ActionResult CustomerList(long id)
        {
            return View(_eventCustomerReportingService.GetCustomerScheduleModel(id));
        }

        [HttpPost]
        public ActionResult RegeneratePacket(long eventId)
        {
            _eventCustomerResultRepository.SetRecordforRegeneratingResultPacket(eventId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return Content("");
        }

        [HttpPost]
        public ActionResult GenerateHealthAssesmentForm(long eventId)
        {
            _eventRepository.SetCommandforGenrateHealthAssesmentForm(eventId);
            return Content("");
        }

        public ActionResult EndofDay(long id)
        {
            return View(_eventEndofDayService.GetforEvent(id));
        }

        [HttpPost]
        public ActionResult SignOff(string password, long eventId)
        {
            var isValidUser = _userLoginRepository.ValidateUser(_sessionContext.UserSession.UserName, password);

            if (isValidUser)
            {
                _eventRepository.SaveEventSignoffData(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, eventId);

                return Json(new { Result = true, Message = "Event Signoff was successful!" });
            }
            else
            {
                return Json(new { Result = false, Message = "Invalid Password!" });
            }
        }

        public ActionResult IsResultPacketDownloadable(long eventId)
        {
            var ids = _eventCustomerResultRepository.GetClinicalFormGeneratedEventIds(new[] { eventId });
            if (ids.Count() < 1)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            ids = _cdContentGeneratorTrackingRepository.GetCdContentGeneratedEventIds(ids);
            if (ids.Count() < 1)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCdContentStatus(long id)
        {
            var model = id > 0 ? _eventService.GetEventCdContentStatus(id) : null;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePackageTrackingNumbers(long eventId, string bloodPackageTrackingNumber, string recordsPackageTrackingNumber)
        {
            try
            {
                _eventRepository.UpdatePackageTrackingNumbers(eventId, bloodPackageTrackingNumber, recordsPackageTrackingNumber);
                return Json(new { Result = true, Message = "Updated" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }

        public ActionResult HealthPlanEvents(bool showUpcoming = false, EventBasicInfoViewModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            if (filter == null) filter = new EventBasicInfoViewModelFilter();
            filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            if (showUpcoming)
            {
                filter.DateFrom = DateTime.Now.Date;
                filter.DateTo = null;
            }

            var listModel = _eventService.GetHealthPlanEvents(pageNumber, _pageSize, filter, out totalRecords) ?? new HealthPlanEventListModel();

            listModel.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new { pageNumber = pn, filter.DateFrom, filter.DateTo, filter.City, filter.EventId, filter.Name, filter.Pod, filter.Radius, filter.State, filter.ZipCode, filter.AccountId });
            listModel.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(listModel);
        }

        public ActionResult CorporateEventCustomerList(long eventId)
        {
            int totalRecords = 0;
            int pagenumber = 1;
            var filter = new CorporateEventCustomerModelFilter();
            filter.EventId = eventId;
            return View(_eventCustomerReportingService.GetCorporateEventCustomerViewModel(pagenumber, _pageSize, filter, out totalRecords));
        }

        [HttpGet]
        public ActionResult AddEventNotes(AddNotesModelFilter filter = null, int eventNoteId = 0)
        {
            if (filter != null && (filter.EventDateFrom.HasValue || filter.EventDateTo.HasValue || filter.HealthPlanId > 0 || filter.Id > 0 || filter.PodId > 0))
            {
                if (filter.EventDateFrom.HasValue && filter.EventDateFrom < DateTime.Today.AddDays(1))
                {
                    return View(new AddNotesListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("From date must be future date.") });
                }

                var listModel = _eventService.GetEventForAddNotes(filter, eventNoteId) ?? new AddNotesListModel();

                listModel.Filter = listModel.Filter ?? filter;

                return View(listModel);
            }

            filter = new AddNotesModelFilter();

            return View(new AddNotesListModel { Filter = filter });
        }

        [HttpPost]
        public ActionResult AddEventNotes(AddNotesListModel model)
        {
            try
            {
                model = _eventService.SaveEventNotes(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                model.Filter = new AddNotesModelFilter { EventDateFrom = DateTime.Today.AddDays(1) };

                model.IsSavedSuccessfully = true;

                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Note saved successfully for selected events.");

                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Error: " + ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult ManageEventNotes(EventNotesModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;

            filter = filter ?? new EventNotesModelFilter();

            var listModel = _eventService.GetEventNotes(pageNumber, _pageSize, filter, out totalRecords) ?? new EventNotesListModel();

            listModel.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.FromDate, filter.ToDate, filter.HealthPlanId, filter.PodId });
            listModel.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(listModel);
        }

        [HttpGet]
        public ActionResult GetActiveEvents(EventsDateRangeType duration)
        {
            var events = _eventService.GetActiveEvents(duration);
            if (events != null)
                return Json(events.Collection, JsonRequestBehavior.AllowGet);
            return null;
        }
    }
}
