using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Kareo;

namespace Falcon.App.Infrastructure.Insurance.Impl
{
    [DefaultImplementation]
    public class PatientKareoIntegrationPollingAgent : IPatientKareoIntegrationPollingAgent
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBillingAccountRepository _billingAccountRepository;
        private readonly ICustomerBillingAccountRepository _customerBillingAccountRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;
        private readonly KareoApi _kareoApi;
        private readonly string _customSettingFile;
        private readonly DateTime _cutOffDate;
        private readonly ISettings _settings;

        public PatientKareoIntegrationPollingAgent(ILogManager logManager, ICustomerRepository customerRepository, IBillingAccountRepository billingAccountRepository,ICustomerBillingAccountRepository customerBillingAccountRepository, 
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IEventCustomerRepository eventCustomerRepository, ISettings settings, ICustomSettingManager customSettingManager)
        {
            _customerRepository = customerRepository;
            _billingAccountRepository = billingAccountRepository;
            _customerBillingAccountRepository = customerBillingAccountRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customSettingManager = customSettingManager;
            _logger = logManager.GetLogger("PatientKareoIntegration");
            _kareoApi = new KareoApi();
            _customSettingFile = settings.KareoIntegrationSettingResourcePath;
            _cutOffDate = settings.KareoIntegrationCutOffDate;
            _settings = settings;
        }

        public void PollForIntegration()
        {
            _logger.Info("Starting kareo integration for patients.");

            var fromDate = _settings.SyncStartDate.HasValue ? _settings.SyncStartDate.Value : DateTime.Today.AddDays(7);
            var toDate = _settings.SyncEndDate.HasValue ? _settings.SyncEndDate.Value : DateTime.Today.AddDays(7);

            var eventCustomers = _eventCustomerRepository.GetByEventDate(fromDate, toDate).ToList();

            var eventCustomersForToday = _eventCustomerRepository.GetByEventDate(DateTime.Today, DateTime.Today);
            eventCustomers.AddRange(eventCustomersForToday);

            var customSettingFilePath = string.Format(_customSettingFile, "PatientKareoIntegration");
            var customSettings = _customSettingManager.Deserialize(customSettingFilePath);

            if (customSettings.LastTransactionDate == null)
            {
                fromDate = _cutOffDate;
                toDate = DateTime.Today.AddDays(-1);
                var pastEventCustomers = _eventCustomerRepository.GetByEventDate(fromDate, toDate).ToList();
                eventCustomers.AddRange(pastEventCustomers);
            }

            if (eventCustomers.IsNullOrEmpty())
            {
                _logger.Info("No event customers found.");
                return;
            }

            var billingAccounts = _billingAccountRepository.GetAll();
            if (billingAccounts.IsNullOrEmpty())
            {
                _logger.Info("No Billing Accounts added.");
                return;
            }

            var billingAccount = billingAccounts.First();

            var orderedEventCustomers = eventCustomers.OrderBy(x => x.EventId).ToArray();

            var eventIds = orderedEventCustomers.OrderBy(x => x.EventId).Select(x => x.EventId).Distinct().ToArray();

            _logger.Info("No. of Events : " + eventIds.Count());

            foreach (var eventId in eventIds)
            {
                try
                {
                    _logger.Info("Integrating for EventID : " + eventId);

                    var customerIds = orderedEventCustomers.Where(x => x.EventId == eventId).Select(x => x.CustomerId).ToArray();

                    var customersAlreadySyncedBySystem = _customerBillingAccountRepository.GetAlreadySyncedCustomers(customerIds, billingAccount.Id);

                    var customersToSync = _customerRepository.GetCustomers(customerIds);

                    var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

                    foreach (var customer in customersToSync)
                    {
                        try
                        {
                            var pcp = primaryCarePhysicians.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

                            if (customersAlreadySyncedBySystem.Select(x => x.CustomerId).Contains(customer.CustomerId))
                            {
                                var syncedCustomer = customersAlreadySyncedBySystem.First(x => x.CustomerId == customer.CustomerId);

                                var existingPatientResponse = _kareoApi.GetPatients(customer.Name.FirstName, customer.Name.LastName, customer.DateOfBirth.Value, billingAccount);

                                _kareoApi.UpdatePatient(syncedCustomer.BillingPatientId, customer, pcp, billingAccount);

                                _logger.Info("Updated patient informationon Kareo for Customer ID : " + customer.CustomerId);
                                _logger.Info("\n");
                            }
                            else
                            {
                                var patientResponse = new GetPatientsResp();

                                if (customer.DateOfBirth.HasValue)
                                {
                                    patientResponse = _kareoApi.GetPatients(customer.Name.FirstName, customer.Name.LastName, customer.DateOfBirth.Value, billingAccount);
                                }

                                if (patientResponse != null && !patientResponse.Patients.IsNullOrEmpty() && patientResponse.Patients.Any(x => !string.IsNullOrEmpty(x.ID)))
                                {
                                    _logger.Info(string.Format("Customer : {0} already synced.", customer.CustomerId));

                                    var patient = patientResponse.Patients.First();

                                    var patientId = Convert.ToInt64(patient.ID);

                                    _kareoApi.UpdatePatient(patientId, customer, pcp, billingAccount);

                                    SaveCustomerBillingAccount(billingAccount, patientId, customer.CustomerId);

                                    _logger.Info("Updated patient informationon Kareo for Customer ID : " + customer.CustomerId);
                                    _logger.Info("\n");
                                }
                                else
                                {
                                    _logger.Info("Creating patient on Kareo for Customer ID : " + customer.CustomerId);

                                    var createPatientResp = _kareoApi.CreatePatientNew(customer, pcp, billingAccount);

                                    if (!createPatientResp.PatientID.HasValue)
                                    {
                                        _logger.Info(string.Format("Patient not created for Event (Id: {0}) and Customer (Id: {1}) and Billing Account {2}", eventId, customer.CustomerId, billingAccount.Name));
                                        _logger.Info("\n");
                                        continue;
                                    }

                                    SaveCustomerBillingAccount(billingAccount, createPatientResp.PatientID.Value, customer.CustomerId);

                                    _logger.Info(string.Format("Customer : {0} synced.", customer.CustomerId));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Info(string.Format("Error integrating for EventID : {0} and Customer ID : {1} \nMessage : {2} \nStack Trace : {3}", eventId, customer.CustomerId, ex.Message, ex.StackTrace));
                        }

                    }
                    _logger.Info("Completed for EventID : " + eventId);
                    _logger.Info("\n");
                }
                catch (Exception ex)
                {
                    _logger.Info(string.Format("Error integrating for EventID : {0} \nMessage : {1} \nStack Trace : {2}", eventId, ex.Message, ex.StackTrace));
                }
            }

            customSettings.LastTransactionDate = DateTime.Today;
            _customSettingManager.SerializeandSave(customSettingFilePath, customSettings);

            _logger.Info("Kareo integration completed.");
        }

        private void SaveCustomerBillingAccount(BillingAccount billingAccount, long patientId, long customerId)
        {
            var customerBillingAccount = new CustomerBillingAccount()
            {
                BillingAccountId = billingAccount.Id,
                BillingPatientId = patientId,
                CustomerId = customerId,
                DateCreated = DateTime.Now
            };
            _customerBillingAccountRepository.Save(customerBillingAccount);
        }
    }
}
