using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Core.Insurance.Enum;
using Falcon.App.Core.Insurance.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Newtonsoft.Json;

namespace Falcon.App.Infrastructure.Insurance.Impl
{
    [DefaultImplementation]
    public class EligibilityService : IEligibilityService
    {
        private readonly IEligibilityApi _eligibilityApi;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IEligibilityRepository _eligibilityRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IInsuranceServiceTypeRepository _insuranceServiceTypeRepository;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IBillingAccountRepository _billingAccountRepository;
        

        public EligibilityService(IEligibilityApi eligibilityApi, IInsuranceCompanyRepository insuranceCompanyRepository, IEligibilityRepository eligibilityRepository, IEventPackageRepository eventPackageRepository,
            IEventTestRepository eventTestRepository, IInsuranceServiceTypeRepository insuranceServiceTypeRepository, IChargeCardRepository chargeCardRepository, IPaymentProcessor paymentProcessor,
            IBillingAccountRepository billingAccountRepository)
        {
            _eligibilityApi = eligibilityApi;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _eligibilityRepository = eligibilityRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _insuranceServiceTypeRepository = insuranceServiceTypeRepository;
            _chargeCardRepository = chargeCardRepository;
            _paymentProcessor = paymentProcessor;
            _billingAccountRepository = billingAccountRepository;
        }

        public EligibilityEditModel CheckEligibility(EligibilityEditModel model, long? orgRoleUserId)
        {
            var insuranceCompany = _insuranceCompanyRepository.GetById(model.Request.InsuranceCompanyId);
            var insuranceServiceType = _insuranceServiceTypeRepository.GetById((long)EligibilityServiceType.HBPC);

            var eligibilityRespose = _eligibilityApi.GetCoverage(model.Request, insuranceCompany, insuranceServiceType);

            var creditCardResponse = CheckCreditCard(model.CardDetail);

            if (eligibilityRespose.Plan != null && (eligibilityRespose.Plan.CoverageStatus == EligibleCoverageStatus.ActiveCoverage || eligibilityRespose.Plan.CoverageStatus == EligibleCoverageStatus.ActiveFullRiskCapitation
                || eligibilityRespose.Plan.CoverageStatus == EligibleCoverageStatus.ActiveServicesCapitated || eligibilityRespose.Plan.CoverageStatus == EligibleCoverageStatus.ActiveServicesCapitatedToPrimaryCarePhysician)
                && creditCardResponse.ProcessorResult == ProcessorResponseResult.Accepted)
            {
                decimal coPay = 0;
                decimal coInsurance = 0;

                if (eligibilityRespose.Plan.FinancialData != null)
                {
                    if (eligibilityRespose.Plan.FinancialData.CoPayment != null && eligibilityRespose.Plan.FinancialData.CoPayment.Amounts != null)
                    {
                        if (insuranceCompany.InNetwork)
                        {
                            if (eligibilityRespose.Plan.FinancialData.CoPayment.Amounts.InNetWork != null && eligibilityRespose.Plan.FinancialData.CoPayment.Amounts.InNetWork.Any())
                                coPay = eligibilityRespose.Plan.FinancialData.CoPayment.Amounts.InNetWork.First().Amount;
                        }
                        else
                        {
                            if (eligibilityRespose.Plan.FinancialData.CoPayment.Amounts.OutNetWork != null && eligibilityRespose.Plan.FinancialData.CoPayment.Amounts.OutNetWork.Any())
                                coPay = eligibilityRespose.Plan.FinancialData.CoPayment.Amounts.OutNetWork.First().Amount;
                        }
                    }

                    if (eligibilityRespose.Plan.FinancialData.CoInsurance != null && eligibilityRespose.Plan.FinancialData.CoInsurance.Percents != null)
                    {
                        if (insuranceCompany.InNetwork)
                        {
                            if (eligibilityRespose.Plan.FinancialData.CoInsurance.Percents.InNetWork != null && eligibilityRespose.Plan.FinancialData.CoInsurance.Percents.InNetWork.Any())
                                coInsurance = eligibilityRespose.Plan.FinancialData.CoInsurance.Percents.InNetWork.First().Amount;
                        }
                        else
                        {
                            if (eligibilityRespose.Plan.FinancialData.CoInsurance.Percents.OutNetWork != null && eligibilityRespose.Plan.FinancialData.CoInsurance.Percents.OutNetWork.Any())
                                coPay = eligibilityRespose.Plan.FinancialData.CoInsurance.Percents.OutNetWork.First().Amount;
                        }
                    }
                }
                var eligibility = new Eligibility
                {
                    Id = model.EligibilityId,
                    Guid = eligibilityRespose.Guid,
                    InsuranceCompanyId = model.Request.InsuranceCompanyId,
                    PlanName = eligibilityRespose.Plan.PlanName,
                    GroupName = eligibilityRespose.Demographics.Subscriber.GroupName,
                    CoPayment = coPay,
                    CoInsurance = coInsurance,
                    Request = JsonConvert.SerializeObject(model.Request),
                    Response = eligibilityRespose.RawResponse,
                    DateCreated = DateTime.Now,
                    CreatedByOrgRoleUserId = orgRoleUserId
                };

                eligibility = _eligibilityRepository.Save(eligibility);
                model.EligibilityId = eligibility.Id;

                var chargeCard = model.CardDetail;
                chargeCard.DataRecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(orgRoleUserId.HasValue && orgRoleUserId.Value > 0 ? orgRoleUserId.Value : 1),
                    DateCreated = DateTime.Now
                };
                chargeCard = _chargeCardRepository.Save(chargeCard);
                model.CardDetail = chargeCard;
            }

            model.Response = eligibilityRespose;
            if (creditCardResponse.ProcessorResult != ProcessorResponseResult.Accepted)
            {
                model.ChargeCardResponse = creditCardResponse.Message;
                model.HideCardDetails = false;
            }

            return model;
        }

        public EligibilityViewModel GetEligibilityDetail(long eligibilityId, long eventId, long packageId, IEnumerable<long> testIds)
        {
            var eligibility = _eligibilityRepository.GetById(eligibilityId);
            var amountCoveredByInsurance = GetAmountCoveredByInsurance(eventId, packageId, testIds);
            var model = new EligibilityViewModel
            {
                EligibilityId = eligibility.Id,
                Response = JsonConvert.DeserializeObject<EligibleResponse>(eligibility.Response),
                AmountCovered = amountCoveredByInsurance - eligibility.CoPayment,
                CoPayAmount = eligibility.CoPayment
            };

            return model;
        }

        public bool CheckTestCoveredByinsurance(long eventId, long packageId, IEnumerable<long> testIds)
        {
            var testCoveredByInsurance = false;

            var billingAccountTests = _billingAccountRepository.GetAllBillingAccountTests();
            if (billingAccountTests == null || !billingAccountTests.Any())
                return testCoveredByInsurance;

            var insuredTestIds = billingAccountTests.Select(bat => bat.TestId).ToList();

            var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);

            if (eventPackage != null)
                testCoveredByInsurance = eventPackage.Package.Tests.Any(t => insuredTestIds.Contains(t.Id));

            if (!testCoveredByInsurance && !testIds.IsNullOrEmpty())
                return testIds.Any(t => insuredTestIds.Contains(t));

            return testCoveredByInsurance;
        }

        private decimal GetAmountCoveredByInsurance(long eventId, long packageId, IEnumerable<long> testIds)
        {
            decimal amount = 0;

            var billingAccountTests = _billingAccountRepository.GetAllBillingAccountTests();
            if (billingAccountTests == null || !billingAccountTests.Any())
                return amount;

            var insuredTestIds = billingAccountTests.Select(bat => bat.TestId).ToList();

            var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);

            if (eventPackage != null)
                amount = eventPackage.Package.Tests.Where(t => insuredTestIds.Contains(t.Id)).Sum(t => t.PackagePrice);

            if (!testIds.IsNullOrEmpty())
            {
                var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, testIds);
                amount += eventTests.Where(t => insuredTestIds.Contains(t.TestId)).Sum(t => t.Price);
            }

            return decimal.Round(amount, 2);
        }

        private ProcessorResponse CheckCreditCard(ChargeCard chargeCard)
        {
            var creditCardProcessingInfo = new CreditCardProcessorProcessingInfo
            {
                CreditCardNo = chargeCard.Number,
                SecurityCode = chargeCard.CVV,
                ExpiryMonth = chargeCard.ExpirationDate.Month,
                ExpiryYear = chargeCard.ExpirationDate.Year,
                CardType = chargeCard.TypeId.ToString(),
                Price = "1",
                Currency = "USD"
            };
            return _paymentProcessor.AuthorizeOnly(creditCardProcessingInfo);
        }

        public IEnumerable<InsuranceDetailViewModel> GetInsuranceDetailByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            var eligibilities = _eligibilityRepository.GetByEventCustomerIds(eventCustomerIds);
            if (eligibilities != null && eligibilities.Any())
            {
                var insurancedetailViewModels = new List<InsuranceDetailViewModel>();

                var eventCustomerEligibilities = _eligibilityRepository.GetEventCustomerEligibilityIdByEventCustomerIds(eventCustomerIds);
                
                var insuranceCompanies = _insuranceCompanyRepository.GetAll();

                eligibilities.ToList().ForEach(e=>
                {
                    var response = JsonConvert.DeserializeObject<EligibleResponse>(e.Response);
                    InsuranceCompany insuranceCompany = null;
                    if (response.PrimaryInsurance != null)
                    {
                        insuranceCompany = insuranceCompanies.FirstOrDefault(ic => ic.Code == response.PrimaryInsurance.Id);
                    }
                    else if (response.Insurance != null)
                    {
                        insuranceCompany = insuranceCompanies.FirstOrDefault(ic => ic.Code == response.Insurance.Id);
                    }

                    if (insuranceCompany == null)
                    {
                        insuranceCompany = insuranceCompanies.First(ic => ic.Id == e.InsuranceCompanyId);
                    }

                    var eventCustomerEligibility = eventCustomerEligibilities.First(ece => ece.EligibilityId == e.Id);

                   insurancedetailViewModels.Add(new InsuranceDetailViewModel
                   {
                       EventCustomerId = eventCustomerEligibility.EventCustomerId,
                       MemberId = response.Demographics.Subscriber.MemberId,
                       InsuranceCompany = insuranceCompany.Name,
                       PlanName = response.Plan.PlanName,
                       PlanId = string.IsNullOrEmpty(response.Plan.PlanNumber) ? "N/A" : response.Plan.PlanNumber,
                       GroupName = string.IsNullOrEmpty(response.Demographics.Subscriber.GroupName) ? "N/A" : response.Demographics.Subscriber.GroupName,
                       GroupId = string.IsNullOrEmpty(response.Demographics.Subscriber.GroupId) ? "N/A" : response.Demographics.Subscriber.GroupId,
                   });
                });
                return insurancedetailViewModels;
            }
            return null;
        }

    }
}
