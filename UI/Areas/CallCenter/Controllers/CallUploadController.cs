using System;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]
    public class CallUploadController : Controller
    {
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ISessionContext _session;
        private readonly IMediaRepository _mediaRepository;
        private readonly int _pageSize;
        private readonly ICallUploadRepository _callUploadRepository;
        private readonly ICsvReader _csvReader;
        private readonly ICallUploadService _callUploadService;
        private readonly ICallUploadHelper _callUploadHelper;


        public CallUploadController(IUniqueItemRepository<File> fileRepository, ISessionContext session, IMediaRepository mediaRepository, ISettings settings, ICallUploadRepository callUploadRepository, ICsvReader csvReader,
            ICallUploadService callUploadService, ICallUploadHelper callUploadHelper)
        {
            _fileRepository = fileRepository;
            _session = session;
            _mediaRepository = mediaRepository;
            _pageSize = settings.DefaultPageSizeForReports;
            _callUploadRepository = callUploadRepository;
            _csvReader = csvReader;
            _callUploadService = callUploadService;
            _callUploadHelper = callUploadHelper;
        }

        public ActionResult CallUploadDetail(CallUploadListModelFilter filter = null, int pageNumber = 1)
        {
            try
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Call Upload Index method called @" + DateTime.Now);
                int totalRecords;
                var model = _callUploadService.GetCallUploadDetails(pageNumber, _pageSize, filter, out totalRecords);

                IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Call Upload Result returned from service @" + DateTime.Now);
                if (model == null)
                    model = new CallUploadListModel();
                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                Func<int, string> urlFunc =
                    pn =>
                        Url.Action(currentAction,
                            new
                            {
                                pageNumber = pn,
                                filter.FromUploadDate,
                                filter.ToUploadDate,
                                filter.UploadedBy
                            });

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Call Upload going to return view @" + DateTime.Now);

                return View(model);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error(ex.Message);
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Call Upload Stack Trace :" + ex.StackTrace);
                var model = new CallUploadListModel();
                model.Filter = filter;
                return View(model);
            }

        }

        public ActionResult Upload()
        {
            var uploadMediaLocation = _mediaRepository.GetCallUploadMediaFileLocation();
            var model = new CallUploadEditModel
            {
                UploadCsvMediaUrl = uploadMediaLocation.Url
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Upload(CallUploadEditModel model)
        {
            var uploadMediaLocation = _mediaRepository.GetCallUploadMediaFileLocation();
            model.UploadCsvMediaUrl = uploadMediaLocation.Url;

            HttpPostedFileBase postedFile = Request.Files[0];           

            if (postedFile == null || postedFile.ContentLength < 1)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("No file has been uploaded. Please upload a csv file.");
                return View(model);
            }

            if (System.IO.Path.GetExtension(postedFile.FileName).ToLower() != ".csv")
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Please upload a csv file!");
                return View(model);
            }

            var physicalPath = uploadMediaLocation.PhysicalPath;

            var fileContent = System.IO.Path.GetFileNameWithoutExtension(postedFile.FileName) + "_" + DateTime.Now.ToString("MMddyyyyhhmmss") + System.IO.Path.GetExtension(postedFile.FileName);

            var fullPath = physicalPath + fileContent;
            postedFile.SaveAs(fullPath);

            var customerTable = _csvReader.ReadWithTextQualifier(fullPath);
            if (customerTable.Rows.Count == 0)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Uploaded file has no data.");
                return View(model);
            }

            var missingColumnNames = _callUploadHelper.CheckForColumns(customerTable.Rows[0]);
            if (!string.IsNullOrEmpty(missingColumnNames))
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Missing Column Name(s) : " + missingColumnNames);
                return View(model);
            }

            var file = new File
            {
                Path = fileContent,
                FileSize = postedFile.ContentLength,
                Type = FileType.Csv,
                UploadedBy = new OrganizationRoleUser(_session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                UploadedOn = DateTime.Now
            };

            file = _fileRepository.Save(file);

            var callUpload = new CallUpload
            {
                FileId = file.Id,
                UploadTime = DateTime.Now,
                StatusId = (long)CallUploadStatus.Uploaded,
                UploadedBy = _session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
            };

            callUpload = _callUploadRepository.Save(callUpload);

            if (callUpload != null && callUpload.Id > 0)
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("File Uploaded Successfull.");

            return View(model);
        }
    }
}