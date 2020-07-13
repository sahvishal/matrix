using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Sales.Controllers
{
    [RoleBasedAuthorize]
    public class PhoneNumberUploadController : Controller
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IPhoneNumberUpdateUploadHelper _phoneNumberUpdateUploadHelper;
        private readonly ISessionContext _sessionContext;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ICustomerPhoneNumberUpdateUploadRepository _customerPhoneNumberUpdateUploadRepository;
        private readonly ICsvReader _csvReader;
        private readonly IPhoneNumberUploadService _phoneNumberUploadService;
        private readonly int _pageSize;

        public PhoneNumberUploadController(IMediaRepository mediaRepository, IPhoneNumberUpdateUploadHelper phoneNumberUpdateUploadHelper, ISessionContext sessionContext,
            IUniqueItemRepository<File> fileRepository, ICustomerPhoneNumberUpdateUploadRepository customerPhoneNumberUpdateUploadRepository, ICsvReader csvReader, ISettings settings,
            IPhoneNumberUploadService phoneNumberUploadService)
        {
            _mediaRepository = mediaRepository;
            _phoneNumberUpdateUploadHelper = phoneNumberUpdateUploadHelper;
            _sessionContext = sessionContext;
            _fileRepository = fileRepository;
            _customerPhoneNumberUpdateUploadRepository = customerPhoneNumberUpdateUploadRepository;
            _csvReader = csvReader;
            _phoneNumberUploadService = phoneNumberUploadService;
            _pageSize = settings.DefaultPageSizeForReports;
        }

        // GET: Sales/PhoneNumberUpload
        public ActionResult Index()
        {
            return View(new CustomerPhoneNumberUpdateUploadViewModel());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase phoneNumberFileUpload)
        {
            var uploadDateTime = DateTime.Now;
            var fileUploadName = @"PhoneNumberUpdate_" + uploadDateTime.ToString("yyyyMMddHHmmss") + "_" + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId + ".csv";
            long uploadStatus = (long)PhoneNumberUploadStatus.FileNotFound;
            var model = new CustomerPhoneNumberUpdateUploadViewModel();
            model.FeedbackMessage = new FeedbackMessageModel();
            HttpPostedFileBase file = Request.Files[0];
            var tempMediaFileLocation = _mediaRepository.GetTempMediaFileLocation();      //will store file at Temp location first
            var uploadMediaFileLocation = _mediaRepository.GetCustomerPhoneNumberUploadLocation();

            var physicalPath = tempMediaFileLocation.PhysicalPath;
            var fullpath = physicalPath + fileUploadName;

            try
            {
                // we set uploadStatus as "FileNotFound" to indicate only UI error message , no DB logging
                if (Request.Files.Count != 1 || phoneNumberFileUpload == null)
                {
                    uploadStatus = (long)PhoneNumberUploadStatus.FileNotFound;
                    throw new Exception("No file has been uploaded. Please upload a csv file.");
                }

                var fileExtension = file.FileName.Split('.');
                if ((fileExtension.Length >= 2 && fileExtension[fileExtension.Length - 1].ToLower() != "csv") || fileExtension.Length < 2)
                {
                    uploadStatus = (long)PhoneNumberUploadStatus.FileNotFound;
                    throw new Exception("Uploaded file is not in CSV format");
                }

                try
                {
                    file.SaveAs(fullpath);
                }
                catch (Exception)
                {
                    uploadStatus = (long)PhoneNumberUploadStatus.UploadFailed;
                    throw;
                }

                var phoneNumberTable = _csvReader.ReadWithTextQualifier(fullpath);

                System.IO.File.Copy(fullpath, uploadMediaFileLocation.PhysicalPath + fileUploadName);
                //fullpath = uploadMediaFileLocation.PhysicalPath + fileUploadName;

                if (phoneNumberTable.Rows.Count == 0)
                {
                    uploadStatus = (long)PhoneNumberUploadStatus.FileNotFound;
                    throw new Exception("Uploaded file has no data");
                }

                var columns = phoneNumberTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                var missingColumnNames = _phoneNumberUpdateUploadHelper.CheckAllColumnExist(columns);
                if (!string.IsNullOrEmpty(missingColumnNames))
                {
                    uploadStatus = (long)PhoneNumberUploadStatus.FileNotFound;
                   
                    var customString = missingColumnNames.Replace(PhoneNumberUpdateUploadLogColumn.CustomerId, "Customer Id")
                        .Replace(PhoneNumberUpdateUploadLogColumn.FirstName, "First Name").Replace(PhoneNumberUpdateUploadLogColumn.LastName, "Last Name")
                        .Replace(PhoneNumberUpdateUploadLogColumn.MemberId, "Member Id").Replace(PhoneNumberUpdateUploadLogColumn.PhoneNumber, "New Phone Number")
                        .Replace(PhoneNumberUpdateUploadLogColumn.PhoneType, "Phone Type").Replace(PhoneNumberUpdateUploadLogColumn.DOB, "Dob");
                    
                    throw new Exception("Missing Column Name(s):" + customString);
                }

                var files = new File
                {
                    Path = fileUploadName,
                    FileSize = file.ContentLength,
                    Type = FileType.Csv,
                    UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                    UploadedOn = DateTime.Now,
                    IsArchived = false
                };

                files = _fileRepository.Save(files);

                var customerPhoneNumberUpdateUpload = new CustomerPhoneNumberUpdateUpload
                {
                    FileId = files.Id,
                    StatusId = (long)PhoneNumberUploadStatus.Uploaded,
                    SuccessUploadCount = 0,
                    FailedUploadCount = 0,
                    UploadTime = uploadDateTime,
                    ParseStartTime = null,
                    ParseEndTime = null,
                    UploadedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                    LogFileId = null
                };
                _customerPhoneNumberUpdateUploadRepository.Save(customerPhoneNumberUpdateUpload);
            }

            catch (Exception ex)
            {
                model.FeedbackMessage.MessageType = UserInterfaceMessageType.Error;
                model.FeedbackMessage.Message = ex.Message;
                if (uploadStatus == (long)PhoneNumberUploadStatus.UploadFailed)
                {
                    model.FeedbackMessage.Message = "Upload Failed";
                }
                return View("Index", model);

            }
            model.FeedbackMessage.Message = "Upload Success";
            return View("Index", model);
        }

        public ActionResult ManagePhoneNumber(CustomerPhoneNumberUpdateModelFilter filter = null, int pageNumber = 1)
        {
            try
            {
                int totalRecords;
                var model = _phoneNumberUploadService.GetPhoneNumberUploadDetails(filter, pageNumber, _pageSize, out totalRecords);

                if (model == null)
                    model = new CustomerPhoneNumberListModel();
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
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error(ex.Message);
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Phone Number Upload Manage:  Stack Trace :" + ex.StackTrace);
                var model = new CustomerPhoneNumberListModel();
                model.Filter = filter;
                return View(model);
            }
        }
    }
}