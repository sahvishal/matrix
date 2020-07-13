using Falcon.App.Core;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Domain;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public abstract class DomainEntityMapper<Domain, Entity> : Mapper<Domain,Entity>
        where Domain : DomainObjectBase, new()
        where Entity : EntityBase2, new()
    {
        protected abstract void MapDomainFields(Entity entity, Domain domainObjectToMapTo);
        protected abstract void MapEntityFields(Domain domainObject, Entity entityToMapTo);

        public sealed override Domain Map(Entity entity)
        {
            NullArgumentChecker.CheckIfNull(entity, "entity");
            var domainObject = new Domain();
            MapDomainFields(entity, domainObject);
            return domainObject;
        }

        public sealed override Entity Map(Domain domainObject)
        {
            NullArgumentChecker.CheckIfNull(domainObject, "domainObject");
            var entity = new Entity {IsNew = domainObject.Id == 0};
            MapEntityFields(domainObject, entity);
            return entity;
        }
    }
}