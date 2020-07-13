using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falcon.App.UI.Areas.FileManager.Controllers
{
    public class DownloadController : Controller
    {

        private readonly ICorporateUploadService _corporateUploadService;
        private readonly ILogger _logger;
        public DownloadController(ICorporateUploadService corporateUploadService,ILogManager logManager)
        {
            _corporateUploadService = corporateUploadService;
            _logger = logManager.GetLogger<DownloadController>();
        }

        // GET: /FileManager/Download/
        public ActionResult Index()
        {
            return View();
        }

        public void DownlaodMemberUploadDetailsReportFile(string FileName)
        {
            try
            {

                var FullPath = _corporateUploadService.DownlaodFilePath(FileName);

                Response.ContentType = "text/plain";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
                Response.TransmitFile(FullPath);
                Response.End();
            }
            catch(Exception ex) {
                _logger.Info("Member Upload Details Report Download Error: " + ex.ToString());
            }
        }
	}
}