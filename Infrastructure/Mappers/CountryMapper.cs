using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;
namespace Falcon.App.Infrastructure.Mappers
{
    public class CountryMapper : DomainEntityMapper<Country, CountryEntity>
    {

        protected override void MapDomainFields(CountryEntity entity, Country domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.CountryId;
            domainObjectToMapTo.Name = entity.Name;
        }

        protected override void MapEntityFields(Country domainObject, CountryEntity entityToMapTo)
        {
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.CountryId = domainObject.Id;
        }
    }
}