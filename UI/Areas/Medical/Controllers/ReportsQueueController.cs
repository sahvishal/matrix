using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class ReportsQueueController : BaseReportQueueController
    {
        private readonly ISessionContext _sessionContext;

        public ReportsQueueController(ISessionContext sessionContext, ILogManager logManager, IExportableReportsQueueService exportableReportsQueueService)
            : base(logManager, exportableReportsQueueService)
        {
            _sessionContext = sessionContext;
        }

        //
        // GET: /Medical/ReportsQueue/
        [HttpPost]
        public ActionResult TestPerformed(TestPerformedListModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.TestPerformed, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult TestNotPerformed(TestNotPerformedListModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.TestNotPerformed, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult GapsClosureReport(GapsClosureModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.GapsClosure, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult HealthPlanGapsClosureReport(GapsClosureModelFilter filter = null)
        {
            if (filter == null) filter = new GapsClosureModelFilter();
            filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            return CreateExportQueue(filter, ExportableReportType.GapsClosure, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult EventArchiveStats(EventArchiveStatsFilter filter = null)
        {
            if (filter == null) filter = new EventArchiveStatsFilter();

            return CreateExportQueue(filter, ExportableReportType.EventArchiveStats, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public ActionResult DisqualifiedTestReport(DisqualifiedTestReportFilter filter = null)
        {
            if (filter == null) filter = new DisqualifiedTestReportFilter();

            return CreateExportQueue(filter, ExportableReportType.DisqualifiedTestReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
    }
}