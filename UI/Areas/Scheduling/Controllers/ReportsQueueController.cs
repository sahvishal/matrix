using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    public class ReportsQueueController : BaseReportQueueController
    {
        private readonly ISessionContext _sessionContext;
        public ReportsQueueController(ILogManager logManager, ISessionContext sessionContext, IExportableReportsQueueService exportableReportsQueueService)
            : base(logManager, exportableReportsQueueService)
        {

            _sessionContext = sessionContext;

        }

        //
        // GET: /Scheduling/ReportsQueue/
        [HttpPost]
        public ActionResult CustomerExport(CustomerExportListModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.CustomerExport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public ActionResult AppointmentsBooked(AppointmentsBookedListModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.AppointmentsBooked, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult MemberStatusReport(MemberStatusListModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.MemberStatusReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult HealthPlanMemberStatusReport(MemberStatusListModelFilter filter = null)
        {
            if (filter == null) filter = new MemberStatusListModelFilter();
            filter.HealthPlanId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            return CreateExportQueue(filter, ExportableReportType.MemberStatusReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult HealthPlanEventReport(EventBasicInfoViewModelFilter filter = null)
        {
            if (filter == null) filter = new EventBasicInfoViewModelFilter();
            filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            return CreateExportQueue(filter, ExportableReportType.EventReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult TestsBookedReport(TestsBookedListModelFilter filter = null)
        {
            if (filter == null) filter = new TestsBookedListModelFilter();

            return CreateExportQueue(filter, ExportableReportType.TestBooked, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult PcpTrackingReport(PcpTrackingReportFilter filter = null)
        {
            if (filter == null) filter = new PcpTrackingReportFilter();

            return CreateExportQueue(filter, ExportableReportType.PcpTrackingReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult CustomerSchedule(CustomerScheduleModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.CustomerSchedule, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
    }
}