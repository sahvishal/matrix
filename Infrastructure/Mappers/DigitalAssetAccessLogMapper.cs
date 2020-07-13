using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<DigitalAssetAccessLog, DigitalAssetAccessLogEntity>))]
    public class DigitalAssetAccessLogMapper : DomainEntityMapper<DigitalAssetAccessLog, DigitalAssetAccessLogEntity>
    {
        protected override void MapDomainFields(DigitalAssetAccessLogEntity entity, DigitalAssetAccessLog domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.DigitalAssetAccessLogId;
            domainObjectToMapTo.OrganizationRoleUserId = entity.OrganisationRoleUserId;
            domainObjectToMapTo.UserLoginLogId = entity.UserLoginLogId;
            domainObjectToMapTo.DigitalAssetType = entity.DigitalAssetType;
            domainObjectToMapTo.DigitalAsset = entity.DigitalAsset;
            domainObjectToMapTo.AccessedOn = entity.AccessedOn;
        }
        protected override void MapEntityFields(DigitalAssetAccessLog domainObject, DigitalAssetAccessLogEntity entityToMapTo)
        {
            entityToMapTo.DigitalAssetAccessLogId = domainObject.Id;
            entityToMapTo.OrganisationRoleUserId = domainObject.OrganizationRoleUserId;
            entityToMapTo.UserLoginLogId = domainObject.UserLoginLogId;
            entityToMapTo.DigitalAssetType = domainObject.DigitalAssetType;
            entityToMapTo.DigitalAsset = domainObject.DigitalAsset;
            entityToMapTo.AccessedOn = domainObject.AccessedOn;

        }
    }
}
