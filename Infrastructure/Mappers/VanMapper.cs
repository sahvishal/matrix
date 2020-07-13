using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<Van,VanDetailsEntity>))]
    public class VanMapper : DomainEntityMapper<Van, VanDetailsEntity>
    {
        protected override void MapDomainFields(VanDetailsEntity entity, Van domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.VanId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.IsActive = entity.IsActive.Value;
            domainObjectToMapTo.Make = entity.Make;
            domainObjectToMapTo.RegistrationNumber = entity.RegistrationNumber;
            domainObjectToMapTo.StateId = entity.StateId.Value;
            domainObjectToMapTo.VehicleIdentificationNumber = entity.Vin;
        }

        protected override void MapEntityFields(Van domainObject, VanDetailsEntity entityToMapTo)
        {
            entityToMapTo.VanId = domainObject.Id;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.Description = domainObject.Description;
            entityToMapTo.IsActive = domainObject.IsActive;
            entityToMapTo.Make = domainObject.Make;
            entityToMapTo.RegistrationNumber = domainObject.RegistrationNumber;
            entityToMapTo.StateId = domainObject.StateId;
            entityToMapTo.Vin = domainObject.VehicleIdentificationNumber;
        }
    }
}