using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;


namespace Falcon.App.Infrastructure.Insurance.Impl
{
    [DefaultImplementation]
    public class EncounterPollingAgent : IEncounterPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEligibilityRepository _eligibilityRepository;
        private readonly KareoApi _kareoApi;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IBillingAccountRepository _billingAccountRepository;
        private readonly ICustomerBillingAccountRepository _customerBillingAccountRepository;
        private readonly IEncounterRepository _encounterRepository;

        public EncounterPollingAgent(ILogManager logManager, IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IEventRepository eventRepository, IEligibilityRepository eligibilityRepository,
            IInsuranceCompanyRepository insuranceCompanyRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository,
            IEventTestRepository eventTestRepository, IAppointmentRepository appointmentRepository, IBillingAccountRepository billingAccountRepository, ICustomerBillingAccountRepository customerBillingAccountRepository,
            IEncounterRepository encounterRepository)
        {
            _logger = logManager.GetLogger<EncounterPollingAgent>();
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _eligibilityRepository = eligibilityRepository;
            _kareoApi = new KareoApi();
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _appointmentRepository = appointmentRepository;
            _billingAccountRepository = billingAccountRepository;
            _customerBillingAccountRepository = customerBillingAccountRepository;
            _encounterRepository = encounterRepository;
        }

        public void PollforInsuranceEncounter()
        {
            const int pageSize = 50;
            int pageNumber = 1;

            _logger.Info("\n");
            _logger.Info(string.Format("Creating Patients and Encounter. Date: {0:MM/dd/yyyy}", DateTime.Now));
            _logger.Info("\n");

            var filter = new InsurancePaymentListModelFilter
            {
                EventFrom = DateTime.Now.Date.AddDays(-1),
                EventTo = DateTime.Now.Date.AddDays(-1)
            };

            while (true)
            {
                try
                {
                    int totalRecords;

                    var eventCustomers = _eventCustomerRepository.GetInsurancePayment(pageNumber, pageSize, filter, out totalRecords);

                    if (eventCustomers == null || !eventCustomers.Any())
                    {
                        _logger.Info("No Records Found!");
                        break;
                    }

                    var insuranceCompanies = _insuranceCompanyRepository.GetAll();
                    var billingAccounts = _billingAccountRepository.GetAll();
                    var billingAccountTests = _billingAccountRepository.GetAllBillingAccountTests();

                    if (billingAccounts == null || !billingAccounts.Any())
                    {
                        _logger.Info("No billing account has been setup");
                        break;
                    }

                    if (billingAccountTests == null || !billingAccountTests.Any())
                    {
                        _logger.Info("No billing account test has been setup");
                        break;
                    }
                    //var response = _kareoApi.GetPatient(4, billingAccounts.First());
                    foreach (var eventCustomer in eventCustomers)
                    {
                        if (eventCustomer.NoShow || !eventCustomer.AppointmentId.HasValue || !eventCustomer.LeftWithoutScreeningReasonId.HasValue)
                            continue;

                        var appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

                        if (!appointment.CheckInTime.HasValue)
                            continue;

                        _logger.Info(string.Format("Creating Patient and Encounter for Event (Id: {0}) and Customer (Id: {1})", eventCustomer.EventId, eventCustomer.CustomerId));
                        _logger.Info("\n");

                        var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);
                        var eventData = _eventRepository.GetById(eventCustomer.EventId);
                        var eligibility = _eligibilityRepository.GetByEventCustomerId(eventCustomer.Id);
                        var pcp = _primaryCarePhysicianRepository.Get(eventCustomer.CustomerId);

                        var eventTests = new List<EventTest>();

                        var orderId = _orderRepository.GetOrderIdByEventCustomerId(eventCustomer.Id);
                        var eventPackage = _eventPackageRepository.GetPackageForOrder(orderId);
                        var alaCarteTests = _eventTestRepository.GetTestsForOrder(orderId);

                        if (eventPackage != null)
                        {
                            foreach (var test in eventPackage.Tests)
                            {
                                test.Price = test.Test.PackagePrice;
                            }
                            eventTests.AddRange(eventPackage.Tests);
                        }

                        if (alaCarteTests != null && alaCarteTests.Any())
                            eventTests.AddRange(alaCarteTests);

                        foreach (var billingAccount in billingAccounts)
                        {
                            var billingAccountTestIds = billingAccountTests.Where(bat => bat.BillingAccountId == billingAccount.Id).Select(bat => bat.TestId).ToArray();

                            var insuranceTests = eventTests.Where(et => billingAccountTestIds.Contains(et.TestId)).Select(et => et).ToArray();
                            if (insuranceTests == null || !insuranceTests.Any())
                                continue;

                            long patientId;
                            var customerBillingAccount = _customerBillingAccountRepository.GetByCustomerIdBillingAccountId(eventCustomer.CustomerId, billingAccount.Id);
                            if (customerBillingAccount != null)
                            {
                                patientId = customerBillingAccount.BillingPatientId;
                            }
                            else
                            {
                                var patientResponse = _kareoApi.CreatePatient(customer, eligibility, insuranceCompanies, pcp, billingAccount);
                                if (!patientResponse.PatientID.HasValue)
                                {
                                    _logger.Info(string.Format("Patient not created for Event (Id: {0}) and Customer (Id: {1}) and Billing Account {2}", eventCustomer.EventId, eventCustomer.CustomerId, billingAccount.Name));
                                    _logger.Info("\n");
                                    continue;
                                }

                                customerBillingAccount = new CustomerBillingAccount()
                                {
                                    BillingAccountId = billingAccount.Id,
                                    BillingPatientId = patientResponse.PatientID.Value,
                                    CustomerId = customer.CustomerId,
                                    DateCreated = DateTime.Now
                                };
                                _customerBillingAccountRepository.Save(customerBillingAccount);

                                patientId = patientResponse.PatientID.Value;

                                _logger.Info(string.Format("Patient created for Event (Id: {0}) and Customer (Id: {1}) and Billing Account {2}", eventCustomer.EventId, eventCustomer.CustomerId, billingAccount.Name));
                            }

                            if (patientId > 0)
                            {
                                var encounterResponse = _kareoApi.CreateEncounter(patientId, eventData, insuranceTests, billingAccount);
                                if (encounterResponse.EncounterID > 0)
                                {
                                    var encounter = new Encounter
                                    {
                                        Id = encounterResponse.EncounterID,
                                        BillingAccountId = billingAccount.Id,
                                        DateCreated = DateTime.Now
                                    };
                                    encounter = _encounterRepository.Save(encounter);
                                    _encounterRepository.SaveEventCustomerEncounter(eventCustomer.Id, encounter.Id);

                                    _logger.Info(string.Format("Encounter created for Event (Id: {0}) and Customer (Id: {1}) and Billing Account {2}", eventCustomer.EventId, eventCustomer.CustomerId, billingAccount.Name));
                                }
                                else
                                {
                                    _logger.Info(string.Format("Encounter not created for Event (Id: {0}) and Customer (Id: {1}) and Billing Account {2}", eventCustomer.EventId, eventCustomer.CustomerId, billingAccount.Name));
                                    _logger.Info("\n");
                                }
                            }
                        }
                    }

                    if ((pageNumber * pageSize) >= totalRecords)
                        break;

                    pageNumber++;
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Error while fetching event customers Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                    _logger.Info("\n");
                    break;
                }
            }
        }
    }
}
