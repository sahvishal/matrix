using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<PrimaryCarePhysician, CustomerPrimaryCarePhysicianEntity>))]
    public class PrimaryCarePhysicianMapper : DomainEntityMapper<PrimaryCarePhysician, CustomerPrimaryCarePhysicianEntity>
    {

        protected override void MapDomainFields(CustomerPrimaryCarePhysicianEntity entity, PrimaryCarePhysician domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.PrimaryCarePhysicianId;
            domainObjectToMapTo.Name = new Name(entity.FirstName, entity.MiddleName, entity.LastName);

            domainObjectToMapTo.DataRecorderMetaData =
                new DataRecorderMetaData(entity.CreatedByOrgRoleUserId ?? 0, entity.DateCreated, entity.DateModified)
                    {
                        DataRecorderModifier =
                            entity.UpdatedByOrganizationRoleUserId.HasValue
                                ? new OrganizationRoleUser(entity.UpdatedByOrganizationRoleUserId.Value)
                                : null
                    };

            domainObjectToMapTo.Primary = PhoneNumber.Create(entity.PhoneNumber, PhoneNumberType.Unknown);
            domainObjectToMapTo.Secondary = PhoneNumber.Create(entity.PhoneOther, PhoneNumberType.Unknown);

            domainObjectToMapTo.CustomerId = entity.CustomerId;

            if (!string.IsNullOrEmpty(entity.Email))
                domainObjectToMapTo.Email = new Email(entity.Email);

            if (!string.IsNullOrEmpty(entity.EmailOther))
                domainObjectToMapTo.SecondaryEmail = new Email(entity.EmailOther);

            domainObjectToMapTo.Address = entity.Pcpaddress.HasValue ? new Address(entity.Pcpaddress.Value) : null;
            domainObjectToMapTo.MailingAddress = entity.MailingAddressId.HasValue ? new Address(entity.MailingAddressId.Value) : null;

            domainObjectToMapTo.Website = entity.Website;
            domainObjectToMapTo.Npi = entity.Npi;
            domainObjectToMapTo.Fax = PhoneNumber.Create(entity.Fax, PhoneNumberType.Unknown);

            domainObjectToMapTo.PrefixText = entity.PrefixText;
            domainObjectToMapTo.SuffixText = entity.SuffixText;
            domainObjectToMapTo.CredentialText = entity.CredentialText;
            domainObjectToMapTo.PhysicianMasterId = entity.PhysicianMasterId;
            domainObjectToMapTo.IsActive = entity.IsActive;
            domainObjectToMapTo.IsPcpAddressVerified = entity.IsPcpAddressVerified;
            domainObjectToMapTo.PcpAddressVerifiedBy = entity.PcpAddressVerifiedBy;
            domainObjectToMapTo.PcpAddressVerifiedOn = entity.PcpAddressVerifiedOn;
            domainObjectToMapTo.Source = entity.Source;
        }

        protected override void MapEntityFields(PrimaryCarePhysician domainObject, CustomerPrimaryCarePhysicianEntity entityToMapTo)
        {
            entityToMapTo.PrimaryCarePhysicianId = domainObject.Id;
            entityToMapTo.FirstName = domainObject.Name.FirstName;
            entityToMapTo.LastName = domainObject.Name.LastName;
            entityToMapTo.MiddleName = domainObject.Name.MiddleName;

            if (domainObject.DataRecorderMetaData != null)
            {
                entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
                entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified;

                entityToMapTo.CreatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator != null
                                                           ? (long?)domainObject.DataRecorderMetaData.DataRecorderCreator.Id
                                                           : null;

                entityToMapTo.UpdatedByOrganizationRoleUserId = domainObject.DataRecorderMetaData.DataRecorderModifier != null
                                                           ? (long?)domainObject.DataRecorderMetaData.DataRecorderModifier.Id
                                                           : null;
            }

            entityToMapTo.Pcpaddress = domainObject.Address != null ? (long?)domainObject.Address.Id : null;
            entityToMapTo.MailingAddressId = domainObject.MailingAddress != null ? (long?)domainObject.MailingAddress.Id : null;

            entityToMapTo.PhoneNumber = domainObject.Primary != null ? domainObject.Primary.AreaCode + domainObject.Primary.Number : "";
            entityToMapTo.PhoneOther = domainObject.Secondary != null ? domainObject.Secondary.AreaCode + domainObject.Secondary.Number : "";

            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.Email = domainObject.Email != null ? domainObject.Email.ToString() : "";
            entityToMapTo.EmailOther = domainObject.SecondaryEmail != null ? domainObject.SecondaryEmail.ToString() : "";
            entityToMapTo.Website = domainObject.Website;
            entityToMapTo.Npi = domainObject.Npi;
            entityToMapTo.Fax = domainObject.Fax != null ? domainObject.Fax.AreaCode + domainObject.Fax.Number : "";

            entityToMapTo.PrefixText = domainObject.PrefixText;
            entityToMapTo.SuffixText = domainObject.SuffixText;
            entityToMapTo.CredentialText = domainObject.CredentialText;

            entityToMapTo.PhysicianMasterId = domainObject.PhysicianMasterId.HasValue && domainObject.PhysicianMasterId.Value > 0
                                              ? domainObject.PhysicianMasterId
                                              : null;
            entityToMapTo.IsActive = domainObject.Id <= 0 || domainObject.IsActive;

            entityToMapTo.Fields["PhysicianMasterId"].IsChanged = true;
            entityToMapTo.Fields["Pcpaddress"].IsChanged = true;
            entityToMapTo.IsPcpAddressVerified = domainObject.IsPcpAddressVerified;
            entityToMapTo.PcpAddressVerifiedBy = domainObject.PcpAddressVerifiedBy;
            entityToMapTo.PcpAddressVerifiedOn = domainObject.PcpAddressVerifiedOn;
            entityToMapTo.Source = domainObject.Source;
        }



    }
}