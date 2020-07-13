using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Factories.Users;
using Falcon.App.Infrastructure.Users.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IAddressService _addressService;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IUserService _userService;


        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IUniqueItemRepository<ProspectCustomer> _uniqueItemProspectCustomerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IUserNameGenerator _userNameGenerator;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILanguageService _languageService;
        private readonly ICustomerProfileHistoryRepository _customerProfileHistoryRepository;
        private readonly IPhoneNumberFactory _phoneNumberFactory;
        private readonly ICallQueueCustomerPublisher _callQueueCustomerPublisher;
        private readonly ICustomerTargetedService _customerTargetedService;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly IPhysicianRecordRequestSignatureRepository _physicianRecordRequestSignatureRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICallQueueCustomerPubFactory _callQueueCustomerPubFactory;

        public CustomerService(IAddressService addressService, ICustomerRepository customerRepository, ITestimonialRepository testimonialRepository, IUserService userService,
            IProspectCustomerRepository prospectCustomerRepository, IUniqueItemRepository<ProspectCustomer> uniqueItemProspectCustomerRepository, IEventCustomerRepository eventCustomerRepository,
            IUserNameGenerator userNameGenerator, IShippingDetailRepository shippingDetailRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            IEventRepository eventRepository, ICorporateAccountRepository corporateAccountRepository, ILanguageRepository languageRepository, ILanguageService languageService,
            ICustomerProfileHistoryRepository customerProfileHistoryRepository, IPhoneNumberFactory phoneNumberFactory, ICallQueueCustomerPublisher callQueueCustomerPublisher,
            ICustomerTargetedService customerTargetedService, ICustomerEligibilityRepository customerEligibilityRepository, IPhysicianRecordRequestSignatureRepository physicianRecordRequestSignatureRepository,
            IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, ICallQueueCustomerPubFactory callQueueCustomerPubFactory)
        {
            _addressService = addressService;
            _customerRepository = customerRepository;
            _testimonialRepository = testimonialRepository;
            _userService = userService;
            _prospectCustomerRepository = prospectCustomerRepository;
            _uniqueItemProspectCustomerRepository = uniqueItemProspectCustomerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _userNameGenerator = userNameGenerator;
            _shippingDetailRepository = shippingDetailRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _eventRepository = eventRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _languageRepository = languageRepository;
            _languageService = languageService;
            _customerProfileHistoryRepository = customerProfileHistoryRepository;
            _phoneNumberFactory = phoneNumberFactory;
            _callQueueCustomerPublisher = callQueueCustomerPublisher;
            _customerTargetedService = customerTargetedService;
            _customerEligibilityRepository = customerEligibilityRepository;
            _physicianRecordRequestSignatureRepository = physicianRecordRequestSignatureRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _callQueueCustomerPubFactory = callQueueCustomerPubFactory;
        }

        public bool SaveCustomer(Customer customer, long updatedby, bool createHistory = true)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            return SaveCustomerOnly(customer, updatedby, createHistory);
        }

        public List<CustomerTestimonialAggregate> GetCustomerTestimonials(bool? isAccepted, int pageNumber, int pageSize)
        {
            List<Testimonial> testimonials;
            var customerTestimonialAggregates = new List<CustomerTestimonialAggregate>();
            try
            {
                testimonials = _testimonialRepository.GetTestimonials(isAccepted, pageNumber, pageSize);
            }
            catch (Exception)
            {
                return null;
            }
            var testimonialGroups = testimonials.GroupBy(t => t.CustomerId);
            ICustomerTestimonialAggregateFactory customerTestimonialAggregateFactory =
                new CutomerTestimonailAggregateFactory();
            foreach (var testimonialGroup in testimonialGroups)
            {
                customerTestimonialAggregates.Add(customerTestimonialAggregateFactory.CreateCustomerTestimonialAggregate(testimonialGroup));
            }
            return customerTestimonialAggregates;
        }

        public List<CustomerTestimonialAggregate> GetAcceptedTestimonials(bool? isAccepted, string gender, int pageNumber, int pageSize)
        {
            List<Testimonial> testimonials;
            var customerTestimonialAggregates = new List<CustomerTestimonialAggregate>();
            try
            {
                testimonials = _testimonialRepository.GetAcceptedTestimonials(isAccepted, gender, pageNumber, pageSize);
            }
            catch (Exception)
            {
                return null;
            }
            var testimonialGroups = testimonials.GroupBy(t => t.CustomerId);
            ICustomerTestimonialAggregateFactory customerTestimonialAggregateFactory =
                new CutomerTestimonailAggregateFactory();
            foreach (var testimonialGroup in testimonialGroups)
            {
                customerTestimonialAggregates.Add(customerTestimonialAggregateFactory.CreateCustomerTestimonialAggregate(testimonialGroup));
            }
            return customerTestimonialAggregates;
        }

        // Used by Win Service - Upload Result
        //public Customer GetCustomerbyFilterforanEvent(string firstName, string lastName, DateTime? dob, long eventid)
        //{
        //    var customers = _customerRepository.GetCustomerByFilters(firstName, lastName, 0, 0, string.Empty, string.Empty, null, string.Empty);

        //    var selectedCustomers = customers.FindAll(customer => customer.DateOfBirth.HasValue && (dob == null || (dob != null && customer.DateOfBirth.Value.Date == dob.Value.Date)));

        //    Customer customerForEvent = null;
        //    if (!selectedCustomers.IsNullOrEmpty())
        //    {
        //        selectedCustomers.ForEach(customer =>
        //        {
        //            var isCustomerRegistered = _eventCustomerService.IsCustomerRegisteredfortheGivenEvent(customer.CustomerId, eventid);
        //            if (isCustomerRegistered) customerForEvent = customer;
        //        });
        //    }

        //    return customerForEvent;
        //}

        public void MarkProspectCustomerConverted(long eventCustomerId)
        {
            var prospectCustomer = GetProspectCustomer(eventCustomerId);
            if (prospectCustomer == null)
                return;
            prospectCustomer.IsConverted = true;
            prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
            prospectCustomer.ConvertedOnDate = DateTime.Now;

            _uniqueItemProspectCustomerRepository.Save(prospectCustomer);
        }

        public void UnMarkProspectCustomerConverted(long eventCustomerId, ProspectCustomerTag tag)
        {
            var prospectCustomer = GetProspectCustomer(eventCustomerId);
            if (prospectCustomer == null || (tag == ProspectCustomerTag.Cancellation && prospectCustomer.Tag == ProspectCustomerTag.NoShow && prospectCustomer.IsConverted.HasValue && prospectCustomer.IsConverted.Value == false))
                return;
            prospectCustomer.IsConverted = false;
            prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
            prospectCustomer.Tag = tag;
            prospectCustomer.CreatedOn = DateTime.Now;
            prospectCustomer.TagUpdateDate = DateTime.Now;

            _uniqueItemProspectCustomerRepository.Save(prospectCustomer);
        }

        private ProspectCustomer GetProspectCustomer(long eventCustomerId)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            if (eventCustomer == null)
                return null;
            var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(eventCustomer.CustomerId);

            if (prospectCustomer == null)
            {
                var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);
                prospectCustomer = new ProspectCustomer
                                       {
                                           FirstName = customer.Name.FirstName,
                                           LastName = customer.Name.LastName,
                                           Gender = customer.Gender,
                                           Address = customer.Address,
                                           CallBackPhoneNumber = customer.HomePhoneNumber,
                                           Email = customer.Email,
                                           BirthDate = customer.DateOfBirth,
                                           MarketingSource = customer.MarketingSource,
                                           CustomerId = customer.CustomerId,
                                           Source = ProspectCustomerSource.CallCenter
                                       };
            }
            return prospectCustomer;
        }

        public Customer SaveCustomer(SchedulingCustomerEditModel model, bool isExistingCustomer)
        {
            Customer customer;
            model.FullName.FirstName = model.FullName.FirstName.ToUppercaseInitalLetter();
            model.FullName.LastName = model.FullName.LastName.ToUppercaseInitalLetter();
            model.FullName.MiddleName = model.FullName.MiddleName.ToUppercaseInitalLetter();

            if (model.Id > 0)
            {
                customer = _customerRepository.GetCustomer(model.Id);
                customer.DateModified = DateTime.Now;
                customer.DateOfBirth = model.DateofBirth;
                customer.Gender = (Gender)(model.Gender != null && model.Gender > 0 ? model.Gender.Value : 0);

                var addressId = customer.Address.Id;
                customer.Address = Mapper.Map<AddressEditModel, Address>(model.ShippingAddress);
                customer.Address.Id = addressId;

                if (!isExistingCustomer)
                    customer.MarketingSource = model.MarketingSource;
            }
            else
            {
                customer = new Customer
                               {
                                   UserLogin = new UserLogin
                                                   {
                                                       UserName = !string.IsNullOrEmpty(model.UserName) ? model.UserName : _userNameGenerator.Generate(model.FullName),
                                                       Password = model.Password,
                                                       HintAnswer = null,
                                                       HintQuestion = null,
                                                       IsSecurityQuestionVerified = false,
                                                       UserVerified = true
                                                   },
                                   AddedByRoleId = (long)Roles.Customer,
                                   DateCreated = DateTime.Now,
                                   DateOfBirth = model.DateofBirth,
                                   Gender = (Gender)(model.Gender != null && model.Gender > 0 ? model.Gender.Value : 0),
                                   Address = Mapper.Map<AddressEditModel, Address>(model.ShippingAddress),
                                   MarketingSource = model.MarketingSource,
                                   EnableTexting = model.ConfirmationToEnablTexting != null && model.ConfirmationToEnablTexting.Value,
                                   EnableVoiceMail = model.ConfirmationToEnableVoiceMail != null && model.ConfirmationToEnableVoiceMail.Value
                               };

                //customer.Address.Id = 0;
            }

            customer.Name = model.FullName;

            if (!string.IsNullOrEmpty(model.Email))
                customer.Email = new Email(model.Email);
            else
                customer.Email = null;

            customer.HomePhoneNumber = new PhoneNumber
                                            {
                                                PhoneNumberType = PhoneNumberType.Home,
                                                Number = model.HomeNumber
                                            };
            customer.MobilePhoneNumber = new PhoneNumber
            {
                PhoneNumberType = PhoneNumberType.Mobile,
                Number = model.PhoneCell
            };
            customer.EnableTexting = model.ConfirmationToEnablTexting != null && model.ConfirmationToEnablTexting.Value;
            customer.EnableVoiceMail = model.ConfirmationToEnableVoiceMail != null && model.ConfirmationToEnableVoiceMail.Value;

            customer.InsuranceId = model.InsuranceId;
            customer.Ssn = model.Ssn;

            var result = SaveCustomer(customer, model.Id);

            return result ? customer : null;

        }

        public Customer SaveCustomer(HealthAssessmentHeaderEditModel headerModel, HealthAssessmentFooterEditModel footerModel, long orgRoleId)
        {
            Customer customer = _customerRepository.GetCustomer(headerModel.CustomerId);

            customer.Name = headerModel.CustomerName;
            customer.Gender = (Gender)headerModel.Gender;

            customer.DateOfBirth = headerModel.DateofBirth;
            customer.Address = Mapper.Map<AddressEditModel, Address>(headerModel.Address);
            customer.Email = !string.IsNullOrEmpty(headerModel.Email) ? new Email(headerModel.Email) : null;
            customer.HomePhoneNumber = !string.IsNullOrEmpty(headerModel.PhoneNumber)
                                           ? PhoneNumber.Create(PhoneNumber.ToNumber(headerModel.PhoneNumber), PhoneNumberType.Home)
                                           : null;

            customer.Height = headerModel.Height > 0 ? new Height(Math.Floor((double)(headerModel.Height / 12)), headerModel.Height % 12) : null;
            customer.Weight = headerModel.Weight > 0 ? new Weight(headerModel.Weight) : null;

            customer.EmergencyContactName = footerModel.EmergencyContact;
            customer.EmergencyContactRelationship = footerModel.Relationship;
            customer.EmergencyContactPhoneNumber = !string.IsNullOrEmpty(footerModel.ContactPhoneNumber) ? PhoneNumber.Create(footerModel.ContactPhoneNumber, PhoneNumberType.Unknown) : null;
            customer.Race = (Race)headerModel.Race;
            customer.Ssn = string.IsNullOrEmpty(headerModel.Ssn) ? "" : headerModel.Ssn.Replace("-", "");

            customer.LanguageId = null;
            if (!string.IsNullOrWhiteSpace(headerModel.Laguage))
            {
                var language = _languageRepository.GetByName(headerModel.Laguage) ??
                                    _languageService.AddLanguage(headerModel.Laguage, orgRoleId);
                customer.LanguageId = language.Id;
            }

            var result = SaveCustomer(customer, orgRoleId);
            return result ? customer : null;
        }

        public void UpdateCustomerShippingAddress(long customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);

            var shippingDetails = _shippingDetailRepository.GetShippingDetailsForCustomer(customerId);
            if (shippingDetails == null || shippingDetails.Count() < 1)
                return;
            var shippingAddressIds = shippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd.ShippingAddress.Id).ToArray();
            if (shippingAddressIds.Count() < 1)
                return;
            foreach (var shippingAddressId in shippingAddressIds)
            {
                var address = customer.Address;
                address.Id = shippingAddressId;
                _addressService.SaveAfterSanitizing(address);

            }
        }

        public void SavePrimaryCarePhysician(PrimaryCarePhysicianEditModel pcpEditModel, long customerId, long orgRoleUserId = 0)
        {
            var pcp = _primaryCarePhysicianRepository.Get(customerId);

            if (pcp == null && pcpEditModel == null) return;

            if (pcp != null && pcpEditModel == null)
            {
                _primaryCarePhysicianRepository.DecativatePhysician(customerId, orgRoleUserId > 0 ? orgRoleUserId : customerId);

            }
            else
            {
                if (pcp == null)
                {
                    pcp = new PrimaryCarePhysician
                    {
                        Name = pcpEditModel.FullName,
                        Primary = !string.IsNullOrEmpty(pcpEditModel.Phone) ? PhoneNumber.Create(pcpEditModel.Phone, PhoneNumberType.Unknown) : pcpEditModel.PhoneNumber,
                        Email = string.IsNullOrEmpty(pcpEditModel.Email) ? new Email(string.Empty, string.Empty) : new Email(pcpEditModel.Email),
                        CustomerId = customerId,
                        DataRecorderMetaData = new DataRecorderMetaData(orgRoleUserId > 0 ? orgRoleUserId : customerId, DateTime.Now, null)
                    };
                }
                else
                {
                    pcp.Name = pcpEditModel.FullName;
                    pcp.Primary = !string.IsNullOrEmpty(pcpEditModel.Phone) ? PhoneNumber.Create(pcpEditModel.Phone, PhoneNumberType.Unknown) : pcpEditModel.PhoneNumber;
                    pcp.Email = string.IsNullOrEmpty(pcpEditModel.Email) ? new Email(string.Empty, string.Empty) : new Email(pcpEditModel.Email);
                    pcp.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleUserId > 0 ? orgRoleUserId : customerId);
                    pcp.DataRecorderMetaData.DateModified = DateTime.Now;
                }

                if (pcpEditModel.Address != null && !pcpEditModel.Address.IsEmpty())
                {
                    long addressId = 0;
                    if (pcp.Address != null)
                        addressId = pcp.Address.Id;
                    pcp.Address = Mapper.Map<AddressEditModel, Address>(pcpEditModel.Address);
                    pcp.Address.Id = addressId;

                }
                else
                    pcp.Address = null;

                if (pcpEditModel.MailingAddress != null && !pcpEditModel.MailingAddress.IsEmpty() && !IsAddressSame(pcpEditModel))
                {
                    long addressId = 0;
                    if (pcp.MailingAddress != null && pcp.Address != null && pcp.MailingAddress.Id != pcp.Address.Id)
                    {
                        addressId = pcp.MailingAddress.Id;
                    }

                    pcp.MailingAddress = Mapper.Map<AddressEditModel, Address>(pcpEditModel.MailingAddress);
                    pcp.MailingAddress.Id = addressId;

                }
                else
                    pcp.MailingAddress = null;

                _primaryCarePhysicianRepository.Save(pcp);
            }

        }

        public MammoConsentEditModel GetClientNoticeEditModel(long customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var model = new MammoConsentEditModel
            {
                CustomerId = customer.CustomerId,
                FullName = customer.Name,
                HomeNumber = customer.HomePhoneNumber,
                Address = Mapper.Map<Address, AddressViewModel>(customer.Address)
            };

            var pcp = _primaryCarePhysicianRepository.Get(customer.CustomerId);
            if (pcp != null)
            {
                model.Pcp = pcp;
            }

            return model;
        }

        public AbnConsentViewModel GetAbnModel(long eventCustomerId)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);
            return new AbnConsentViewModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name.FullName
            };
        }

        public string SetCustomerTag(Customer customer, long eventId, long orgRoleId, DateTime eventDate)
        {
            //var customer = _customerRepository.GetCustomer(customerId);
            var previousTag = string.Empty;

            if (string.IsNullOrEmpty(customer.Tag))
            {
                var account = _corporateAccountRepository.GetbyEventId(eventId);
                previousTag = customer.Tag;
                if (account != null)
                {
                    customer.Tag = account.Tag;
                    customer.ActivityId = (long)UploadActivityType.DoNotCallDoNotMail;

                    if (!account.AllowCustomerPortalLogin)
                        customer.UserLogin.Locked = true;
                    else
                        customer.UserLogin.Locked = false;

                    _customerTargetedService.Save(customer.CustomerId, eventDate.Year, false, orgRoleId);
                }
                else
                {
                    customer.UserLogin.Locked = false;
                }

                customer.DateModified = DateTime.Now;

                SaveCustomer(customer, orgRoleId);
            }

            return previousTag;
        }

        public AwvPcpConsentViewModel GetAwvPcpConsentViewModel(long customerId, long eventId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var pcp = _primaryCarePhysicianRepository.Get(customer.CustomerId);
            var eventData = _eventRepository.GetById(eventId);

            string signatureUrl = string.Empty;
            DateTime? signedDate = null;
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var mediaLocation = _mediaRepository.GetPhysicianRecordRequestSignatureLocation(eventId, customerId);
            var physicianRecordRequest = _physicianRecordRequestSignatureRepository.GetByEventCustomerId(eventCustomer.Id);
            if (physicianRecordRequest != null)
            {
                var signatureFile = _fileRepository.GetById(physicianRecordRequest.SignatureFileId);
                signatureUrl = mediaLocation.Url + signatureFile.Path;
                signedDate = physicianRecordRequest.ConsentSignedDate;
            }

            return GetAwvPcpConsentViewModel(customer, eventData, pcp, signatureUrl, signedDate);
        }

        public AwvPcpConsentViewModel GetAwvPcpConsentViewModel(Customer customer, Event eventData, PrimaryCarePhysician pcp, string signatureUrl, DateTime? signedDate = null)
        {

            var model = new AwvPcpConsentViewModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                PhoneNumber = customer.HomePhoneNumber,
                DateOfBirth = customer.DateOfBirth,
                SignatureImageUrl = signatureUrl,
                ConsentSignedDate = signedDate.HasValue ? signedDate.Value.ToString("MM/dd/yyyy") : string.Empty
            };

            if (pcp != null)
            {
                model.Pcp = pcp;
            }

            model.ScreeningDate = eventData.EventDate;

            return model;
        }

        public MammogramHistoryFormViewModel GetMammogramHistoryFormViewModel(long customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var model = new MammogramHistoryFormViewModel()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                Dob = customer.DateOfBirth,
                HomePhoneNumber = customer.HomePhoneNumber,
                OfficePhoneNumber = customer.OfficePhoneNumber,
                CellPhoneNumber = customer.MobilePhoneNumber,
            };
            return model;
        }

        private bool IsAddressSame(PrimaryCarePhysicianEditModel pcpEditModel)
        {
            return pcpEditModel.MailingAddress.StreetAddressLine1 == pcpEditModel.Address.StreetAddressLine1 && pcpEditModel.MailingAddress.StreetAddressLine2 == pcpEditModel.Address.StreetAddressLine2
                && pcpEditModel.MailingAddress.City == pcpEditModel.Address.City && pcpEditModel.MailingAddress.ZipCode == pcpEditModel.Address.ZipCode
                && pcpEditModel.MailingAddress.StateId == pcpEditModel.Address.StateId;
        }

        public bool SaveCustomerOnly(Customer customer, long orgRoleId, bool createHistory = true)
        {
            if (customer.CustomerId <= 0)
            {
                customer.PhoneCellConsentUpdateDate = customer.PhoneHomeConsentUpdateDate = customer.PhoneOfficeConsentUpdateDate = customer.EnableEmailUpdateDate = DateTime.Now;

                return SaveCustomerUser(customer);
            }

            UpdateCallQueueCustomer(customer);
            var customerFromDb = _customerRepository.GetCustomer(customer.CustomerId);                                                      //fetch from DB

            UpdateConsentDates(customerFromDb, customer);

            if (customerFromDb.EnableEmail != customer.EnableEmail)
                customer.EnableEmailUpdateDate = DateTime.Now;
            else
                customer.EnableEmailUpdateDate = customerFromDb.EnableEmailUpdateDate;

            if (createHistory && IsBasicCustomerDetailsUpdated(customer, customerFromDb))
            {
                var customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                var customerProfileHistoryId = _customerProfileHistoryRepository.CreateCustomerHistory(customer.CustomerId, orgRoleId, customerEligibility);
                _eventCustomerRepository.UpdateCustomerProfileIdByCustomerId(customer.CustomerId, customerProfileHistoryId);
                _eventCustomerRepository.UpdatePreferredContactTypeByCustomerId(customer.CustomerId, customer.PreferredContactType);
            }

            return SaveCustomerUser(customer);
        }

        private bool IsBasicCustomerDetailsUpdated(Customer customerForPersistence, Customer customer)
        {
            if (CheckforStringfield(customer.InsuranceId, customerForPersistence.InsuranceId)
                || CheckforStringfield(customer.Hicn, customerForPersistence.Hicn)
                || CheckforStringfield(customer.Tag, customerForPersistence.Tag)
                || CheckforStringfield(customer.MedicareAdvantageNumber, customerForPersistence.MedicareAdvantageNumber)
                || CheckforStringfield(customer.MedicareAdvantagePlanName, customerForPersistence.MedicareAdvantagePlanName)
                || CheckforNullableLong(customer.LabId, customerForPersistence.LabId)
                || CheckforNullableLong(customer.LanguageId, customerForPersistence.LanguageId)
                || CheckforStringfield(customer.Copay, customerForPersistence.Copay)
                || CheckforStringfield(customer.Lpi, customerForPersistence.Lpi)
                || CheckforStringfield(customer.Market, customerForPersistence.Market)
                || CheckforStringfield(customer.Mrn, customerForPersistence.Mrn)
                || CheckforStringfield(customer.GroupName, customerForPersistence.GroupName)
                || CheckforStringfield(customer.AdditionalField1, customerForPersistence.AdditionalField1)
                || CheckforStringfield(customer.AdditionalField2, customerForPersistence.AdditionalField2)
                || CheckforStringfield(customer.AdditionalField3, customerForPersistence.AdditionalField3)
                || CheckforStringfield(customer.AdditionalField4, customerForPersistence.AdditionalField4)
                || IsAddressUpdated(customer.BillingAddress, customerForPersistence.BillingAddress)
                || IsAddressUpdated(customer.Address, customerForPersistence.Address)
                || CheckforStringfield(customer.Name.ToString(), customerForPersistence.Name.ToString())
                || CheckForPhoneNumberUpdate(customer.MobilePhoneNumber, customerForPersistence.MobilePhoneNumber)
                || CheckForPhoneNumberUpdate(customer.HomePhoneNumber, customerForPersistence.HomePhoneNumber)
                || CheckForPhoneNumberUpdate(customer.OfficePhoneNumber, customerForPersistence.OfficePhoneNumber)
                || CheckForPhoneNumberUpdate(customer.EmergencyContactPhoneNumber, customerForPersistence.EmergencyContactPhoneNumber)
                || CheckforStringfield(customer.EmergencyContactName, customerForPersistence.EmergencyContactName)
                || CheckforStringfield(customer.Employer, customerForPersistence.Employer)
                || CheckforStringfield(customer.EmergencyContactRelationship, customerForPersistence.EmergencyContactRelationship)
                || CheckforStringfield(customer.Ssn, customerForPersistence.Ssn)
                || CheckForEmailUpdate(customer.Email, customerForPersistence.Email)
                || CheckForEmailUpdate(customer.AlternateEmail, customerForPersistence.AlternateEmail)
                || CheckCustomerWeight(customer.Weight, customerForPersistence.Weight)
                || CheckCustomerWaist(customer.Waist, customerForPersistence.Waist)
                || CheckNullabeLongFile(customer.DoNotContactTypeId, customerForPersistence.DoNotContactTypeId)
                || CheckNullabeLongFile(customer.DoNotContactReasonId, customerForPersistence.DoNotContactReasonId)
                || CheckNullabeLongFile(customer.DoNotContactUpdateSource, customerForPersistence.DoNotContactUpdateSource)
                || CheckNullabeLongFile(customer.ActivityId, customerForPersistence.ActivityId)
                || (customer.IsIncorrectPhoneNumber != customerForPersistence.IsIncorrectPhoneNumber)
                || (customer.IsLanguageBarrier != customerForPersistence.IsLanguageBarrier)
                || CheckforNullableBool(customer.IsSubscribed, customerForPersistence.IsSubscribed)
                || CheckNullabeLongFile(customer.PreferredContactType, customerForPersistence.PreferredContactType)
                || CheckforStringfield(customer.Mbi, customerForPersistence.Mbi)
                || CheckforStringfield(customer.AcesId, customerForPersistence.AcesId)
                || customer.PhoneCellConsentId != customerForPersistence.PhoneCellConsentId
                || customer.PhoneHomeConsentId != customerForPersistence.PhoneHomeConsentId
                || customer.PhoneOfficeConsentId != customerForPersistence.PhoneOfficeConsentId
                || CheckforStringfield(customer.BillingMemberId, customerForPersistence.BillingMemberId)
                || CheckforStringfield(customer.BillingMemberPlan, customerForPersistence.BillingMemberPlan)
                || customer.BillingMemberPlanYear != customerForPersistence.BillingMemberPlanYear
                || customer.EnableEmail != customerForPersistence.EnableEmail
                || customer.MemberUploadSourceId != customerForPersistence.MemberUploadSourceId
                || customer.ActivityTypeIsManual != customerForPersistence.ActivityTypeIsManual
                || customer.ProductTypeId != customerForPersistence.ProductTypeId
                || customer.AcesClientId != customerForPersistence.AcesClientId

                )
            {
                return true;
            }
            return false;
        }

        private void UpdateConsentDates(Customer customerFromDb, Customer customer)
        {
            var consentUpdateDate = DateTime.Now;
            if (customerFromDb.PhoneCellConsentId != customer.PhoneCellConsentId)
            {
                customer.PhoneCellConsentUpdateDate = consentUpdateDate;
            }
            if (customerFromDb.PhoneHomeConsentId != customer.PhoneHomeConsentId)
            {
                customer.PhoneHomeConsentUpdateDate = consentUpdateDate;
            }
            if (customerFromDb.PhoneOfficeConsentId != customer.PhoneOfficeConsentId)
            {
                customer.PhoneOfficeConsentUpdateDate = consentUpdateDate;
            }
        }

        private bool CheckNullabeLongFile(long? fieldValue, long? persistnceFieldValue)
        {
            var tempfieldValue = fieldValue ?? 0;
            var pFieldValue = persistnceFieldValue ?? 0;
            return pFieldValue != tempfieldValue;
        }
        private bool CheckCustomerWeight(Weight customerweight, Weight persistenceWeight)
        {
            var weight = customerweight == null ? 0 : customerweight.Pounds;
            var pweight = persistenceWeight == null ? 0 : persistenceWeight.Pounds;
            return weight != pweight;
        }

        private bool CheckCustomerWaist(decimal? waist, decimal? persistencewaist)
        {
            var weight = waist == null ? 0 : waist.Value;
            var pweight = persistencewaist == null ? 0 : persistencewaist.Value;
            return weight != pweight;
        }

        private bool CheckForPhoneNumberUpdate(PhoneNumber phoneNumber, PhoneNumber phoneForPersistnece)
        {

            if (phoneNumber == null && phoneForPersistnece == null) return false;
            if (phoneNumber != null && phoneForPersistnece == null) return true;
            if (phoneNumber == null && phoneForPersistnece != null) return true;

            var phoneNumberFormated = _phoneNumberFactory.CreatePhoneNumber(phoneForPersistnece.ToString(), phoneForPersistnece.PhoneNumberType);
            return phoneNumber.ToString() != phoneNumberFormated.ToString();
        }

        private bool CheckForEmailUpdate(Email email, Email emailForPersistnece)
        {
            var email1 = (email == null || string.IsNullOrEmpty(email.ToString())) ? string.Empty : email.ToString();
            var emailForPersist1 = (emailForPersistnece == null || string.IsNullOrEmpty(emailForPersistnece.ToString())) ? string.Empty : emailForPersistnece.ToString();

            return email1 != emailForPersist1;
        }

        private bool IsAddressUpdated(Address address, Address addForPersistence)
        {
            if (address == null && addForPersistence == null) return false;

            if (address != null && addForPersistence == null) return true;
            if (address == null && addForPersistence != null) return true;

            address = _addressService.GetSanitizeAddress(address);
            addForPersistence = _addressService.GetSanitizeAddress(addForPersistence);

            return CheckforStringfield(address.StreetAddressLine1, addForPersistence.StreetAddressLine1)
                   || CheckforStringfield(address.StreetAddressLine2, addForPersistence.StreetAddressLine2)
                   || CheckforStringfield(address.City, addForPersistence.City)
                   || address.StateId != addForPersistence.StateId
                   || address.ZipCode.Zip != addForPersistence.ZipCode.Zip;

        }

        private bool CheckforStringfield(string customerField, string customerForPerstence)
        {
            if (string.IsNullOrWhiteSpace(customerField) && !string.IsNullOrWhiteSpace(customerForPerstence)) return true;
            if (!string.IsNullOrWhiteSpace(customerField) && string.IsNullOrWhiteSpace(customerForPerstence)) return true;
            if (customerField != customerForPerstence) return true;

            return false;
        }

        private bool CheckforNullableBool(bool? customerField, bool? customerForPerstence)
        {
            if (customerField.HasValue && !customerForPerstence.HasValue) return true;
            if (!customerField.HasValue && customerForPerstence.HasValue) return true;
            if (customerField != customerForPerstence) return true;

            return false;
        }

        private bool CheckforNullableLong(long? customerField, long? customerForPerstence)
        {
            if (customerField.HasValue && !customerForPerstence.HasValue) return true;
            if (!customerField.HasValue && customerForPerstence.HasValue) return true;
            if (customerField != customerForPerstence) return true;

            return false;
        }

        private bool SaveCustomerUser(Customer customer, bool checkZipData = false)
        {
            var isSkipAddressCheck = customer.MemberUploadSourceId.HasValue && customer.MemberUploadSourceId.Value == (long)MemberUploadSource.Aces ? true : false;

            if (customer.BillingAddress != null && customer.BillingAddress.Id != customer.Address.Id)
            {
                _addressService.SaveAfterSanitizing(customer.BillingAddress, checkZipData);
            }

            IOrganizationRepository organizationRepository = new OrganizationRepository();
            var organization = organizationRepository.GetOrganizationCollection(OrganizationType.Franchisor);
            if (organization != null && organization.Count() > 0)
            {
                var franchisorOrganization = organization.SingleOrDefault();
                var userId = _userService.SaveUserforOrganization(franchisorOrganization.Id, Roles.Customer, customer, checkZipData);
                customer.Id = userId;
                return _customerRepository.SaveCustomer(customer);
            }
            return false;
        }

        private void UpdateCallQueueCustomer(Customer customer)
        {
            var address = _addressService.GetSanitizeAddress(customer.Address);
            var callQueueCustomer = _callQueueCustomerPubFactory.GetCallQueueCustomerPubViewModel(customer, address);
            _callQueueCustomerPublisher.UpdateCustomerDetailOnCallQueueResponse(callQueueCustomer);
        }

        public void UpdateIsLanguageBarrier(long customerId, bool isLanguageBarrier, long orgRoleId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            customer = UpdateIsLanguageBarrier(customer, isLanguageBarrier);

            SaveCustomerOnly(customer, orgRoleId);
        }

        public bool UpdateIsIncorrectPhoneNumber(long customerId, bool isIncorrectPhoneNumber, long orgRoleId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            customer = UpdateIsIncorrectPhoneNumber(customer, isIncorrectPhoneNumber);
            SaveCustomerOnly(customer, orgRoleId);
            return true;
        }
        public bool UpdateDoNotCallStatus(long customerId, bool isRevertDoNotCall, long orgRoleId, long? sourceId = null)
        {
            var customer = _customerRepository.GetCustomer(customerId);

            customer = UpdateDoNotCallStatus(customer, isRevertDoNotCall, sourceId);
            SaveCustomerOnly(customer, orgRoleId);
            return true;
        }

        public Customer UpdateDoNotCallStatus(Customer customer, bool isRevertDoNotCall, long? sourceId = null)
        {
            customer.DoNotContactTypeId = isRevertDoNotCall ? (long?)null : (long)DoNotContactType.DoNotCall;
            customer.DoNotContactReasonId = isRevertDoNotCall ? (long?)null : (long)DoNotContactReason.CustomerRequest;
            customer.DoNotContactUpdateDate = isRevertDoNotCall ? (DateTime?)null : DateTime.Now;
            customer.DoNotContactUpdateSource = isRevertDoNotCall ? (long?)null : sourceId;

            return customer;
        }

        public Customer UpdateIsLanguageBarrier(Customer customer, bool isLanguageBarrier)
        {
            customer.IsLanguageBarrier = isLanguageBarrier;
            customer.LanguageBarrierMarkedDate = isLanguageBarrier ? DateTime.Now : (DateTime?)null;

            return customer;
        }

        public Customer UpdateIsIncorrectPhoneNumber(Customer customer, bool isIncorrectPhoneNumber)
        {
            customer.IsIncorrectPhoneNumber = isIncorrectPhoneNumber;
            customer.IncorrectPhoneNumberMarkedDate = isIncorrectPhoneNumber ? DateTime.Now : (DateTime?)null;

            return customer;
        }

        public Customer UpdateDoNotCallStatuswithReason(Customer customer, bool isRevertDoNotCall, ProspectCustomerTag prospectCustomerTag, long? sourceId = null)
        {
            customer.DoNotContactTypeId = isRevertDoNotCall ? (long?)null : (long)DoNotContactType.DoNotCall;

            if (ProspectCustomerTag.MemberStatesIneligibleMastectomy == prospectCustomerTag)
                customer.DoNotContactReasonId = isRevertDoNotCall ? (long?)null : (long)DoNotContactReason.Other;
            else
                customer.DoNotContactReasonId = isRevertDoNotCall ? (long?)null : (long)DoNotContactReason.CustomerRequest;

            customer.DoNotContactUpdateDate = isRevertDoNotCall ? (DateTime?)null : DateTime.Now;
            customer.DoNotContactUpdateSource = isRevertDoNotCall ? (long?)null : sourceId;

            return customer;
        }

    }
}
