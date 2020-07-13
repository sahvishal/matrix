using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;
using File = Falcon.App.Core.Application.Domain.File;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class MedicationController : Controller
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ISessionContext _session;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IFileHelper _fileHelper;
        private readonly ICsvReader _csvReader;
        private readonly JavaScriptSerializer _javaScriptSerializer;
        private readonly IMedicationUploadHelper _medicationUploadHelper;
        private readonly IMedicationUploadRepository _medicationUploadRepository;
        private readonly IMedicationService _medicationService;
        private readonly INdcRepository _ndcRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly int _pageSize;

        public MedicationController(IMediaRepository mediaRepository, ISessionContext session, IUniqueItemRepository<File> fileRepository,
            IFileHelper fileHelper, ICsvReader csvReader, ISettings settings, IMedicationUploadHelper medicationUploadHelper,
            IMedicationUploadRepository medicationUploadRepository, IMedicationService medicationService, INdcRepository ndcRepository,
            ILookupRepository lookupRepository, IUnitRepository unitRepository)
        {
            _mediaRepository = mediaRepository;
            _session = session;
            _fileRepository = fileRepository;
            _fileHelper = fileHelper;
            _csvReader = csvReader;
            _javaScriptSerializer = new JavaScriptSerializer();
            _medicationUploadHelper = medicationUploadHelper;
            _medicationUploadRepository = medicationUploadRepository;
            _medicationService = medicationService;
            _ndcRepository = ndcRepository;
            _pageSize = settings.DefaultPageSizeForReports;
            _lookupRepository = lookupRepository;
            _unitRepository = unitRepository;
        }

        // GET: Medical/Medication

        public ActionResult Upload()
        {
            var uploadMediaLocation = _mediaRepository.GetMedicationUploadMediaFileLocation();
            var model = new MedicationFileUploadEditModel
            {
                UploadCsvMediaUrl = uploadMediaLocation.Url
            };

            System.Web.HttpContext.Current.Response.Headers.Remove("Refresh");
            return View(model);
        }

        public JsonResult CreateResultArchive(string fileName, long fileSize)
        {
            var file = new File
            {
                Path = fileName,
                Type = FileType.Compressed,
                FileSize = fileSize,
                UploadedBy = new OrganizationRoleUser(_session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                UploadedOn = DateTime.Now
            };

            file = _fileRepository.Save(file);

            var medicationUpload = new MedicationUpload
            {
                FileId = file.Id,
                UploadTime = DateTime.Now,
                StatusId = (long)MedicationUploadStatus.UploadStarted,
                UploadedBy = _session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
            };

            medicationUpload = _medicationUploadRepository.Save(medicationUpload);

            //update the file name
            file.Path = _fileHelper.AddPostFixToFileName(file.Path, medicationUpload.Id.ToString());
            _fileRepository.Save(file);


            var editModel = new MedicationFileUploadEditModel
            {
                File = file,
                Id = medicationUpload.Id
            };

            return Json(editModel, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public void ProcessUpload(MedicationFileUploadEditModel medicationEditModel)
        {
            if (Request.Files.Count != 1)
            {
                throw new Exception("File count should not be empty!");
            }

            try
            {
                HttpPostedFileBase postedFile = Request.Files[0];

                decimal returnLength = 0;
                var statuses = new List<FileUploadStatusModel>();
                if (string.IsNullOrEmpty(Request.Headers["X-File-Name"]))
                {
                    UploadWholeFile(postedFile, medicationEditModel.File.Path, statuses);
                    returnLength = medicationEditModel.File.FileSize;
                }
                else
                {
                    returnLength = UploadPartialFile(postedFile, medicationEditModel.File.Path, statuses);
                }
                if (returnLength == medicationEditModel.File.FileSize || returnLength == 0)
                {
                    var resultArchive = _medicationUploadRepository.GetById(medicationEditModel.Id);
                    if (returnLength == medicationEditModel.File.FileSize)
                    {
                        long count = 0;
                        if (IsFileValid(medicationEditModel, out count))
                        {
                            resultArchive.TotalCount = count;
                            resultArchive.StatusId = (long)MedicationUploadStatus.Uploaded;
                        }
                        else
                        {
                            var s = statuses.First();
                            s.Error = medicationEditModel.FeedbackMessage.Message;
                        }
                    }
                    else
                    {
                        resultArchive.StatusId = (long)MedicationUploadStatus.UploadStarted;
                    }
                    _medicationUploadRepository.Save(resultArchive);
                }
                WriteJsonIframeSafe(statuses);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Upload Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
            }
        }

        private bool IsFileValid(MedicationFileUploadEditModel model, out long count)
        {
            try
            {
                var archiveLocation = _mediaRepository.GetMedicationUploadMediaFileLocation();
                _csvReader.Delimiter = _csvReader.GetFileDelimiter(archiveLocation.PhysicalPath + model.File.Path).ToString();
                var medicationTable = _csvReader.ReadWithTextQualifier(archiveLocation.PhysicalPath + model.File.Path);

                count = medicationTable.Rows.Count;
                if (medicationTable.Rows.Count == 0)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Uploaded file has no data.");
                    return false;
                }

                var missingColumnNames = _medicationUploadHelper.CheckForColumns(medicationTable.Rows[0]);
                if (!string.IsNullOrEmpty(missingColumnNames))
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Missing Column Name(s) : " + missingColumnNames);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                count = 0;
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Medication Upload Validation Failure: " + ex.Message + "\n\t" + ex.StackTrace);
                return false;
            }
        }

        private void UploadWholeFile(HttpPostedFileBase file, string fileName, List<FileUploadStatusModel> statuses)
        {
            var archiveLocation = _mediaRepository.GetMedicationUploadMediaFileLocation();
            file.SaveAs(archiveLocation.PhysicalPath + fileName);

            var fname = Path.GetFileName(file.FileName);
            statuses.Add(new FileUploadStatusModel
            {
                FileName = fname,
                Url = archiveLocation.Url + fileName,
                Size = file.ContentLength,
                DeleteUrl = "",   //maybe later..                                     
                Progress = "1.0"
            });

        }

        private long UploadPartialFile(HttpPostedFileBase file, string fileName, List<FileUploadStatusModel> statuses)
        {
            if (Request.Files.Count != 1)
            {
                throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            }

            var archiveLocation = _mediaRepository.GetMedicationUploadMediaFileLocation();
            var inputStream = file.InputStream;
            var fullName = archiveLocation.PhysicalPath + fileName;

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];
                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }

            var length = (new FileInfo(fullName)).Length;
            statuses.Add(new FileUploadStatusModel
            {
                FileName = fileName,
                Url = archiveLocation.Url + fileName,
                Size = (int)length,
                DeleteUrl = "",   //maybe later..                                     
                Progress = "1.0"
            });
            return length;
        }

        private void WriteJsonIframeSafe(List<FileUploadStatusModel> statuses)
        {
            Response.AddHeader("Vary", "Accept");
            try
            {
                if (Request["HTTP_ACCEPT"].Contains("application/json"))
                {
                    Response.ContentType = "application/json";
                }
                else
                {
                    Response.ContentType = "text/plain";
                }
            }
            catch
            {
                Response.ContentType = "text/plain";
            }

            var json = _javaScriptSerializer.Serialize(statuses.ToArray());
            Response.Write(json);
        }

        public ActionResult Log(MedicationUploadListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter != null && filter.Status == 0)
                filter.Status = null;
            if (filter != null && filter.UploadedBy == -1)
                filter.UploadedBy = null;
            var medicationData = _medicationService.GetUploadList(pageNumber, _pageSize, filter, out totalRecords);
            var model = medicationData == null ? new MedicationUploadListModel() : new MedicationUploadListModel { Collection = medicationData };
            model.Filter = filter;
            model.Url = _mediaRepository.GetMedicationUploadMediaFileLocation().Url;

            var values = MedicationUploadStatus.UploadStarted.GetNameValuePairs();
            var status = new List<OrderedPair<long, string>>();
            status.Add(new OrderedPair<long, string>(0, "All"));
            foreach (var source in values.Where(x => x.FirstValue != (long)MedicationUploadStatus.UploadStarted && x.FirstValue != (long)MedicationUploadStatus.FileNotFound))
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

        public PartialViewResult GetMedication(long customerId, DateTime serviceDate)
        {
            var model = new MedicationListModel();
            model.Medications = _medicationService.GetMedications(customerId);
            model.Frequency = _lookupRepository.GetByLookupId((long)MedicationFrequency.AC).OrderBy(x => x.DisplayName);
            model.CustomerId = customerId;
            model.ServiceDate = serviceDate;
            model.Unit = _unitRepository.GetAll();
            return PartialView(model);
        }

        [HttpPost]
        public bool SaveMedication(MedicationListModel model)
        {
            try
            {
                var orgRoleUserId = _session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                _medicationService.SaveMedications(model.Medications, model.CustomerId, orgRoleUserId);
                return true;
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Saving Medications failed! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                return false;
            }
        }

        [HttpPost]
        public JsonResult GetMedicationName(string searchText)
        {
            var names = _ndcRepository.GetBySearchText(searchText);
            return Json(new { d = names.Select(x => x.SecondValue).Distinct().ToList() }, JsonRequestBehavior.AllowGet);
        }
    }
}