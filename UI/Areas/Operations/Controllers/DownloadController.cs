using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    public class DownloadController : Controller
    {
        private readonly int _pageSize;
        private readonly ISessionContext _sessionContext;
        private readonly IExportableReportsQueueService _exportableReportsQueueService;

        public DownloadController(ISettings settings, ISessionContext sessionContext, IExportableReportsQueueService exportableReportsQueueService)
        {
            _pageSize = settings.DefaultPageSizeForReports;
            _sessionContext = sessionContext;
            _exportableReportsQueueService = exportableReportsQueueService;
        }

        //
        // GET: /Operations/Download/
        public ActionResult Index(ExportableReportsQueueFilter filter, int pageNumber = 1)
        {
            int totalRecords = 0;

            filter.RequestedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            var model = _exportableReportsQueueService.GetExportableReportQueue(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new ExportableReportsQueueListModel();

            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new
            {
                pageNumber = pn, 
                filter.ReportId,
                filter.FromDate, 
                filter.ToDate,
                filter.RequestedBy
            });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
    }
}