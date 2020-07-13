using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    public class PhysicalProductMapper : DomainEntityMapper<PhysicalProduct, ProductEntity>
    {
        protected override void MapDomainFields(ProductEntity entity, PhysicalProduct domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.ProductId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Price = entity.Price;
            domainObjectToMapTo.ShortDescription = entity.ShortDescription;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.Weight = entity.Weight != null ? new Weight(entity.Weight.Value) : null;
            domainObjectToMapTo.Depth = entity.Depth != null ? new Length(0, entity.Depth.Value) : null;
            domainObjectToMapTo.Height = entity.Height != null ? new Length(0, entity.Height.Value) : null;
            domainObjectToMapTo.Width = entity.Width != null ? new Length(0, entity.Width.Value) : null;


        }

        protected override void MapEntityFields(PhysicalProduct domainObject, ProductEntity entityToMapTo)
        {
            entityToMapTo.ProductId = domainObject.Id;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.Price = domainObject.Price;
            entityToMapTo.ShortDescription = domainObject.ShortDescription;
            entityToMapTo.DateCreated = domainObject.DateCreated;
            entityToMapTo.Weight = domainObject.Weight != null ? domainObject.Weight.Pounds :
                (double?)null;
            entityToMapTo.Height = domainObject.Height != null ? domainObject.Height.Inches :
                (double?)null;
            entityToMapTo.Width = domainObject.Width != null ? domainObject.Width.Inches : (double?)null;
            entityToMapTo.Depth = domainObject.Depth != null ? domainObject.Depth.Inches : (double?)null;
            
        }
    }
}
