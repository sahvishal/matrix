using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations;
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
    public class MedicalVendorController : Controller
    {

        private readonly IOrganizationService _organizationService;
        private readonly IPackageRepository _packageRepository;
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISessionContext _sessionContext;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMedicalVendorRepository _medicalVendorRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;

        private int _pageSize = 10;


        public MedicalVendorController(IOrganizationService organizationService, IPackageRepository packageRepository, ITerritoryRepository territoryRepository, ISessionContext sessionContext, IUniqueItemRepository<File> fileRepository,
            IMediaRepository mediaRepository, IMedicalVendorRepository medicalVendorRepository, IHospitalPartnerRepository hospitalPartnerRepository, ISettings settings, IHospitalFacilityRepository hospitalFacilityRepository,
            IConfigurationSettingRepository configurationSettingRepository, IShippingOptionRepository shippingOptionRepository)
        {
            _organizationService = organizationService;
            _packageRepository = packageRepository;
            _territoryRepository = territoryRepository;
            _mediaRepository = mediaRepository;
            _sessionContext = sessionContext;
            _fileRepository = fileRepository;
            _medicalVendorRepository = medicalVendorRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _pageSize = settings.DefaultPageSizeForReports;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _shippingOptionRepository = shippingOptionRepository;
        }

        public ActionResult Create()
        {
            var model = new MedicalVendorEditModel();
            SetPackageAndTerritory(model);

            var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AskPreQualificationQuestion);
            var askPreQualificationQuestion = value.ToLower() == bool.TrueString.ToLower();

            model.HospitalPartnerEditModel.ShowAskPreQualificationQuestionSetttings = askPreQualificationQuestion;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MedicalVendorEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.OrganizationEditModel.LogoImage = FileObject(model.OrganizationEditModel.Name, "organization_logo", _mediaRepository.GetOrganizationLogoImageFolderLocation());
                    model.ResultLetterCoBrandingFile = FileObject(model.OrganizationEditModel.Name, "result_letter", _mediaRepository.GetOrganizationResultLetterFolderLocation());

                    model.DoctorLetterFile = FileObject(model.OrganizationEditModel.Name, "doctor_letter", _mediaRepository.GetOrganizationDoctorLetterFolderLocation());

                    model.OrganizationEditModel.OrganizationType = OrganizationType.MedicalVendor;
                    _organizationService.CreateMedicalVendor(model);

                    var newModel = new MedicalVendorEditModel();
                    SetPackageAndTerritory(newModel);

                    newModel.FeedbackMessage =
                       FeedbackMessageModel.CreateSuccessMessage(string.Format("The medical vendor {0} was saved successfully. You can add more medical vendors from here.", model.OrganizationEditModel.Name));

                    return View(newModel);
                }
                SetPackageAndTerritory(model);
                return View(model);
            }
            catch (Exception ex)
            {
                SetPackageAndTerritory(model);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure. Message: " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(long id)
        {
            var model = _organizationService.GetMedicalVendorCreateModel(id);
            SetPackageAndTerritory(model);
            if (model.OrganizationEditModel.BillingAddress == null)
                model.OrganizationEditModel.BillingAddress = new AddressEditModel();

            if (model.HospitalPartnerEditModel != null && !string.IsNullOrEmpty(model.HospitalPartnerEditModel.DeactivedPackages))
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage(model.HospitalPartnerEditModel.DeactivedPackages);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MedicalVendorEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.OrganizationEditModel.LogoImage = FileObject(model.OrganizationEditModel.Name, "organization_logo", _mediaRepository.GetOrganizationLogoImageFolderLocation(), model.OrganizationEditModel.LogoImage != null ? model.OrganizationEditModel.LogoImage.Id : 0);
                    model.ResultLetterCoBrandingFile = FileObject(model.OrganizationEditModel.Name, "result_letter", _mediaRepository.GetOrganizationResultLetterFolderLocation(), model.ResultLetterCoBrandingFile != null ? model.ResultLetterCoBrandingFile.Id : 0);

                    model.DoctorLetterFile = FileObject(model.OrganizationEditModel.Name, "doctor_letter", _mediaRepository.GetOrganizationDoctorLetterFolderLocation(), model.DoctorLetterFile != null ? model.DoctorLetterFile.Id : 0);

                    var attachedEventIds = _hospitalPartnerRepository.GetAttachedHospitalMaterialEventIdsForHospitalPartner(model.OrganizationEditModel.Id);
                    if (model.ResultLetterCoBrandingFile == null && attachedEventIds.Count() > 0)
                    {
                        model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("You can not remove result letter since event(s) are attached to it.");
                        return View(model);
                    }
                    model.OrganizationEditModel.OrganizationType = OrganizationType.MedicalVendor;

                    _organizationService.CreateMedicalVendor(model);

                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(string.Format("The medical vendor {0} was saved successfully.", model.OrganizationEditModel.Name));

                    SetPackageAndTerritory(model);
                    return View(model);
                }
                SetPackageAndTerritory(model);
                return View(model);
            }
            catch (Exception ex)
            {
                SetPackageAndTerritory(model);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure. Message: " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Index(MedicalVendorListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _organizationService.GetMedicalVendorlistModel(pageNumber, _pageSize, filter, out totalRecords);
            if (model == null) model = new MedicalVendorListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        private void SetPackageAndTerritory(MedicalVendorEditModel model)
        {
            model.HospitalPartnerEditModel.OrganizationPackageList = _packageRepository.GetAll().Select(x => new OrganizationPackageViewModel { Gender = ((Gender)x.Gender), Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToList();
            model.HospitalPartnerEditModel.Territories = _territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.HospitalPartner).OrderBy(x => x.SecondValue);
            model.HospitalPartnerEditModel.HospitalFacilities = _hospitalFacilityRepository.GetAllForHospitalPartner(model.OrganizationEditModel.Id);
            model.HospitalPartnerEditModel.ShippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();
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

        [HttpPost]
        public ActionResult GetMedicalVendor(long medicalVendorId)
        {
            return Json(_medicalVendorRepository.GetMedicalVendor(medicalVendorId));
        }

        public ActionResult GetHospitalPartner(long hospiatalPartnerId)
        {
            return Json(_hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospiatalPartnerId));
        }
    }
}
