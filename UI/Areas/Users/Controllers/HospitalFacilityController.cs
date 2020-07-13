using System;
using System.IO;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Filters;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.UI.Areas.Users.Controllers
{
    [RoleBasedAuthorize]
    public class HospitalFacilityController : Controller
    {
        private readonly IOrganizationService _organizationService;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISessionContext _sessionContext;
        private readonly IUniqueItemRepository<File> _fileRepository;
        

        private int _pageSize = 10;
        
        public HospitalFacilityController(IOrganizationService organizationService, IMediaRepository mediaRepository, ISessionContext sessionContext, IUniqueItemRepository<File> fileRepository,
            ISettings settings)
        {
            _organizationService = organizationService;
            _mediaRepository = mediaRepository;
            _sessionContext = sessionContext;
            _fileRepository = fileRepository;
            
            _pageSize = settings.DefaultPageSizeForReports;
        }
        //
        // GET: /Users/HospitalFacility/

        public ActionResult Create()
        {
            var model = new HospitalFacilityEditModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(HospitalFacilityEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.OrganizationEditModel.LogoImage = FileObject(model.OrganizationEditModel.Name, "organization_logo", _mediaRepository.GetOrganizationLogoImageFolderLocation());
                    model.ResultLetterFile = FileObject(model.OrganizationEditModel.Name, "result_letter", _mediaRepository.GetOrganizationResultLetterFolderLocation());

                    model.OrganizationEditModel.OrganizationType = OrganizationType.HospitalFacility;
                    _organizationService.CreateHospitalFacility(model);

                    var newModel = new HospitalFacilityEditModel();

                    newModel.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(string.Format("The hospital facility {0} was saved successfully. You can add more hospital facilities from here.", model.OrganizationEditModel.Name));

                    return View(newModel);
                }
                
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure. Message: " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(long id)
        {
            var model = _organizationService.GetHospitalFacilityCreateModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(HospitalFacilityEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.OrganizationEditModel.LogoImage = FileObject(model.OrganizationEditModel.Name, "organization_logo", _mediaRepository.GetOrganizationLogoImageFolderLocation(), model.OrganizationEditModel.LogoImage != null ? model.OrganizationEditModel.LogoImage.Id : 0);
                    model.ResultLetterFile = FileObject(model.OrganizationEditModel.Name, "result_letter", _mediaRepository.GetOrganizationResultLetterFolderLocation(), model.ResultLetterFile != null ? model.ResultLetterFile.Id : 0);
                    
                    model.OrganizationEditModel.OrganizationType = OrganizationType.HospitalFacility;
                    _organizationService.CreateHospitalFacility(model);

                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(string.Format("The hospital facility {0} was saved successfully.", model.OrganizationEditModel.Name));
                    
                    return View(model);
                }
                
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure. Message: " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Index(HospitalFacilityListModelFilter filter, int pageNumber = 1)
        {
            int totalRecords;
            var model = _organizationService.GetHospitalFacilityListModel(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new HospitalFacilityListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name, filter.ParentHospitalPartnerId });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        private File FileObject(string fileNamePrefix, string fileUploadElementName, MediaLocation fileLocation, long fileId = 0)
        {
            if (Request.Files != null && Request.Files.Count > 0 && Request.Files[fileUploadElementName] != null)
            {
                var fileUploaded = Request.Files[fileUploadElementName];
                if (string.IsNullOrEmpty(fileUploaded.FileName))
                {
                    return fileId > 0 ? _fileRepository.GetById(fileId) : null;
                }

                var newFileName = fileNamePrefix.Replace(" ", "") + "_" + DateTime.Now.ToFileTimeUtc() + Path.GetExtension(fileUploaded.FileName);

                fileUploaded.SaveAs(fileLocation.PhysicalPath + newFileName);

                return new File
                {
                    Id = fileId,
                    FileSize = fileUploaded.ContentLength,
                    Path = newFileName,
                    Type = FileType.Image,
                    UploadedOn = DateTime.Now,
                    UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                };
            }

            return fileId > 0 ? _fileRepository.GetById(fileId) : null;
        }
    }
}
