using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Territories
{
    public abstract class TerritoryMapper<T> : DomainEntityMapper<T, TerritoryEntity>
        where T : Territory, new()
    {
        private readonly IMapper<ZipCode, ZipEntity> _zipCodeMapper;

        protected TerritoryMapper(IMapper<ZipCode, ZipEntity> zipCodeMapper)
        {
            _zipCodeMapper = zipCodeMapper;
        }

        protected abstract void MapUniqueTerritoryFields(TerritoryEntity territoryEntity, 
            T territoryToMapTo);

        protected sealed override void MapDomainFields(TerritoryEntity entity, 
            T domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.TerritoryId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.ZipCodes = _zipCodeMapper.
                MapMultiple(entity.ZipCollectionViaTerritoryZip).ToList();
            domainObjectToMapTo.ParentTerritoryId = entity.ParentTerritoryId;
            MapUniqueTerritoryFields(entity, domainObjectToMapTo);
        }

        protected sealed override void MapEntityFields(T domainObject, 
            TerritoryEntity entityToMapTo)
        {
            entityToMapTo.TerritoryId = domainObject.Id;
            entityToMapTo.ParentTerritoryId = domainObject.ParentTerritoryId;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.Description = domainObject.Description;
            entityToMapTo.Type = (byte) domainObject.TerritoryType;
            entityToMapTo.IsActive = true;
            if (domainObject.DataRecorderMetadata != null)
            {
                entityToMapTo.CreatedBy = domainObject.DataRecorderMetadata.DataRecorderCreator.Id;
                entityToMapTo.DateCreated = domainObject.DataRecorderMetadata.DateCreated;
                entityToMapTo.DateModified = domainObject.DataRecorderMetadata.DateModified != null ? domainObject.DataRecorderMetadata.DateModified.Value : domainObject.DataRecorderMetadata.DateCreated;
            }            
        }
    }
}