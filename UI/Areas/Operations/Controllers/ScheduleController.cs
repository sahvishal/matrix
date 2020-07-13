using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    //[RoleBasedAuthorize]
    public class ScheduleController : Controller
    {
        private readonly IEventStaffAssignmentService _eventStaffAssignmentService;
        private readonly IEventService _eventService;
        private readonly ISessionContext _sessionContext;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IStaffEventScheduleUploadRepository _staffEventScheduleUploadRepository;
        private readonly ILogger _logger;
        private readonly int _pageSize;

        public ScheduleController(IEventStaffAssignmentService eventStaffAssignmentService, IEventService eventService, ISessionContext sessionContext,
            IMediaRepository mediaRepository, ILogManager logManager, ICsvReader csvReader, IUniqueItemRepository<File> fileRepository,
            IStaffEventScheduleUploadRepository staffEventScheduleUploadRepository, ISettings settings)
        {
            _eventService = eventService;
            _eventStaffAssignmentService = eventStaffAssignmentService;
            _sessionContext = sessionContext;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _fileRepository = fileRepository;
            _staffEventScheduleUploadRepository = staffEventScheduleUploadRepository;
            _logger = logManager.GetLogger<ScheduleController>();
            _pageSize = settings.DefaultPageSizeForReports;
        }

        [RoleBasedAuthorize]
        public ActionResult Index(EventStaffAssignmentListModelFilter filter = null)
        {
            var isCurrentRoleTechnician = _sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.Technician);
            return View(_eventStaffAssignmentService.GetforStaffCalendar(isCurrentRoleTechnician, filter));
        }

        public ActionResult Print(EventStaffAssignmentListModelFilter filter = null)
        {
            var isCurrentRoleTechnician = filter.RoleId == (long)Roles.Technician;
            return View(_eventStaffAssignmentService.GetforStaffCalendar(isCurrentRoleTechnician, filter));
        }

        [RoleBasedAuthorize]
        public ActionResult GenerateCalendarPdf(EventStaffAssignmentListModelFilter filter = null)
        {
            var mediaLocation = IoC.Resolve<IMediaRepository>().GetTempMediaFileLocation();
            var url = Request.Url.OriginalString.Replace(Request.Url.Query, "");
            string newpdfpath = url.Replace(Request.Url.AbsolutePath, "/Operations/Schedule/Print" + Request.Url.Query);

            var pdfConverterPath = Server.MapPath(@"~\bin");

            var wkHtmltoPdfSwitches =
            new WkHtmltoPdfSwitches()
            {
                MarginBottom = 0.5m,
                MarginRight = 0.5m,
                MarginLeft = 1.5m,
                MarginTop = 1m,
                RedirectDelay = 5000,
                Orientation = "Landscape"
            };

            var pdfGenerator = IoC.Resolve<IPdfGenerator>();
            pdfGenerator.SetDefaultSwitch(wkHtmltoPdfSwitches);

            string pdfname = pdfGenerator.Generate(newpdfpath, mediaLocation.PhysicalPath, pdfConverterPath);
            Response.RedirectUser(mediaLocation.Url + pdfname);
            return null;
        }

        [RoleBasedAuthorize]
        public ActionResult Edit(long Id)
        {
            return View(_eventService.GetEventStaff(Id));
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult SaveEventStaffAssignments(long eventId, long podId, IEnumerable<EventStaffBasicInfoModel> assigneStaff)
        {
            try
            {
                _eventStaffAssignmentService.Save(eventId, podId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, assigneStaff);
                return Json("Staff Assignments saved successfully");
            }
            catch (Exception exception)
            {
                return Json("System Error:" + exception.Message);
            }
        }

        //[RoleBasedAuthorize]
        public JsonResult GetStaffScheduleFor(EventStaffAssignmentListModelFilter filter)
        {
            var eventStaffAssignmentViewModels = _eventService.GetEventStaff(filter).StaffEventAssignments;
            return Json(Mapper.Map<IEnumerable<EventStaffAssignmentViewModel>, EventJsonModel[]>(eventStaffAssignmentViewModels), JsonRequestBehavior.AllowGet);
        }

        [RoleBasedAuthorize]
        public ActionResult ScheduleUpload(string message)
        {
            var model = new StaffEventScheduleUploadViewModel
            {
                SampleCsvMediaUrl = _mediaRepository.GetSamplesLocation().Url + "StaffEventScheduleUploadSample.csv",
                SampleRoleUrl = _mediaRepository.GetSamplesLocation().Url + "StaffEventScheduleRoleSample.csv"
            };
            if (message != null)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(message);
            }
            return View(model);
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult ScheduleUpload(HttpPostedFileBase scheduleUploadFile)
        {
            var model = new StaffEventScheduleUploadViewModel
            {
                FeedbackMessage = new FeedbackMessageModel(),
                SampleCsvMediaUrl = _mediaRepository.GetSamplesLocation().Url + "StaffEventScheduleUploadSample.csv"
            };

            try
            {
                if (Request.Files.Count < 1 || scheduleUploadFile == null)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("No file has been uploaded. Please upload a csv file.");
                    return View(model);
                }

                HttpPostedFileBase file = Request.Files[0];
                var fileExtension = file.FileName.Split('.');
                if ((fileExtension.Length >= 2 && fileExtension[fileExtension.Length - 1].ToLower() != "csv") || fileExtension.Length < 2)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("File uploaded is not a CSV");
                    return View(model);
                }

                var uploadMediaLocation = _mediaRepository.GetStaffScheduleUploadMediaFileLocation();

                var physicalPath = uploadMediaLocation.PhysicalPath;
                var fileUploadedName = (Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName)).Replace("'", "").Replace("&", "");
                var fileName = (Path.GetFileNameWithoutExtension(fileUploadedName) + "_" + DateTime.Now.ToString("MMddyyyyhhmmss") + Path.GetExtension(fileUploadedName)).Replace("'", "").Replace("&", "");

                var fullPath = physicalPath + fileName;

                try
                {
                    file.SaveAs(fullPath);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Staff Event Schedule Upload\nException occurred while saving file on server. FileName:{0} Path: {1}", fileUploadedName, fullPath));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                var staffScheduleTable = _csvReader.ReadWithTextQualifier(fullPath);
                if (staffScheduleTable.Rows.Count == 0)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Uploaded file has no data.");

                    return View(model);
                }

                var columns = staffScheduleTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                var missingColumnNames = CheckAllScheduleUploadColumnExist(columns);
                if (!string.IsNullOrEmpty(missingColumnNames))
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Missing Column Name(s) : " + missingColumnNames);

                    return View(model);
                }

                var files = new File
                {
                    Path = fileName,
                    FileSize = file.ContentLength,
                    Type = FileType.Csv,
                    UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                    UploadedOn = DateTime.Now
                };

                try
                {
                    files = _fileRepository.Save(files);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Staff Event Schedule Upload\nException occurred while saving info in File table."));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                var staffAssignmentUpload = new StaffEventScheduleUpload
                {
                    FileId = files.Id,
                    UploadTime = DateTime.Now,
                    UploadedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                    StatusId = (long)StaffEventScheduleParseStatus.Uploaded
                };

                try
                {
                    staffAssignmentUpload = _staffEventScheduleUploadRepository.Save(staffAssignmentUpload);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Staff Event Schedule Upload\nException occurred while saving info in StaffEventScheduleUpload."));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                if (staffAssignmentUpload != null && staffAssignmentUpload.Id > 0)
                {
                    ModelState.Clear();
                    return RedirectToAction("ScheduleUpload", "Schedule", new { message = "File uploaded successfully" });
                }

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("File upload failed");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Staff Event Schedule Upload\nException occurred"));
                _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                return View(model);
            }
        }

        private string CheckAllScheduleUploadColumnExist(string[] givenList)
        {
            var columns = StaffEventScheduleUploadColumn.EventDate.GetDescription() + "," +
                          StaffEventScheduleUploadColumn.Pod.GetDescription() + "," +
                          StaffEventScheduleUploadColumn.Role.GetDescription() + "," +
                          StaffEventScheduleUploadColumn.EmployeeId.GetDescription() + "," +
                          StaffEventScheduleUploadColumn.StaffName.GetDescription();
            string[] checkList = columns.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            var list = checkList.Except(givenList);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

        [RoleBasedAuthorize]
        public ActionResult ScheduleUploadDetails(StaffEventScheduleUploadModelFilter filter = null, int pageNumber = 1)
        {
            try
            {
                int totalRecords;
                var model = _eventStaffAssignmentService.GetStaffEventScheduleUploadDetails(pageNumber, _pageSize, filter, out totalRecords) ?? new StaffEventScheduleUploadListModel();

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

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Staff Event Schedule Upload Details\nException occurred"));
                _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                var model = new StaffEventScheduleUploadListModel { Filter = filter };
                return View(model);
            }
        }
    }
}
