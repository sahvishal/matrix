using API.Areas.Users.Controllers;
using API.Attribute;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Areas.Medicare.Controllers
{
    [AppAuthenticationAttribute]
    public class MedicareEventCustomerResultController : ApiController
    {
        private readonly IMedicareService _medicareService;
        private readonly ITestResultService _testResultService;

        private readonly ILogger _logger;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IAccountHraChatQuestionnaireHistoryServices _accountHraChatQuestionnaireHistoryServices;


        public MedicareEventCustomerResultController(ILogManager logManager, IMedicareService medicareService,
            ITestResultService testResultService, IOrganizationRoleUserRepository organizationRoleUserRepository,
            ICorporateAccountRepository corporateAccountRepository, IEventCustomerRepository eventCustomerRepository, IEventRepository eventRepository, IAccountHraChatQuestionnaireHistoryServices accountHraChatQuestionnaireHistoryServices)
        {
            _medicareService = medicareService;
            _testResultService = testResultService;

            _logger = logManager.GetLogger<LoginController>();
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            _accountHraChatQuestionnaireHistoryServices = accountHraChatQuestionnaireHistoryServices;
        }

        [HttpPost]
        public bool SaveCustomerResultAcesApprovedOn(MedicareEventCustomerModel model)
        {
            try
            {
                _logger.Info("Running SaveCustomerResultAcesApprovedOn API for Aces for Customer Id: " + model.CustomerId + " EventId : " + model.EventId);

                if (string.IsNullOrWhiteSpace(model.EmployeeId))
                {
                    _logger.Info("EmployeeId is blank. SaveCustomerResultAcesApprovedOn API for Customer Id: " + model.CustomerId + " EventId : " + model.EventId);
                    return false;
                }

                var oru = _organizationRoleUserRepository.GetOrganizationRoleUserByEmployeeIdandRoleId(model.EmployeeId, (long)Roles.FranchisorAdmin);
                if (oru == null)
                {
                    _logger.Info("EmployeeId or FranchisorAdmin role not exist. SaveCustomerResultAcesApprovedOn API for Customer Id: " + model.CustomerId + " EventId : " + model.EventId);
                    return false;
                }

                var result = _testResultService.SaveCustomerResultAcesApprovedOn(model, oru);

                if (result)
                {
                    _logger.Info(string.Format("EventCustomerResult AcesApprovedOn saved successfully for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));
                }
                else
                {
                    _logger.Info(string.Format("EventCustomerResult AcesApprovedOn not saved for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error occurred while saving EventCustomerResult AcesApprovedOn for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));
                _logger.Error("Message: " + ex.Message);
                _logger.Error("StackTrace: " + ex.StackTrace);
                return false;
            }
        }

        [HttpGet]
        public IEnumerable<MedicareEventCustomerAcesViewModel> GetEventCustomerForAces()
        {
            try
            {
                return _medicareService.GetEventCustomerForAces();
            }
            catch (Exception ex)
            {
                _logger.Error("Error occurred while getting event customer data for aces.");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("StackTrace: " + ex.StackTrace);
                return null;
            }
        }

        [HttpPost]
        public bool CodingCompleted(MedicareCustomerResultCodedViewModel codingCompleted)
        {
            try
            {
                _logger.Info("Running CodingCompled API for Aces for Customer Id: " + codingCompleted.CustomerId + " EventId : " + codingCompleted.EventId);

                if (string.IsNullOrWhiteSpace(codingCompleted.EmployeeId))
                {
                    _logger.Info("EmployeeId is blank. CodingCompleted API for Customer Id: " + codingCompleted.CustomerId + " EventId : " + codingCompleted.EventId);
                    return false;
                }

                var oru = _organizationRoleUserRepository.GetOrganizationRoleUserByEmployeeIdandRoleId(codingCompleted.EmployeeId, (long)Roles.Coder);
                if (oru == null)
                {
                    _logger.Info("EmployeeId or Coder role not exist. CodingCompleted API for Customer Id: " + codingCompleted.CustomerId + " EventId : " + codingCompleted.EventId);
                    return false;
                }

                var account = _corporateAccountRepository.GetbyEventId(codingCompleted.EventId);

                if (account != null && account.IsHealthPlan)
                {
                    var eventCustomer = _eventCustomerRepository.Get(codingCompleted.EventId, codingCompleted.CustomerId);
                    var isTestPurchased = _testResultService.IsTestPurchasedByCustomer(eventCustomer.Id, (long)TestType.eAWV);

                    var theEvent = _eventRepository.GetById(codingCompleted.EventId);

                    var questionnaireType = _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);

                    if ((questionnaireType != QuestionnaireType.HraQuestionnaire) || !isTestPurchased)
                    {
                        _testResultService.SaveCustomerResultCoded(codingCompleted, oru);
                        _logger.Info("customer result state Updated for Customer Id: " + codingCompleted.CustomerId + " EventId : " + codingCompleted.EventId);
                    }

                    else
                    {
                        _logger.Info("Only HRA is allowed to update for customer Id: " + codingCompleted.CustomerId + "  EventId: " + codingCompleted.EventId);
                        return false;
                    }
                }
                else
                {
                    _logger.Info("Coding Completed can be marked only for HealthPlan Events. Customer Id: " + codingCompleted.CustomerId + "  EventId: " + codingCompleted.EventId);
                    return false;
                }

                _logger.Info("completed CodingCompleted API for Customer Id: " + codingCompleted.CustomerId + " EventId : " + codingCompleted.EventId + " Successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Info("completed CodingCompleted API for Customer Id: " + codingCompleted.CustomerId + " EventId : " + codingCompleted.EventId + " With Error");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("StackTrace: " + ex.StackTrace);

                return false;
            }
        }

        [HttpPost]
        public bool SaveCustomerResultSigned(MedicareCustomerResultSignedNPViewModel model)
        {
            _logger.Info("Method called : SaveCustomerResultSigned for CustmerId: " + model.CustomerId + " EventId: " + model.EventId + " UserId: " + model.UserId);
            if (model.UserId <= 0)
            {
                _logger.Info("UserId is less than or equal to 0. SaveCustomerResultSigned API for Customer Id: " + model.CustomerId + " EventId : " + model.EventId);
                return false;
            }

            var orgRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUserByUserIdAndRoleId(model.UserId, (long)Roles.NursePractitioner);
            if (orgRoleUser == null)
            {
                _logger.Info("UserId or Nurse Practitioner role not exist. SaveCustomerResultSigned API for Customer Id: " + model.CustomerId + " EventId : " + model.EventId + " UserId: " + model.UserId);
                return false;
            }
            try
            {
                var isUpdated = _testResultService.SaveCustomerResultSigned(model, orgRoleUser);

                if (isUpdated)
                {
                    _logger.Info(string.Format("EventCustomerResult Signed saved successfully for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));
                    _logger.Info("Method Completed : SaveCustomerResultSigned for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                }
                else
                {
                    _logger.Info(string.Format("EventCustomerResult Chart Not Signed for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));
                    _logger.Info("Method Completed : SaveCustomerResultSigned for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                }

                return isUpdated;
            }
            catch (Exception ex)
            {
                _logger.Info("completed SaveCustomerResultSigned API for Customer Id: " + model.CustomerId + " EventId : " + model.EventId + " With Error");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("StackTrace: " + ex.StackTrace);
                return false;
            }
        }
    }
}
