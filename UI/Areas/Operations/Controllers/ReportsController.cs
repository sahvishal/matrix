using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{

    public class ReportsController : Controller
    {
        private readonly IOperationsReportingService _operationsReportingService;
        private readonly ISettings _settings;
        private readonly IMediaRepository _mediaRepository;
        private readonly IPatientWorksheetService _patientWorksheetService;


        public ReportsController(IOperationsReportingService operationsReportingService, ISettings settings, IMediaRepository mediaRepository, IPatientWorksheetService patientWorksheetService)
        {
            _operationsReportingService = operationsReportingService;
            _settings = settings;
            _pageSize = settings.DefaultPageSizeForReports;
            _mediaRepository = mediaRepository;
            _patientWorksheetService = patientWorksheetService;
        }

        private readonly int _pageSize;

        [RoleBasedAuthorize]
        public ActionResult CdImageStatus(CdImageStatusModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;
            var model = _operationsReportingService.GetCdImageStatusmodel(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null) model = new CdImageStatusListModel();

            model.Filter = filter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new { pageNumber = pn, filter.FromDate, filter.ToDate });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        [RoleBasedAuthorize]
        public ActionResult CustomerLabels(long eventId = 0, int shippingStatus = 1)
        {
            var model = new CustomerLabelListModel
                                               {
                                                   ShippingStatus = shippingStatus
                                               };
            if (eventId < 1) return View(model);

            model = _operationsReportingService.GetCustomerLabels(eventId, shippingStatus);
            if (model != null)
            {
                model.EventId = eventId;
                model.ShippingStatus = shippingStatus;
            }
            return View(model);
        }

        [HttpPost]
        public ContentResult GeneratePdf(long eventId = 0, int shippingStatus = 1)
        {

            if (eventId < 0) return null;
            var model = _operationsReportingService.GetCustomerLabels(eventId, shippingStatus);

            var pdfConverterPath = Server.MapPath(@"~\bin");

            string view = RenderView(@"~\Config\Content\Views\Shared\CustomerLabelListModel.cshtml", model);

            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var wkHtmltoPdfSwitches =
            new WkHtmltoPdfSwitches()
                {
                    MarginBottom = 0.5m,
                    MarginRight = 0.5m,
                    MarginLeft = 1.5m,
                    MarginTop = 0.25m,
                    PageSize = "Letter",
                    RedirectDelay = 100
                };

            var pdfGenerator = IoC.Resolve<IPdfGenerator>();
            pdfGenerator.SetDefaultSwitch(wkHtmltoPdfSwitches);

            var pdfname = pdfGenerator.Generate(new StringBuilder(view), mediaLocation.PhysicalPath, pdfConverterPath);

            var pdfUrl = mediaLocation.Url + "/" + pdfname;

            return Content(pdfUrl);

        }


        private string RenderView<TModel>(string viewPath, TModel model, TempDataDictionary tempData = null)
        {
            var view = new RazorView(
                ControllerContext,
                viewPath: viewPath,
                layoutPath: null,
                runViewStartPages: false,
                viewStartFileExtensions: null
            );

            var writer = new StringWriter();
            var viewContext = new ViewContext(ControllerContext, view, new ViewDataDictionary<TModel>(model), tempData ?? new TempDataDictionary(), writer);
            view.Render(viewContext, writer);
            return writer.ToString();
        }

        public ActionResult BloodworksLabels(long eventId)
        {
            var model = _operationsReportingService.GetBloodworksLabel(eventId);

            return View(model);
        }

        public ActionResult BloodworksLabelForCustomer(long eventId, long customerId)
        {
            var model = _operationsReportingService.GetBloodworksLabelForCustomer(eventId, customerId);
            return View(model);
        }

        [RoleBasedAuthorize]
        public ContentResult GenerateBloodworksLabelForCustomerPdf(long eventId, long customerId)
        {

            if (eventId < 0) return null;
            var model = _operationsReportingService.GetBloodworksLabelForCustomer(eventId, customerId);

            var pdfConverterPath = Server.MapPath(@"~\bin");

            string view = RenderView(@"~\Areas\Operations\Views\Reports\BloodworksLabelForCustomer.cshtml", model);

            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var wkHtmltoPdfSwitches =
                new WkHtmltoPdfSwitches
                    {
                        MarginBottom = 0,
                        MarginRight = 0,
                        MarginLeft = 0,
                        MarginTop = 0,
                        PageSize = "",
                        PageWidth = 102,
                        PageHeight = 59,
                        RedirectDelay = 100
                    };

            var pdfGenerator = IoC.Resolve<IPdfGenerator>();
            pdfGenerator.SetDefaultSwitch(wkHtmltoPdfSwitches);

            var pdfname = pdfGenerator.Generate(new StringBuilder(view), mediaLocation.PhysicalPath, pdfConverterPath);

            var pdfUrl = mediaLocation.Url + "/" + pdfname;

            return Content(pdfUrl);

        }

        public ActionResult CdLabels(long eventId)
        {
            var model = _operationsReportingService.GetCdLabelForEvent(eventId);
            return View(model);
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ContentResult GenerateCdLabelForEventPdf(long eventId)
        {

            if (eventId < 0) return null;
            var model = _operationsReportingService.GetCdLabelForEvent(eventId);

            var pdfConverterPath = Server.MapPath(@"~\bin");

            string view = RenderView(@"~\Areas\Operations\Views\Reports\CdLabels.cshtml", model);

            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var wkHtmltoPdfSwitches = new WkHtmltoPdfSwitches
                                          {
                                              MarginBottom = 0,
                                              MarginRight = 0,
                                              MarginLeft = 0,
                                              MarginTop = 0,
                                              PageSize = "",
                                              PageWidth = 54,
                                              PageHeight = 25,
                                              RedirectDelay = 100
                                          };

            var pdfGenerator = IoC.Resolve<IPdfGenerator>();
            pdfGenerator.SetDefaultSwitch(wkHtmltoPdfSwitches);

            var pdfname = pdfGenerator.Generate(new StringBuilder(view), mediaLocation.PhysicalPath, pdfConverterPath);

            var pdfUrl = mediaLocation.Url + "/" + pdfname;

            return Content(pdfUrl);

        }

        [RoleBasedAuthorize]
        public ActionResult BloodworkRequisitionFormPdf(long eventId, long customerId)
        {
            string pdfUrl = string.Empty;
            try
            {
                if (eventId < 0) return null;
                var pdfGenerator = IoC.Resolve<IPdfGenerator>();
                var mediaLocation = _mediaRepository.GetTempMediaFileLocation();

                var fileName = "BloodrequisitionForm_" + eventId + "_" + customerId + ".pdf";

                var url = _settings.AppUrl + "/Operations/Reports/BloodworkRequisitionForm?eventId=" + eventId + "&customerId=" + customerId;
                pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
                pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

                pdfUrl = mediaLocation.Url + "/" + fileName;

            }
            catch (Exception)
            {
                return Content(pdfUrl);
            }
            Response.RedirectUser(pdfUrl);
            return null;
        }

        public ActionResult BloodworkRequisitionForm(long eventId, long customerId)
        {
            var model = _operationsReportingService.GetBloodworksLabelForCustomer(eventId, customerId);

            return PartialView(model);
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ContentResult GenerateBatchLabelPdf(long eventId)
        {

            if (eventId < 0) return null;
            var model = _operationsReportingService.GetBatchLabelsForEvent(eventId);

            var pdfConverterPath = Server.MapPath(@"~\bin");

            string view = RenderView(@"~\Areas\Operations\Views\Reports\BatchLabels.cshtml", model);

            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var wkHtmltoPdfSwitches = new WkHtmltoPdfSwitches
            {
                MarginBottom = 0,
                MarginRight = 0,
                MarginLeft = 0,
                MarginTop = 0,
                PageSize = "",
                PageWidth = 70,
                PageHeight = 25,
                RedirectDelay = 100
            };

            var pdfGenerator = IoC.Resolve<IPdfGenerator>();
            pdfGenerator.SetDefaultSwitch(wkHtmltoPdfSwitches);

            var pdfname = pdfGenerator.Generate(new StringBuilder(view), mediaLocation.PhysicalPath, pdfConverterPath);

            var pdfUrl = mediaLocation.Url + "/" + pdfname;

            return Content(pdfUrl);

        }

        [RoleBasedAuthorize]
        public ActionResult PatientWorksheet(long customerId, long eventId, bool printPatientWorkSheet, bool printScreeningInfo)
        {
            string pdfUrl = string.Empty;
            try
            {
                if (eventId < 0) return null;
                var pdfGenerator = IoC.Resolve<IPdfGenerator>();
                var mediaLocation = _mediaRepository.GetTempMediaFileLocation();

                var fileName = "PatientWorksheet_" + eventId + "_" + customerId + ".pdf";

                var url = _settings.AppUrl + "/Operations/Reports/PatientWorksheetForm?eventId=" + eventId + "&customerId=" + customerId + "&printPatientWorkSheet=" + printPatientWorkSheet + "&printScreeningInfo=" + printScreeningInfo;
                pdfGenerator.AllowLoadingJavascriptbeforePdfGenerate = true;
                pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

                pdfUrl = mediaLocation.Url + "/" + fileName;

            }
            catch (Exception)
            {
                return Content(pdfUrl);
            }

            Response.RedirectUser(pdfUrl);
            return null;
        }

        public ActionResult PatientWorksheetForm(long customerId, long eventId, bool printPatientWorkSheet, bool printScreeningInfo)
        {
            var model = _patientWorksheetService.GetPatientWorksheetModel(customerId, eventId);
            model.PrintScreeningInfo = printScreeningInfo;
            model.PrintPatientWorkSheet = printPatientWorkSheet;
            return PartialView(model);
        }

    }
}
