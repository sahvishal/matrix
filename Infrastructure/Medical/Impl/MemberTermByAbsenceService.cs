using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MemberTermByAbsenceService : IMemberTermByAbsenceService
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly ICorporateUploadRepository _corporateUploadRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ICustomerEligibilityService _customerEligibilityService;
        private readonly ILogger _logger;
        private const int PageSize = 500;
        private const int OrganizationRoleId = 1;

        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;

        public MemberTermByAbsenceService(ICustomerRepository customerRepository, ILogManager logManager,
            ICorporateUploadRepository corporateUploadRepository, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            ICustomerEligibilityService customerEligibilityService, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier)
        {
            _customerRepository = customerRepository;
            _corporateUploadRepository = corporateUploadRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _customerEligibilityService = customerEligibilityService;
            _logger = logManager.GetLogger("MemberTermByAbsence");
            
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
        }

        public void SubscribeForEligibiltyUpdate(long corporateUploadId)
        {
            try
            {
                var corporateUpload = _corporateUploadRepository.GetById(corporateUploadId);
                if (corporateUpload == null || corporateUpload.AccountId.HasValue == false)
                {
                    _logger.Info("No Corporate Upload found for the Corporate Id " + corporateUploadId);
                    return;
                }

                var filter = CreateFilter(corporateUpload);
                if (filter == null) return;
                _logger.Info("Starting For Corporate Upload Id " + corporateUploadId);
                UpdateMemberByFilter(filter);

                _logger.Info("Completed For Corporate Upload Id " + corporateUploadId);
                _logger.Info("********************** ");
                _logger.Info("  ");
            }
            catch (Exception exception)
            {
                _logger.Error("Some error occurred");
                _logger.Error("Message: " + exception.Message);
                _logger.Error("Stack trace: " + exception.StackTrace);
            }
        }

        private void UpdateMemberByFilter(MemberTermByAbsenceFilter filter)
        {
            int pageNumber = 1;
            int errorCount = 0;

            while (true)
            {
                int totalRecords;
                try
                {
                    _logger.Info("Fetching Records for: Page Number " + PageSize + " Filter " + filter);
                    var customerIds = _customerRepository.GetCustomerForTermByAbsence(pageNumber, PageSize, filter, out totalRecords);
                    _logger.Info("Fetched Records for: Page Number " + PageSize + " Filter " + filter);

                    if (customerIds.IsNullOrEmpty())
                    {
                        break;
                    }
                    _logger.Info("Starting: Total Records: " + totalRecords);

                    UpdateMemberEligibility(customerIds);

                    _logger.Info("Completed: Total Records: " + totalRecords);
                    errorCount = 0;
                    

                }
                catch (Exception ex)
                {
                    errorCount++;
                    _logger.Info("Error occurred while Fetching Records");
                    _logger.Info("Error Message: " + ex.Message);
                    _logger.Info("Error Stack Trace: " + ex.StackTrace);
                }

                if (errorCount >= 3)
                {
                    ErrorMailSend(filter, _logger);
                    return;
                }
            }
        }

        private void UpdateMemberEligibility(IEnumerable<long> customerIds)
        {
            foreach (var customerId in customerIds)
            {
                try
                {
                    _logger.Info("Starting for CustomreId: " + customerId + " to Update Eligibility ");

                    _customerEligibilityService.Save(customerId, DateTime.Today.Year, false, OrganizationRoleId, _logger);

                    _logger.Info("Completed for CustomreId: " + customerId + " to Update Eligibility ");
                }
                catch (Exception ex)
                {
                    _logger.Error(" error occurred while updating Eligibility for Customer: " + customerId);
                    _logger.Error(" Message: " + ex.Message);
                    _logger.Error(" Stack Trace: " + ex.StackTrace);
                }
            }
        }

        private MemberTermByAbsenceFilter CreateFilter(CorporateUpload corporateUpload)
        {
            if (corporateUpload.AccountId.HasValue)
            {
                var account = _corporateAccountRepository.GetById(corporateUpload.AccountId.Value);
                return new MemberTermByAbsenceFilter
                {
                    CorporateUploadId = corporateUpload.Id,
                    Tag = account.Tag
                };
            }

            _logger.Info("corporate account Id can not be null ");
            return null;
        }

        private void ErrorMailSend(MemberTermByAbsenceFilter filter,ILogger logger)
        {

            try
            {
                var fileNotPostedModel = _emailNotificationModelsFactory.GetAbsenceByMemberViewModel(filter.Tag, filter.CorporateUploadId);
                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AbsenceByMember, EmailTemplateAlias.AbsenceByMember, fileNotPostedModel, 0, 1, "Absence By Member");
            }
            catch (Exception ex)
            {
                logger.Error("Error while sending File Not Posted notification");
                logger.Error("Message:" + ex.Message);
                logger.Error("Stack Trace:" + ex.StackTrace);
            }
        }
    }
}