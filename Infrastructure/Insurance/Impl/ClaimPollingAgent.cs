using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Insurance.Impl
{
    [DefaultImplementation]
    public class ClaimPollingAgent : IClaimPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ISettings _settings;
        private readonly KareoApi _kareoApi;
        private readonly IBillingAccountRepository _billingAccountRepository;
        private readonly IEncounterRepository _encounterRepository;
        private readonly IClaimRepository _claimRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICombinedPaymentInstrumentRepository _paymentInstrumentRepository;
        private readonly IUniqueItemRepository<Event> _eventRepository;

        public ClaimPollingAgent(ILogManager logManager, IEventCustomerRepository eventCustomerRepository, ISettings settings, IBillingAccountRepository billingAccountRepository, IEncounterRepository encounterRepository,
            IClaimRepository claimRepository, IOrderRepository orderRepository, ICombinedPaymentInstrumentRepository paymentInstrumentRepository, IUniqueItemRepository<Event> eventRepository)
        {
            _logger = logManager.GetLogger<ClaimPollingAgent>();
            _eventCustomerRepository = eventCustomerRepository;
            _settings = settings;
            _kareoApi = new KareoApi();
            _billingAccountRepository = billingAccountRepository;
            _encounterRepository = encounterRepository;
            _claimRepository = claimRepository;
            _orderRepository = orderRepository;
            _paymentInstrumentRepository = paymentInstrumentRepository;
            _eventRepository = eventRepository;
        }

        public void PollForInsuranceClaim()
        {
            _logger.Info("\n");
            _logger.Info(string.Format("Creating Claims. Date: {0:MM/dd/yyyy}", DateTime.Now));
            _logger.Info("\n");

            try
            {
                var billingAccounts = _billingAccountRepository.GetAll();
                if (billingAccounts == null || !billingAccounts.Any())
                {
                    _logger.Info("No billing account has been setup");
                }
                foreach (var billingAccount in billingAccounts)
                {
                    var eventCustomers = _eventCustomerRepository.GetEventCustomersForInsuranceClaim(_settings.DaysAfterGetClaim, billingAccount.Id);

                    if (eventCustomers == null || !eventCustomers.Any())
                    {
                        _logger.Info("No Records Found!");
                        continue;
                    }

                    var eventCustomerEncounters = _encounterRepository.GetEventCustomerEncounterByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());
                    

                    var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();

                    var events = _eventRepository.GetByIds(eventIds);

                    foreach (var eventId in eventIds)
                    {
                        var eventData = events.First(e => e.Id == eventId);
                        var claimResponse = _kareoApi.GetClaim(billingAccount, 32090, eventData.EventDate);//eventId
                        if (claimResponse == null || claimResponse.Charges == null || !claimResponse.Charges.Any())
                        {
                            _logger.Info(string.Format("No Claims for Event (Id:{0})", eventId));
                            continue;
                        }

                        var eventCustomersData = eventCustomers.Where(ec => ec.EventId == eventId).Select(ec => ec).ToArray();
                        foreach (var eventCustomer in eventCustomersData)
                        {
                            var eventCustomerEncounter = eventCustomerEncounters.First(ece => ece.EventCustomerId == eventCustomer.Id);
                            var chargeData = claimResponse.Charges.Where(c => c.EncounterID == eventCustomerEncounter.EncounterId.ToString()).Select(c => c).ToArray();

                            if (chargeData == null || !chargeData.Any())
                            {
                                _logger.Info(string.Format("No Claims for Event (Id:{0}) and Customer (Id:{1}) ", eventId, eventCustomer.CustomerId));
                                continue;
                            }

                            var orderId = _orderRepository.GetOrderIdByEventCustomerId(eventCustomer.Id);
                            var paymentsApplied = _paymentInstrumentRepository.GetByOrderId(orderId);
                            var insurancePayment = paymentsApplied.Where(pi => pi.PaymentType == PaymentType.Insurance).Select(pi => pi).SingleOrDefault();
                            if (insurancePayment == null)
                            {
                                _logger.Info(string.Format("No Insurance payment for Event (Id:{0}) and Customer (Id:{1}) ", eventId, eventCustomer.CustomerId));
                                continue;
                            }
                            decimal amount = 0m;
                            foreach (var charge in chargeData)
                            {
                                var claim = new Claim
                                {
                                    Id = Convert.ToInt64(charge.ID),
                                    EncounterId = Convert.ToInt64(charge.EncounterID),
                                    BillingPatientId = Convert.ToInt64(charge.PatientID),
                                    InsurancePaymentId = insurancePayment.Id,
                                    ProcedureCode = charge.ProcedureCode,
                                    ProcedureName = charge.ProcedureName,
                                    Units = Convert.ToInt32(Convert.ToDecimal(charge.Units)),
                                    TotalCharges = Convert.ToDecimal(charge.TotalCharges),
                                    AdjustedCharges = Convert.ToDecimal(charge.AdjustedCharges),
                                    Receipts = Convert.ToDecimal(charge.Receipts),
                                    PatientBalance = Convert.ToDecimal(charge.PatientBalance),
                                    InsuranceBalance = Convert.ToDecimal(charge.InsuranceBalance),
                                    TotalBalance = Convert.ToDecimal(charge.TotalBalance),
                                    Status = charge.Status,
                                    DateCreated = DateTime.Now,
                                    //FirstBillDate = Convert.ToDateTime(charge.PatientFirstBillDate),
                                    //LastBillDate = Convert.ToDateTime(charge.PatientLastBillDate)
                                };
                                //TODO:Save Claim
                                _claimRepository.Save(claim);
                                amount += claim.TotalCharges - claim.TotalBalance;
                            }
                            //TODO:Update Insurance payment
                            insurancePayment.Amount = amount;
                            _paymentInstrumentRepository.SavePaymentInstrument(insurancePayment);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while fetching event customers Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                _logger.Info("\n");
            }
        }
    }
}
