using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<GuardianDetails, GuardianDetailsEntity>))]
    public class GuardianMapper : DomainEntityMapper<GuardianDetails, GuardianDetailsEntity>
    {
        protected override void MapDomainFields(GuardianDetailsEntity entity, GuardianDetails domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.Id;
            domainObjectToMapTo.CustomerId = entity.CustomerId;
            domainObjectToMapTo.Relationship = new Relationship { Id = entity.RelationshipId };

            domainObjectToMapTo.Name = new Name(entity.FirstName, entity.MiddleName, entity.LastName);
            domainObjectToMapTo.Address = entity.AddressId.HasValue ? new Address(entity.AddressId.Value) : null;

            domainObjectToMapTo.PhoneCell = PhoneNumber.Create(entity.PhoneCell, PhoneNumberType.Mobile);
            domainObjectToMapTo.PhoneOffice = PhoneNumber.Create(entity.PhoneOffice, PhoneNumberType.Office);
            domainObjectToMapTo.PhoneHome = PhoneNumber.Create(entity.PhoneHome, PhoneNumberType.Home);

            if (!string.IsNullOrEmpty(entity.EmailId))
                domainObjectToMapTo.Email = new Email(entity.EmailId);

            domainObjectToMapTo.DataRecorderMetaData =
                new DataRecorderMetaData(entity.CreatedBy, entity.DateCreated, entity.DateModified)
                {
                    DataRecorderModifier = entity.ModifiedBy.HasValue ? new OrganizationRoleUser(entity.ModifiedBy.Value) : null
                };

            domainObjectToMapTo.IsActive = entity.IsActive;
        }

        protected override void MapEntityFields(GuardianDetails domainObject, GuardianDetailsEntity entityToMapTo)
        {
            entityToMapTo.Id = domainObject.Id;
            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.RelationshipId = domainObject.Relationship.Id;

            entityToMapTo.FirstName = domainObject.Name.FirstName;
            entityToMapTo.LastName = domainObject.Name.LastName;
            entityToMapTo.MiddleName = domainObject.Name.MiddleName;

            entityToMapTo.AddressId = domainObject.Address != null ? (long?)domainObject.Address.Id : null;

            entityToMapTo.PhoneCell = domainObject.PhoneCell != null ? domainObject.PhoneCell.AreaCode + domainObject.PhoneCell.Number : "";
            entityToMapTo.PhoneHome = domainObject.PhoneHome != null ? domainObject.PhoneHome.AreaCode + domainObject.PhoneHome.Number : "";
            entityToMapTo.PhoneOffice = domainObject.PhoneOffice != null ? domainObject.PhoneOffice.AreaCode + domainObject.PhoneOffice.Number : "";

            entityToMapTo.EmailId = domainObject.Email != null ? domainObject.Email.ToString() : "";

            if (domainObject.DataRecorderMetaData != null)
            {
                entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
                entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified;

                entityToMapTo.CreatedBy = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
                entityToMapTo.ModifiedBy = domainObject.DataRecorderMetaData.DataRecorderModifier != null
                                                           ? (long?)domainObject.DataRecorderMetaData.DataRecorderModifier.Id
                                                           : null;
            }

            entityToMapTo.IsActive = domainObject.IsActive;

            entityToMapTo.Fields["AddressId"].IsChanged = true;

            entityToMapTo.Fields["PhoneCell"].IsChanged = true;
            entityToMapTo.Fields["PhoneHome"].IsChanged = true;
            entityToMapTo.Fields["PhoneOffice"].IsChanged = true;

            entityToMapTo.Fields["EmailId"].IsChanged = true;
        }
    }
}
