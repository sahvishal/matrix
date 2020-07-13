using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<ScreeningAuthorization, ScreeningAuthorizationEntity>))]
    public class ScreeningAuthorizationMapper : DomainEntityMapper<ScreeningAuthorization,ScreeningAuthorizationEntity>
    {
        protected override void MapDomainFields(ScreeningAuthorizationEntity entity, ScreeningAuthorization domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.EventCustomerId;
            domainObjectToMapTo.Initials = entity.Initials;
            domainObjectToMapTo.Signature = entity.Signature;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.PhysicianId = entity.PhysicianOrgRoleUserId;
        }

        protected override void MapEntityFields(ScreeningAuthorization domainObject, ScreeningAuthorizationEntity entityToMapTo)
        {
            entityToMapTo.EventCustomerId = domainObject.Id;
            entityToMapTo.Initials = domainObject.Initials;
            entityToMapTo.Signature = domainObject.Signature;
            entityToMapTo.DateCreated = DateTime.Now;
            entityToMapTo.PhysicianOrgRoleUserId = domainObject.PhysicianId;
            entityToMapTo.IsNew = true;
        }
    }
}
