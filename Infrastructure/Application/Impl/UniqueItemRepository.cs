using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public abstract class UniqueItemRepository<Domain, Entity> : Repository<Domain, Entity>, 
        IUniqueItemRepository<Domain>
        where Domain : DomainObjectBase
        where Entity : EntityBase2, new()
    {        
        protected UniqueItemRepository(IMapper<Domain, Entity> mapper)
            : this(new SqlPersistenceLayer(), mapper, new RepositoryStrategySet<Domain>())
        {}

        protected UniqueItemRepository(IPersistenceLayer persistenceLayer, 
            IMapper<Domain, Entity> mapper, RepositoryStrategySet<Domain> strategySet)
            : base(persistenceLayer, mapper, strategySet)
        {}

        public Domain GetById(long id)
        {
            return GetByUniquePredicate(new PredicateExpression(EntityIdField == id), id);
        }
        
        public IEnumerable<Domain> GetByIds(IEnumerable<long> ids)
        {
            var entityCollection = new EntityCollection<Entity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (new PredicateExpression(EntityIdField == ids.ToList()));

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entityCollection, bucket);
            }

            IEnumerable<Domain> domainObjects = Mapper.MapMultiple(entityCollection);
            
            foreach (IPostFetchStrategy<IEnumerable<Domain>> strategy in 
                StrategySet.PostFetchCollectionStrategies)
            {
                strategy.ApplyStrategy(domainObjects);
            }

            // TODO: inject post-fetch strategy instead. This is harder than the one-item case.
            return PostFetchTransform(domainObjects);
        }

        protected abstract EntityField2 EntityIdField { get; }
        
        protected virtual IEnumerable<Domain> PostFetchTransform(IEnumerable<Domain> domainObjects)
        {
            return domainObjects;
        }

    }
}