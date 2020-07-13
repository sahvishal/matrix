using System;
using System.Collections.Generic;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.CCD;
using Falcon.App.Core.CCD.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;


namespace Falcon.App.Infrastructure.CCD.impl
{
    [DefaultImplementation]
    public class ClinicalDocumentReportingService : IClinicalDocumentReportingService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IClinicalDocumentFactory _clinicalDocumentFactory;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IXmlSerializer<ClinicalDocument> _clinicalDocumentSerializer;
        private readonly ISettings _settings;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEnumerable<long> _accountIds;
        private readonly ILogger _logger;

        private readonly ICustomSettingManager _customSettingManager;

        public ClinicalDocumentReportingService(ICustomerRepository customerRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            IClinicalDocumentFactory clinicalDocumentFactory, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            IXmlSerializer<ClinicalDocument> clinicalDocumentSerializer, ISettings settings, IEventRepository eventRepository,
            ICorporateAccountRepository corporateAccountRepository, ILogManager logManager, ICustomSettingManager customSettingManager)
        {
            _customerRepository = customerRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _clinicalDocumentFactory = clinicalDocumentFactory;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _clinicalDocumentSerializer = clinicalDocumentSerializer;
            _settings = settings;
            _eventRepository = eventRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _accountIds = settings.ClinicalDoumentAccountIds;
            _logger = logManager.GetLogger("ClinicalDocumentReportingService");
            _customSettingManager = customSettingManager;
        }

        public void PollForClinicalDocument()
        {
            if (_accountIds.IsNullOrEmpty()) return;
            var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

            _logger.Info("Starting CCD Service...");

            foreach (var account in corporateAccounts)
            {
                try
                {
                    _logger.Info("running For Account Id..... " + account.Id);

                    var customSettingFilePath = string.Format(_settings.ClinicalDoumentSettingPath, account.Tag);
                    var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

                    var fromDate = customSettings.LastTransactionDate ?? _settings.PcpDownloadCutOfDate;
                    var toDate = DateTime.Now;

                    var eventCustomers = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, toDate, fromDate, account.Id, account.Tag);

                    if (eventCustomers.IsNullOrEmpty()) return;

                    var directoryPath = string.Format(_settings.ClinicalDoumentPath, account.FolderName);

                    foreach (var ecr in eventCustomers)
                    {
                        try
                        {
                            _logger.Info("Generating CCD Report for Customer Id " + ecr.CustomerId + " eventid: " + ecr.EventId);
                            var customer = _customerRepository.GetCustomer(ecr.CustomerId);
                            var pcp = _primaryCarePhysicianRepository.Get(customer.CustomerId);
                            var theEvent = _eventRepository.GetById(ecr.EventId);
                            var model = _clinicalDocumentFactory.Create(ecr, customer, pcp, theEvent);

                            var fileName = customer.Name.FirstName + customer.Name.LastName + ".xml";

                            var filePath = Path.Combine(directoryPath, fileName);

                            DirectoryOperationsHelper.DeleteFileIfExist(filePath);

                            _clinicalDocumentSerializer.SerializeandSave(filePath, model);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error("some Exception occured while generating CCD Xml for customerId: " + ecr.CustomerId + " Eventid: " + ecr.EventId + " for Tag" + account.Tag);
                            _logger.Error("Message: " + exception.Message);
                            _logger.Error("Stack Trace: " + exception.StackTrace);
                        }

                    }

                    _logger.Info("compeletd  For Account Id..... " + account.Id);
                }
                catch (Exception exception)
                {
                    _logger.Error("some Exception occured while generating CCD Xml for account Tag " + account.Tag);
                    _logger.Error("Message: " + exception.Message);
                    _logger.Error("Stack Trace: " + exception.StackTrace);
                }
            }



        }
    }
}
