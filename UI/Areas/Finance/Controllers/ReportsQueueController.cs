using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Finance.Controllers
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

        [HttpPost]
        public ActionResult GiftCertificate(GiftCertificateReportFilter filter = null)
        {
            return CreateExportQueue(filter, ExportableReportType.GiftCertificate, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
    }
}