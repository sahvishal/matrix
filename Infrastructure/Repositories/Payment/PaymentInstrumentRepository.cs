using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    public abstract class PaymentInstrumentRepository<Domain, Entity>
        : UniqueItemRepository<Domain, Entity>, Core.Finance.Interfaces.IPaymentInstrumentRepository
        where Domain : PaymentInstrument
        where Entity : EntityBase2, new()
    {
        protected abstract override EntityField2 EntityIdField { get; }
        protected abstract IPredicate PaymentIdPredicate(long paymentId);
    
        protected PaymentInstrumentRepository(IMapper<Domain, Entity> mapper)
            : base(mapper)
        {}

        protected PaymentInstrumentRepository(IPersistenceLayer persistenceLayer, 
            IMapper<Domain, Entity> mapper, RepositoryStrategySet<Domain> repositoryStrategySet)
            : base(persistenceLayer, mapper, repositoryStrategySet)
        {}

        public abstract PaymentType PaymentType { get; }

        public IEnumerable<PaymentInstrument> GetByPaymentId(long paymentId)
        {
            var entityCollection = new EntityCollection<Entity>();

            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (new PredicateExpression(PaymentIdPredicate(paymentId)));

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entityCollection, bucket);
            }

            IEnumerable<Domain> domainObjects = PostFetchTransform(Mapper.MapMultiple(entityCollection));
            return domainObjects.Select(paymentInstrument => paymentInstrument as PaymentInstrument);
        }

        public IEnumerable<PaymentInstrument> GetByPaymentIds(IEnumerable<long> paymentIds)
        {
            throw new NotImplementedException();
        }

        public virtual PaymentInstrument SavePaymentInstrument(PaymentInstrument paymentInstrument)
        {
            return Save((Domain) paymentInstrument);
        }
    }
}