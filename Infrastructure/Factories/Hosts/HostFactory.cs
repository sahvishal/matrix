using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Sales.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Hosts
{
    public class HostFactory : IHostFactory
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public HostFactory()
            : this(new EmailFactory(), new PhoneNumberFactory())
        { }

        public HostFactory(IEmailFactory emailFactory, IPhoneNumberFactory phoneNumberFactory)
        {
            _emailFactory = emailFactory;
            _phoneNumberFactory = phoneNumberFactory;
        }

        public Host CreateHost(ProspectsEntity prospectsEntity, Address address, Address mailingAddress)
        {
            return new Host(prospectsEntity.ProspectId)
            {
                Address = address,
                MailingAddress = mailingAddress,
                OrganizationName = prospectsEntity.OrganizationName ?? string.Empty,
                TaxIdNumber = prospectsEntity.TaxIdNumber ?? string.Empty,
                Notes = prospectsEntity.Notes,
                Email = _emailFactory.CreateEmail(prospectsEntity.EmailId),
                OfficePhoneNumber =
                    _phoneNumberFactory.CreatePhoneNumber(prospectsEntity.PhoneOffice, PhoneNumberType.Office),
                MobilePhoneNumber =
                    _phoneNumberFactory.CreatePhoneNumber(prospectsEntity.PhoneCell, PhoneNumberType.Mobile),
                OtherPhoneNumber =
                    _phoneNumberFactory.CreatePhoneNumber(prospectsEntity.PhoneOther, PhoneNumberType.Unknown),
                Status =
                    HostStatus.HostStatuses.Find(
                    hostStatus => hostStatus.PersistenceLayerId.ToString() == prospectsEntity.Status),
                Type = prospectsEntity.ProspectTypeId.HasValue ? ((HostProspectType)prospectsEntity.ProspectTypeId.Value) : HostProspectType.Other,
                FaxNumber = _phoneNumberFactory.CreatePhoneNumber(prospectsEntity.Fax, PhoneNumberType.Unknown),
                DataRecorderMetaData = new DataRecorderMetaData
                                           {
                                               DateCreated = prospectsEntity.DateCreated,
                                               DateModified = prospectsEntity.DateModified,
                                               DataRecorderCreator = prospectsEntity.OrgRoleUserId.HasValue ? new OrganizationRoleUser(prospectsEntity.OrgRoleUserId.Value) : null
                                           },
                IsHost = prospectsEntity.IsHost.HasValue && prospectsEntity.IsHost.Value
            };
        }

        public List<Host> CreateHosts(List<ProspectsEntity> hostsEntities, List<Address> addresses, List<Address> mailingAddresses)
        {
            var hosts = new List<Host>();
            hostsEntities.ForEach(h => hosts.Add(CreateHost(h, addresses.Find(a => a.Id == h.AddressId), mailingAddresses.Find(a => a.Id == h.AddressIdmailling))));
            return hosts;
        }

        public ProspectsEntity CreateHostEntity(Host host)
        {
            return new ProspectsEntity
                       {
                           ProspectId = host.Id,
                           ProspectTypeId = (long) host.Type,
                           OrganizationName = host.OrganizationName,
                           AddressId = host.Address.Id,
                           AddressIdmailling = host.MailingAddress.Id,
                           IsHost = true,
                           DateCreated = host.Id > 0 ? host.DataRecorderMetaData.DateCreated : DateTime.Now,
                           DateModified = DateTime.Now,
                           OrgRoleUserId =
                               host.DataRecorderMetaData.DataRecorderCreator != null &&
                               host.DataRecorderMetaData.DataRecorderCreator.Id > 0
                                   ? host.DataRecorderMetaData.DataRecorderCreator.Id
                                   : (long?) null,
                           PhoneOffice =
                               host.OfficePhoneNumber != null
                                   ? host.OfficePhoneNumber.AreaCode + host.OfficePhoneNumber.Number
                                   : string.Empty,
                           PhoneCell =
                               host.MobilePhoneNumber != null
                                   ? host.MobilePhoneNumber.AreaCode + host.MobilePhoneNumber.Number
                                   : string.Empty,
                           PhoneOther =
                               host.OtherPhoneNumber != null
                                   ? host.OtherPhoneNumber.AreaCode + host.OtherPhoneNumber.Number
                                   : string.Empty,
                           Fax = host.FaxNumber != null ? host.FaxNumber.AreaCode + host.FaxNumber.Number : string.Empty,
                           EmailId = host.Email != null ? host.Email.ToString() : string.Empty,
                           Notes = host.Notes,
                           IsActive = true,
                           IsNew = host.Id <= 0
                       };
        }

    }
}