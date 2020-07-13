using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Users.Mappers
{
 
    public class OrganizationMapper : DomainEntityMapper<Organization, OrganizationEntity>
    {
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public OrganizationMapper(IPhoneNumberFactory phoneNumberFactory)
        {
            _phoneNumberFactory = phoneNumberFactory;
        }

        public OrganizationMapper()
        {
            _phoneNumberFactory = new PhoneNumberFactory();
        }

        protected override void MapDomainFields(OrganizationEntity entity, Organization domainObjectToMapTo)
        {
            domainObjectToMapTo.BillingAddressId = entity.BillingAddressId != null ? entity.BillingAddressId.Value : 0;
            domainObjectToMapTo.BusinessAddressId = entity.BusinessAddressId != null ? entity.BusinessAddressId.Value : 0;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.Email = entity.Email;
            domainObjectToMapTo.FaxNumber = _phoneNumberFactory.CreatePhoneNumber(entity.FaxNumber, PhoneNumberType.Unknown);
            domainObjectToMapTo.Id = entity.OrganizationId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.OrganizationType = (OrganizationType)entity.OrganizationTypeId;
            domainObjectToMapTo.PhoneNumber = _phoneNumberFactory.CreatePhoneNumber(entity.PhoneNumber, PhoneNumberType.Unknown);
            domainObjectToMapTo.LogoImageId = entity.LogoImageId != null ? entity.LogoImageId.Value : 0;
            domainObjectToMapTo.TeamImageId = entity.TeamImageId != null ? entity.TeamImageId.Value : 0;
        }

        protected override void MapEntityFields(Organization domainObject, OrganizationEntity entityToMapTo)
        {
            if (domainObject.BillingAddressId > 0) entityToMapTo.BillingAddressId = domainObject.BillingAddressId;
            if (domainObject.BusinessAddressId > 0) entityToMapTo.BusinessAddressId = domainObject.BusinessAddressId;

            entityToMapTo.Description = domainObject.Description;
            entityToMapTo.Email = domainObject.Email;
            entityToMapTo.Fields["Email"].IsChanged = true;

            if (entityToMapTo.PhoneNumber != null) entityToMapTo.PhoneNumber = domainObject.PhoneNumber.ToString();
            if (entityToMapTo.FaxNumber != null) entityToMapTo.FaxNumber = domainObject.FaxNumber.ToString();
            
            entityToMapTo.OrganizationId = domainObject.Id;
            entityToMapTo.OrganizationTypeId = (long)domainObject.OrganizationType;
            entityToMapTo.Name = domainObject.Name;

            if (domainObject.TeamImageId > 0)
                entityToMapTo.TeamImageId = domainObject.TeamImageId;

            if (domainObject.LogoImageId > 0)
                entityToMapTo.LogoImageId = domainObject.LogoImageId;

            entityToMapTo.Fields["LogoImageId"].IsChanged = true;
            entityToMapTo.Fields["TeamImageId"].IsChanged = true;
        }
    }
}
