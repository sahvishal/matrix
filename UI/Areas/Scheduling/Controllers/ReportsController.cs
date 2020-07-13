using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    public class ReportsController : Controller
    {
        private readonly IEventReportingService _eventReportingService;
        private readonly IEventCustomerReportingService _eventCustomerReportingService;

        private readonly ISessionContext _sessionContext;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IAppointmentBookedReportingService _appointmentBookedReportingService;
        private readonly IPcpTrackingReportService _pcpTrackingReportService;
        private readonly int _pageSize;

        public ReportsController(IEventReportingService eventReportingService, IEventCustomerReportingService eventCustomerReportingService, ISettings settings, ISessionContext sessionContext, ICorporateAccountRepository corporateAccountRepository, IAppointmentBookedReportingService appointmentBookedReportingService, IPcpTrackingReportService pcpTrackingReportService)
        {
            _eventReportingService = eventReportingService;
            _eventCustomerReportingService = eventCustomerReportingService;
            _sessionContext = sessionContext;
            _corporateAccountRepository = corporateAccountRepository;
            _appointmentBookedReportingService = appointmentBookedReportingService;
            _pcpTrackingReportService = pcpTrackingReportService;
            _pageSize = settings.DefaultPageSizeForReports;
        }

        public ActionResult PublicEventVolume(bool showThisYear = false, EventVolumeListModelFilter filter = null, int pageNumber = 1)
        {
            if (showThisYear)
            {
                if (filter == null)
                    filter = new EventVolumeListModelFilter();
                filter.FromDate = Convert.ToDateTime("01/01/" + DateTime.Today.Year);
            }
            int totalRecords;
            var model = _eventReportingService.GetEventVolumeForPublicPatients(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new EventVolumeListModel();
            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                               {
                                   pageNumber = pn,
                                   filter.Territory,
                                   filter.Vehicle,
                                   filter.FromDate,
                                   filter.ToDate,
                                   filter.ZipCode,
                                   filter.IsPublicEvent,
                                   filter.IsPrivateEvent
                               });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CorporateEventVolume(bool showThisYear = false, EventVolumeListModelFilter filter = null, int pageNumber = 1)
        {
            if (showThisYear)
            {
                if (filter == null)
                    filter = new EventVolumeListModelFilter();
                filter.FromDate = Convert.ToDateTime("01/01/" + DateTime.Today.Year);
            }
            int totalRecords;
            var model = _eventReportingService.GetEventVolumeForCorporatePatients(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new EventVolumeListModel();
            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                               {
                                   pageNumber = pn,
                                   filter.Territory,
                                   filter.Vehicle,
                                   filter.FromDate,
                                   filter.ToDate,
                                   filter.ZipCode,
                                   filter.IsPublicEvent,
                                   filter.IsPrivateEvent
                               });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult ClientEventVolume(bool showThisYear = false, ClientEventVolumeListModelFilter filter = null, int pageNumber = 1)
        {
            if (showThisYear)
            {
                if (filter == null)
                    filter = new ClientEventVolumeListModelFilter();
                filter.FromDate = Convert.ToDateTime("01/01/" + DateTime.Today.Year);
            }
            int totalRecords;
            var model = _eventReportingService.GetEventVolumeForHealthPlanPatients(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new ClientEventVolumeListModel();
            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.Vehicle,
                               filter.FromDate,
                               filter.ToDate,
                               filter.Sponsers
                           });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CustomerSchedule(CustomerScheduleModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetCustomerScheduleModel(pageNumber, _pageSize, filter, out totalRecords) ??
                        new EventCustomerScheduleListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                               {
                                   pageNumber = pn,
                                   filter.Vehicle,
                                   filter.FromDate,
                                   filter.ToDate,
                                   filter.IsCorporateEvent,
                                   filter.IsRetailEvent,
                                   filter.IsPublicEvent,
                                   filter.IsPrivateEvent
                               });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult AppointmentsBooked(AppointmentsBookedListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetAppointmentsBooked(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new AppointmentsBookedListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = new RouteValueDictionary
            {
                {"IsRetailEvent", filter.IsRetailEvent},
                {"IsCorporateEvent", filter.IsCorporateEvent},
                {"IsHealthPlanEvent", filter.IsHealthPlanEvent},
                {"IsPublicEvent", filter.IsPublicEvent},
                {"IsPrivateEvent", filter.IsPrivateEvent},
                {"EventFrom",filter.EventFrom},
                {"EventTo", filter.EventTo},
                {"FromDate",filter.FromDate},
                {"ToDate",filter.ToDate},
                {"EventId",filter.EventId},
                {"CancelledCustomer",filter.CancelledCustomer},
                {"Tag",filter.Tag},
                {"EventStatus",filter.EventStatus},
                {"AccountId",filter.AccountId},
                 {"ProductTypeId",filter.ProductTypeId}
            };

            if (!filter.CustomTags.IsNullOrEmpty())
            {
                var index = 0;
                foreach (var customtag in filter.CustomTags)
                {
                    routeValueDictionary.Add(string.Format("CustomTags[{0}]", index), customtag);
                    index++;
                }
            }
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        private RouteValueDictionary AddRouteValueDictionary(RouteValueDictionary routeValueDictionary, int pageNumber)
        {
            routeValueDictionary.Remove("pageNumber");
            routeValueDictionary.Add("pageNumber", pageNumber);

            return routeValueDictionary;
        }

        public ActionResult NoShowCustomer(NoShowCustomerModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetNoShowCustomers(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new NoShowCustomerListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                                                    {
                                                        pageNumber = pn,
                                                        filter.FromDate,
                                                        filter.ToDate,
                                                        filter.IsRetailEvent,
                                                        filter.IsCorporateEvent,
                                                        filter.IsPublicEvent,
                                                        filter.IsPrivateEvent
                                                    });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult EventCustomerSummaryModel(long eventId, long customerId)
        {
            return View(_eventCustomerReportingService.GetEventCustomerSummary(eventId, customerId));
        }

        public ActionResult CancelledCustomer(CancelledCustomerModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetCancelledCustomers(pageNumber, _pageSize, filter, out totalRecords) ??
                        new CancelledCustomerListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.IsRetailEvent,
                    filter.IsCorporateEvent,
                    filter.IsPublicEvent,
                    filter.IsPrivateEvent,
                    filter.CorporateAccountId,
                    filter.HospitalPartnerId
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CustomerExport(CustomerExportListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetCustomersForExport(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new CustomerExportListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForCustomerExport(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult RescheduleAppointment(RescheduleApplointmentListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;

            var model = _eventCustomerReportingService.GetRescheduleAppointments(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new RescheduleApplointmentListModel();

            if (filter == null)
                filter = new RescheduleApplointmentListModelFilter { RescheduleFrom = DateTime.Now.AddDays(-30), RescheduleTo = DateTime.Now };

            filter.RescheduleFrom = filter.RescheduleFrom.HasValue ? filter.RescheduleFrom.Value : DateTime.Now.Date.AddDays(-30);
            filter.RescheduleTo = filter.RescheduleTo.HasValue ? filter.RescheduleTo.Value : DateTime.Now.Date;

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.EventFrom,
                    filter.EventTo,
                    filter.RescheduleFrom,
                    filter.RescheduleTo,
                    filter.CustomerId,
                    filter.CustomerName,
                    filter.CorporateAccountId,
                    filter.HospitalPartnerId
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult EventCancelation(EventCancellationModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventReportingService.GetCancelledEventsList(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new EventCancellationListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.EventId
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult TestsBooked(TestsBookedListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter == null)
            {
                filter = new TestsBookedListModelFilter { FromDate = DateTime.Now.Date };
            }
            filter.FromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now.Date;

            if (filter != null && filter.FromDate < DateTime.Today)
            {
                return View(new TestsBookedListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("From date can not be past date.") });
            }

            var model = _eventCustomerReportingService.GetTestsBooked(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null)
                model = new TestsBookedListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.EventId
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        private RouteValueDictionary GetRouteValueDictionaryForCustomerExport(CustomerExportListModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"FromDate",filter.FromDate},
                {"ToDate",filter.ToDate},  
                {"FirstName",filter.FirstName},
                {"LastName",filter.LastName},
                {"CustomerId",filter.CustomerId},
                {"IsAttendedCustomers",filter.IsAttendedCustomers},
                {"IsNotAttendedCustomers",filter.IsNotAttendedCustomers},
                {"IsRetailEvent", filter.IsRetailEvent},
                {"IsCorporateEvent", filter.IsCorporateEvent},
                {"IsPublicEvent", filter.IsPublicEvent},
                {"IsPrivateEvent", filter.IsPrivateEvent},
                {"Tag",filter.Tag},
                {"DoNotContactOnly",filter.DoNotContactOnly},
                {"IncludeDoNotContact",filter.IncludeDoNotContact},
                {"EligibleStatus",filter.EligibleStatus},
                {"HealthPlanId",filter.HealthPlanId},
                {"AppointmentFrom",filter.AppointmentFrom},
                {"AppointmentTo",filter.AppointmentTo},
                {"ProductTypeId",filter.ProductTypeId}
            };

            if (!filter.CustomTags.IsNullOrEmpty())
            {
                var index = 0;
                foreach (var customtag in filter.CustomTags)
                {
                    routeValueDictionary.Add(string.Format("CustomTags[{0}]", index), customtag);
                    index++;
                }
            }

            return routeValueDictionary;
        }

        public ActionResult PcpAppointment(PcpAppointmentListModelFilter filter = null, int pageNumber = 1)
        {

            var filterValidator = IoC.Resolve<PcpAppointmentListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (result.IsValid)
            {
                int totalRecords;
                var model = _eventCustomerReportingService.GetPcpAppointment(pageNumber, _pageSize, filter, out totalRecords);
                model = model ?? new PcpAppointmentListModel();
                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                var routeValueDictionary = GetRouteValueDictionaryForPcpAppointment(filter);

                Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }

            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));
            return View(new PcpAppointmentListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
        }

        private RouteValueDictionary GetRouteValueDictionaryForPcpAppointment(PcpAppointmentListModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"FromDate",filter.FromDate},
                {"ToDate",filter.ToDate},  
                {"Tag",filter.Tag},
            };

            if (!filter.CustomTags.IsNullOrEmpty())
            {
                var index = 0;
                foreach (var customtag in filter.CustomTags)
                {
                    routeValueDictionary.Add(string.Format("CustomTags[{0}]", index), customtag);
                    index++;
                }
            }

            return routeValueDictionary;
        }

        public ActionResult MemberStatusReport(MemberStatusListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetMemberStatusReport(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new MemberStatusListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForMemberStatus(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        private RouteValueDictionary GetRouteValueDictionaryForMemberStatus(MemberStatusListModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"FirstName",filter.FirstName},
                {"LastName",filter.LastName},
                {"CustomerId",filter.CustomerId},
                {"IsAttendedCustomers",filter.IsAttendedCustomers},
                {"IsNotAttendedCustomers",filter.IsNotAttendedCustomers},
                {"IsPublicEvent", filter.IsPublicEvent},
                {"IsPrivateEvent", filter.IsPrivateEvent},
                {"Tag",filter.Tag},
                {"DoNotContactOnly",filter.DoNotContactOnly},
                {"IncludeDoNotContact",filter.IncludeDoNotContact},
                {"EligibleStatus",filter.EligibleStatus},
                {"HealthPlanId",filter.HealthPlanId},
                {"Year", filter.Year},
                {"TargetMemberStatus", filter.TargetMemberStatus},
                {"CallAttemptFilter", filter.CallAttemptFilter},
                {"ProductTypeId",filter.ProductTypeId}
            };

            if (!filter.CustomTags.IsNullOrEmpty())
            {
                var index = 0;
                foreach (var customtag in filter.CustomTags)
                {
                    routeValueDictionary.Add(string.Format("CustomTags[{0}]", index), customtag);
                    index++;
                }
            }

            return routeValueDictionary;
        }

        public ActionResult DailyVolume(DailyVolumeListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;

            if (filter == null)
                filter = new DailyVolumeListModelFilter { FromDate = DateTime.Today.AddDays(-1), ToDate = DateTime.Today.AddDays(-1) };

            var model = _eventReportingService.GetDailyVolumeReport(pageNumber, _pageSize, filter, out totalRecords) ??
                        new DailyVolumeListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.Pod,
                    filter.HealthPlanId,
                    IsRetail = filter.IsRetailEvent,
                    IsCorporate = filter.IsCorporateEvent,
                    IsHealthPlan = filter.IsHealthPlanEvent,

                });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult CustomerLeftWithoutScreening(CustomerLeftWithoutScreeningModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetCustomerLeftWithoutScreening(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new CustomerLeftWithoutScreeningListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.IsRetailEvent,
                    filter.IsCorporateEvent,
                    filter.IsPublicEvent,
                    filter.IsPrivateEvent,
                    filter.AccountId,
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
        public ActionResult VoiceMailReminder(VoiceMailReminderModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetVoiceMailReminderReport(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new VoiceMailReminderListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.EventId,
                    filter.HospitalPartnerId,
                    filter.CorporateAccountId,
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult TextReminder(TextReminderModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetTextReminderReport(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new TextReminderListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.EventId,
                    filter.CustomerId,
                    filter.HealthPlanId,
                    filter.ShowSmsOptedCustomers,
                    filter.ShowSmsNotOptedCustomers
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult HealthPlanMemberStatusReport(MemberStatusListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new MemberStatusListModelFilter();

            filter.HealthPlanId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            var model = _eventCustomerReportingService.GetMemberStatusReport(pageNumber, _pageSize, filter, out totalRecords) ?? new MemberStatusListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForMemberStatus(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        [HttpGet]
        public ActionResult GetBookedAppointmentChart(AppointmentBookedChartStatus type)
        {
            var model = _appointmentBookedReportingService.GetAppointmentBookedChartForLastSevenDays(type);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PcpTrackingReport(PcpTrackingReportFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new PcpTrackingReportFilter();

            var model = _pcpTrackingReportService.GetPcpTrackingReport(pageNumber, _pageSize, filter, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = new RouteValueDictionary
            {
                {"HealthPlanId", filter.HealthPlanId},
                {"PatientId", filter.PatientId},
                {"PatientName", filter.PatientName},
            };

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
    }
}
