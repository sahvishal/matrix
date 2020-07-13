using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.CallQueues;

namespace Falcon.App.Infrastructure.Scheduling.Services
{
    [DefaultImplementation]
    public class CorporateCustomerUploadService : ICorporateCustomerUploadService
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRegistrationHelper _customerRegistrationHelper;
        private readonly ICurrentMedicationRepository _currentMedicationRepository;
        private readonly IEventCustomerCurrentMedicationRepository _eventCustomerCurrentMedicationRepository;
        private readonly IEventCustomerPreApprovedTestRepository _eventCustomerPreApprovedTestRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IEventCustomerPreApprovedPackageTestRepository _eventCustomerPreApprovedPackageTestRepository;
        private readonly IPreApprovedPackageRepository _preApprovedPackageRepository;
        private readonly IPackageTestRepository _packageTestRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IEventCustomerPrimaryCarePhysicianRepository _eventCustomerPrimaryCarePhysicianRepository;
        private readonly IIcdCodesRepository _icdCodesRepository;
        private readonly ICustomerIcdCodesRepository _customerIcdCodesRepository;
        private readonly IEventCustomerIcdCodesRepository _eventCustomerIcdCodesRepository;
        private readonly ICustomerPredictedZipRespository _customerPredictedZipRespository;
        private readonly ICustomerTargetedService _customerTargetedService;
        private readonly ICustomerEligibilityService _customerEligibilityService;
        private readonly ICustomerWarmTransferService _customerWarmTransferService;
        private readonly IAddressRepository _addressRepository;
        private readonly ICorporateUploadHelper _corporateUploadHelper;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        //private readonly IRequiredTestRepository _requiredTestRepository;


        public CorporateCustomerUploadService(IZipCodeRepository zipCodeRepository, IEventCustomerRepository eventCustomerRepository,
            ICustomerRegistrationHelper customerRegistrationHelper, ICurrentMedicationRepository currentMedicationRepository,
            IEventCustomerCurrentMedicationRepository eventCustomerCurrentMedicationRepository,
            IEventCustomerPreApprovedTestRepository eventCustomerPreApprovedTestRepository, IPreApprovedTestRepository preApprovedTestRepository,
            IEventCustomerPreApprovedPackageTestRepository eventCustomerPreApprovedPackageTestRepository, IPreApprovedPackageRepository preApprovedPackageRepository,
            IPackageTestRepository packageTestRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            IEventCustomerPrimaryCarePhysicianRepository eventCustomerPrimaryCarePhysicianRepository, IIcdCodesRepository icdCodesRepository,
            ICustomerIcdCodesRepository customerIcdCodesRepository, IEventCustomerIcdCodesRepository eventCustomerIcdCodesRepository,
            ICustomerPredictedZipRespository customerPredictedZipRespository, ICustomerTargetedService customerTargetedService,
            ICustomerEligibilityService customerEligibilityService, ICustomerWarmTransferService customerWarmTransferService, IAddressRepository addressRepository
            , ICorporateUploadHelper corporateUploadHelper, ICallQueueCustomerRepository callQueueCustomerRepository
            //, IRequiredTestRepository requiredTestRepository
            )
        {
            _zipCodeRepository = zipCodeRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRegistrationHelper = customerRegistrationHelper;
            _currentMedicationRepository = currentMedicationRepository;
            _eventCustomerCurrentMedicationRepository = eventCustomerCurrentMedicationRepository;
            _eventCustomerPreApprovedTestRepository = eventCustomerPreApprovedTestRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _eventCustomerPreApprovedPackageTestRepository = eventCustomerPreApprovedPackageTestRepository;
            _preApprovedPackageRepository = preApprovedPackageRepository;
            _packageTestRepository = packageTestRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _eventCustomerPrimaryCarePhysicianRepository = eventCustomerPrimaryCarePhysicianRepository;
            _icdCodesRepository = icdCodesRepository;
            _customerIcdCodesRepository = customerIcdCodesRepository;
            _eventCustomerIcdCodesRepository = eventCustomerIcdCodesRepository;
            _customerPredictedZipRespository = customerPredictedZipRespository;
            _customerTargetedService = customerTargetedService;
            _customerEligibilityService = customerEligibilityService;
            _customerWarmTransferService = customerWarmTransferService;
            _addressRepository = addressRepository;
            _corporateUploadHelper = corporateUploadHelper;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            //_requiredTestRepository = requiredTestRepository;
        }

        public string ValidateZipCodes(string zipCodes)
        {
            if (!string.IsNullOrEmpty(zipCodes))
            {
                var delimeter = ",";
                var predictedZipCodes = zipCodes.Split(new[] { delimeter }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                var isAllZipValid = predictedZipCodes.All(x => x.Length == 5);

                if (!isAllZipValid)
                    return string.Join(", ", predictedZipCodes.Where(x => x.Length != 5)) + " Zip code(s) are invalid.";

                var result = 0;
                isAllZipValid = predictedZipCodes.All(x => int.TryParse(x, out result));

                if (!isAllZipValid)
                    return string.Join(", ", predictedZipCodes.Where(x => !int.TryParse(x, out result))) + " Zip code(s) are invalid.";

                var existingZipCodes = _zipCodeRepository.GetZipCodesByZipCode(predictedZipCodes);
                if (existingZipCodes.IsNullOrEmpty())
                    return string.Join(", ", predictedZipCodes) + " Zip code(s) are invalid.";

                var notVaidZipList = predictedZipCodes.Except(existingZipCodes.Select(x => x.Zip).Distinct());
                if (notVaidZipList.Any())
                    return string.Join(", ", notVaidZipList) + " Zip code(s) are invalid.";
            }
            return string.Empty;
        }

        public void UpdateCustomerData(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer, ILogger logger)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomerForFurtureEventsByCustomerId(customer.CustomerId);

            UpdateCustomerCurrentMedication(model, createdByOrgRoleUser, customer, eventCustomers);
            UpdateCustomerPrimaryCarePhysician(model, createdByOrgRoleUser, customer, eventCustomers);
            UpdateCustomerIcdCodes(model, createdByOrgRoleUser, customer, eventCustomers);
            SaveCustomerPredictedZip(customer.CustomerId, model.PredictedZip);

            //UpateCustomerPreApprovedTest(model, createdByOrgRoleUser.Id, customer.CustomerId);
            //UpdateCustomerPreApprovedPackges(model, createdByOrgRoleUser.Id, customer.CustomerId);
            //UpdateCustomerPreApprovedForFutureEvents(eventCustomers, model);

            //if (model.MemberUploadSourceId == null)
            //    UpateCustomerRequiredTest(model, createdByOrgRoleUser, customer);

            UpdateCustomerTargeted(model, createdByOrgRoleUser, customer);
            UpdateCustomerEligibility(model, createdByOrgRoleUser, customer, logger);
            UpdateCustomerWarmTransfer(model, createdByOrgRoleUser, customer, logger);
            
            UpdateCallQueueCustomerProductType(model, customer, logger);

        }

        private void UpdateCustomerCurrentMedication(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer, IEnumerable<EventCustomer> eventCustomers)
        {
            //Moved CurrentMedication logic to Function
            var ndcMedicationSourcePairs = _customerRegistrationHelper.PrepareNdcPairs(model);

            if (!ndcMedicationSourcePairs.IsNullOrEmpty())
            {
                _currentMedicationRepository.SaveCurrentMedication(customer.CustomerId, ndcMedicationSourcePairs, createdByOrgRoleUser.Id);

                if (!eventCustomers.IsNullOrEmpty())
                {
                    //save EventCustomerCurrentMedication domain for each event customer
                    foreach (var eventCustomer in eventCustomers)
                    {
                        var eventCustomerCurrentMedicationList = ndcMedicationSourcePairs.Select(ndcMedicationSourcePair => new EventCustomerCurrentMedication
                        {
                            EventCustomerId = eventCustomer.Id,
                            IsOtc = ndcMedicationSourcePair.SecondValue == "o",
                            IsPrescribed = ndcMedicationSourcePair.SecondValue == "p",
                            NdcId = ndcMedicationSourcePair.FirstValue
                        }).ToList();
                        _eventCustomerCurrentMedicationRepository.Save(eventCustomer.Id, eventCustomerCurrentMedicationList);
                    }
                }
            }
        }

        public void UpdateCustomerPreApprovedForFutureEvents(IEnumerable<EventCustomer> eventCustomers, CorporateCustomerEditModel customerEditModel)
        {
            if (!eventCustomers.IsNullOrEmpty())
            {
                var pairs = TestType.A1C.GetNameValuePairs();

                var preApprovedTestIds = customerEditModel.PreApprovedTest.IsNullOrEmpty() ? new long[0] : pairs.Where(x => customerEditModel.PreApprovedTest.Contains(x.SecondValue.ToLower())).Select(x => (long)x.FirstValue).ToArray();

                foreach (var eventCustomer in eventCustomers)
                {
                    if (!preApprovedTestIds.IsNullOrEmpty())
                    {
                        preApprovedTestIds = _corporateUploadHelper.RemoveFocFromPreApprovedTest(preApprovedTestIds.ToList()).ToArray();

                        _eventCustomerPreApprovedTestRepository.Save(eventCustomer.Id, preApprovedTestIds);
                    }

                    if (customerEditModel.PreApprovedPackageId > 0)
                    {
                        var preApprovedPacakgeTests = _packageTestRepository.GetbyPackageId(customerEditModel.PreApprovedPackageId);

                        if (preApprovedPacakgeTests != null && preApprovedPacakgeTests.Any())
                        {
                            _eventCustomerPreApprovedPackageTestRepository.Save(eventCustomer.Id, customerEditModel.PreApprovedPackageId, preApprovedPacakgeTests.Select(x => x.TestId));
                        }
                    }
                }
            }
        }

        public void UpdateCustomerPreApprovedPackges(CorporateCustomerEditModel model, long createdByOrgRoleUserId, long customerId)
        {
            if (model.PreApprovedPackageId > 0)
            {
                _preApprovedPackageRepository.SavePreApprovedPackages(customerId, model.PreApprovedPackageId, createdByOrgRoleUserId);
            }
        }

        public void UpateCustomerPreApprovedTest(CorporateCustomerEditModel model, long createdByOrgRoleUserId, long customerId)
        {
            if (model.PreApprovedTest != null && model.PreApprovedTest.Any())
            {
                var pairs = TestType.A1C.GetNameValuePairs();
                var preApprovedTestIds =
                    pairs.Where(x => model.PreApprovedTest.Contains(x.SecondValue.ToLower())).Select(x => (long)x.FirstValue);

                if (preApprovedTestIds != null && preApprovedTestIds.Any())
                {
                    preApprovedTestIds = _corporateUploadHelper.RemoveFocFromPreApprovedTest(preApprovedTestIds.ToList());

                    _preApprovedTestRepository.SavePreApprovedTests(customerId, preApprovedTestIds,
                        createdByOrgRoleUserId);
                }

            }
        }

        private void UpdateCustomerPrimaryCarePhysician(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer, IEnumerable<EventCustomer> eventCustomers)
        {

            if (!string.IsNullOrEmpty(model.PcpFirstName) || !string.IsNullOrEmpty(model.PcpLastName))
            {
                var pcp = _primaryCarePhysicianRepository.Get(customer.CustomerId);

                var ispcpUpdated = pcp != null && IsPcpUpdated(pcp, model);

                pcp = ispcpUpdated ? null : pcp;

                if (pcp == null)
                {
                    pcp = new PrimaryCarePhysician
                    {
                        CustomerId = customer.CustomerId,
                        DataRecorderMetaData = new DataRecorderMetaData(createdByOrgRoleUser.Id, DateTime.Now, null)
                    };
                }
                else
                {
                    pcp.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(createdByOrgRoleUser.Id);
                    pcp.DataRecorderMetaData.DateModified = DateTime.Now;
                }

                pcp.IsPcpAddressVerified = null;
                pcp.PcpAddressVerifiedBy = null;
                pcp.PcpAddressVerifiedOn = null;
                pcp.Source = (long)CustomerPcpUpdateSource.CorporateUpload;

                pcp.Name = new Name(model.PcpFirstName, "", model.PcpLastName);
                pcp.Fax = PhoneNumber.Create(PhoneNumber.ToNumber(model.PcpFax), PhoneNumberType.Unknown);
                pcp.Primary = PhoneNumber.Create(PhoneNumber.ToNumber(model.PcpPhone), PhoneNumberType.Office);
                if (!string.IsNullOrEmpty(model.PcpEmail))
                {
                    pcp.Email = new Email(model.PcpEmail);
                }

                pcp.Npi = model.PcpNpi;
                pcp.PhysicianMasterId = null;

                SetPcpPracticeAddress(pcp, model);
                SetPcpMailingAddress(pcp, model);

                if (IsPcpAddressSame(pcp))
                    pcp.MailingAddress = null;

                pcp.IsActive = true;

                pcp = _primaryCarePhysicianRepository.Save(pcp);

                if (pcp != null)
                {
                    model.CustomerAddressId = customer.Address != null ? customer.Address.Id : 0;
                    model.PCPAddressId = pcp.Address != null ? pcp.Address.Id : 0;
                    model.PCPMailingAddressId = pcp.MailingAddress != null ? pcp.MailingAddress.Id : 0;
                }

                if (ispcpUpdated)
                {
                    foreach (var eventCustomer in eventCustomers)
                    {
                        _eventCustomerPrimaryCarePhysicianRepository.Save(new EventCustomerPrimaryCarePhysician
                        {
                            EventCustomerId = eventCustomer.Id,
                            IsPcpAddressVerified = false,
                            PcpAddressVerifiedBy = createdByOrgRoleUser.Id,
                            PcpAddressVerifiedOn = DateTime.Now,
                            PrimaryCarePhysicianId = pcp.Id
                        });
                    }
                }
            }
        }

        private void UpdateCustomerIcdCodes(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer, IEnumerable<EventCustomer> eventCustomers)
        {
            var icdCodes = !model.IcdCodes.IsNullOrEmpty() ? model.IcdCodes.Where(x => !string.IsNullOrEmpty(x)) : null;

            if (!icdCodes.IsNullOrEmpty())
            {
                var icdCodesCollection = _icdCodesRepository.GetIcdByCodeNames(icdCodes).ToList();

                var icdCodesAlreadyInDb = icdCodesCollection.Select(x => x.CodeName);
                var icdCodesToAddinDB = icdCodes.Where(x => !icdCodesAlreadyInDb.Contains(x));

                if (!icdCodesToAddinDB.IsNullOrEmpty())
                {
                    icdCodesCollection = icdCodesToAddinDB.Select(tempIcdCode => new IcdCode
                    {
                        CodeName = tempIcdCode,
                        DataRecorderMetaData = new DataRecorderMetaData(createdByOrgRoleUser, DateTime.Now, null),
                        IsActive = true
                    }).ToList();

                    _icdCodesRepository.Save(icdCodesCollection);

                    icdCodesCollection = _icdCodesRepository.GetIcdByCodeNames(icdCodes).ToList();
                }

                if (!icdCodesCollection.IsNullOrEmpty())
                {
                    var customericdCodes =
                        icdCodesCollection.Select(x =>
                            new CustomerIcdCode
                            {
                                CustomerId = customer.CustomerId,
                                IcdCodeId = x.Id,
                                DateCreated = DateTime.Now,
                                IsActive = true,
                                CreatedByOrgRoleUserId = createdByOrgRoleUser.Id
                            }).ToList();

                    _customerIcdCodesRepository.Save(customericdCodes, customer.CustomerId);

                    UpdateIcdCodesForFutureEvent(eventCustomers, icdCodesCollection);
                }
            }
        }

        public void UpdateIcdCodesForFutureEvent(IEnumerable<EventCustomer> eventCustomers, IEnumerable<IcdCode> icdCodes)
        {
            if (!eventCustomers.IsNullOrEmpty())
            {
                foreach (var eventCustomer in eventCustomers)
                {
                    _eventCustomerIcdCodesRepository.SaveAll(eventCustomer.Id, icdCodes.Select(x => x.Id));
                }
            }
        }

        private void SaveCustomerPredictedZip(long customerId, string predictedZip)
        {
            if (!string.IsNullOrEmpty(predictedZip))
            {
                var delimeter = ",";

                var predictedZipCodes = predictedZip.Split(new[] { delimeter }, StringSplitOptions.RemoveEmptyEntries);
                predictedZipCodes = predictedZipCodes.Select(x => x.Trim()).Distinct().ToArray();

                var currentDateTime = DateTime.Now;
                var customerIds = new long[] { customerId };
                var fromDate = new DateTime(currentDateTime.Year, 1, 1);
                var toDate = new DateTime(currentDateTime.Year, 12, 31).AddDays(1);

                var existingCustomerZipCodes = _customerPredictedZipRespository.GetByCustomerIdAndDate(customerIds, fromDate, toDate);
                predictedZipCodes = predictedZipCodes.Except(existingCustomerZipCodes.Select(x => x.PredictedZip.Trim())).ToArray();

                if (predictedZipCodes.Any())
                {
                    var customerPredictedZips = new List<CustomerPredictedZip>();
                    foreach (var zipCode in predictedZipCodes)
                    {
                        var customerPredictedZip = new CustomerPredictedZip()
                        {
                            CustomerId = customerId,
                            DateCreated = currentDateTime,
                            IsActive = true,
                            PredictedZip = zipCode
                        };

                        customerPredictedZips.Add(customerPredictedZip);
                    }

                    _customerPredictedZipRespository.Save(customerPredictedZips);
                }
            }
        }

        private bool IsPcpUpdated(PrimaryCarePhysician pcp, CorporateCustomerEditModel model)
        {
            if (!(string.IsNullOrEmpty(model.PcpFirstName) || model.PcpFirstName.Equals(pcp.Name.FirstName, StringComparison.InvariantCultureIgnoreCase)) ||
                !(string.IsNullOrEmpty(model.PcpLastName) || model.PcpLastName.Equals(pcp.Name.LastName, StringComparison.InvariantCultureIgnoreCase)))
                return true;

            return false;
        }

        private void SetPcpPracticeAddress(PrimaryCarePhysician pcp, CorporateCustomerEditModel model)
        {
            if (model.PcpAddress1.Length > 0 && model.PcpState.Length > 0 && model.PcpCity.Length > 0 && model.PcpZip.Length > 0)
            {
                long addressId = 0;
                if (pcp.Address != null)
                    addressId = pcp.Address.Id;

                pcp.Address = new Address(addressId)
                {
                    StreetAddressLine1 = model.PcpAddress1,
                    StreetAddressLine2 = model.PcpAddress2,
                    City = model.PcpCity,
                    State = model.PcpState,
                    ZipCode = model.PcpZip.Length >= 5 ? new ZipCode(model.PcpZip.Substring(0, 5)) : new ZipCode(model.PcpZip.PadLeft(5, '0')),
                    CountryId = (long)CountryCode.UnitedStatesAndCanada
                };
            }
            else
            {
                pcp.Address = null;
            }
        }

        private void SetPcpMailingAddress(PrimaryCarePhysician pcp, CorporateCustomerEditModel model)
        {
            if ((model.PCPMailingAddress1.Length > 0 && model.PCPMailingState.Length > 0 && model.PCPMailingCity.Length > 0 && model.PCPMailingZip.Length > 0))
            {
                bool isAddress = false;
                long addressId = 0;
                if (pcp.MailingAddress != null && (pcp.Address == null || pcp.MailingAddress.Id != pcp.Address.Id))
                {
                    isAddress = IsPcpAddressSame(pcp);
                    if (isAddress == false)
                        addressId = pcp.MailingAddress.Id;
                }

                pcp.MailingAddress = new Address(addressId)
                {
                    StreetAddressLine1 = model.PCPMailingAddress1,
                    StreetAddressLine2 = model.PCPMailingAddress2,
                    City = model.PCPMailingCity,
                    State = model.PCPMailingState,
                    ZipCode = model.PCPMailingZip.Length >= 5 ? new ZipCode(model.PCPMailingZip.Substring(0, 5)) : new ZipCode(model.PCPMailingZip.PadLeft(5, '0')),
                    CountryId = (long)CountryCode.UnitedStatesAndCanada
                };
            }
            else
            {
                pcp.MailingAddress = null;
            }
        }

        private bool IsPcpAddressSame(PrimaryCarePhysician pcp)
        {
            if (pcp.Address != null && pcp.MailingAddress != null)
            {
                return pcp.Address.StreetAddressLine1 == pcp.MailingAddress.StreetAddressLine1 && pcp.Address.StreetAddressLine2 == pcp.MailingAddress.StreetAddressLine2 && pcp.Address.City == pcp.MailingAddress.City && pcp.Address.State == pcp.MailingAddress.State && pcp.Address.ZipCode.Zip == pcp.MailingAddress.ZipCode.Zip;
            }
            return false;
        }

        private void UpdateCustomerTargeted(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer)
        {
            var forYear = DateTime.Now.Year;
            bool? isTargeted = null;

            if (!string.IsNullOrEmpty(model.TargetYear))
            {
                forYear = Convert.ToInt32(model.TargetYear);
                isTargeted = true;
            }

            _customerTargetedService.Save(customer.CustomerId, forYear, isTargeted, createdByOrgRoleUser.Id);
        }

        private void UpdateCustomerEligibility(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer, ILogger logger)
        {
            var forYear = Convert.ToInt32(model.EligibilityYear);
            bool? isEligible;

            if (model.IsEligible.ToLower() == "yes")
                isEligible = true;
            else if (model.IsEligible.ToLower() == "no")
                isEligible = false;
            else
                isEligible = null;

            _customerEligibilityService.Save(customer.CustomerId, forYear, isEligible, createdByOrgRoleUser.Id, logger);

        }

        private void UpdateCustomerWarmTransfer(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer, ILogger logger)
        {
            if (string.IsNullOrEmpty(model.WarmTransferYear) && string.IsNullOrEmpty(model.WarmTransferAllowed)) return;

            var warmTransferYear = Convert.ToInt32(model.WarmTransferYear);
            bool? isWarmTransfer;

            if (model.WarmTransferAllowed.ToLower() == "yes")
                isWarmTransfer = true;
            else if (model.WarmTransferAllowed.ToLower() == "no")
                isWarmTransfer = false;
            else
                isWarmTransfer = null;

            _customerWarmTransferService.Save(customer.CustomerId, warmTransferYear, isWarmTransfer, createdByOrgRoleUser.Id, logger);
        }

        //private void UpateCustomerRequiredTest(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer)
        //{
        //    if (model.RequiredTest != null && model.RequiredTest.Any())
        //    {
        //        var pairs = TestType.A1C.GetNameValuePairs();
        //        var requiredTestIds =
        //            pairs.Where(x => model.RequiredTest.Contains(x.SecondValue.ToLower())).Select(x => (long)x.FirstValue);

        //        if (requiredTestIds != null && requiredTestIds.Any())
        //        {
        //            _requiredTestRepository.SaveRequiredTests(customer.CustomerId, requiredTestIds,
        //                createdByOrgRoleUser.Id, Convert.ToInt32(model.ForYear));
        //        }

        //    }
        //}

        private void UpdateCallQueueCustomerProductType(CorporateCustomerEditModel model, Customer customer, ILogger logger)
        {
            if (!string.IsNullOrWhiteSpace(model.Product) && customer.CustomerId > 0)
            {
                
                var productTypePairs = ProductType.CHA.GetNameValuePairs();

                var productType = productTypePairs.Where(x => x.SecondValue.ToLower() == model.Product.ToLower()).Select(x => x.FirstValue).First();
                
                var success = _callQueueCustomerRepository.UpdateCallQueueCustomerProductType(customer.CustomerId, productType);
                if (success)
                {
                    logger.Info("Product updated on Call Queue Customer, CustomerId :" + customer.CustomerId + ", Product Name : " + model.Product);
                }
                else
                {
                    logger.Info("Product not updated on Call Queue Customer, CustomerId :" + customer.CustomerId + ", Product Name : " + model.Product);
                }
            }
        }

    }
}