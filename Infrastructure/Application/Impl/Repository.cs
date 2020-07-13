using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public abstract class Repository<Domain, Entity> : PersistenceRepository, IRepository<Domain>
        where Domain : DomainObjectBase
        where Entity : EntityBase2, new()
    {
        protected readonly IMapper<Domain, Entity> Mapper;
        protected readonly RepositoryStrategySet<Domain> StrategySet;

        protected Repository(IMapper<Domain, Entity> factory)
            : this(new SqlPersistenceLayer(), factory, new RepositoryStrategySet<Domain>())
        {}

        protected Repository(IPersistenceLayer persistenceLayer, IMapper<Domain, Entity> factory,
            RepositoryStrategySet<Domain> strategySet)
            : base(persistenceLayer)
        {
            Mapper = factory;
            StrategySet = strategySet;
        }

        private Domain CreateDomainObject(Entity entity)
        {
            Domain domainObject = Mapper.Map(entity);
            foreach (IPostFetchStrategy<Domain> strategy in StrategySet.PostFetchStrategies)
            {
                strategy.ApplyStrategy(domainObject);
            }
            return domainObject;
        }

        protected Domain GetByUniquePredicate(IPredicateExpression predicateExpression, long id)
        {
            var entity = new Entity();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.FetchEntityUsingUniqueConstraint(entity, predicateExpression))
                {
                    throw new ObjectNotFoundInPersistenceException<Domain>(id);
                }
            }
            return CreateDomainObject(entity);
        }        

        protected IEnumerable<Domain> GetByPredicate(IPredicateExpression predicateExpression)
        {
            var entityCollection = new EntityCollection<Entity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(predicateExpression);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entityCollection, bucket);
            }
            return entityCollection.Select(e => CreateDomainObject(e));
        }

        public Domain Save(Domain domainObject)
        {
            using (var transactionScope = new TransactionScope())
            {
                if (domainObject == null)
                {
                    throw new ArgumentNullException("domainObject", 
                        "The given object to persist cannot be null.");
                }

                foreach (IPrePersistenceStrategy<Domain> prePersistenceStrategy in 
                    StrategySet.PrePersistenceStrategies)
                {
                    prePersistenceStrategy.ApplyStrategy(domainObject);
                }

                Entity entity = Mapper.Map(domainObject);
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }
                }

                var newDomainObject = Mapper.Map(entity);
                foreach (IPostPersistenceStrategy<Domain> postPersistenceStrategy in 
                    StrategySet.PostPersistenceStrategies)
                {
                    postPersistenceStrategy.ApplyStrategy(newDomainObject);
                }

                transactionScope.Complete();
                return newDomainObject;
            }
        }

        public void Delete(Domain domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.DeleteEntity(Mapper.Map(domainObject)))
                {
                    throw new DeletionFailureException<Domain>();
                }
            }
        }

        public void Delete(IEnumerable<Domain> domainObjects)
        {
            foreach (var domainObject in domainObjects)
            {
                Delete(domainObject);
            }
        }
    }
}