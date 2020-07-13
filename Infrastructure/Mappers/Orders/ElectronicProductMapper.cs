using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class ElectronicProductMapper : DomainEntityMapper<ElectronicProduct,ProductEntity>
    {
        protected override void MapDomainFields(ProductEntity entity, ElectronicProduct domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.ProductId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Price = entity.Price;
            domainObjectToMapTo.ShortDescription = entity.ShortDescription;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
        }

        protected override void MapEntityFields(ElectronicProduct domainObject, ProductEntity entityToMapTo)
        {
            entityToMapTo.ProductId = domainObject.Id;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.Price = domainObject.Price;
            entityToMapTo.ShortDescription = domainObject.ShortDescription;
            entityToMapTo.DateCreated = domainObject.DateCreated;
            
        }
    }
}
