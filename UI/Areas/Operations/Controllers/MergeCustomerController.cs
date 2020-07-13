using System;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    public class MergeCustomerController : Controller
    {
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ISessionContext _session;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly IMergeCustomerUploadHelper _mergeCustomerUploadHelper;
        private readonly IMergeCustomerUploadRepository _mergeCustomerUploadRepository;
        private readonly int _pageSize;
        private readonly IMergeCustomerUploadService _mergeCustomerUploadService;

        public MergeCustomerController(IUniqueItemRepository<File> fileRepository, ISessionContext session, IMediaRepository mediaRepository, ICsvReader csvReader,
            IMergeCustomerUploadHelper mergeCustomerUploadHelper, IMergeCustomerUploadRepository mergeCustomerUploadRepository, ISettings settings, IMergeCustomerUploadService mergeCustomerUploadService)
        {
            _fileRepository = fileRepository;
            _session = session;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _mergeCustomerUploadHelper = mergeCustomerUploadHelper;
            _mergeCustomerUploadRepository = mergeCustomerUploadRepository;
            _mergeCustomerUploadService = mergeCustomerUploadService;
            _pageSize = settings.DefaultPageSizeForReports;
        }


        public ActionResult Upload()
        {
            var sampleMediaLocation = _mediaRepository.GetSamplesLocation();
            var model = new MergeCustomerEditModel
            {
                UploadCsvMediaUrl = sampleMediaLocation.Url
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Upload(MergeCustomerEditModel model)
        {
            var sampleMediaLocation = _mediaRepository.GetSamplesLocation();
            var uploadMediaLocation = _mediaRepository.GetMergeCustomerUploadMediaFileLocation();
            model.UploadCsvMediaUrl = sampleMediaLocation.Url;

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
            var missingColumnNames = _mergeCustomerUploadHelper.CheckForColumns(customerTable.Rows[0]);
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

            var mergeCustomerUpload = new MergeCustomerUpload
            {
                FileId = file.Id,
                StatusId = (long)MergeCustomerUploadStatus.Uploaded,
                UploadedBy = _session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                UploadTime = DateTime.Now
            };

            mergeCustomerUpload = _mergeCustomerUploadRepository.Save(mergeCustomerUpload);

            if (mergeCustomerUpload != null && mergeCustomerUpload.Id > 0)
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("File Uploaded Successfull.");

            return View(model);
        }

        public ActionResult UploadDetail(MergeCustomerUploadListModelFilter filter = null, int pageNumber = 1)
        {
            try
            {
                
                int totalRecords;
                var model = _mergeCustomerUploadService.GetMergeCustomerUploadDetails(pageNumber, _pageSize, filter, out totalRecords);

                
                if (model == null)
                    model = new MergeCustomerUploadListModel();
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
                var model = new MergeCustomerUploadListModel();
                model.Filter = filter;
                return View(model);
            }

        }
    }
}
