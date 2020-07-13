using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Application.ViewModels;
using System.Web.Routing;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]        
    public class ReportsController : Controller
    {
        // GET: /CallCenter/Reports/

        private readonly ICallQueueService _callQueueService;
        private readonly ICallCenterReportService _callCenterReportService;
        private readonly ICallQueueCustomerReportService _callQueueCustomerReportService;
        private readonly IHealthPlanCallQueueCriteriaService _callQueueCriteriaService;
        private readonly IHealthPlanEventService _eventService;
        private readonly ICampaignService _campaignService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IHealthPlanOutboundCallQueueService _healthPlanOutboundCallQueueService;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly IHealthPlanCallQueueCriteriaService _healthPlanCallQueueCriteriaService;
        private readonly IConfirmationReportingService _confirmationReportingService;
        private readonly ICallSkippedReportService _callSkippedReportService;
        private readonly IUserRepository<User> _userRepository;
        private readonly IGmsExcludedCustomerService _gmsExcludedCustomerService;
        private readonly int _pageSize;
        private readonly int _zipRangeInMiles;

        private readonly IPreAssessmentReportingService _preAssessmentReportingService;

        public ReportsController(ICallQueueService callQueueService, ISettings settings, ICallCenterReportService callCenterReportService,
            ICallQueueCustomerReportService callQueueCustomerReportService, IHealthPlanCallQueueCriteriaService callQueueCriteriaService,
            IHealthPlanEventService eventService, ICampaignService campaignService, IOrganizationRepository organizationRepository,
            IHealthPlanOutboundCallQueueService healthPlanOutboundCallQueueService, ICallQueueCustomerRepository callQueueCustomerRepository,
            IHealthPlanCallQueueCriteriaService healthPlanCallQueueCriteriaService, IConfirmationReportingService confirmationReportingService,
            ICallSkippedReportService callSkippedReportService, IUserRepository<User> userRepository, IGmsExcludedCustomerService gmsExcludedCustomerService,
            IPreAssessmentReportingService preAssessmentReportingService)
        {
            _callQueueService = callQueueService;
            _callCenterReportService = callCenterReportService;
            _callQueueCustomerReportService = callQueueCustomerReportService;
            _callQueueCriteriaService = callQueueCriteriaService;
            _eventService = eventService;
            _campaignService = campaignService;
            _organizationRepository = organizationRepository;
            _pageSize = settings.DefaultPageSizeForReports;
            _zipRangeInMiles = settings.ZipRangeInMiles;
            _healthPlanOutboundCallQueueService = healthPlanOutboundCallQueueService;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _healthPlanCallQueueCriteriaService = healthPlanCallQueueCriteriaService;
            _confirmationReportingService = confirmationReportingService;
            _callSkippedReportService = callSkippedReportService;
            _userRepository = userRepository;
            _gmsExcludedCustomerService = gmsExcludedCustomerService;
            _preAssessmentReportingService = preAssessmentReportingService;
        }

        public ActionResult CallQueueReport(CallQueueReportModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _callQueueService.GetCallQueueReport(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new CallQueueReportListModel();
            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.AssignedToOrgRoleUserId,
                               filter.CallQueueId
                           });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult OutreachCallReport(OutreachCallReportModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;

            if (filter == null)
                filter = new OutreachCallReportModelFilter { DateFrom = DateTime.Now.AddDays(-1).Date, DateTo = DateTime.Now.Date.AddDays(-1).Date };

            var model = _callQueueService.GetOutreachCallReport(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null)
                model = new OutreachCallReportListModel();

            if (string.IsNullOrEmpty(filter.Tag) && (filter.CustomTags == null) && !filter.DateFrom.HasValue && !filter.DateTo.HasValue && !filter.CustomerId.HasValue && filter.HealthPlanId <= 0 && filter.CallQueueId <= 0)
            {
                filter.DateFrom = filter.DateFrom.HasValue ? filter.DateFrom.Value : DateTime.Now.AddDays(-1).Date;
                filter.DateTo = filter.DateTo.HasValue ? filter.DateTo.Value : DateTime.Now.AddDays(-1).Date;
            }

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForOutreachCallReportModel(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        private RouteValueDictionary GetRouteValueDictionaryForOutreachCallReportModel(OutreachCallReportModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"DateFrom",filter.DateFrom},
                {"DateTo",filter.DateTo},  
                {"Tag",filter.Tag},
                {"CustomerId",filter.CustomerId},
                {"HealthPlanId",filter.HealthPlanId},
                {"CallQueueId",filter.CallQueueId},
                {"EventId",filter.EventId },
                {"CallAttemptFilter", filter.CallAttemptFilter},
                {"ProductTypeId",filter.ProductTypeId}
            };

            if (filter.CustomTags != null)
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

        private RouteValueDictionary AddRouteValueDictionary(RouteValueDictionary routeValueDictionary, int pageNumber)
        {
            routeValueDictionary.Remove("pageNumber");
            routeValueDictionary.Add("pageNumber", pageNumber);

            return routeValueDictionary;
        }

        public ActionResult UncontactedCustomersReport(UncontactedCustomersReportModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _callQueueService.GetUncontactedCustomersReport(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new UncontactedCustomersReportListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForUncontactedCustomerReportModel(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult CallQueueSchedulingReport(CallQueueSchedulingReportFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new CallQueueSchedulingReportFilter();
            var model = _callCenterReportService.GetHealthPlanCallQueueReport(pageNumber, _pageSize, filter, out totalRecords);

            model = model ?? new CallQueueSchedulingReportListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                 pn =>
                 Url.Action(currentAction,
                            new
                            {
                                pageNumber = pn,
                                filter.HealthPlanId,
                                filter.DateFrom,
                                filter.DateTo,
                                filter.CallQueueId
                            });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        private RouteValueDictionary GetRouteValueDictionaryForUncontactedCustomerReportModel(UncontactedCustomersReportModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"EligibleStatus",filter.EligibleStatus},
                {"HelathPlanId",filter.HelathPlanId},                                
            };

            if (filter.CustomTags != null)
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

        public ActionResult CallQueueCriteriaReports(HealthPlanCallQueueListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new HealthPlanCallQueueListModelFilter();
            filter.ShowMailRoundCriteria = true;

            ListModelBase<HealthPlanCallQueueViewModel, HealthPlanCallQueueListModelFilter> model = null;
            totalRecords = 0;
            if (filter.HealthPlanId > 0)
            {
                model = _callQueueCriteriaService.GetHealthPlanCallQueueList(pageNumber, _pageSize, filter, out totalRecords);
            }

            model = model ?? new HealthPlanCallQueueListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.HealthPlanId,
                               filter.CallQueueId,
                           });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CallQueueCustomers(OutboundCallQueueFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new OutboundCallQueueFilter();

            var model = _callQueueCustomerReportService.GetCallQueueCustomers(pageNumber, _pageSize, filter, out totalRecords);

            model = model ?? new CallQueueCustomersReportModelListModel { RejectedCustomersStats = new CallQueueCustomersStatsViewModel() };
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForCallQueueCustomerReportModel(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult FillEventCallQueue([FromUri]FillEventsCallQueueFilter filter, int pageNumber = 1)
        {
            int totalRecords;

            var model = _eventService.GetEventBasicInfoForCallQueueReport(filter, _pageSize, out totalRecords) ?? new FillEventCallQueueModel { Filter = filter };
            var account = _organizationRepository.GetOrganizationbyId(filter.HealthPlanId);
            model.HealthPlanName = account.Name;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.CallQueueId,
                               filter.CriteriaId,
                               filter.HealthPlanId,
                               filter.EventId,
                           });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CampaignCallQueue([FromUri]CampaignCallQueueFilter filter, int pageNumber = 1)
        {
            int totalRecords;
            var model = _campaignService.GetCampaignListModel(filter, _pageSize, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.CallQueueId,
                               filter.CampaignId,
                               filter.HealthPlanId,
                           });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        private RouteValueDictionary GetRouteValueDictionaryForCallQueueCustomerReportModel(OutboundCallQueueFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"CriteriaId",filter.CriteriaId},
                {"CallQueueId",filter.CallQueueId},
                {"HealthPlanId",filter.HealthPlanId},                
                {"EventId",filter.EventId},                
                {"Radius",filter.Radius},
                {"ZipCode",filter.ZipCode},
                {"CustomerId",filter.CustomerId},
                {"CampaignId",filter.CampaignId},
                {"MemberId",filter.MemberId},
                {"DirectMailDate",filter.DirectMailDate},
                {"UseCustomTagExclusively",filter.UseCustomTagExclusively},
                {"SuppressionType",filter.SuppressionType}
            };

            if (filter.CustomTags != null)
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

        public ActionResult CallQueueExcludedCustomerReport(CallQueueExcludedCustomerReportModelFilter filter = null, int pageNumber = 1)
        {
            if (filter != null && ((filter.CustomerId.HasValue && filter.CustomerId > 0) || filter.HealthPlanId > 0 || !string.IsNullOrEmpty(filter.MemberId)))
            {
                int totalRecords;
                var model = _callQueueService.GetCallQueueExcludedCustomerReport(pageNumber, _pageSize, filter, out totalRecords);
                if (model == null)
                    model = new CallQueueExcludedCustomerReportListModel();
                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                var routeValueDictionary = GetRouteValueDictionaryForCallQueueExcludedCustomerReportModel(filter);

                Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
                return View(model);
            }
            else
            {
                return View(new CallQueueExcludedCustomerReportListModel { Filter = filter });
            }
        }

        private RouteValueDictionary GetRouteValueDictionaryForCallQueueExcludedCustomerReportModel(CallQueueExcludedCustomerReportModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {                             
                {"CustomerId",filter.CustomerId},
                {"HealthPlanId",filter.HealthPlanId},
                {"MemberId",filter.MemberId},
                {"IsEligible",filter.IsEligible},
                {"DoNotContact",filter.DoNotContact},
                {"BookedAppointment",filter.BookedAppointment},
                {"InCorrectPhoneNumber",filter.InCorrectPhoneNumber},
                {"ZipCode",filter.ZipCode},
                {"CampaignId", filter.CampaignId},
                {"DirectMailDate", filter.DirectMailDate}
            };

            if (filter.CustomTags != null)
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

        public ActionResult AgentConversionReport(AgentConversionReportFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;

            filter = filter ?? new AgentConversionReportFilter();

            var model = _callCenterReportService.GetAgentConversionReport(pageNumber, _pageSize, filter, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.FromDate, filter.ToDate, filter.CallCenterAgentId });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CustomerWithNoEventsInAreaReport(CustomerWithNoEventsInAreaReportModelFilter filter = null, int pageNumber = 1)
        {
            filter = filter ?? new CustomerWithNoEventsInAreaReportModelFilter();

            filter.ZipRangeInMiles = _zipRangeInMiles;

            if (filter.AccountId > 0 || (filter.CustomerId.HasValue && filter.CustomerId > 0) || !string.IsNullOrEmpty(filter.MemberId))
            {
                int totalRecords;
                var model = _callQueueService.GetCustomerWithNoEventsInArea(pageNumber, _pageSize, filter, out totalRecords);
                if (model == null)
                    model = new CustomerWithNoEventsInAreaReportListModel();

                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                var routeValueDictionary = GetRouteValueDictionaryForCustomerWithNoEventsInArea(filter);

                Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
                return View(model);
            }

            return View(new CustomerWithNoEventsInAreaReportListModel { Filter = filter });
        }

        private RouteValueDictionary GetRouteValueDictionaryForCustomerWithNoEventsInArea(CustomerWithNoEventsInAreaReportModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"CustomerId", filter.CustomerId},
                {"AccountId", filter.AccountId},
                {"ZipCode", filter.ZipCode},
                {"MemberId", filter.MemberId}
            };

            if (filter.CustomTags != null)
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

        public ActionResult CallQueueEstimatedCustomerReport(HealthPlanCallQueueListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new HealthPlanCallQueueListModelFilter();
            filter.ShowMailRoundCriteria = true;

            ListModelBase<HealthPlanCallQueueViewModel, HealthPlanCallQueueListModelFilter> model = null;
            totalRecords = 0;
            if (filter.HealthPlanId > 0)
            {
                model = _callQueueCriteriaService.GetHealthPlanCallQueueList(pageNumber, _pageSize, filter, out totalRecords);
            }

            model = model ?? new HealthPlanCallQueueListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.HealthPlanId,
                               filter.CallQueueId,
                           });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CallQueueEstimatedCustomer(OutboundCallQueueFilter filter, int pageNumber = 1)
        {
            filter = filter ?? new OutboundCallQueueFilter();
            _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);
            var model = _callQueueCustomerRepository.GetCallQueueEstimatedNumbers(filter);
            model.CallQueueCriteria = _healthPlanCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(filter.CallQueueId, filter.HealthPlanId, null, filter.CampaignId.HasValue ? filter.CampaignId.Value : 0, filter.CriteriaId);

            return View(model);
        }

        public ActionResult CallCenterCallReport(CallCenterCallReportModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;

            if (filter == null)
                filter = new CallCenterCallReportModelFilter { DateFrom = DateTime.Now.AddDays(-1).Date, DateTo = DateTime.Now.Date.AddDays(-1).Date };

            var model = _callQueueService.GetCallCenterCallReport(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null)
                model = new CallCenterCallReportListModel();

            if (string.IsNullOrEmpty(filter.Tag) && (filter.CustomTags == null) && !filter.DateFrom.HasValue && !filter.DateTo.HasValue && !filter.CustomerId.HasValue && filter.HealthPlanId <= 0 && filter.CallQueueId <= 0)
            {
                filter.DateFrom = filter.DateFrom.HasValue ? filter.DateFrom.Value : DateTime.Now.AddDays(-1).Date;
                filter.DateTo = filter.DateTo.HasValue ? filter.DateTo.Value : DateTime.Now.AddDays(-1).Date;
            }

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForCallCenterCallReportModel(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        private RouteValueDictionary GetRouteValueDictionaryForCallCenterCallReportModel(CallCenterCallReportModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"DateFrom",filter.DateFrom},
                {"DateTo",filter.DateTo},  
                {"Tag",filter.Tag},
                {"CustomerId",filter.CustomerId},
                {"HealthPlanId",filter.HealthPlanId},
                {"CallQueueId",filter.CallQueueId},
                {"CallType",filter.CallType}
            };

            if (filter.CustomTags != null)
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

        public ActionResult ConfirmationReport(ConfirmationReportFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            if (filter == null)
                filter = new ConfirmationReportFilter();

            var model = _confirmationReportingService.GetConfirmationReport(pageNumber, _pageSize, filter, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = new RouteValueDictionary
            {
                {"EventDateFrom",filter.EventDateFrom},
                {"EventDateTo",filter.EventDateTo},
                {"HealthPlanId",filter.HealthPlanId},
                {"Disposition",filter.Disposition}
            };

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CallSkippedReport(CallSkippedReportFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;
            if (filter == null)
                filter = new CallSkippedReportFilter { DateFrom = DateTime.Now, DateTo = DateTime.Now.Date };

            var model = _callSkippedReportService.GetCallSkippedReport(pageNumber, _pageSize, filter, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = new RouteValueDictionary
            {
                {"CallQueueId",filter.CallQueueId},
                {"DateFrom",filter.DateFrom},
                {"DateTo",filter.DateTo},
                {"CustomerId",filter.CustomerId},
                {"HealthPlanId",filter.HealthPlanId},
                {"AgentId",filter.AgentId},
                {"AgentName",filter.AgentName}
            };
            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult GetAgentsList(string searchText)
        {
            return Json(_userRepository.SearchUsersByNameAndRole(searchText, Roles.CallCenterRep).ToList().Select(x => new { id = x.Key, label = x.Value }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExcludedCustomers(OutboundCallQueueFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;

            filter = filter ?? new OutboundCallQueueFilter();
            var model = _gmsExcludedCustomerService.GetExcludedCustomers(pageNumber, _pageSize, filter, out totalRecords);
            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForCallQueueCustomerReportModel(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

            var excludedCustomerListModel = new ExcludedCustomerListModel
            {
                Collection = model.Collection,
                Filter = model.Filter,
                PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc)
            };

            excludedCustomerListModel = _gmsExcludedCustomerService.SetHeaderData(filter, excludedCustomerListModel);

            return View(excludedCustomerListModel);
        }
         
        public ActionResult PreAssessmentReport(PreAssessmentReportFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            if (filter == null)
                filter = new PreAssessmentReportFilter();

            var model = _preAssessmentReportingService.GetPreAssessmentReport(pageNumber, _pageSize, filter, out totalRecords);

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = new RouteValueDictionary
            {
                {"EventDateFrom",filter.EventDateFrom},
                {"EventDateTo",filter.EventDateTo},
                {"HealthPlanId",filter.HealthPlanId},
                {"Disposition",filter.Disposition}
            };

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
    }
}
