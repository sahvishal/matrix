using System;
using System.Web.Mvc;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;

namespace Falcon.App.UI.Controllers
{
    public class BaseReportQueueController : Controller
    {
        private readonly ILogger _logger;

        private readonly IExportableReportsQueueService _exportableReportsQueueService;
        public BaseReportQueueController(ILogManager logManager, IExportableReportsQueueService exportableReportsQueueService)
        {
            _logger = logManager.GetLogger<Global>();
            _exportableReportsQueueService = exportableReportsQueueService;
        }
        // GET: BaseReportQueue
        protected JsonResult CreateExportQueue(object filter, ExportableReportType reportType, long requestedBy)
        {
            try
            {
                _exportableReportsQueueService.SaveExportableReportsQueue(filter, (long)reportType, requestedBy);
                var result = new { IsQueued = true, Message = "Request queued sucessfully." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error(reportType.GetDescription() + "csv queue Error");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);

                var result = new { IsQueued = false, Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}