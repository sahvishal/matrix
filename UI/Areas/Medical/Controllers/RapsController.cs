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
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels; 
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Medical.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class RapsController : Controller
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ISessionContext _session;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IRapsUploadRepository _rapsUploadRepository;
        private readonly IFileHelper _fileHelper;
        private readonly IRapsUploadHelper _rapsUploadHelper;
        private readonly ICsvReader _csvReader;
        private readonly IRapsService _rapsService;
        private readonly JavaScriptSerializer _javaScriptSerializer;
        private readonly int _pageSize;

        public RapsController(IMediaRepository mediaRepository, ISessionContext session, IUniqueItemRepository<File> fileRepository,
            IRapsUploadRepository rapsUploadRepository, IFileHelper fileHelper, IRapsUploadHelper rapsUploadHelper, ICsvReader csvReader,ISettings settings,
            IRapsService rapsService)
        {
            _mediaRepository = mediaRepository;
            _session = session;
            _fileRepository = fileRepository;
            _rapsUploadRepository = rapsUploadRepository;
            _fileHelper = fileHelper;
            _rapsUploadHelper = rapsUploadHelper;
            _csvReader = csvReader;
            _rapsService = rapsService;
            _javaScriptSerializer = new JavaScriptSerializer();
            _pageSize = settings.DefaultPageSizeForReports;
        }

        // GET: /Medical/Raps/Upload
        public ActionResult Upload()
        {
            var uploadMediaLocation = _mediaRepository.GetRapsUploadMediaFileLocation();
            var model = new RapsFileUploadEditModel
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

            var rapsUpload = new RapsUpload
            {
                FileId = file.Id,
                UploadTime = DateTime.Now,
                StatusId = (long)RapsUploadStatus.UploadStarted,
                UploadedBy = _session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
            };

            rapsUpload = _rapsUploadRepository.Save(rapsUpload);

            //update the file name
            file.Path = _fileHelper.AddPostFixToFileName(file.Path, rapsUpload.Id.ToString());
            _fileRepository.Save(file);


            var editModel = new RapsFileUploadEditModel
            {
                File = file,
                Id = rapsUpload.Id
            };

            return Json(editModel, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public void ProcessUpload(RapsFileUploadEditModel rapsEditModel)
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
                    UploadWholeFile(postedFile, rapsEditModel.File.Path, statuses);
                    returnLength = rapsEditModel.File.FileSize;
                }
                else
                {
                    returnLength = UploadPartialFile(postedFile, rapsEditModel.File.Path, statuses);
                }



                if (returnLength == rapsEditModel.File.FileSize || returnLength == 0)
                {
                    var resultArchive = _rapsUploadRepository.GetById(rapsEditModel.Id);
                    if (returnLength == rapsEditModel.File.FileSize)
                    {
                        long count = 0;
                        if (IsFileValid(rapsEditModel, out count))
                        {
                            resultArchive.TotalCount = count;
                            resultArchive.StatusId = (long)RapsUploadStatus.Uploaded;
                        }
                        else
                        {
                            //statuses= new List<FileUploadStatusModel>();
                            //var fname = Path.GetFileName(postedFile.FileName);
                            //statuses.Add(new FileUploadStatusModel
                            //{
                            //    FileName = fname,
                            //    Url = "",
                            //    Size = 0,
                            //    DeleteUrl = "",   //maybe later..                                     
                            //    Progress = "1.0",
                            //    Error = rapsEditModel.FeedbackMessage.Message
                            //});
                            var s = statuses.First();
                            s.Error = rapsEditModel.FeedbackMessage.Message;
                           //  throw new Exception(rapsEditModel.FeedbackMessage.Message);
                        }
                    }
                    else
                    {
                        resultArchive.StatusId = (long)RapsUploadStatus.UploadStarted;
                    }

                    _rapsUploadRepository.Save(resultArchive);
                }

                WriteJsonIframeSafe(statuses);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Upload Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
            }
        }

        private bool IsFileValid(RapsFileUploadEditModel model,out long count)
        {
            try
            {

                var archiveLocation = _mediaRepository.GetRapsUploadMediaFileLocation();
                _csvReader.Delimiter = _csvReader.GetFileDelimiter(archiveLocation.PhysicalPath + model.File.Path).ToString();
                var customerTable = _csvReader.ReadWithTextQualifier(archiveLocation.PhysicalPath + model.File.Path);
                count = customerTable.Rows.Count;
                if (customerTable.Rows.Count == 0)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Uploaded file has no data.");
                    return false;
                }

                var missingColumnNames = _rapsUploadHelper.CheckForColumns(customerTable.Rows[0]);
                if (!string.IsNullOrEmpty(missingColumnNames))
                {
                    model.FeedbackMessage =
                        FeedbackMessageModel.CreateFailureMessage("Missing Column Name(s) : " + missingColumnNames);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                count = 0;
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Raps Upload Validation Failure: " + ex.Message + "\n\t" + ex.StackTrace); 
                return false;
            }
        }
        
        private void UploadWholeFile(HttpPostedFileBase file, string fileName, List<FileUploadStatusModel> statuses)
        {
            var archiveLocation = _mediaRepository.GetRapsUploadMediaFileLocation();
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

            var archiveLocation = _mediaRepository.GetRapsUploadMediaFileLocation();
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

        public ActionResult Log(RapsUploadListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter!=null &&  filter.Status == 0)
                filter.Status = null;
            if (filter != null && filter.UploadedBy == -1)
                filter.UploadedBy = null;
            var rapsData = _rapsService.GetUploadList(pageNumber, _pageSize, filter, out totalRecords);
            var  model = rapsData == null ? new RapsUploadListModel() : new RapsUploadListModel {Collection = rapsData};
            model.Filter = filter;
            model.Url = _mediaRepository.GetRapsUploadMediaFileLocation().Url;
           // Path.GetFileNameWithoutExtension(fileName) + "_FailedRaps.csv"

            var values = RapsUploadStatus.UploadStarted.GetNameValuePairs();
            var status = new List<OrderedPair<long, string>>();
            status.Add(new OrderedPair<long, string>(0, "All"));
            foreach (var source in  values.Where(x => x.FirstValue != (long)RapsUploadStatus.UploadStarted && x.FirstValue != (long)RapsUploadStatus.FileNotFound))
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