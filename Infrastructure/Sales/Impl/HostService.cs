using System;
using AutoMapper;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    public class HostService : IHostService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IAddressService _addressService;

        public HostService(IHostRepository hostRepository, IAddressService addressService)
        {
            _hostRepository = hostRepository;
            _addressService = addressService;
        }
        public long CreateHostFromAccount(CorporateAccountEditModel corporateAccount)
        {
            Host host = null;
            if (corporateAccount.ConvertedHostId.HasValue && corporateAccount.ConvertedHostId.Value > 0)
                host = _hostRepository.GetHostById(corporateAccount.ConvertedHostId.Value);
            else
                host = new Host();

            var hostAddressId = host.Address != null ? host.Address.Id : 0;
            var hostMailingAddressId = host.MailingAddress != null ? host.MailingAddress.Id : 0;

            host.Address = Mapper.Map<AddressEditModel, Address>(corporateAccount.OrganizationEditModel.BusinessAddress);
            host.MailingAddress = Mapper.Map<AddressEditModel, Address>(corporateAccount.OrganizationEditModel.BillingAddress);

            host.Address.Id = hostAddressId;
            host.MailingAddress.Id = hostMailingAddressId;

            host.OrganizationName = corporateAccount.OrganizationEditModel.Name;
            host.Type = HostProspectType.CorporateLocation;
            host.Notes = corporateAccount.ContractNotes;
            if (!string.IsNullOrEmpty(corporateAccount.OrganizationEditModel.Email))
            {
                string[] emailSplitUp = corporateAccount.OrganizationEditModel.Email.Split(new[] { '@' });

                host.Email = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }
            host.OfficePhoneNumber = corporateAccount.OrganizationEditModel.PhoneNumber;
            host.FaxNumber = corporateAccount.OrganizationEditModel.FaxNumber;
            if(host.DataRecorderMetaData==null)
                host.DataRecorderMetaData=new DataRecorderMetaData
                                              {
                                                  DateCreated = DateTime.Now
                                              };
            host.Address = _addressService.SaveAfterSanitizing(host.Address);
            host.MailingAddress = _addressService.SaveAfterSanitizing(host.MailingAddress);
            host = _hostRepository.CreateHost(host);
            return host.Id;
        }

        public long CreateHostFromBasicInfo(CorporateAccountBasicInfoEditModel corporateAccount)
        {
            Host host = null;
            if (corporateAccount.ConvertedHostId.HasValue && corporateAccount.ConvertedHostId.Value > 0)
                host = _hostRepository.GetHostById(corporateAccount.ConvertedHostId.Value);
            else
                host = new Host();

            var hostAddressId = host.Address != null ? host.Address.Id : 0;
            var hostMailingAddressId = host.MailingAddress != null ? host.MailingAddress.Id : 0;

            host.Address = Mapper.Map<AddressEditModel, Address>(corporateAccount.OrganizationEditModel.BusinessAddress);
            host.MailingAddress = Mapper.Map<AddressEditModel, Address>(corporateAccount.OrganizationEditModel.BillingAddress);

            host.Address.Id = hostAddressId;
            host.MailingAddress.Id = hostMailingAddressId;

            host.OrganizationName = corporateAccount.OrganizationEditModel.Name;
            host.Type = HostProspectType.CorporateLocation;
            host.Notes = corporateAccount.ContractNotes;
            if (!string.IsNullOrEmpty(corporateAccount.OrganizationEditModel.Email))
            {
                string[] emailSplitUp = corporateAccount.OrganizationEditModel.Email.Split(new[] { '@' });

                host.Email = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }
            host.OfficePhoneNumber = corporateAccount.OrganizationEditModel.PhoneNumber;
            host.FaxNumber = corporateAccount.OrganizationEditModel.FaxNumber;
            if (host.DataRecorderMetaData == null)
                host.DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = DateTime.Now
                };
            host.Address = _addressService.SaveAfterSanitizing(host.Address);
            host.MailingAddress = _addressService.SaveAfterSanitizing(host.MailingAddress);
            host = _hostRepository.CreateHost(host);
            return host.Id;
        }

        public bool DeleteHost(long hostId)
        {
            return _hostRepository.DeleteHost(hostId);
        }
    }
}
