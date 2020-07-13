using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class SuspectConditionController : Controller
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ISessionContext _session;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ISuspectConditionUploadRepository _suspectConditionUploadRepository;
        private readonly ISuspectConditionUploadHelper _suspectConditionUploadHelper;
        private readonly ISuspectConditionService _SuspectConditionService;
        private readonly ISuspectConditionUploadLogRepository _suspectConditionUploadLogRepository;
        private readonly int _pageSize;

        public SuspectConditionController(IMediaRepository mediaRepository, ISessionContext session, IUniqueItemRepository<File> fileRepository,
            ISuspectConditionUploadRepository suspectConditionUploadRepository, ISuspectConditionUploadHelper suspectConditionUploadHelper, ISuspectConditionService SuspectConditionService,
            ISettings settings, ISuspectConditionUploadLogRepository suspectConditionUploadLogRepository)
        {
            _mediaRepository = mediaRepository;
            _session = session;
            _fileRepository = fileRepository;
            _suspectConditionUploadRepository = suspectConditionUploadRepository;
            _suspectConditionUploadHelper = suspectConditionUploadHelper;
            _SuspectConditionService = SuspectConditionService;
            _pageSize = settings.DefaultPageSizeForReports;
            _suspectConditionUploadLogRepository = suspectConditionUploadLogRepository;
        }

        public ActionResult Upload()
        {
            var sampleCsvMediaUrl = _mediaRepository.GetSamplesLocation();
            var model = new SuspectConditionFileUploadEditModel
            {
                SampleCsvMediaUrl = sampleCsvMediaUrl.Url
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Upload(SuspectConditionFileUploadEditModel model, HttpPostedFileBase suspectConditionUploadFile)
        {
            if (Request.Files.Count < 1 || suspectConditionUploadFile == null)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("No file has been uploaded. Please upload a csv file.");
                return View(model);
            }

            var uploadMediaLocation = _mediaRepository.GetSuspectConditionUploadMediaFileLocation();

            model.SampleCsvMediaUrl = _mediaRepository.GetSamplesLocation().Url;

            HttpPostedFileBase file = Request.Files[0];
            var physicalPath = uploadMediaLocation.PhysicalPath;
            var fileUploadedName = (Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName)).Replace("'", "").Replace("&", "");

            var fileName = (Path.GetFileNameWithoutExtension(fileUploadedName) + "_" + DateTime.Now.ToString("MMddyyyyhhmmss") + Path.GetExtension(fileUploadedName)).Replace("'", "").Replace("&", "");

            var fullPath = physicalPath + fileName;
            file.SaveAs(fullPath);

            var csvReader = IoC.Resolve<ICsvReader>();
            var customerTable = csvReader.ReadWithTextQualifier(fullPath);
            if (customerTable.Rows.Count == 0)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Uploaded file has no data.");
                return View(model);
            }

            var columns = customerTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            var missingColumnNames = _suspectConditionUploadHelper.CheckForColumns(columns);
            if (!string.IsNullOrEmpty(missingColumnNames))
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Missing Column Name(s) : " + missingColumnNames);
                return View(model);
            }

            var files = new Core.Application.Domain.File
            {
                Path = fileName,
                FileSize = file.ContentLength,
                Type = FileType.Csv,
                UploadedBy = new OrganizationRoleUser(_session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                UploadedOn = DateTime.Now
            };
            files = _fileRepository.Save(files);

            var suspectConditionUpload = new SuspectConditionUpload
            {
                FileId = files.Id,
                UploadTime = DateTime.Now,
                StatusId = (long)SuspectConditionUploadStatus.UploadStarted,
                UploadedBy = _session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                TotalCount = customerTable.Rows.Count,
                ParseStartTime = DateTime.Now
            };
            suspectConditionUpload = _suspectConditionUploadRepository.Save(suspectConditionUpload);

            model.TotalRecords = customerTable.Rows.Count;
            model.IsUploadSucceded = true;
            model.IsParseSucceded = false;
            model.FileName = fileName;

            model.FailedRecordsFile = Path.GetFileNameWithoutExtension(fileName) + "_Failed" + ".csv";

            if (suspectConditionUpload != null && suspectConditionUpload.Id > 0)
                model.SuspectConditionUploadId = suspectConditionUpload.Id;

            var failureRecords = uploadMediaLocation.PhysicalPath + model.FailedRecordsFile;
            _suspectConditionUploadHelper.CreateHeaderFileRecord(failureRecords, customerTable);

            return View(model);
        }

        [HttpPost]
        public JsonResult UploadSuspectConditions(UploadSuspectCondition model)
        {
            var fileName = model.FileName;
            var pageSize = model.PageSize;
            var failedRecordsFile = model.FailedRecordsFile;
            var pageNumber = model.PageNumber;

            var suspectConditionModel = new SuspectConditionFileUploadEditModel { FileName = fileName, SuspectConditionUploadId = model.SuspectConditionUploadId };

            var mediaLocation = _mediaRepository.GetSuspectConditionUploadMediaFileLocation();
            var file = mediaLocation.PhysicalPath + suspectConditionModel.FileName;

            var csvReader = IoC.Resolve<ICsvReader>();

            var failureRecords = mediaLocation.PhysicalPath + failedRecordsFile;
            var failedRecordsList = new List<SuspectConditionUploadLog>();

            var customerTable = csvReader.ReadWithTextQualifier(file);
            try
            {
                var query = customerTable.AsEnumerable();

                var rows = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                var customerToRender = rows.Count();
                var suspectConditionUploadLogs = rows.Select(row => _suspectConditionUploadHelper.GetUploadLog(row, model.SuspectConditionUploadId)).ToList();

                suspectConditionModel.TotalRecords = customerTable.Rows.Count;

                _SuspectConditionService.ParseSuspectCondition(suspectConditionUploadLogs, failedRecordsList);

                if (failedRecordsList.Any())
                {
                    var suspectConditionFailedRecords = Mapper.Map<IEnumerable<SuspectConditionUploadLog>, IEnumerable<SuspectConditionUploadLogViewModel>>(failedRecordsList);
                    _suspectConditionUploadHelper.UpdateFailedRecords(failureRecords, suspectConditionFailedRecords);

                    if (model.LogFileId < 1)
                    {
                        var fileInfo = new FileInfo(failureRecords);

                        var files = new Core.Application.Domain.File
                        {
                            Path = fileInfo.Name,
                            FileSize = fileInfo.Length,
                            Type = FileType.Csv,
                            UploadedBy = new OrganizationRoleUser(_session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                            UploadedOn = DateTime.Now
                        };

                        files = _fileRepository.Save(files);

                        model.LogFileId = files.Id;
                    }
                }

                var totalPages = suspectConditionModel.TotalRecords / pageSize + (suspectConditionModel.TotalRecords % pageSize != 0 ? 1 : 0);

                suspectConditionModel.FailedRecords = failedRecordsList.Count;
                suspectConditionModel.UploadedRecords = customerToRender - suspectConditionModel.FailedRecords;
                suspectConditionModel.IsParseSucceded = totalPages == pageNumber;

                if (suspectConditionModel.SuspectConditionUploadId > 0 && suspectConditionModel.IsParseSucceded)
                {
                    var count = _suspectConditionUploadLogRepository.GetUploadFailedCount(suspectConditionModel.SuspectConditionUploadId);

                    var suspectConditionUpload = _suspectConditionUploadRepository.GetById(suspectConditionModel.SuspectConditionUploadId);
                    suspectConditionUpload.SuccessfullUploadCount = (suspectConditionModel.TotalRecords - count);
                    suspectConditionUpload.FailedUploadCount = count;

                    if (model.LogFileId > 0)
                        suspectConditionUpload.LogFileId = model.LogFileId;
                    suspectConditionUpload.StatusId = (long)SuspectConditionUploadStatus.Parsed;
                    suspectConditionUpload.ParseEndTime = DateTime.Now;

                    _suspectConditionUploadRepository.Save(suspectConditionUpload);

                    suspectConditionModel.FailedRecordsListPath = _suspectConditionUploadHelper.CheckIsFileContainsRecord(mediaLocation, failedRecordsFile);
                }
            }
            catch (Exception ex)
            {
                var suspectConditionUpload = _suspectConditionUploadRepository.GetById(suspectConditionModel.SuspectConditionUploadId);

                var count = _suspectConditionUploadLogRepository.GetUploadFailedCount(suspectConditionModel.SuspectConditionUploadId);

                suspectConditionUpload.SuccessfullUploadCount = (suspectConditionModel.TotalRecords - count);
                suspectConditionUpload.FailedUploadCount = count;
                suspectConditionUpload.StatusId = (long)SuspectConditionUploadStatus.ParseFailed;
                suspectConditionUpload.ParseEndTime = DateTime.Now;
                if (model.LogFileId > 0)
                    suspectConditionUpload.LogFileId = model.LogFileId;
                _suspectConditionUploadRepository.Save(suspectConditionUpload);
                suspectConditionModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(ex.Message);
            }

            return Json(new
            {
                suspectConditionModel.FileName,
                UploadedRecords = suspectConditionModel.UploadedRecords,
                FailedRecords = suspectConditionModel.FailedRecords,
                suspectConditionModel.IsParseSucceded,
                PageNumber = pageNumber + 1,
                FailedRecordsListPath = suspectConditionModel.FailedRecordsListPath,
                LogFileId = model.LogFileId,
                suspectConditionModel.FeedbackMessage,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Log(SuspectConditionUploadListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter != null && filter.Status == 0)
                filter.Status = null;
            if (filter != null && filter.UploadedBy == -1)
                filter.UploadedBy = null;

            var SuspectConditionData = _SuspectConditionService.GetUploadList(pageNumber, _pageSize, filter, out totalRecords);
            var model = SuspectConditionData == null ? new SuspectConditionUploadListModel() : new SuspectConditionUploadListModel { Collection = SuspectConditionData };
            model.Filter = filter;
            model.Url = _mediaRepository.GetSuspectConditionUploadMediaFileLocation().Url;

            var values = SuspectConditionUploadStatus.UploadStarted.GetNameValuePairs();
            var status = new List<OrderedPair<long, string>>();

            status.Add(new OrderedPair<long, string>(0, "All"));

            foreach (var source in values.Where(x => x.FirstValue != (long)SuspectConditionUploadStatus.UploadStarted && x.FirstValue != (long)SuspectConditionUploadStatus.FileNotFound))
            {
                status.Add(new OrderedPair<long, string>(source.FirstValue, source.SecondValue));
            }

            ViewBag.Status = status;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                filter != null ? Url.Action(currentAction,
                    new
                    {
                        pageNumber = pn,
                        filter.Name,
                        filter.FromDate,
                        filter.ToDate,
                        filter.Status,
                    }) : null;
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }
    }
}