using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class MedicareService : IMedicareService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMedicareFactory _medicareFactory;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IZipCodeRepository _zipRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IAddressService _addressService;
        private readonly ITestRepository _testRepository;
        private readonly INdcRepository _ndcRepository;
        private readonly ICurrentMedicationRepository _currentMedicationRepository;
        private readonly IRapsRepository _rapsRepository;
        private readonly ISettings _settings;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICustomerService _customerService;
        private readonly IMedicareApiService _medicareApiService;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public MedicareService(IUserRepository<User> userRepository, ICustomerRepository customerRepository, IMedicareFactory medicareFactory, IStateRepository stateRepository,
            ICityRepository cityRepository, IZipCodeRepository zipRepository, IProspectCustomerRepository prospectCustomerRepository, IAddressService addressService,
            ITestRepository testRepository, INdcRepository ndcRepository, ICurrentMedicationRepository currentMedicationRepository, ISettings settings, IRapsRepository rapsRepository,
            IPreApprovedTestRepository preApprovedTestRepository, ILanguageRepository languageRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            ICustomerService customerService, IMedicareApiService medicareApiService, IEventCustomerRepository eventCustomerRepository)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _medicareFactory = medicareFactory;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _zipRepository = zipRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _addressService = addressService;
            _testRepository = testRepository;
            _ndcRepository = ndcRepository;
            _currentMedicationRepository = currentMedicationRepository;
            _settings = settings;
            _rapsRepository = rapsRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _languageRepository = languageRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _customerService = customerService;
            _medicareApiService = medicareApiService;
            _eventCustomerRepository = eventCustomerRepository;
        }

        public MedicareUserViewModel GetUser(long userId)
        {
            var user = _userRepository.GetUser(userId);
            return new MedicareUserViewModel { EmailId = user.Email.ToString(), UserId = user.Id };
        }

        public MedicareCustomerViewModel GetCustomerDetails(long customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            if (customer == null) return null;
            var model = _medicareFactory.CreateCustomerViewModel(customer);
            if (customer.LanguageId.HasValue)
            {
                var lang = _languageRepository.GetById(customer.LanguageId.Value);
                if (lang != null)
                    model.PreferredLanguage = lang.Name;
            }
            var currentMedications = _currentMedicationRepository.GetByCustomerId(customerId).ToArray();
            if (currentMedications.Any())
            {
                var currentMedicationList = new List<MedicareCurrentMedication>();
                var ndcIds = currentMedications.Select(x => x.NdcId);
                var ndcs = _ndcRepository.GetByIds(ndcIds);
                if (ndcs != null && ndcs.Any())
                {
                    foreach (var ndc in ndcs)
                    {
                        var curr = currentMedications.FirstOrDefault(x => x.NdcId == ndc.Id);
                        currentMedicationList.Add(new MedicareCurrentMedication
                        {
                            CurrentMedication = ndc.NdcCode,
                            IsPrescribed = curr != null && curr.IsPrescribed,
                            IsOtc = curr != null && curr.IsOtc,
                        });
                    }

                }
                if (currentMedicationList.Any())
                {
                    model.CurrentMedications = new List<MedicareCurrentMedication>();
                    model.CurrentMedications = model.CurrentMedications.Concat(currentMedicationList);
                }
            }
            var raps = _rapsRepository.GetByCustomerId(customerId).ToArray();
            if (raps.Any())
            {
                model.Raps = raps.Select(Mapper.Map<Raps, MedicareRapsViewModel>);
            }

            var preApproved = _preApprovedTestRepository.GetByCustomerId(customerId).ToArray();
            if (preApproved.Any())
            {
                var testIds = preApproved.Select(x => x.TestId);
                model.PreapprovedTestList = _testRepository.GetAliasListByTestIdList(testIds);
            }

            return model;
        }

        public MedicareEventCustomerViewModel GetEventCustomerDetails(long customerId, long eventId)
        {
            var model = new MedicareEventCustomerViewModel();
            var domain = _customerRepository.GetCustomer(customerId);
            if (domain == null) return null;

            model.CustomerModel = _medicareFactory.CreateCustomerViewModel(domain);
            model.EventId = eventId;
            return model;
        }

        public bool UpdateCustomerDetails(MedicareCustomerViewModel customerViewModel)
        {
            var customer = _customerRepository.GetCustomer(customerViewModel.Id);
            if (customer == null) return false;
            _medicareFactory.UpdateCustomer(customerViewModel, customer);
            PrepareAddress(customer, customerViewModel);
            //_addressService.SaveAfterSanitizing(customer.Address);
            //_userRepository.SaveUser(customer);

            ProspectCustomer prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerViewModel.Id);

            if (prospectCustomer == null) return _customerService.SaveCustomerOnly(customer, customerViewModel.UpdatedBy);
            prospectCustomer.FirstName = customerViewModel.FirstName;
            prospectCustomer.LastName = customerViewModel.LastName;

            if (customer.Gender > 0)
            {
                prospectCustomer.Gender = customer.Gender;
            }
            prospectCustomer.BirthDate = customer.DateOfBirth;
            prospectCustomer.Email = customer.Email;
            prospectCustomer.CallBackPhoneNumber = customer.HomePhoneNumber;

            if (customer.Address != null)
            {
                prospectCustomer.Address.StreetAddressLine1 = customer.Address.StreetAddressLine1;
                prospectCustomer.Address.StreetAddressLine2 = customer.Address.StreetAddressLine2;
                if (customer.Address.StateId > 0)
                {
                    var state = _stateRepository.GetState(customer.Address.StateId);
                    prospectCustomer.Address.State = state.Name;
                }

                if (!string.IsNullOrEmpty(customer.Address.City))
                {
                    prospectCustomer.Address.City = customer.Address.City;
                }
                prospectCustomer.Address.ZipCode = customer.Address.ZipCode;
            }
            ((IUniqueItemRepository<ProspectCustomer>)_prospectCustomerRepository).Save(prospectCustomer);

            return _customerService.SaveCustomer(customer, customerViewModel.UpdatedBy);
        }

        private void PrepareAddress(User model, MedicareCustomerViewModel ehrModel)
        {
            var state = _stateRepository.GetStatebyCode(ehrModel.StateCode);
            if (state == null) return;

            var city = _cityRepository.GetCityByStateAndName(state.Id, ehrModel.City);
            if (city == null) return;

            var zip = _zipRepository.GetZipCode(ehrModel.Zip, city.Id);
            if (zip == null) return;



            if (model.Address != null)
            {
                model.Address.StreetAddressLine1 = ehrModel.StreetAddressLine1;
                model.Address.StreetAddressLine2 = ehrModel.StreetAddressLine2;
                model.Address.State = state.Name;
                model.Address.StateId = state.Id;
                model.Address.StateCode = state.Code;
                model.Address.CityId = city.Id;
                model.Address.City = city.Name;
                model.Address.CountryId = state.CountryId;
                model.Address.ZipCode = zip;

            }
            else
            {
                model.Address = new Address
                {
                    StreetAddressLine1 = ehrModel.StreetAddressLine1,
                    StreetAddressLine2 = ehrModel.StreetAddressLine2,
                    State = state.Name,
                    StateId = state.Id,
                    StateCode = state.Code,
                    CityId = city.Id,
                    City = city.Name,
                    CountryId = state.CountryId,
                    ZipCode = zip
                };
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetTestListByAliasList(IEnumerable<string> list)
        {
            return _testRepository.GetTestIdListByAliasList(list);
        }

        public MedicareUserEditModel CreateUserEditModel(UserEditModel userEditModel, string defaultRoleAlias, IEnumerable<string> roles, IEnumerable<string> removedRoles)
        {
            var userModel = new MedicareUserEditModel
            {
                FirstName = userEditModel.FullName.FirstName,
                LastName = userEditModel.FullName.LastName,
                MiddleName = userEditModel.FullName.MiddleName,
                UserName = userEditModel.UserName,
                OfficeNumber = userEditModel.OfficeNumber.ToString(),
                CellNumber = userEditModel.CellNumber.ToString(),
                HomeNumber = userEditModel.HomeNumber.ToString(),
                Email = userEditModel.Email,
                StreetAddressLine1 = userEditModel.Address.StreetAddressLine1,
                StreetAddressLine2 = userEditModel.Address.StreetAddressLine2,
                City = userEditModel.Address.City,
                StateCode = _stateRepository.GetState(userEditModel.Address.StateId).Code,
                Zip = userEditModel.Address.ZipCode,
                OrganizationName = _settings.OrganizationNameForHraQuestioner,

                DefaultRoleAlias = defaultRoleAlias,
                RoleAlias = roles.ToList(),
                EhrUserId = userEditModel.Id,
                Credential = userEditModel.Credential,
                Npi = userEditModel.Npi,
                RemovedRoleAlias = removedRoles.IsNullOrEmpty() ? new List<string>() : removedRoles.ToList(),

                EmployeeId = userEditModel.EmployeeId
            };

            return userModel;
        }

        public int GetResultState(long eventId, long customerId)
        {
            var ecr = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            return ecr != null ? ecr.ResultState : 0;
        }

        public IEnumerable<MedicareEventCustomerAcesViewModel> GetEventCustomerForAces()
        {
            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultForInvoicing(_settings.ResultFlowChangeDate);
            if (eventCustomerResults.IsNullOrEmpty()) return null;

            var customerIds = eventCustomerResults.Select(x => x.CustomerId).Distinct().ToArray();
            var customers = _customerRepository.GetCustomersWoithoutLoginAndAddressDetails(customerIds);

            return _medicareFactory.GetMedicareEventCustomerAcesViewModelList(eventCustomerResults, customers);
        }

        public MedicareUserDeactivateModel DeactivateUserModel(long userId, bool isActive)
        {
            var userModel = new MedicareUserDeactivateModel
            {
                EhrUserId = userId,
                IsActive = isActive,
            };

            return userModel;
        }

        public void UpdateMedicareVisitStatus(long eventCustomerId, int visitStatus, string sessionId, ISessionContext sessionContext)
        {
            if (!_settings.SyncWithHra)
            {
                return;
            }
            
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            if (eventCustomer.AwvVisitId.HasValue)
            {
                try
                {
                    _medicareApiService.Connect(sessionContext.UserSession.UserLoginLogId);
                }
                catch (Exception)
                {
                    var userSession = sessionContext.UserSession;
                    var token = (sessionId + "_" + userSession.UserId + "_" + userSession.CurrentOrganizationRole.RoleId + "_" + userSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                    var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = _settings.OrganizationNameForHraQuestioner, Tag = _settings.OrganizationNameForHraQuestioner, IsForAdmin = false, RoleAlias = "CallCenterRep" };
                    _medicareApiService.PostAnonymous<string>(_settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                    _medicareApiService.Connect(sessionContext.UserSession.UserLoginLogId);
                }

                _medicareApiService.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + visitStatus + "&unlock=true");
            }
        }
    }
}
