using System;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Users.Interfaces;

namespace Falcon.App.Infrastructure.Service
{
    public class CallCenterRepService : ICallCenterRepService
    {
        private readonly IAddressService _addressService;
        private readonly ICallCenterRepRepository _callcenterRepository;
        private readonly IUserRepository<CallCenterRep> _userRepository;
        private readonly IOrganizationRoleUserRepository _orgRoleUserRepository;
        

        public CallCenterRepService()
            :this(new AddressService(),new CallCenterRepRepository(), new UserRepository<CallCenterRep>(),new OrganizationRoleUserRepository())
        {
            
        }
        public CallCenterRepService(IAddressService addressService, ICallCenterRepRepository callcenterRepository, IUserRepository<CallCenterRep> userRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _addressService = addressService;
            _callcenterRepository= callcenterRepository;
            _userRepository = userRepository;
            _orgRoleUserRepository = organizationRoleUserRepository;
        }
        
        public CallCenterRep SaveCallCenterRep(CallCenterRep callCenterRep, long organizationId)
        {
            if (callCenterRep == null)
            {
                throw new ArgumentNullException("CallCenterRep");
            }

            if (callCenterRep.Address != null)
            {
               callCenterRep.Address = _addressService.SaveAfterSanitizing(callCenterRep.Address);
            }
            callCenterRep.DefaultRole = Roles.CallCenterRep;
            callCenterRep = _userRepository.SaveUser(callCenterRep);
            var orgRoleUser = _orgRoleUserRepository.SaveOrganizationRoleUser(new OrganizationRoleUser(callCenterRep.Id, (long) Roles.CallCenterRep,
                                                                                     organizationId));
            _callcenterRepository.Save(callCenterRep, orgRoleUser.Id);
            return callCenterRep;
        }

        public CallCenterRep GetUser(long organizationRoleUserId)
        {
            return _callcenterRepository.GetCallCenterRep(organizationRoleUserId);
        }
    }
}