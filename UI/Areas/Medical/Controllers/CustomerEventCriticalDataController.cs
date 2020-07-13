using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.MobileControls;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    // [RoleBasedAuthorize] -- For Pdf utilizes one of the Action Results
    public class CustomerEventCriticalDataController : Controller
    {
        private readonly ITestResultService _testResultService;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly int _pageSize;
        private readonly ISessionContext _sessionContext;
        private readonly ICustomerCriticalDataRepository _customerCriticalDataRepository;
        private readonly ITestRepository _testRepository;
        private readonly IEventCustomerCriticalQuestionRepository _eventCustomerCriticalQuestionRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public CustomerEventCriticalDataController(ITestResultService testResultService, IPdfGenerator pdfGenerator, IMediaRepository mediaRepository, ISettings settings, ISessionContext sessionContext,
            ICustomerCriticalDataRepository customerCriticalDataRepository, ITestRepository testRepository, IEventCustomerCriticalQuestionRepository eventCustomerCriticalQuestionRepository, IEventCustomerRepository eventCustomerRepository)
        {
            _testResultService = testResultService;
            _pdfGenerator = pdfGenerator;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _pageSize = settings.DefaultPageSizeForReports;
            _sessionContext = sessionContext;
            _customerCriticalDataRepository = customerCriticalDataRepository;
            _testRepository = testRepository;
            _eventCustomerCriticalQuestionRepository = eventCustomerCriticalQuestionRepository;
            _eventCustomerRepository = eventCustomerRepository;
        }
        //
        // GET: /Medical/CustomerEventCriticalData/
        [RoleBasedAuthorize]
        public ActionResult Edit(long theeventId, long thecustomerId, long thetestId)
        {
            CustomerEventCriticalTestDataEditModel model = null;
            model = _testResultService.GetModel(theeventId, thecustomerId, thetestId);
            return View(model);
        }

        public ActionResult View(long eventId, long customerId, long testId)
        {
            var model = _testResultService.GetCustomerEventCriticalDataViewModel(eventId, customerId, testId);
            return View(model);
        }

        [RoleBasedAuthorize]
        public ActionResult Print(long eventId, long customerId, long testId)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();
            var fileName = "Pdf_" + DateTime.Now.ToFileTimeUtc() + ".pdf";

            //var url = Request.Url.OriginalString.Replace(Request.Url.Query, "");
            // string newpdfpath = url.Replace(Request.Url.AbsolutePath, string.Concat("/Medical/CustomerEventCriticalData/View?eventId=", eventId, "&customerId=", customerId, "&testId=", testId));
            string newpdfpath = _settings.AppUrl + "/Medical/CustomerEventCriticalData/View?eventId=" + eventId + "&customerId=" + customerId + "&testId=" + testId;
            _pdfGenerator.GeneratePdf(newpdfpath, mediaLocation.PhysicalPath + fileName);

            if (mediaLocation.PhysicalPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                throw new InvalidFileNameException();

            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename=\"" + HttpUtility.HtmlEncode(Path.GetFileName(mediaLocation.PhysicalPath + fileName).Replace(Environment.NewLine, "")) + "\"");
            Response.AddHeader("content-length", new FileInfo(mediaLocation.PhysicalPath + fileName).Length.ToString());

            Response.TransmitFile(mediaLocation.PhysicalPath + fileName);

            Response.Flush();
            Response.Close();

            return Content("");
        }

        public ActionResult GetModel(long eventId, long customerId, long testId)
        {
            return Json(_testResultService.GetModel(eventId, customerId, testId));
        }

        [RoleBasedAuthorize]
        public ActionResult GetCustomerEventCriticalData(CustomerEventCriticalDataListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter == null)
                filter = new CustomerEventCriticalDataListModelFilter();
            var model = _testResultService.GetCustomerwithCriticalData(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null)
                model = new CustomerEventCriticalDataListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.CustomerName, filter.CustomerId, filter.FromDate, filter.ToDate, filter.EventId });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        [RoleBasedAuthorize]
        public bool SaveNotes(long eventCustomerResultId, string text)
        {
            var notes = new Notes
            {
                Text = text,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = DateTime.Now,
                    DataRecorderCreator = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                }
            };
            notes = _customerCriticalDataRepository.SaveCriticalNotes(eventCustomerResultId, notes);
            return notes.Id > 0 ? true : false;
        }

        [RoleBasedAuthorize]
        public ActionResult GetNotes(long eventCustomerResultId)
        {
            return Json(_customerCriticalDataRepository.GetNotes(eventCustomerResultId));
        }

        [RoleBasedAuthorize]
        public ActionResult ViewAllCriticalTest(long eventId, long customerId)
        {
            var criticalTestIds = _customerCriticalDataRepository.GetCriticalTestIdDataAvaliablePair(eventId, customerId);
            var allTests = _testRepository.GetAll();
            var criticalTests = (from criticalTestId in criticalTestIds
                                 let test = allTests.Where(t => t.Id == criticalTestId.FirstValue).Single()
                                 select new OrderedPair<Test, bool>(test, criticalTestId.SecondValue)).ToList();
            var model = new AllCriticalTestViewModel
                            {
                                CustomerId = customerId,
                                EventId = eventId,
                                Tests = criticalTests
                            };
            return View(model);
        }

        [RoleBasedAuthorize]
        public ActionResult GetCriticalPatientData(long eventId, long customerId)
        {
            var eventCustomer = _eventCustomerRepository.GetbyCustomerId(customerId).FirstOrDefault(x => x.EventId == eventId);
            if (eventCustomer == null) return Json(null, JsonRequestBehavior.AllowGet);
            var criticalAnswers = _eventCustomerCriticalQuestionRepository.GetByEventCustomerId(eventCustomer.Id);

            var model = new PatientCriticalDataEditModel
            {
                EventCustomerId = eventCustomer.Id
            };
            var answers = new List<CriticalQuestionAnswerEditModel>();

            if (!criticalAnswers.IsNullOrEmpty())
            {
                foreach (var answer in criticalAnswers)
                {
                    answers.Add(new CriticalQuestionAnswerEditModel { QuestionId = answer.QuestionId, Answer = answer.Answer, Note = answer.Note });
                }
            }
            model.Answers = answers;

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [RoleBasedAuthorize]
        public bool SaveCriticalPatientData(PatientCriticalDataEditModel model)
        {
            if (model != null && !model.Answers.IsNullOrEmpty())
            {
                _eventCustomerCriticalQuestionRepository.DeleteByEventCustomerId(model.EventCustomerId);

                foreach (var answer in model.Answers)
                {
                    _eventCustomerCriticalQuestionRepository.Save(new EventCustomerCriticalQuestion
                    {
                        EventCustomerId = model.EventCustomerId,
                        QuestionId = answer.QuestionId,
                        Answer = answer.Answer,
                        Note = answer.Note
                    });
                }

                return true;
            }

            return false;
        }
    }
}
