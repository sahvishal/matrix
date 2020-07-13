using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.Infrastructure.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IOrganizationRoleUserRepository _orgRoleUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IAddressService _addressService;
        private readonly ISessionContext _sessionContext;
        private readonly IValidator<UserEditModel> _userModelValidator;
        private readonly IOrganizationRoleUserModelFactory _organizationRoleUserModelFactory;
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IPhysicianLicenseModelFactory _physicianLicenseModelFactory;
        private readonly IStateRepository _stateRepository;
        private readonly IOneWayHashingService _oneWayHashingService;
        private readonly IPasswordChangelogService _passwordChangelogService;
        private readonly IAccountCoordinatorProfileRepository _accountCoordinatorProfileRepository;
        private readonly ICallCenterRepProfileRepository _callCenterRepProfileRepository;
        private readonly IUserNpiInfoRepository _userNpiInfoRepository;
        private readonly ISystemUserInfoRepository _systemUserInfoRepository;
        private readonly IPinChangeLogService _pinChangeLogService;

        public UserService(IUserRepository<User> userRepository, IOrganizationRoleUserRepository orgRoleUserRepository, IOrganizationRepository organizationRepository,
                                IAddressService addressService, IRoleRepository roleRepository, ISessionContext sessionContext, IValidator<UserEditModel> userCValidator,
                                IOrganizationRoleUserModelFactory organizationRoleUserModelFactory, ITechnicianRepository technicianRepository, IPhysicianRepository physicianRepository,
                                IPhysicianLicenseModelFactory physicianLicenseModelFactory, IStateRepository stateRepository, IOneWayHashingService oneWayHashingService,
                                IPasswordChangelogService passwordChangelogService, IAccountCoordinatorProfileRepository accountCoordinatorProfileRepository, ICallCenterRepProfileRepository callCenterRepProfileRepository,
            IUserNpiInfoRepository userNpiInfoRepository, ISystemUserInfoRepository systemUserInfoRepository, IPinChangeLogService pinChangeLogService)
        {
            _oneWayHashingService = oneWayHashingService;
            _passwordChangelogService = passwordChangelogService;
            _userRepository = userRepository;
            _orgRoleUserRepository = orgRoleUserRepository;
            _organizationRepository = organizationRepository;
            _roleRepository = roleRepository;
            _addressService = addressService;
            _sessionContext = sessionContext;
            _userModelValidator = userCValidator;
            _organizationRoleUserModelFactory = organizationRoleUserModelFactory;
            _technicianRepository = technicianRepository;
            _physicianRepository = physicianRepository;
            _physicianLicenseModelFactory = physicianLicenseModelFactory;
            _stateRepository = stateRepository;
            _accountCoordinatorProfileRepository = accountCoordinatorProfileRepository;
            _callCenterRepProfileRepository = callCenterRepProfileRepository;
            _userNpiInfoRepository = userNpiInfoRepository;
            _systemUserInfoRepository = systemUserInfoRepository;
            _pinChangeLogService = pinChangeLogService;
        }

        public IEnumerable<OrderedPair<long, string>> GetRoleswithRegistrationEnabled()
        {
            var roles = _roleRepository.GetAll();
            return roles.Where(r => r.Id == (long)Roles.Technician || r.Id == (long)Roles.NursePractitioner || r.Id == (long)Roles.CallCenterRep || r.Id == (long)Roles.FranchisorAdmin || r.Id == (long)Roles.Customer || r.Id == (long)Roles.CallCenterManager).Select(r => new OrderedPair<long, string>(r.Id, r.DisplayName));
        }

        public long SaveDefaultUserforOrganization(long organizationId, OrganizationType type, User user)
        {

            _addressService.SaveAfterSanitizing(user.Address);
            Roles defaultRole = 0;

            switch (type)
            {
                case OrganizationType.Franchisee:
                    defaultRole = Roles.FranchiseeAdmin;
                    break;

                case OrganizationType.CallCenter:
                    defaultRole = Roles.CallCenterManager;
                    break;

                case OrganizationType.MedicalVendor:
                    defaultRole = Roles.MedicalVendorAdmin;
                    break;
            }
            if (user.Id == 0)
            {
                user.DefaultRole = defaultRole;
                user.UserLogin.IsSecurityQuestionVerified = false;
            }
            long userId = _userRepository.SaveUser(user).Id;
            _orgRoleUserRepository.SaveOrganizationRoleUser(new OrganizationRoleUser(userId, (long)defaultRole, organizationId));

            return userId;
        }

        public long SaveUserforOrganization(long organizationId, Roles role, User user, bool checkZipData = false)
        {
            _addressService.SaveAfterSanitizing(user.Address, checkZipData);

            if (user.Id == 0)
            {
                if (role != Roles.Customer)
                    user.UserLogin.IsSecurityQuestionVerified = false;

                user.DefaultRole = role;
            }

            long userId = _userRepository.SaveUser(user).Id;
            _orgRoleUserRepository.SaveOrganizationRoleUser(new OrganizationRoleUser(userId, (long)role, organizationId));

            return userId;
        }

        public User GetDefaultUserforOrganization(long organizationId, OrganizationType type)
        {
            OrganizationRoleUser orgRoleUser = null;
            switch (type)
            {
                case OrganizationType.Franchisee:
                    orgRoleUser = _orgRoleUserRepository.GetDefaultOrgRoleUserforOrganization(organizationId, (long)Roles.FranchiseeAdmin);
                    break;

                case OrganizationType.CallCenter:
                    orgRoleUser = _orgRoleUserRepository.GetDefaultOrgRoleUserforOrganization(organizationId, (long)Roles.CallCenterManager);
                    break;

                case OrganizationType.MedicalVendor:
                    orgRoleUser = _orgRoleUserRepository.GetDefaultOrgRoleUserforOrganization(organizationId, (long)Roles.MedicalVendorAdmin);
                    break;
            }
            if (orgRoleUser != null) return _userRepository.GetUser(orgRoleUser.UserId);
            return null;
        }

        public User GetUser(long organizationRoleUserId)
        {
            var orgRoleUser = _orgRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId);
            if (orgRoleUser == null) return null;
            return _userRepository.GetUser(orgRoleUser.UserId);
        }

        public UserEditModel Save(UserEditModel userToSave)
        {
            _userModelValidator.ValidateAndThrow(userToSave);

            var userAddress = _addressService.SaveAfterSanitizing(Mapper.Map<AddressEditModel, Address>(userToSave.Address));
            OrganizationRoleUser organizationRoleUser = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(_sessionContext.UserSession.CurrentOrganizationRole);

            userToSave.DataRecorderMetaData = new DataRecorderMetaData(organizationRoleUser, DateTime.Now, DateTime.Now);

            var user = Mapper.Map<UserEditModel, User>(userToSave);
            var isPasswordUpdatedOrCreated = false;
            SecureHash secureHash = null;
            if (userToSave.Id > 0 && string.IsNullOrEmpty(userToSave.Password))
            {
                var existingUser = _userRepository.GetUser(userToSave.Id);
                user.UserLogin.Password = existingUser.UserLogin.Password;
                user.UserLogin.Salt = existingUser.UserLogin.Salt;
                user.UserLogin.UserVerified = existingUser.UserLogin.UserVerified;//For a scenario: User is created and then immediatly updated
                user.UserLogin.LastPasswordChangeDate = existingUser.UserLogin.LastPasswordChangeDate;
                user.UserLogin.LastLogged = existingUser.UserLogin.LastLogged;
            }
            else if (!string.IsNullOrEmpty(userToSave.Password))
            {
                secureHash = _oneWayHashingService.CreateHash(userToSave.Password);
                user.UserLogin.Password = secureHash.HashedText;
                user.UserLogin.Salt = secureHash.Salt;
                isPasswordUpdatedOrCreated = true;
                user.UserLogin.LastPasswordChangeDate = DateTime.Now;
            }

            user.Address = userAddress;
            if (isPasswordUpdatedOrCreated)//&& user.Id > 0 && userToSave.UsersRoles.Count() == 1 && userToSave.UsersRoles.Single().RoleId == (long)Roles.Customer)
            {
                user.UserLogin.UserVerified = false;
            }

            user.UserLogin.IsTwoFactorAuthrequired = userToSave.OverRideTwoFactorAuthrequired ? userToSave.IsTwoFactorAuthrequired : (bool?)null;


            user = _userRepository.SaveUser(user);
            if (isPasswordUpdatedOrCreated && secureHash != null && !(user.Id > 0 && userToSave.UsersRoles.Count() == 1 && userToSave.UsersRoles.Single().RoleId == (long)Roles.Customer))
            {
                _passwordChangelogService.Update(user.Id, secureHash, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }

            userToSave.Id = user.Id;
            //map & save user roles
            _orgRoleUserRepository.DeactivateAllOrganizationRolesForUser(user.Id);
            foreach (var organizationRoleModel in userToSave.UsersRoles)
            {
                organizationRoleModel.UserId = user.Id;
                var orgRoleUser = _orgRoleUserRepository.SaveOrganizationRoleUser(Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(organizationRoleModel));
                var roleId = GetParentRoleIdByRoleId(orgRoleUser.RoleId);
                switch (roleId)
                {
                    case (long)Roles.Technician:
                        var technician = Mapper.Map<TechnicianModel, Technician>(userToSave.TechnicianProfile);
                        technician.TechnicianId = orgRoleUser.Id;
                        var repository = ((IRepository<Technician>)_technicianRepository);
                        repository.Save(technician);
                        if (!string.IsNullOrWhiteSpace(userToSave.TechnicianProfile.Pin))
                            _pinChangeLogService.Update(userToSave.TechnicianProfile.Pin.Encrypt(), orgRoleUser.Id, organizationRoleUser.Id);
                        break;
                    case (long)Roles.MedicalVendorUser:
                        var physician = Mapper.Map<PhysicianModel, Physician>(userToSave.PhysicianProfile);
                        physician.PhysicianId = orgRoleUser.Id;
                        physician.AuthorizedStateLicenses =
                            _physicianLicenseModelFactory.CreateMultiple(userToSave.PhysicianProfile.Licenses,
                                                                         orgRoleUser.Id);
                        _physicianRepository.SavePhysician(physician);
                        break;
                    case (long)Roles.CorporateAccountCoordinator:
                        var accountCoordinator = Mapper.Map<AccountCoordinatorProfileModel, AccountCoordinatorProfile>(userToSave.AccountCoordinatorProfile);
                        accountCoordinator.AccountCoordinatorId = orgRoleUser.Id;
                        var accountCoordinatorRepository = ((IRepository<AccountCoordinatorProfile>)_accountCoordinatorProfileRepository);
                        accountCoordinatorRepository.Save(accountCoordinator);
                        break;

                    case (long)Roles.CallCenterRep:
                        var callCenterRepProfile = new CallCenterRepProfile
                        {
                            CallCenterRepId = orgRoleUser.Id,
                            CanRefund = false,
                            CanChangeNotes = false,
                            DialerUrl = organizationRoleModel.DialerUrl
                        };
                        _callCenterRepProfileRepository.Save(callCenterRepProfile);
                        break;
                }
            }

            if (userToSave.UsersRoles.Any(x => x.RoleId == (long)Roles.NursePractitioner))
            {
                var userNpiInfo = new UserNpiInfo
                {
                    UserId = userToSave.Id,
                    Npi = !string.IsNullOrEmpty(userToSave.Npi) ? userToSave.Npi : null,
                    Credential = !string.IsNullOrEmpty(userToSave.Credential) ? userToSave.Credential : null
                };
                _userNpiInfoRepository.Save(userNpiInfo);
            }

            var systemUserInfo = new SystemUserInfo
            {
                EmployeeId = userToSave.UsersRoles.Count() == 1 && userToSave.UsersRoles.Any(x => x.RoleId == (long)Roles.Customer) ? string.Empty : userToSave.EmployeeId,
                UserId = userToSave.Id
            };
            _systemUserInfoRepository.Save(systemUserInfo);

            return userToSave; //this does not return the same object. the saved user are out of sync at this point.!!
        }
        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }
        public UserEditModel Get(long id)
        {
            var user = _userRepository.GetUser(id);
            var orgRoles = _orgRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(user.Id);
            var orgs = _organizationRepository.GetAllOrganizationsforUser(user.Id);
            var roles = _roleRepository.GetAll();

            var userEditModel = Mapper.Map<User, UserEditModel>(user);
            userEditModel.UsersRoles = _organizationRoleUserModelFactory.CreateMulti(user, orgRoles, orgs, roles, null, null);

            var defaultRole = userEditModel.UsersRoles.FirstOrDefault(x => x.IsDefault);
            if (defaultRole != null)
            {
                var role = _roleRepository.GetByRoleId(defaultRole.RoleId);
                if (user.UserLogin.IsTwoFactorAuthrequired == null)
                {
                    userEditModel.IsTwoFactorAuthrequired = role.IsTwoFactorAuthrequired;
                    userEditModel.OverRideTwoFactorAuthrequired = false;
                }
                else
                {
                    userEditModel.IsTwoFactorAuthrequired = user.UserLogin.IsTwoFactorAuthrequired.Value;
                    if (user.UserLogin.IsTwoFactorAuthrequired.Value)
                    {
                        userEditModel.OverRideTwoFactorAuthrequired = true;
                    }
                    else
                    {
                        userEditModel.OverRideTwoFactorAuthrequired = role.IsTwoFactorAuthrequired;
                    }
                }
            }
            foreach (var organizationRoleUser in orgRoles)
            {
                var roleId = GetParentRoleIdByRoleId(organizationRoleUser.RoleId);
                switch (roleId)
                {
                    case (long)Roles.Technician:
                        var technician = _technicianRepository.GetTechnician(organizationRoleUser.Id);
                        userEditModel.TechnicianProfile = Mapper.Map<Technician, TechnicianModel>(technician);
                        break;
                    case (long)Roles.MedicalVendorUser:
                        var states = _stateRepository.GetAllStates();
                        var physician = _physicianRepository.GetPhysician(organizationRoleUser.Id);
                        userEditModel.PhysicianProfile = Mapper.Map<Physician, PhysicianModel>(physician);
                        if (physician.AuthorizedStateLicenses != null && physician.AuthorizedStateLicenses.Count() > 0)
                            userEditModel.PhysicianProfile.Licenses =
                                _physicianLicenseModelFactory.CreateMultiple(physician.AuthorizedStateLicenses, states);

                        break;
                    case (long)Roles.CorporateAccountCoordinator:
                        var accountCoordinator = _accountCoordinatorProfileRepository.GetAccountCoordinatorProfile(organizationRoleUser.Id);
                        userEditModel.AccountCoordinatorProfile = Mapper.Map<AccountCoordinatorProfile, AccountCoordinatorProfileModel>(accountCoordinator);
                        break;

                    /*case (long)Roles.CallCenterRep:
                        var callCenterRepProfile = _callCenterRepProfileRepository.Get(organizationRoleUser.Id);
                        userEditModel.CallCenterAgentProfile = new CallCenterAgentProfileModel { DialerUrl = callCenterRepProfile != null ? callCenterRepProfile.DialerUrl : "" };
                        break;*/
                }
            }

            foreach (var usersRole in userEditModel.UsersRoles)
            {
                if (usersRole.CheckRole(usersRole.RoleId))
                {
                    var callCenterRepProfile = _callCenterRepProfileRepository.Get(usersRole.OrganizationRoleUserId);
                    usersRole.DialerUrl = callCenterRepProfile != null && !string.IsNullOrEmpty(callCenterRepProfile.DialerUrl) ? callCenterRepProfile.DialerUrl : string.Empty;
                }
            }

            var userNpiInfo = _userNpiInfoRepository.Get(id);
            if (userNpiInfo != null)
            {
                userEditModel.Npi = userNpiInfo.Npi ?? string.Empty;
                userEditModel.Credential = userNpiInfo.Credential ?? string.Empty;
            }
            else
            {
                userEditModel.Npi = string.Empty;
                userEditModel.Credential = string.Empty;
            }

            var systemUserInfo = _systemUserInfoRepository.Get(id);
            if (systemUserInfo != null)
            {
                userEditModel.EmployeeId = systemUserInfo.EmployeeId;
            }
            return userEditModel;
        }

        public IEnumerable<UserBasicInfoModel> GetUsers(OrganizationType organizationType)
        {
            IEnumerable<UserBasicInfoModel> orgRoleUsers = null;
            switch (organizationType)
            {
                case OrganizationType.Franchisee:
                    break;
                case OrganizationType.CallCenter:
                    break;

                case OrganizationType.MedicalVendor:
                    break;

            }
            return orgRoleUsers;
        }

    }
}
