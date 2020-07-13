using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.CallCenter.Controllers
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
        public ActionResult OutreachCallReport(OutreachCallReportModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.OutreachCallReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public ActionResult CallQueueSchedulingReport(CallQueueSchedulingReportFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.CallQueueSchedulingReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
        public ActionResult CallQueueExcludedCustomerReport(CallQueueExcludedCustomerReportModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.CallQueueExcludedCustomerReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
        public ActionResult CallQueueCustomers(OutboundCallQueueFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.CallQueueCustomerReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public ActionResult CustomerWithNoEventsInAreaReport(CustomerWithNoEventsInAreaReportModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.CustomerWithNoEventsInAreaReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public ActionResult CallCenterCallReport(CallCenterCallReportModelFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.CallCenterCallReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public ActionResult ConfirmationReport(ConfirmationReportFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.ConfirmationReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public ActionResult CallSkippedReport(CallSkippedReportFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.CallSkippedReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public ActionResult ExcludedCustomerReport(OutboundCallQueueFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.ExcludedCustomerReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public ActionResult PreAssessmentReport(PreAssessmentReportFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.PreAssessmentReport, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
    }
}