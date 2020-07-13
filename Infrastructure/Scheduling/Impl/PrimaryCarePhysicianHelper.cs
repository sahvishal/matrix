using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class PrimaryCarePhysicianHelper : IPrimaryCarePhysicianHelper
    {
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ICustomerService _customerService;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IRoleRepository _roleRepository;

        public PrimaryCarePhysicianHelper(IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ICustomerService customerService, IOrganizationRoleUserRepository organizationRoleUserRepository, IUserRepository<User> userRepository, IRoleRepository roleRepository)
        {
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _customerService = customerService;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public PrimaryCarePhysicianEditModel GetPrimaryCarePhysicianEditModel(long customerId)
        {
            PrimaryCarePhysicianEditModel pcpEditModel = null;
            var pcp = _primaryCarePhysicianRepository.Get(customerId);

            if (pcp != null)
            {
                pcpEditModel = Mapper.Map<PrimaryCarePhysician, PrimaryCarePhysicianEditModel>(pcp);
                pcpEditModel.Address = Mapper.Map<Address, AddressEditModel>(pcp.Address);
                pcpEditModel.MailingAddress = pcp.MailingAddress != null ? Mapper.Map<Address, AddressEditModel>(pcp.MailingAddress) : pcpEditModel.Address;
                if (pcpEditModel.IsPcpAddressVerified.HasValue)
                {
                    pcpEditModel.IsPcpAddressVerified = pcp.IsPcpAddressVerified;
                    pcpEditModel.PcpAddressVerifiedOn = pcp.PcpAddressVerifiedOn;
                    if (pcp.PcpAddressVerifiedBy.HasValue)
                    {
                        var orgRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUser(pcp.PcpAddressVerifiedBy.Value);
                        if (orgRoleUser != null)
                        {
                            if (orgRoleUser.RoleId > 0)
                            {
                                var role = _roleRepository.GetByRoleId(orgRoleUser.RoleId);
                                if (role != null)
                                {
                                    pcpEditModel.PcpAddresVarifiedByRole = role.DisplayName;
                                }
                            }
                            if (orgRoleUser.UserId > 0)
                            {
                                var user = _userRepository.GetUser(orgRoleUser.UserId);
                                if (user != null)
                                {
                                    pcpEditModel.PcpAddresVarifiedByUserName = user.Name.ToString();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                pcpEditModel = new PrimaryCarePhysicianEditModel { Address = new AddressEditModel(), PhoneNumber = new PhoneNumber { CountryCode = CountryCode.UnitedStatesAndCanada }, MailingAddress = new AddressEditModel(), HasSameAddress = true };
            }

            pcpEditModel.HasSameAddress = IsMailingAddressSame(pcpEditModel);

            return pcpEditModel;
        }

        public void UpdatePrimaryCarePhysician(PrimaryCarePhysicianEditModel primaryCarePhysician, long customerId, long orgRoleUserId)
        {
            _customerService.SavePrimaryCarePhysician(primaryCarePhysician, customerId, orgRoleUserId);
        }

        public PrimaryCarePhysicianViewModel GetPrimaryCarePhysicianViewModel(long customerId)
        {
            PrimaryCarePhysicianViewModel pcpEditModel = null;
            var pcp = _primaryCarePhysicianRepository.Get(customerId);
            if (pcp != null)
            {
                pcpEditModel = Mapper.Map<PrimaryCarePhysician, PrimaryCarePhysicianViewModel>(pcp);
                pcpEditModel.Address = Mapper.Map<Address, AddressViewModel>(pcp.Address);
                pcpEditModel.MailingAddress = Mapper.Map<Address, AddressViewModel>(pcp.MailingAddress);
                pcpEditModel.HasSameAddress = IsMailingAddressSame(pcp);
                if (pcpEditModel.Address != null && pcpEditModel.MailingAddress == null)
                    pcpEditModel.MailingAddress = pcpEditModel.Address;
                if (pcp.Primary != null)
                    pcpEditModel.Phone = pcp.Primary.FormatPhoneNumber;


            }
            return pcpEditModel;
        }

        private bool IsMailingAddressSame(PrimaryCarePhysician pcp)
        {
            if (pcp.Address == null && pcp.MailingAddress == null) return true;
            if (pcp.Address != null && pcp.MailingAddress == null) return true;
            if (pcp.Address == null && pcp.MailingAddress != null) return true;
            return (pcp.MailingAddress.Id == pcp.Address.Id);
        }

        private bool IsMailingAddressSame(PrimaryCarePhysicianEditModel pcp)
        {
            if (pcp.Address == null && pcp.MailingAddress == null) return true;
            if (pcp.Address != null && pcp.MailingAddress == null) return true;
            if (pcp.Address == null && pcp.MailingAddress != null) return true;

            return pcp.MailingAddress.StreetAddressLine1 == pcp.Address.StreetAddressLine1 && pcp.MailingAddress.StreetAddressLine2 == pcp.Address.StreetAddressLine2
                && pcp.MailingAddress.City == pcp.Address.City && pcp.MailingAddress.ZipCode == pcp.Address.ZipCode && pcp.MailingAddress.StateId == pcp.Address.StateId;
        }
    }
}