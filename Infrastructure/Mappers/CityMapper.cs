using System;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class CityMapper : DomainEntityMapper<City, CityEntity>
    {
        protected override void MapDomainFields(CityEntity entity, City domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.CityId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.StateId = entity.StateId;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.CityCode = entity.CityCode;
        }

        protected override void MapEntityFields(City domainObject, CityEntity entityToMapTo)
        {
            entityToMapTo.CityCode = domainObject.CityCode;
            entityToMapTo.CityId = domainObject.Id;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.StateId = domainObject.StateId;
            entityToMapTo.Description = domainObject.Description;
            entityToMapTo.IsActive = true;
            entityToMapTo.DateModified = DateTime.Now;
            if (entityToMapTo.CityId == 0)
                entityToMapTo.DateCreated = DateTime.Now;

        }
    }
}