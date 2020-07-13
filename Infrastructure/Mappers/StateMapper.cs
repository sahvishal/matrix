using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class StateMapper : DomainEntityMapper<State, StateEntity>
    {
        protected override void MapDomainFields(StateEntity entity, State domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.StateId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Code = entity.StateCode;
            //TODO:CountryId is nullable in TblState.
            domainObjectToMapTo.CountryId = entity.CountryId == null ? (long)AddressValidatableCountries.USA : entity.CountryId.Value;
        }

        protected override void MapEntityFields(State domainObject, StateEntity entityToMapTo)
        {
            entityToMapTo.StateId = domainObject.Id;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.StateCode = domainObject.Code;
            entityToMapTo.CountryId = domainObject.CountryId;
        }
    }
}