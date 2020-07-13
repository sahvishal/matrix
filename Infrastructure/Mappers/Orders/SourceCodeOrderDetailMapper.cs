using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class SourceCodeOrderDetailMapper : DomainEntityMapper<SourceCodeOrderDetail, 
        SourceCodeOrderDetailEntity>
    {
        protected override void MapDomainFields(SourceCodeOrderDetailEntity entity, 
            SourceCodeOrderDetail domainObjectToMapTo)
        {
            domainObjectToMapTo.OrderDetailId = entity.OrderDetailId;
            domainObjectToMapTo.Amount = entity.Amount;
            domainObjectToMapTo.SourceCodeId = entity.SourceCodeId;
            domainObjectToMapTo.IsActive = entity.IsActive;
            domainObjectToMapTo.OrganizationRoleUserCreatorId = entity.OrganizationRoleUserCreatorId;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
        }

        protected override void MapEntityFields(SourceCodeOrderDetail domainObject,
            SourceCodeOrderDetailEntity entityToMapTo)
        {
            entityToMapTo.OrderDetailId = domainObject.OrderDetailId;
            entityToMapTo.SourceCodeId = domainObject.SourceCodeId;
            entityToMapTo.Amount = domainObject.Amount;
            entityToMapTo.IsActive = domainObject.IsActive;
            entityToMapTo.OrganizationRoleUserCreatorId = domainObject.OrganizationRoleUserCreatorId;
        }
    }
}