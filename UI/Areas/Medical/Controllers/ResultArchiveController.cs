using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Application;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;
using File = Falcon.App.Core.Application.Domain.File;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class ResultArchiveController : Controller
    {
        private readonly IResultArchiveUploadRepository _resultArchiveUploadRepository;
        private readonly IResultArchiveUploadLogRepository _resultArchiveUploadLogRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ITestRepository _testRepository;
        private readonly IPodRepository _podRepository;

        private readonly ISessionContext _session;
        private readonly ISettings _settings;
        private readonly IFileHelper _fileHelper;
        private readonly int _pageSize;

        private readonly JavaScriptSerializer _javaScriptSerializer;

        public ResultArchiveController(IResultArchiveUploadRepository resultArchiveUploadRepository, IResultArchiveUploadLogRepository resultArchiveUploadLogRepository,
                                    IUniqueItemRepository<File> fileRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ISessionContext session, IEventRepository eventRepository,
                                      ITestRepository testRepository, IMediaRepository mediaRepository, ISettings settings, IFileHelper fileHelper, IPodRepository podRepository)
        {
            _resultArchiveUploadRepository = resultArchiveUploadRepository;
            _resultArchiveUploadLogRepository = resultArchiveUploadLogRepository;
            _fileRepository = fileRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _testRepository = testRepository;
            _settings = settings;
            _eventRepository = eventRepository;
            _session = session;
            _mediaRepository = mediaRepository;
            _fileHelper = fileHelper;
            _podRepository = podRepository;


            _javaScriptSerializer = new JavaScriptSerializer();
            _pageSize = _settings.DefaultPageSizeForReports;

        }

        public ActionResult Index(ResultArchiveUploadListModelFilter filter, int pageNumber = 1)
        {
            var model = new ResultArchiveUploadListModel();

            try
            {
                int totalRecords;
                var resultArchives = _resultArchiveUploadRepository.GetByFilter(filter, pageNumber, _pageSize, out totalRecords);
                if (resultArchives != null && resultArchives.Count() > 0)
                {
                    var fileIds = resultArchives.Where(r => r.FileId.HasValue).Select(r => r.FileId.Value).ToArray();
                    var files = _fileRepository.GetByIds(fileIds);

                    var events = _eventRepository.GetEventswithPodbyIds(resultArchives.Select(r => r.EventId).ToArray());

                    var orgRoleUserIds = resultArchives.Select(r => r.UploadedByOrgRoleUserId).ToArray();
                    var userIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

                    var pods = _podRepository.GetPodsForEvents(events.Select(e => e.Id).ToArray());

                    model.ResultUploads = AutoMapper.Mapper.Map<IEnumerable<ResultArchive>, IEnumerable<ResultArchiveUploadViewModel>>(resultArchives);

                    foreach (var upload in model.ResultUploads)
                    {
                        var theEvent = events.Where(e => e.Id == upload.EventId).SingleOrDefault();
                        var eventPods = pods.Where(p => theEvent.PodIds.Contains(p.Id)).ToArray();

                        upload.EventDate = theEvent.EventDate;
                        upload.EventName = theEvent.Name;
                        upload.PodName = string.Join(", ", eventPods.Select(ep => ep.Name));

                        var userIdNamepair =
                            userIdNamePairs.Where(p => p.FirstValue == resultArchives.Where(r => r.Id == upload.Id).Select(r => r.UploadedByOrgRoleUserId).SingleOrDefault()).SingleOrDefault();

                        if (userIdNamepair != null)
                            upload.UploadedBy = userIdNamepair.SecondValue;

                        if (upload.File == null) continue;

                        var file = files.Where(f => f.Id == upload.File.Id).SingleOrDefault();
                        if (file != null) upload.File = file;
                    }
                }

                if (filter == null) filter = new ResultArchiveUploadListModelFilter();
                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                Func<int, string> urlFunc =
                    pn =>
                    Url.Action(currentAction,
                               new
                                   {
                                       pageNumber = pn,
                                       filter.EventId,
                                       filter.FromEventDate,
                                       filter.FromUploadDate,
                                       filter.ToEventDate,
                                       filter.ToUploadDate,
                                       filter.ResultArchiveUploadStatus,
                                       filter.UploadedBy,
                                       filter.Pod
                                   });

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }

        public ActionResult Upload()
        {
            System.Web.HttpContext.Current.Response.Headers.Remove("Refresh");
            return View();
        }

        public ActionResult Detail(long id = 0)
        {
            ResultArchiveUploadLogListModel model = null;

            if (id > 0)
            {
                model = new ResultArchiveUploadLogListModel();
                var resultArchiveLogRecords = _resultArchiveUploadLogRepository.GetbyResultArchiveId(id);

                var resultArchive = _resultArchiveUploadRepository.GetById(id);
                model.ResultArchive = AutoMapper.Mapper.Map<ResultArchive, ResultArchiveUploadViewModel>(resultArchive);

                var theEvent = _eventRepository.GetById(resultArchive.EventId);
                model.ResultArchive.EventDate = theEvent.EventDate;
                model.ResultArchive.EventName = theEvent.Name;

                if (resultArchive.FileId.HasValue)
                {
                    var file = _fileRepository.GetById(resultArchive.FileId.Value);
                    model.ResultArchive.File = file;
                }

                if (resultArchiveLogRecords != null)
                {
                    model.ResultArchiveLogRecords =
                        AutoMapper.Mapper.Map
                            <IEnumerable<ResultArchiveLog>, IEnumerable<ResultArchiveUploadLogViewModel>>(
                                resultArchiveLogRecords);


                    var orgRoleUserIds = resultArchiveLogRecords.Select(r => r.CustomerId).ToArray();
                    orgRoleUserIds = orgRoleUserIds.Concat(new long[] { resultArchive.UploadedByOrgRoleUserId }).ToArray();

                    var userIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);
                    var userIdNamepair =
                        userIdNamePairs.Where(p => p.FirstValue == resultArchive.UploadedByOrgRoleUserId).
                            SingleOrDefault();

                    if (userIdNamepair != null) model.ResultArchive.UploadedBy = userIdNamepair.SecondValue;

                    var testIds = resultArchiveLogRecords.Select(r => (long)r.TestId).Distinct().ToArray();
                    var tests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(testIds);

                    foreach (var resultArchiveLogRecord in model.ResultArchiveLogRecords)
                    {
                        resultArchiveLogRecord.CustomerName =
                            userIdNamePairs.Where(p => p.FirstValue == resultArchiveLogRecord.CustomerId).
                                SingleOrDefault().
                                SecondValue;

                        resultArchiveLogRecord.TestName =
                            tests.Where(t => t.Id == (long)resultArchiveLogRecord.TestId).Single().Name;
                    }
                }
                else
                {
                    model.ResultArchive.UploadedBy = _organizationRoleUserRepository.GetNameIdPairofUsers(new long[] { resultArchive.UploadedByOrgRoleUserId }).FirstOrDefault().SecondValue;
                }
            }

            return View(model);
        }


        public JsonResult CreateResultArchive(long eventId, string fileName, long fileSize)
        {
            if (eventId < 1)
            {
                throw new Exception("EventId should not be empty!");
            }
            try
            {
                var theEvent = _eventRepository.GetById(eventId);
                if (theEvent == null || theEvent.EventDate.Date > DateTime.Now.Date || theEvent.Status != EventStatus.Active || theEvent.PodIds.IsNullOrEmpty())
                {
                    throw new Exception("Provide a valid EventId!");
                }
            }
            catch
            {
                var model = new ResultArchiveUploadEditModel
                {
                    EventId = -1,
                    File = null,
                    Id = 0
                };

                return Json(model, JsonRequestBehavior.AllowGet);
            }

            var file = new File
                           {
                               Path = fileName,
                               Type = FileType.Compressed,
                               FileSize = fileSize,
                               UploadedBy = new OrganizationRoleUser(_session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                               UploadedOn = DateTime.Now
                           };

            file = _fileRepository.Save(file);

            var resultArchive = new ResultArchive
                                   {
                                       FileId = file.Id,
                                       EventId = eventId,
                                       UploadStartTime = DateTime.Now,
                                       Status = ResultArchiveUploadStatus.Uploading,
                                       UploadedByOrgRoleUserId =
                                       _session.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
                                   };
            resultArchive = _resultArchiveUploadRepository.Save(resultArchive);

            //update the file name
            file.Path = _fileHelper.AddPostFixToFileName(file.Path, resultArchive.Id.ToString());
            _fileRepository.Save(file);


            //return ResultArchiveUploadEditModel;
            var editModel = new ResultArchiveUploadEditModel
                                {
                                    EventId = eventId,
                                    File = file,
                                    Id = resultArchive.Id
                                };

            return Json(editModel, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public void ProcessUpload(ResultArchiveUploadEditModel archiveUploadEditModel)
        {
            if (!ModelState.IsValid)
            {
                archiveUploadEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("server error.");
                SetResultArchiveStatus(archiveUploadEditModel.Id, ResultArchiveUploadStatus.UploadFailed);
                throw new Exception("EventId should not be empty!");
            }

            if (Request.Files.Count != 1)
            {
                SetResultArchiveStatus(archiveUploadEditModel.Id, ResultArchiveUploadStatus.UploadFailed);
                throw new Exception("File count should not be empty!");
            }

            if (archiveUploadEditModel.EventId < 1)
            {
                archiveUploadEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("server error.");
                SetResultArchiveStatus(archiveUploadEditModel.Id, ResultArchiveUploadStatus.UploadFailed);
                throw new Exception("EventId should not be empty!");
            }

            try
            {
                var theEvent = _eventRepository.GetById(archiveUploadEditModel.EventId);
                if (theEvent == null || theEvent.EventDate.Date > DateTime.Now.Date ||
                    theEvent.Status != EventStatus.Active)
                {
                    throw new Exception("Provide a valid EventId!");
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Result Archive Upload Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                SetResultArchiveStatus(archiveUploadEditModel.Id, ResultArchiveUploadStatus.UploadFailed);
                throw new Exception(ex.Message);
            }

            try
            {
                HttpPostedFileBase postedFile = Request.Files[0];

                long returnLength = 0;
                var statuses = new List<FileUploadStatusModel>();
                if (string.IsNullOrEmpty(Request.Headers["X-File-Name"]))
                {
                    UploadWholeFile(postedFile, archiveUploadEditModel.File.Path, statuses,
                                    archiveUploadEditModel.EventId);
                }
                else
                {
                    returnLength = UploadPartialFile(postedFile, archiveUploadEditModel.File.Path, statuses,
                                                     archiveUploadEditModel.EventId);
                }

                var resultArchive = _resultArchiveUploadRepository.GetById(archiveUploadEditModel.Id);

                if (returnLength == archiveUploadEditModel.File.FileSize || returnLength == 0)
                {
                    resultArchive.UploadEndTime = DateTime.Now;
                    resultArchive.Status = ResultArchiveUploadStatus.Uploaded;
                    resultArchive.UploadPercentage = 100;
                }
                else
                {
                    resultArchive.UploadPercentage = (int)((returnLength * 100) / archiveUploadEditModel.File.FileSize);
                }

                _resultArchiveUploadRepository.Save(resultArchive);
                WriteJsonIframeSafe(statuses);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Upload Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                SetResultArchiveStatus(archiveUploadEditModel.Id, ResultArchiveUploadStatus.UploadFailed);
            }
        }

        private void SetResultArchiveStatus(long resultArchiveUploadId, ResultArchiveUploadStatus status)
        {
            if (resultArchiveUploadId > 0)
            {
                var resultArchive = _resultArchiveUploadRepository.GetById(resultArchiveUploadId);
                resultArchive.Status = status;
                resultArchive.UploadEndTime = DateTime.Now;
                _resultArchiveUploadRepository.Save(resultArchive);
            }
        }

        private void UploadWholeFile(HttpPostedFileBase file, string fileName, List<FileUploadStatusModel> statuses, long eventId)
        {
            var archiveLocation = _mediaRepository.GetResultArchiveMediaFileLocation(eventId);
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

        private long UploadPartialFile(HttpPostedFileBase file, string fileName, List<FileUploadStatusModel> statuses, long eventId)
        {
            if (Request.Files.Count != 1)
            {
                throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            }

            var archiveLocation = _mediaRepository.GetResultArchiveMediaFileLocation(eventId);
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

    }
}
