using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.UI.Filters;
using System.Linq;

namespace Falcon.App.UI.Areas.Users.Controllers
{
    [RoleBasedAuthorize]
    public class CorporateAccountController : Controller
    {
        //
        // GET: /Sales/CorporateAccount/
        private readonly IOrganizationService _organizationService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly ICorporateAccountService _corporateAccountService;
        private readonly ITestRepository _testRepository;
        private readonly ISessionContext _sessionContext;

        private const int PAGE_SIZE = 10;
        private readonly ILogger _logger;

        public CorporateAccountController(IOrganizationService organizationRepository, ICorporateAccountRepository corporateAccountRepository, IShippingOptionRepository shippingOptionRepository,
            ILogManager logManager, ICorporateAccountService corporateAccountService, ITestRepository testRepository, ISessionContext sessionContext)
        {
            _organizationService = organizationRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _corporateAccountService = corporateAccountService;
            _testRepository = testRepository;

            _sessionContext = sessionContext;
            _logger = logManager.GetLogger<CorporateAccountController>();
        }

        public ActionResult Create()
        {
            var model = new CorporateAccountEditModel
                            {
                                ShippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess()
                            };
            return View(model);
        }



        public ActionResult Edit(long id)
        {
            if (_organizationService.IsActiveOrganizationbyId(id)==true)
            {
                return View(new CorporateAccountEditModel { AccountId = id });
            }
            else
            {   
                return RedirectToAction("Index", "CorporateAccount");
            }
            
        }


        public ActionResult Index(CorporateAccountListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _organizationService.GetCorporateAccountListModel(pageNumber, PAGE_SIZE, filter, out totalRecords);

            if (model == null) model = new CorporateAccountListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name, filter.ShowHealthPlanOnly, filter.ShowCorporateAccountOnly });
            model.PagingModel = new PagingModel(pageNumber, PAGE_SIZE, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult Cpt(long id)
        {
            var model = _corporateAccountService.GetCptTestMappingModel(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult GetCorporateAccount(long accountId)
        {
            return Json(((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(accountId));
        }

        public ActionResult EditModel(long id, bool openNextTab = false)
        {
            var model = new CorporateAccountEditModel { AccountId = id, OpenNextTab = openNextTab };
            return PartialView(model);
        }

        public ActionResult BasicInfo(long id)
        {
            CorporateAccountBasicInfoEditModel model;

            if (id <= 0)
            {
                model = new CorporateAccountBasicInfoEditModel { IsNew = true };
                return PartialView(model);
            }

            model = _corporateAccountService.GetBasicInfoEditModel(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult BasicInfoModel(CorporateAccountBasicInfoEditModel model)
        {
            if (!ModelState.IsValid) return PartialView(model);

            try
            {
                model = _corporateAccountService.SaveAccountInfo(model);
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Saved Successfully");
            }
            catch (Exception exception)
            {
                _logger.Error(
                    string.Format(
                        "While {0} organization Error Occured Organization Id {1}, \n message: {2} \n stack Trace {3}",
                        (model.IsNew ? "Created" : "Updated"), model.OrganizationEditModel.Id, exception.Message,
                        exception.StackTrace));

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some error Occured while saving");
            }

            return PartialView(model);
        }

        public ActionResult RegistrationConfig(long id)
        {
            var registrationModel = _corporateAccountService.GetRegistrationConfig(id);
            ModelState.Clear();
            return PartialView(registrationModel);
        }

        [HttpPost]
        public ActionResult RegistrationConfigModel(RegistrationConfigEditModel model)
        {
            if (ModelState.IsValid)
            {
                var validClinicalTemplate = false;
                if (!model.AskClinicalQuestions && model.OldClinicalQuestionTemplateId == 0)
                    validClinicalTemplate = true;
                else if (model.AskClinicalQuestions && model.OldClinicalQuestionTemplateId == 0 && model.ClinicalQuestionTemplateId > 0)
                    validClinicalTemplate = true;
                else if (model.AskClinicalQuestions && model.OldClinicalQuestionTemplateId > 0 && model.ClinicalQuestionTemplateId > 0 && model.OldClinicalQuestionTemplateId == model.ClinicalQuestionTemplateId)
                    validClinicalTemplate = true;
                else if (model.AskClinicalQuestions && model.OldClinicalQuestionTemplateId > 0 && model.ClinicalQuestionTemplateId > 0 && model.OldClinicalQuestionTemplateId != model.ClinicalQuestionTemplateId)
                    validClinicalTemplate = _corporateAccountService.CheckCanChangeClinicalTemplate(model.AccountId);
                else if (!model.AskClinicalQuestions && model.OldClinicalQuestionTemplateId > 0)
                    validClinicalTemplate = _corporateAccountService.CheckCanChangeClinicalTemplate(model.AccountId);

                if (validClinicalTemplate)
                {
                    var orgRoleId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                    _corporateAccountService.SaveAccountRegistrationInfo(model, orgRoleId);

                    model = _corporateAccountService.GetRegistrationConfig(model.AccountId);

                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Updated Successfully");
                }
                else
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Clinical template can not be changed/removed.");
                    _corporateAccountService.BindDefaultRegistrationData(model);
                }
            }
            else
            {
                _corporateAccountService.BindDefaultRegistrationData(model);
            }

            return PartialView(model);
        }



        public ActionResult ResultConfig(long id)
        {
            var model = _corporateAccountService.GetResultConfigEditModel(id);
            model.RecordableTests = _testRepository.GetRecordableTests();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ResultConfigModel(ResultConfigEditModel model)
        {
            try
            {
                model.RecordableTests = _testRepository.GetRecordableTests();

                if (!ModelState.IsValid)
                    return PartialView(model);

                _corporateAccountService.SaveAccountResultConfig(model);

                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Updated Successfully");
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Error While Updating {0} \n message: {1} \n stack Trace: {2} ",
                    model.AccountId, exception.Message, exception.StackTrace));

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some Error Occured");
            }

            return PartialView(model);
        }
    }
}
