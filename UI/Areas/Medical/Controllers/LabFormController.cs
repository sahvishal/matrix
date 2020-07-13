using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.UI.Extentions;
using System;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;


namespace Falcon.App.UI.Areas.Medical.Controllers
{
    public class LabFormController : Controller
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        //private readonly IPdfGenerator _pdfGenerator;
        private readonly ILabFormService _labFormService;

        public LabFormController(ISettings settings, ILogManager logManager, IMediaRepository mediaRepository,  ILabFormService labFormService)
        {
            _settings = settings;
            _logger = logManager.GetLogger<LabFormController>();
            _mediaRepository = mediaRepository;
            //_pdfGenerator = IoC.Resolve<PdfGenerator>();
            _labFormService = labFormService;
        }

        [RoleBasedAuthorize]
        public ActionResult PrintIFobtLabForm(long customerId, long eventId)
        {
            string pdfUrl = string.Empty;
            try
            {
                if (eventId < 0) return null;

                var mediaLocation = _mediaRepository.GetTempMediaFileLocation();

                var fileName = "IFOBTLabForm_" + eventId + "_" + customerId + ".pdf";
                var pdfGenerator = IoC.Resolve<IPdfGenerator>();
                var url = _settings.AppUrl + "/Medical/LabForm/IFobtLabForm?eventId=" + eventId + "&customerId=" + customerId;

                pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
                pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

                pdfUrl = mediaLocation.Url + "/" + fileName;

            }
            catch (Exception ex)
            {
                _logger.Error("Error occured while generating  Pdf.  Message: " + ex.Message + "  stack Trace: " + ex.StackTrace);

                return Content(pdfUrl);
            }

            Response.RedirectUser(pdfUrl);
            return null;
        }

        public ActionResult IFobtLabForm(long customerId, long eventId)
        {
            var model = _labFormService.GetIfobtLabFormViewModel(eventId, customerId);
            return PartialView(model);
        }

        [RoleBasedAuthorize]
        public ActionResult PrintMicroalbuminLabForm(long customerId, long eventId)
        {
            string pdfUrl = string.Empty;
            try
            {
                if (eventId < 0) return null;

                var mediaLocation = _mediaRepository.GetTempMediaFileLocation();

                var fileName = "MicroalbuminLabForm_" + eventId + "_" + customerId + ".pdf";
                var pdfGenerator = IoC.Resolve<IPdfGenerator>();
                var url = _settings.AppUrl + "/Medical/LabForm/MicroalbuminLabForm?eventId=" + eventId + "&customerId=" + customerId;
                pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
                pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

                pdfUrl = mediaLocation.Url + "/" + fileName;

            }
            catch (Exception ex)
            {
                _logger.Error("Error occured while generating  Pdf.  Message: " + ex.Message + "  stack Trace: " + ex.StackTrace);
                return Content(pdfUrl);
            }

            Response.RedirectUser(pdfUrl);
            return null;
        }

        public ActionResult MicroalbuminLabForm(long eventId, long customerId)
        {
            var model = _labFormService.GetMicroalbumineLabFormViewModel(eventId, customerId);

            return PartialView(model);
        }
    }
}
