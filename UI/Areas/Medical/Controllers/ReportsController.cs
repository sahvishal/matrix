using System;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Scheduling;
using System.Web.Routing;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class ReportsController : Controller
    {
        //
        // GET: /Medical/Reports/
        private readonly int _pageSize;
        private readonly ITestResultService _testResultService;
        private readonly IPhysicianEvaluationService _physicianEvaluationService;
        private readonly IKynCustomerReportService _kynCustomerReportService;
        private readonly ITestNotPerformedService _testNotPerformedService;
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly ISessionContext _sessionContext;
        private readonly IEventArchiveStatsService _eventArchiveStatsService;
        private readonly IEventCustomerQuestionAnswerService _eventCustomerQuestionAnswerServcie;


        public ReportsController(ISettings settings, ITestResultService testResultService, IPhysicianEvaluationService physicianEvaluationService, IKynCustomerReportService kynCustomerReportService, ITestNotPerformedService testNotPerformedService,
            IEventCustomerReportingService eventCustomerReportingService, ISessionContext sessionContext, IEventArchiveStatsService eventArchiveStatsService, IEventCustomerQuestionAnswerService eventCustomerQuestionAnswerServcie)
        {
            _pageSize = settings.DefaultPageSizeForReports;
            _testResultService = testResultService;
            _physicianEvaluationService = physicianEvaluationService;
            _kynCustomerReportService = kynCustomerReportService;
            _testNotPerformedService = testNotPerformedService;
            _eventCustomerReportingService = eventCustomerReportingService;
            _sessionContext = sessionContext;
            _eventArchiveStatsService = eventArchiveStatsService;
            _eventCustomerQuestionAnswerServcie = eventCustomerQuestionAnswerServcie;
        }

        public ActionResult EventResultsStatus(EventResultStatusViewModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            //if (!filter.EventDateFrom.HasValue)
            //    filter.EventDateFrom = DateTime.Now.Date;

            var model = _testResultService.GetEventResultStatusList(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null)
                model = new EventResultStatusListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.EventId,
                    filter.EventDateFrom,
                    filter.EventDateTo,
                    filter.Status,
                    filter.PodId
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult PhysicianReviewSummary(PhysicianReviewSummaryListModelFilter filter = null, int pageNumber = 1)
        {
            var filterValidator = IoC.Resolve<PhysicianReviewSummaryListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (result.IsValid)
            {
                int totalRecords = 0;

                var model = _physicianEvaluationService.GetPhysicianReviewSummary(pageNumber, _pageSize, filter,
                                                                                  out totalRecords);
                if (model == null)
                    model = new PhysicianReviewSummaryListModel();
                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();

                Func<int, string> urlFunc =
                    pn => Url.Action(currentAction, new
                                                        {
                                                            pageNumber = pn,
                                                            filter.EventId,
                                                            filter.FromDate,
                                                            filter.ToDate,
                                                            filter.DateType,
                                                            filter.PodId,
                                                            filter.IsRetailEvent,
                                                            filter.IsCorporateEvent,
                                                            filter.IsPublicEvent,
                                                            filter.IsPrivateEvent
                                                        });
                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
                return View(model);
            }

            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

            return View(new PhysicianReviewSummaryListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
        }

        public ActionResult PhysicianReview(PhysicianReviewListModelFilter filter = null, int pageNumber = 1)
        {
            var filterValidator = IoC.Resolve<PhysicianReviewListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (result.IsValid)
            {
                int totalRecords = 0;

                var model = _physicianEvaluationService.GetPhysicianReviews(pageNumber, _pageSize, filter,
                                                                            out totalRecords);

                if (model == null)
                    model = new PhysicianReviewListModel();

                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();

                Func<int, string> urlFunc =
                    pn => Url.Action(currentAction, new
                                                        {
                                                            pageNumber = pn,
                                                            filter.EventId,
                                                            filter.FromDate,
                                                            filter.ToDate,
                                                            filter.DateType,
                                                            filter.PhysicianId,
                                                            filter.PodId,
                                                            filter.IsRetailEvent,
                                                            filter.IsCorporateEvent,
                                                            filter.IsPublicEvent,
                                                            filter.IsPrivateEvent
                                                        });
                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }
            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

            return View(new PhysicianReviewListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
        }

        public ActionResult PhysicianQueue(PhysicianQueueListModelFilter filter = null, int pageNumber = 1)
        {
            var filterValidator = IoC.Resolve<PhysicianQueueListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (result.IsValid)
            {
                int totalRecords = 0;

                var model = _physicianEvaluationService.GetPhysicianQueue(pageNumber, _pageSize, filter,
                                                                            out totalRecords);

                if (model == null)
                    model = new PhysicianQueueListModel();

                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();

                Func<int, string> urlFunc =
                    pn => Url.Action(currentAction, new
                    {
                        pageNumber = pn,
                        filter.EventId,
                        filter.FromDate,
                        filter.ToDate,
                        filter.DateType,
                        filter.PhysicianId,
                        filter.PodId,
                        filter.RecordsforPrimaryEval,
                        filter.IsRetailEvent,
                        filter.IsCorporateEvent,
                        filter.IsPublicEvent,
                        filter.IsPrivateEvent
                    });

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }
            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

            return View(new PhysicianQueueListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
        }

        public ActionResult PhysicianEventQueue(PhysicianEventQueueListModelFilter filter = null, int pageNumber = 1)
        {
            var filterValidator = IoC.Resolve<PhysicianEventQueueListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (result.IsValid)
            {
                int totalRecords = 0;

                var model = _physicianEvaluationService.GetPhysicianEventQueue(pageNumber, _pageSize, filter, out totalRecords);

                if (model == null)
                    model = new PhysicianEventQueueListModel();

                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();

                Func<int, string> urlFunc =
                    pn => Url.Action(currentAction, new
                    {
                        pageNumber = pn,
                        filter.EventId,
                        filter.FromDate,
                        filter.ToDate,
                        filter.DateType,
                        filter.PhysicianId,
                        filter.PodId,
                        filter.RecordsforPrimaryEval,
                        filter.IsRetailEvent,
                        filter.IsCorporateEvent,
                        filter.IsPublicEvent,
                        filter.IsPrivateEvent
                    });

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }
            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

            return View(new PhysicianEventQueueListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
        }

        public ActionResult TestPerformed(TestPerformedListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            if (filter == null)
                filter = new TestPerformedListModelFilter { EventDateFrom = DateTime.Now.AddMonths(-1).Date, EventDateTo = DateTime.Now.Date };

            var model = _testResultService.GetTestPerformed(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null)
                model = new TestPerformedListModel();

            filter.EventDateFrom = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now.AddMonths(-1).Date;
            filter.EventDateTo = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now;

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.EventDateFrom,
                    filter.EventDateTo,
                    filter.TechnicianId,
                    filter.HealthPlanId,
                    filter.EventId,
                    filter.Pod,
                    filter.IsCorporateEvent,
                    filter.IsRetailEvent,
                    filter.IsHealthPlanEvent,
                    filter.TestId,
                    filter.IsPdfGenerated
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult TestNotPerformed(TestNotPerformedListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            if (filter == null)
                filter = new TestNotPerformedListModelFilter { EventDateFrom = DateTime.Now.AddMonths(-1).Date, EventDateTo = DateTime.Now.Date };

            var model = _testNotPerformedService.GetTestNotPerformed(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null)
                model = new TestNotPerformedListModel();

            filter.EventDateFrom = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now.AddMonths(-1).Date;
            filter.EventDateTo = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now;

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.EventDateFrom,
                    filter.EventDateTo,
                    filter.HealthPlanId,
                    filter.EventId,
                    filter.Pod,
                    filter.TestId
                });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult PhysicianTestReview(PhysicianTestReviewListModelFilter filter = null, int pageNumber = 1)
        {
            var filterValidator = IoC.Resolve<PhysicianTestReviewListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (result.IsValid)
            {
                int totalRecords = 0;

                var model = _physicianEvaluationService.GetPhysicianTestReview(pageNumber, _pageSize, filter, out totalRecords);
                if (model == null)
                    model = new PhysicianTestReviewListModel();
                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();

                Func<int, string> urlFunc =
                    pn => Url.Action(currentAction, new
                    {
                        pageNumber = pn,
                        filter.EventId,
                        filter.FromDate,
                        filter.ToDate,
                        filter.DateType,
                        filter.PhysicianId,
                        filter.PodId,
                        filter.IsRetailEvent,
                        filter.IsCorporateEvent,
                        filter.IsPublicEvent,
                        filter.IsPrivateEvent
                    });
                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
                return View(model);
            }

            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

            return View(new PhysicianTestReviewListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
        }

        public ActionResult KynCustomerReport(KynCustomerModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            filter = filter ?? new KynCustomerModelFilter();

            var model = _kynCustomerReportService.GetKynCustomerReport(pageNumber, _pageSize, filter, out totalRecords) ??
                        new KynCustomerListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFanc = pn => Url.Action(currentAction, new
            {
                pageNumber = pn,
                filter.EventId,
                filter.FromDate,
                filter.ToDate,
                filter.ShowOnlyKyn,
                filter.Tag,
                CustomTags = filter.CustomTags.IsNullOrEmpty() ? "" : string.Join("&CustomTags=", filter.CustomTags)
            });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFanc);

            return View(model);
        }

        public ActionResult GapClosure(GapsClosureModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _eventCustomerReportingService.GetGapsClosureReport(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new GapsClosureListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForPreApprovedTestStatus(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        private RouteValueDictionary AddRouteValueDictionary(RouteValueDictionary routeValueDictionary, int pageNumber)
        {
            routeValueDictionary.Remove("pageNumber");
            routeValueDictionary.Add("pageNumber", pageNumber);

            return routeValueDictionary;
        }
        private RouteValueDictionary GetRouteValueDictionaryForPreApprovedTestStatus(GapsClosureModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"FromDate",filter.FromDate},
                {"ToDate",filter.ToDate},
                {"AccountId",filter.AccountId},                
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

        public ActionResult HealthPlanGapsClosure(GapsClosureModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;

            if (filter == null) filter = new GapsClosureModelFilter();
            filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            var model = _eventCustomerReportingService.GetGapsClosureReport(pageNumber, _pageSize, filter, out totalRecords) ?? new GapsClosureListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            var routeValueDictionary = GetRouteValueDictionaryForPreApprovedTestStatus(filter);

            Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult EventArchiveStats(EventArchiveStatsFilter filter, int pageNumber = 1)
        {
            int totalRecords;
            if (filter == null) filter = new EventArchiveStatsFilter();

            var model = _eventArchiveStatsService.GetEventArchiveStats(pageNumber, _pageSize, filter, out totalRecords) ?? new EventArchiveStatsListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.EventId, filter.UploadDateFrom, filter.UploadDateTo, filter.UploadedBy, filter.UploadStatus });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult DisqualifiedTestReport(DisqualifiedTestReportFilter filter, int pageNumber = 1)
        {
            int totalRecords;
            if (filter == null) filter = new DisqualifiedTestReportFilter();

            var model = _eventCustomerQuestionAnswerServcie.GetDisqualifiedTestReport(pageNumber, _pageSize, filter, out totalRecords);
            model.Filter = filter;
            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.AccountId, filter.CustomerId, filter.TestId, filter.EventId });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
    }
}
