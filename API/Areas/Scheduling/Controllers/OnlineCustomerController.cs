using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Areas.Application.Controllers;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels; 
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;


namespace API.Areas.Scheduling.Controllers
{
    [AllowAnonymous]
    public class OnlineCustomerController : BaseController
    {
        private readonly IUniqueItemRepository<ProspectCustomer> _prospectCustomerRepository;
        private readonly ITempcartService _tempcartService;
        private readonly ICustomerService _customerService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerService _prospectCustomerService;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IMarketingSourceService _marketingSourceService;
        private readonly ISettings _settings;
        private readonly IEventSchedulerService _eventSchedulerService;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IPasswordChangelogService _passwordChangeLogService;
        private readonly IOnlineShippingService _onlineShippingService;

        private readonly bool _enableTexting;
        private const string OnlineAddress1 = "Online Address";
        private readonly string _onlineCity = "Winter Park";
        private readonly long _onlineStateId = 20;//"Florida";
        private readonly long _onlineCountryId = 1;
        private readonly string _onlineZip = "32792";
        private readonly bool _enableVoiceMail;

        public OnlineCustomerController(IUniqueItemRepository<ProspectCustomer> uniqueItemRepository
               , ITempcartService tempcartService, ICustomerService customerService, IConfigurationSettingRepository configurationSettingRepository
            , ICustomerRepository customerRepository, IProspectCustomerService prospectCustomerService, IEventRepository eventRepository
            , ICorporateAccountRepository corporateAccountRepository, IHospitalPartnerRepository hospitalPartnerRepository, IStateRepository stateRepository
            , IMarketingSourceService marketingSourceService, ISettings settings, IEventSchedulerService eventSchedulerService,IUserLoginRepository userLoginRepository,
            IPasswordChangelogService passwordChangeLogService,IOnlineShippingService onlineShippingService)
        {
            _prospectCustomerRepository = uniqueItemRepository;
            _tempcartService = tempcartService;
            _customerService = customerService;
            _customerRepository = customerRepository;
            _prospectCustomerService = prospectCustomerService;
            _eventRepository = eventRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _stateRepository = stateRepository;
            _marketingSourceService = marketingSourceService;
            _settings = settings;
            _eventSchedulerService = eventSchedulerService;
            _userLoginRepository = userLoginRepository;
            _passwordChangeLogService = passwordChangeLogService;
            _onlineShippingService = onlineShippingService;
            _enableTexting = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableSmsNotification));
            _enableVoiceMail = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableVoiceMailNotification));
            _onlineCity = _settings.City;
            _onlineZip = _settings.ZipCode;
        }

        [HttpPost]
        public ProspectCustomerEditModel SaveProspectCustomer(ProspectCustomerEditModel model)
        {
            //since guid is unavailable for this screen , OnlineRequestStatus is set to valid directly.
            var onlineRequestValidationModel = new OnlineRequestValidationModel() { RequestStatus = OnlineRequestStatus.Valid };
            model.RequestValidationModel = onlineRequestValidationModel;

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;
            var prospectCustomer = Mapper.Map<ProspectCustomerEditModel, ProspectCustomer>(model);

            prospectCustomer.CreatedOn = DateTime.Now;
            _prospectCustomerRepository.Save(prospectCustomer);

            return model;
        }

        [HttpGet]
        public List<string> FetchMarketingSourceByZip(string guid, string text)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var model = new OnlineSchedulingCustomerInfoEditModel
            {
                RequestValidationModel = onlineRequestValidationModel
            };
            var tempCart = onlineRequestValidationModel.TempCart;
            string zip = "";
            var customer = tempCart.CustomerId.HasValue ? _customerRepository.GetCustomer(tempCart.CustomerId.Value) : null;
            if (customer != null)
            {
                zip = customer.Address.ZipCode.Zip;
            }
            return _marketingSourceService.FetchMarketingSourceByZip(zip, true).Where(x => x.ToLower().StartsWith(text.ToLower())).ToList();
        }

        public OnlineCustomerPersonalInformationEditModel GetCustomerInfo(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var model = new OnlineCustomerPersonalInformationEditModel
            {
                RequestValidationModel = onlineRequestValidationModel
            };
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;

            var shippingAddress = new AddressEditModel()
            {
                StreetAddressLine1 = OnlineAddress1,
                City = _onlineCity,
                StateId = _onlineStateId,
                CountryId = _onlineCountryId,
                ZipCode = _onlineZip
            };

            model.CustomerEditModel = new SchedulingCustomerEditModel
            {
                EnableTexting = _enableTexting,
                EnableVoiceMail = _enableVoiceMail,
                ShippingAddress = shippingAddress
            };
           
            var tempCart = onlineRequestValidationModel.TempCart;

            var customer = tempCart.CustomerId.HasValue ? _customerRepository.GetCustomer(tempCart.CustomerId.Value) : null;
            if (customer == null && tempCart.ProspectCustomerId.HasValue && tempCart.ProspectCustomerId.Value > 0)
            {
                model.CustomerEditModel = _prospectCustomerService.GetforProspectCustomerId(tempCart.ProspectCustomerId.Value);
                if (model.CustomerEditModel.ShippingAddress.StreetAddressLine1 == OnlineAddress1)
                    model.CustomerEditModel.ShippingAddress = shippingAddress;
            }
            else if (customer != null)
            {
                model.CustomerEditModel = Mapper.Map<Customer, SchedulingCustomerEditModel>(customer);
                model.CustomerEditModel.ShippingAddress = Mapper.Map<Address, AddressEditModel>(customer.Address);
                model.CustomerEditModel.ConfirmationToEnablTexting = customer.EnableTexting;
                model.CustomerEditModel.ConfirmationToEnableVoiceMail = customer.EnableVoiceMail;
            }

            model.CustomerEditModel.EnableTexting = _enableTexting;
            model.CustomerEditModel.EnableVoiceMail = _enableVoiceMail;
            model.CustomerEditModel.MarketingSource = tempCart.MarketingSource;
            if (tempCart.Dob.HasValue && !model.CustomerEditModel.DateofBirth.HasValue)
                model.CustomerEditModel.DateofBirth = tempCart.Dob.Value;

            if (!string.IsNullOrEmpty(tempCart.Gender) && !(model.CustomerEditModel.Gender.HasValue && model.CustomerEditModel.Gender.Value > 0))
                model.CustomerEditModel.Gender = (int)((Gender)System.Enum.Parse(typeof(Gender), tempCart.Gender, true));
            
            if (tempCart.EventId.HasValue && tempCart.EventId.Value > 0)
            {
                var eventData = _eventRepository.GetById(tempCart.EventId.Value);

                if (eventData.AccountId.HasValue && eventData.AccountId.Value > 0)
                {
                    var account = _corporateAccountRepository.GetbyEventId(tempCart.EventId.Value);
                    model.CustomerEditModel.InsuranceIdLabel = (account != null && !string.IsNullOrEmpty(account.MemberIdLabel)) ? account.MemberIdLabel : string.Empty;
                }

                model.CustomerEditModel.InsuranceIdRequired = eventData.InsuranceIdRequired;
                var eventHospitalPartner = _hospitalPartnerRepository.GetEventHospitalPartnersByEventId(tempCart.EventId.Value);
                if (eventHospitalPartner != null)
                    model.CustomerEditModel.CaptureSsn = eventHospitalPartner.CaptureSsn;
            }

            //model.ShippingOptions = _onlineShippingService.GetShippingOption(tempCart);
            return model;
        }

        [HttpPost]
        public SchedulingCustomerEditModel RegisterCustomer(String guid, SchedulingCustomerEditModel customerEditModel)
        {
            if (!string.IsNullOrEmpty(customerEditModel.HomeNumber))// To eliminate masking
                customerEditModel.HomeNumber = customerEditModel.HomeNumber.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");

            if (!string.IsNullOrEmpty(customerEditModel.PhoneCell))// To eliminate masking
                customerEditModel.PhoneCell = customerEditModel.PhoneCell.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");

            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            customerEditModel.RequestValidationModel = onlineRequestValidationModel;
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return customerEditModel;

            if (!customerEditModel.DateofBirth.HasValue)
                throw new Exception("Please enter Date of Birth!");

            if (customerEditModel.DateofBirth.Value.GetAge() < _settings.MinimumAgeForScreening)
                throw new Exception(string.Format("Customers below {0} years of age are not allowed for screening.In case of any queries, please call us at {1}", _settings.MinimumAgeForScreening, _settings.PhoneTollFree));

            var customer = _customerService.SaveCustomer(customerEditModel, onlineRequestValidationModel.TempCart.IsExistingCustomer);
            var userLogin = _userLoginRepository.GetByUserId(customer.Id);
            _passwordChangeLogService.Update(userLogin.Id, new SecureHash(userLogin.Password, userLogin.Salt), customer.CustomerId);
            onlineRequestValidationModel.TempCart.CustomerId = customer.CustomerId;
            onlineRequestValidationModel.TempCart.MarketingSource = customerEditModel.MarketingSource;

            var tempCart = onlineRequestValidationModel.TempCart;

            _tempcartService.SaveTempCart(tempCart);


            var doesEventCustomerAlreadyExists = tempCart.CustomerId.HasValue ? _eventSchedulerService.DoesEventCustomerAlreadyExists(tempCart.CustomerId.Value, tempCart.EventId.Value) : null;

            if (doesEventCustomerAlreadyExists != null && doesEventCustomerAlreadyExists.FirstValue)
            {
                throw new Exception(doesEventCustomerAlreadyExists.SecondValue);
            }

            customer = tempCart.CustomerId.HasValue ? _customerRepository.GetCustomer(tempCart.CustomerId.Value) : null;
            if (tempCart.ProspectCustomerId.HasValue)
            {
                var prospectCustomer = _prospectCustomerRepository.GetById(tempCart.ProspectCustomerId.Value);
                prospectCustomer.CustomerId = customer.CustomerId;
                prospectCustomer.Tag = ProspectCustomerTag.OnlineSignup;
                prospectCustomer.IsConverted = false;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
                prospectCustomer.ConvertedOnDate = DateTime.Now;
                prospectCustomer.Address.StreetAddressLine1 = customer.Address.StreetAddressLine1;
                prospectCustomer.Address.StreetAddressLine2 = customer.Address.StreetAddressLine2;
                prospectCustomer.Address.City = customer.Address.City;
                prospectCustomer.Address.State = _stateRepository.GetState(customer.Address.StateId).Name;
                prospectCustomer.Address.ZipCode.Zip = customer.Address.ZipCode.Zip;
                prospectCustomer.MarketingSource = customer.MarketingSource;
                prospectCustomer.CallBackPhoneNumber = customer.HomePhoneNumber;
                prospectCustomer.Email = customer.Email;
                prospectCustomer.TagUpdateDate = DateTime.Now;
                _prospectCustomerRepository.Save(prospectCustomer);
            }
            else
            {
                var prospectCustomer = ((IProspectCustomerRepository)_prospectCustomerRepository).GetProspectCustomerByCustomerId(customer.CustomerId);
                if (prospectCustomer != null)
                {
                    prospectCustomer.CustomerId = customer.CustomerId;
                    prospectCustomer.Tag = ProspectCustomerTag.OnlineSignup;
                    prospectCustomer.IsConverted = false;
                    prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
                    prospectCustomer.ConvertedOnDate = DateTime.Now;
                    prospectCustomer.Address.StreetAddressLine1 = customer.Address.StreetAddressLine1;
                    prospectCustomer.Address.StreetAddressLine2 = customer.Address.StreetAddressLine2;
                    prospectCustomer.Address.City = customer.Address.City;
                    prospectCustomer.Address.State = _stateRepository.GetState(customer.Address.StateId).Name;
                    prospectCustomer.Address.ZipCode.Zip = customer.Address.ZipCode.Zip;
                    prospectCustomer.MarketingSource = customer.MarketingSource;
                    prospectCustomer.CallBackPhoneNumber = customer.HomePhoneNumber;
                    prospectCustomer.Email = customer.Email;
                    prospectCustomer.TagUpdateDate = DateTime.Now;
                    _prospectCustomerRepository.Save(prospectCustomer);
                }
            }
            return customerEditModel;
        }

        [HttpPost]
        public ProspectCustomerEditModel SaveProspectCustomerAndUpdateCart(string guid, ProspectCustomerEditModel prospectCustomerEditModel)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            prospectCustomerEditModel.RequestValidationModel = onlineRequestValidationModel;
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return prospectCustomerEditModel;

            var prospectCustomer = Mapper.Map<ProspectCustomerEditModel, ProspectCustomer>(prospectCustomerEditModel);

            prospectCustomer.FirstName = prospectCustomer.FirstName.ToUppercaseInitalLetter();
            prospectCustomer.LastName = prospectCustomer.LastName.ToUppercaseInitalLetter();

            var tempCart = onlineRequestValidationModel.TempCart;

            if (prospectCustomerEditModel.Address != null)
            {
                prospectCustomer.Address.StreetAddressLine1 = prospectCustomer.Address.StreetAddressLine1.ToUppercaseInitalLetter(false);
                prospectCustomer.Address.StreetAddressLine2 = prospectCustomer.Address.StreetAddressLine2.ToUppercaseInitalLetter(false);

                if (prospectCustomerEditModel.Address.StateId > 0)
                {
                    var state = _stateRepository.GetState(prospectCustomerEditModel.Address.StateId);
                    prospectCustomer.Address.State = state.Name;
                }
                prospectCustomer.Address.ZipCode = new ZipCode(tempCart.ZipCode);
            }
            else
            {
                prospectCustomer.Address = new Address
                {
                    ZipCode = new ZipCode(tempCart.ZipCode)
                };
            }

            var inDb =
                ((IProspectCustomerRepository)_prospectCustomerRepository).GetProspectCustomermatchingConditions(
                    prospectCustomer.FirstName, prospectCustomer.LastName,
                    prospectCustomer.Email != null ? prospectCustomer.Email.ToString() : "",
                    prospectCustomer.CallBackPhoneNumber != null ? prospectCustomer.CallBackPhoneNumber.ToString() : "");

            if (tempCart.CustomerId > 0) return prospectCustomerEditModel;

            if (tempCart.ProspectCustomerId != null && tempCart.ProspectCustomerId > 0)
            {
                var prospectCustomerinDb = _prospectCustomerRepository.GetById(tempCart.ProspectCustomerId.Value);
                prospectCustomer.CreatedOn = prospectCustomerinDb.CreatedOn;
                prospectCustomer.Id = prospectCustomerinDb.Id;
            }
            else if (inDb != null)
            {
                inDb.Email = prospectCustomer.Email ?? inDb.Email;
                inDb.CustomerId = null;
                inDb.IsConverted = false;
                inDb.Status = (long)ProspectCustomerConversionStatus.NotConverted;
                inDb.CallBackPhoneNumber = prospectCustomer.CallBackPhoneNumber ?? inDb.CallBackPhoneNumber;
                inDb.BirthDate = prospectCustomer.BirthDate ?? inDb.BirthDate;
                inDb.Address = prospectCustomer.Address != null && !prospectCustomer.Address.IsEmpty() ? prospectCustomer.Address : inDb.Address;
                inDb.MarketingSource = prospectCustomer.MarketingSource;
                inDb.Gender = prospectCustomer.Gender;
                prospectCustomer = inDb;
            }
            else
            {
                prospectCustomer.CreatedOn = DateTime.Now;
                prospectCustomer.IsConverted = false;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
            }

            prospectCustomer = _prospectCustomerRepository.Save(prospectCustomer);
            if (prospectCustomer.Id > 0)
            {
                if (!string.IsNullOrEmpty(prospectCustomer.MarketingSource))
                    tempCart.MarketingSource = prospectCustomer.MarketingSource;
                tempCart.ProspectCustomerId = prospectCustomer.Id;
                tempCart.Dob = prospectCustomer.BirthDate ?? tempCart.Dob;

                _tempcartService.SaveTempCart(tempCart);
            }

            return prospectCustomerEditModel;
        }

        [HttpGet]
        public SchedulingCustomerEditModel UpdateCartwithReturningCustomer(string guid, long customerId)
        {
            var customerEditModel = new SchedulingCustomerEditModel();
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            customerEditModel.RequestValidationModel = onlineRequestValidationModel;

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return customerEditModel;

            var tempCart = onlineRequestValidationModel.TempCart;

            if (tempCart != null)
            {
                tempCart.CustomerId = customerId;
                tempCart.IsExistingCustomer = true;
                tempCart.ProspectCustomerId = null;

                _tempcartService.SaveTempCart(tempCart);
            }

            var customer = _customerRepository.GetCustomer(customerId);
            customerEditModel = Mapper.Map<Customer, SchedulingCustomerEditModel>(customer);
            customerEditModel.PhoneCell = PhoneNumber.ToNumber(customer.MobilePhoneNumber.ToString());
            customerEditModel.ShippingAddress = Mapper.Map<Address, AddressEditModel>(customer.BillingAddress ?? customer.Address);
            customerEditModel.MarketingSource = tempCart.MarketingSource;
            customerEditModel.EnableTexting = _enableTexting;
            customerEditModel.EnableVoiceMail = _enableVoiceMail;
            return customerEditModel;
        }

        [HttpGet]
        public bool CheckUserNameAvailability(string userName)
        {
            return _userLoginRepository.UniqueUserName(0, userName);
        }
        
    }
}
