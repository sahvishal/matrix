using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;


namespace Falcon.App.UI.Areas.Users.Controllers
{
    [RoleBasedAuthorize]
    public class DashboardController : Controller
    {
        private readonly ISessionContext _sessionContext;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IPhysicianEvaluationService _physicianEvaluationService;
        private readonly IPhysicianEvaluationRepository _physicianEvaluationRepository;
        private readonly IOrganizationService _organizationService;
        private readonly IHospitalPartnerService _hospitalPartnerService;
        private readonly IEventService _eventService;
        private readonly ILogger _logger;
        private readonly int _pageSizeForDashboard;

        public DashboardController(ISessionContext sessionContext, IPhysicianEvaluationService physicianEvaluationService, IPhysicianEvaluationRepository physicianEvaluationRepository, IPhysicianRepository physicianRepository,
            IOrganizationService organizationService, ILogManager logManager, IHospitalPartnerService hospitalPartnerService, IEventService eventService, ISettings settings)
        {
            _sessionContext = sessionContext;
            _physicianRepository = physicianRepository;
            _physicianEvaluationService = physicianEvaluationService;
            _physicianEvaluationRepository = physicianEvaluationRepository;
            _organizationService = organizationService;
            _hospitalPartnerService = hospitalPartnerService;
            _eventService = eventService;
            _logger = logManager.GetLogger<Global>();
            _pageSizeForDashboard = settings.DashboardEventListingPageSize;
        }

        public ActionResult Index()
        {
            if (_sessionContext.UserSession != null)
                return RedirectToAction(_sessionContext.UserSession.CurrentOrganizationRole.RoleAlias);

            Response.RedirectUser("/Login");

            return null; 
        }

        public ActionResult FranchisorAdmin()
        {
            Response.RedirectUser("~/App/Franchisor/Dashboard.aspx");
            return null; 
        }

        public ActionResult SalesRep()
        {
            Response.RedirectUser("~/App/Franchisee/SalesRep/Dashboard.aspx");
            return null; 
        }

        public ActionResult FranchiseeAdmin()
        {
            Response.RedirectUser("~/App/Franchisee/Dashboard.aspx");
            return null; 
        }

        public ActionResult CallCenterManager()
        {
            Response.RedirectUser("~/App/CallCenter/CallCenterManagerDashBoard.aspx");
            return null; 
        }

        public ActionResult MedicalVendorAdmin()
        {
            Response.RedirectUser("~/App/MedicalVendor/MVDashboard.aspx");
            return null; 
        }

        public ActionResult MedicalVendorUser()
        {
            Response.RedirectUser("~/Users/Dashboard/Physician");
            return null; 
        }

        public ActionResult Physician()
        {
            try
            {
                _physicianEvaluationRepository.ReleasePhysicianEvaluationOldLocks();
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception while releasing all locked Customers. Message: {0}.\n\t Stack Trace: {1}", ex.Message, ex.StackTrace));
            }

            return View(_physicianEvaluationService.GetPhysicianStats(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId));
        }

        public ActionResult HospitalPartnerCoordinator()
        {
            var model = _organizationService.GetHospitalPartnerDashboardModel(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);
            return View(model);
        }

        public ActionResult CorporateAccountCoordinator()
        {
            var model = _organizationService.GetCorporateAccountDashboardModel(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationId, _pageSizeForDashboard);
            return View(model);
        }

        public JsonResult GetUpcomingEventsForHealthPlan(EventStaffAssignmentListModelFilter filter)
        {
            filter = filter ?? new EventStaffAssignmentListModelFilter();
            filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            var eventStaffAssignmentViewModels = _eventService.GetEventStaff(filter).StaffEventAssignments;
            return Json(Mapper.Map<IEnumerable<EventStaffAssignmentViewModel>, EventJsonModel[]>(eventStaffAssignmentViewModels), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResultSummaryChart(int normalCustomers, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            var totalCount = normalCustomers + abnormalCustomers + criticalCustomers + urgentCustomers;
            var chart = new Chart(445, 200)
                .AddSeries(
                    chartType: "column",
                    xValue:
                        new[]
                            {
                                "Normal (" + normalCustomers + ") " + CalculatePercentage(normalCustomers, totalCount) + "%",
                                "Abnormal (" + abnormalCustomers + ") " + CalculatePercentage(abnormalCustomers, totalCount) + "%",
                                "Critical (" + criticalCustomers + ") " + CalculatePercentage(criticalCustomers, totalCount) + "%",
                                "Urgent (" + urgentCustomers + ") " + CalculatePercentage(urgentCustomers, totalCount) + "%"
                            },
                    yValues: new[] { normalCustomers, abnormalCustomers, criticalCustomers, urgentCustomers });

            var bytes = chart.GetBytes("png");

            return File(bytes, "image/png");
        }

        public ActionResult GetAvailableEventCustomerIdforEvaluation()
        {
            var physicianId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            long eventCustomerId = 0;

            while (true)
            {

                var evaluationPair = _physicianRepository.GetEventCustomerIdForPhysicianEvaluation(physicianId);
                if (evaluationPair != null) eventCustomerId = evaluationPair.FirstItemInTheQueue;
                else break;
                if (eventCustomerId == 0) break;
                var result = AcquireLock(eventCustomerId);
                if (result) break;
            }
            return Content(eventCustomerId.ToString());
        }

        private bool AcquireLock(long eventCustomerId)
        {
            try
            {
                return IoC.Resolve<IPhysicianEvaluationRepository>().AccquirePhysicianEvaluationLock(eventCustomerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult GetAvailableEventCustomerIdforOverread()
        {
            var physicianId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            long eventCustomerId = 0;

            while (true)
            {
                var evaluationPair = _physicianRepository.GetEventCustomerIdForOverReadPhysicianEvaluation(physicianId);
                if (evaluationPair != null) eventCustomerId = evaluationPair.FirstItemInTheQueue;
                else break;
                if (eventCustomerId == 0) break;
                var result = AcquireLock(eventCustomerId);
                if (result) break;
            }
            return Content(eventCustomerId.ToString());
        }

        public ActionResult OperationManager()
        {
            Response.RedirectUser("~/App/CallCenter/CallCenterAdminDasboard.aspx");
            return null; 
        }

        public ActionResult Technician()
        {
            Response.RedirectUser("~/Scheduling/Event/Index?DateFrom=" + DateTime.Now.ToString("MM/dd/yyyy"));
            return null; 
        }

        public ActionResult Customer()
        {
            Response.RedirectUser("~/App/Customer/HomePage.aspx");
            return null; 
        }

        public ActionResult CallCenterRep()
        {
            Response.RedirectUser("~/CallCenter/CallCenterRepDashBoard/Index");
            return null; 
        }

        public ActionResult AdvocateManager()
        {
            Response.RedirectUser("~/App/MarketingPartner/AdvocateManager/Dashboard.aspx");
            return null; 
        }

        public ActionResult Dashboard()
        {
            return RedirectToAction(_sessionContext.UserSession.CurrentOrganizationRole.RoleAlias);
        }

        public ActionResult HospitalPartnerStatusChart(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            var model = _hospitalPartnerService.GetHospitalPartnerCallStatus(hospitalPartnerId, abnormalCustomers, criticalCustomers, urgentCustomers);
            if (model == null || model.TotalCount < 1)
                return File("NoResults", "image/jpeg");

            var chart = GetStatusChart(model);

            var bytes = chart.GetBytes();

            return File(bytes, "image/jpeg");
        }

        public ActionResult HospitalPartnerScheduledOutcomeChart(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            var model = _hospitalPartnerService.GetHospitalPartnerScheduledOutcome(hospitalPartnerId, abnormalCustomers, criticalCustomers, urgentCustomers);
            if (model == null || model.TotalCount < 1)
                return File("NoResults", "image/jpeg");

            var chart = GetScheduledOutcomeChart(model);

            var bytes = chart.GetBytes("png");

            return File(bytes, "image/png");
        }

        public ActionResult HospitalPartnerNotScheduledOutcomeChart(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            var model = _hospitalPartnerService.GetHospitalPartnerNotScheduledOutcome(hospitalPartnerId, abnormalCustomers, criticalCustomers, urgentCustomers);
            if (model == null || model.TotalCount < 1)
                return File("NoResults", "image/jpeg");

            var chart = GetNotScheduledOutcomeChart(model);

            var bytes = chart.GetBytes("png");

            return File(bytes, "image/png");
        }

        private decimal CalculatePercentage(long singleCount, long totalCount)
        {
            if (totalCount == 0) return 0;
            var percentage = (Convert.ToDecimal(singleCount) / Convert.ToDecimal(totalCount)) * 100;
            return Math.Round(percentage, 2);
        }

        //AdvocateSalesManager		App/MarketingPartner/AdvocateSalesManager/Dashboard.aspx
        //PrintVendorAdmin	App/PrintVendor/Dashboard.aspx

        public ActionResult HospitalFacilityCoordinator()
        {
            var model = _organizationService.GetHospitalFacilityDashboardModel(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);
            return View(model);
        }

        public ActionResult HospitalFacilityResultSummaryChart(int normalCustomers, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            var totalCount = normalCustomers + abnormalCustomers + criticalCustomers + urgentCustomers;
            var chart = new Chart(445, 200)
                .AddSeries(
                    chartType: "Column",
                    xValue:
                        new[]
                            {
                                "Normal (" + normalCustomers + ") " + CalculatePercentage(normalCustomers, totalCount) + "%",
                                "Abnormal (" + abnormalCustomers + ") " + CalculatePercentage(abnormalCustomers, totalCount) + "%",
                                "Critical (" + criticalCustomers + ") " + CalculatePercentage(criticalCustomers, totalCount) + "%",
                                "Urgent (" + urgentCustomers + ") " + CalculatePercentage(urgentCustomers, totalCount) + "%"
                            },
                    yValues: new[] { normalCustomers, abnormalCustomers, criticalCustomers, urgentCustomers });

            var bytes = chart.GetBytes("png");

            return File(bytes, "image/png");
        }

        public ActionResult HospitalFacilityStatusChart(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            var model = _hospitalPartnerService.GetHospitalFacilityCallStatus(hospitalFacilityId, abnormalCustomers, criticalCustomers, urgentCustomers);
            if (model == null || model.TotalCount < 1)
                return File("NoResults", "image/jpeg");

            var chart = GetStatusChart(model);

            var bytes = chart.GetBytes();

            return File(bytes, "image/jpeg");
        }

        public ActionResult HospitalFacilityScheduledOutcomeChart(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            var model = _hospitalPartnerService.GetHospitalFacilityScheduledOutcome(hospitalFacilityId, abnormalCustomers, criticalCustomers, urgentCustomers);
            if (model == null || model.TotalCount < 1)
                return File("NoResults", "image/jpeg");

            var chart = GetScheduledOutcomeChart(model);

            var bytes = chart.GetBytes("png");

            return File(bytes, "image/png");
        }

        public ActionResult HospitalFacilityNotScheduledOutcomeChart(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            var model = _hospitalPartnerService.GetHospitalFacilityNotScheduledOutcome(hospitalFacilityId, abnormalCustomers, criticalCustomers, urgentCustomers);
            if (model == null || model.TotalCount < 1)
                return File("NoResults", "image/jpeg");

            var chart = GetNotScheduledOutcomeChart(model);

            var bytes = chart.GetBytes("png");

            return File(bytes, "image/png");
        }

        private Chart GetStatusChart(HospitalPartnerCallStatusViewModel model)
        {
            var chart = new Chart(480, 250).SetXAxis("", 0, 10)
                .AddSeries(
                    chartType: "Column",
                    xValue:
                        new[]
                        {
                            "Not Called (" + model.NotCalledStatus + ") " + CalculatePercentage(model.NotCalledStatus, model.TotalCount) + "%",
                            "Talked to Person (" + model.TalkedToPersonStatus + ") " + CalculatePercentage(model.TalkedToPersonStatus, model.TotalCount) + "%",
                            "Left Voice Mail (" + model.LeftVoiceMailStatus + ") " + CalculatePercentage(model.LeftVoiceMailStatus, model.TotalCount) + "%",
                            "Left Voice Mail2 (" + model.LeftVoiceMail2Status + ") " + CalculatePercentage(model.LeftVoiceMail2Status, model.TotalCount) + "%",
                            "Left Voice Mail3 (" + model.LeftVoiceMail3Status + ") " + CalculatePercentage(model.LeftVoiceMail3Status, model.TotalCount) + "%",
                            "Left Voice Mail4 (" + model.LeftVoiceMail4Status + ") " + CalculatePercentage(model.LeftVoiceMail4Status, model.TotalCount) + "%",
                            "Voice Mail5 (" + model.VoiceMail5Status + ") " + CalculatePercentage(model.VoiceMail5Status, model.TotalCount) + "%",
                            "Voice Mail6 (" + model.VoiceMail6Status + ") " + CalculatePercentage(model.VoiceMail6Status, model.TotalCount) + "%",
                            "Mailed/Emailed (" + model.MailedEmailedStatus + ") " + CalculatePercentage(model.MailedEmailedStatus, model.TotalCount) + "%",
                            "Unreachable (" + model.UnReachableStatus + ") " + CalculatePercentage(model.UnReachableStatus, model.TotalCount) + "%",
                        },
                    yValues: new[]
                    {
                        model.NotCalledStatus, model.TalkedToPersonStatus, model.LeftVoiceMailStatus, model.LeftVoiceMail2Status, model.LeftVoiceMail3Status, 
                        model.LeftVoiceMail4Status, model.VoiceMail5Status, model.VoiceMail6Status, model.MailedEmailedStatus, model.UnReachableStatus
                    });
            return chart;
        }

        private Chart GetScheduledOutcomeChart(HospitalPartnerScheduledOutcomeViewModel model)
        {
            var chart = new Chart(480, 250).SetXAxis("", 0, 10)
                .AddSeries(
                    chartType: "Column",
                    xValue:
                        new[]
                            {
                                //HospitalPartnerCustomerOutcome.Scheduled.GetDescription() + " (" + model.ScheduledOutcome + ") " + CalculatePercentage(model.ScheduledOutcome, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.ScheduledWithAffiliatedPcp.GetDescription() + " (" + model.ScheduledWithAffiliatedPcpOutcome + ") " + CalculatePercentage(model.ScheduledWithAffiliatedPcpOutcome, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.ScheduledWithAffiliatedSpecialist.GetDescription() + " (" + model.ScheduledWithAffiliatedSpecialistOutcome + ") " + CalculatePercentage(model.ScheduledWithAffiliatedSpecialistOutcome, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.ReferredToAffiliatedPcp.GetDescription() + " (" + model.ReferredToAffiliatedPcpOutcome + ") " + CalculatePercentage(model.ReferredToAffiliatedPcpOutcome, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.ReferredToAffiliatedSpecialist.GetDescription() + " (" + model.ReferredToAffiliatedSpecialistOutcome + ") " + CalculatePercentage(model.ReferredToAffiliatedSpecialistOutcome, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.SelfScheduledWithNonAffiliatedPhysician.GetDescription() + " (" + model.SelfScheduledWithNonAffiliatedPhysicianOutcome + ") " + CalculatePercentage(model.SelfScheduledWithNonAffiliatedPhysicianOutcome, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.SelfScheduledWithAffiliatedPhysician.GetDescription() + " (" + model.SelfScheduledWithAffiliatedPhysicianOutcome + ") " + CalculatePercentage(model.SelfScheduledWithAffiliatedPhysicianOutcome, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.ScheduledWithEmployedPhysician.GetDescription() + " (" + model.ScheduledWithEmployedPhysician + ") " + CalculatePercentage(model.ScheduledWithEmployedPhysician, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.ReferredToEmployedPhysician.GetDescription() + " (" + model.ReferredToEmployedPhysician + ") " + CalculatePercentage(model.ReferredToEmployedPhysician, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.SelfScheduledWithEmployedPhysician.GetDescription() + " (" + model.SelfScheduledWithEmployedPhysician + ") " + CalculatePercentage(model.SelfScheduledWithEmployedPhysician, model.TotalCount) + "%",
                                HospitalPartnerCustomerOutcome.Uninsured.GetDescription() + " (" + model.Uninsured + ") " + CalculatePercentage(model.Uninsured, model.TotalCount) + "%"
                            },
                    yValues: new[] { //model.ScheduledOutcome, 
                        model.ScheduledWithAffiliatedPcpOutcome, model.ScheduledWithAffiliatedSpecialistOutcome, model.ReferredToAffiliatedPcpOutcome, model.ReferredToAffiliatedSpecialistOutcome, 
                        model.SelfScheduledWithNonAffiliatedPhysicianOutcome, model.SelfScheduledWithAffiliatedPhysicianOutcome,model.ScheduledWithEmployedPhysician, model.ReferredToEmployedPhysician
                        ,model.SelfScheduledWithEmployedPhysician
                        ,model.Uninsured 
                    }
                 );
            return chart;
        }

        private Chart GetNotScheduledOutcomeChart(HospitalPartnerNotScheduledOutcomeViewModel model)
        {
            var chart = new Chart(445, 240)
                .AddSeries(
                    chartType: "Column",
                    xValue:
                            new[]
                                {
                                    HospitalPartnerCustomerOutcome.NotScheduled.GetDescription() + " (" + model.NotScheduledOutcome + ") " + CalculatePercentage(model.NotScheduledOutcome, model.TotalCount) + "%",
                                    HospitalPartnerCustomerOutcome.NotScheduledSentInformation.GetDescription() + " (" + model.NotScheduledSentInformationOutcome + ") " + CalculatePercentage(model.NotScheduledSentInformationOutcome, model.TotalCount) + "%",
                                    HospitalPartnerCustomerOutcome.NotScheduledNotInterested.GetDescription() + " (" + model.NotScheduledNotInterestedOutcome + ") " + CalculatePercentage(model.NotScheduledNotInterestedOutcome, model.TotalCount) + "%",
                                    HospitalPartnerCustomerOutcome.NotReached.GetDescription() + " (" + model.NotReachedOutcome + ") " + CalculatePercentage(model.NotReachedOutcome, model.TotalCount) + "%",
                                    HospitalPartnerCustomerOutcome.Other.GetDescription() + " (" + model.OtherOutcome + ") " + CalculatePercentage(model.OtherOutcome, model.TotalCount) + "%",
                                    HospitalPartnerCustomerOutcome.NotCalled.GetDescription() + " (" + model.NotCalledOutcome + ") " + CalculatePercentage(model.NotCalledOutcome, model.TotalCount) + "%",
                                    HospitalPartnerCustomerOutcome.RequiresCallBack.GetDescription() + " (" + model.RequiresCallBack + ") " + CalculatePercentage(model.RequiresCallBack, model.TotalCount) + "%"
                                },
                    yValues: new[] { model.NotScheduledOutcome, model.NotScheduledSentInformationOutcome, model.NotScheduledNotInterestedOutcome, model.NotReachedOutcome, model.OtherOutcome, model.NotCalledOutcome, model.RequiresCallBack }
                );
            return chart;
        }

        public ActionResult NursePractitioner()
        {
            Response.RedirectUser("~/Scheduling/Event/Index?DateFrom=" + DateTime.Now.ToString("MM/dd/yyyy"));
            return null; 
        }
    }
}
