using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class GiftCertificateTypeMapper : DomainEntityMapper<GiftCertificateType,
        GiftCertificateTypeEntity>
    {
        protected override void MapDomainFields(GiftCertificateTypeEntity entity, 
            GiftCertificateType domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.GiftCertificateTypeId;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.ImageId = entity.ImageId.HasValue ? entity.ImageId.Value : 0;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.OrganizationRoleUserCreatorId = entity.OrganizationRoleUserCreatorId;
        }

        protected override void MapEntityFields(GiftCertificateType domainObject, 
            GiftCertificateTypeEntity entityToMapTo)
        {
            throw new NotImplementedException();
        }
    }
}