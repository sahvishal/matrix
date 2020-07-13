using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers.Payments;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    class CashPaymentRepository : PaymentInstrumentRepository<CashPayment, CashPaymentEntity>, ICashPaymentRepository
    {
        public CashPaymentRepository()
            : this(new CashPaymentMapper())
        {}

        public CashPaymentRepository(IMapper<CashPayment, CashPaymentEntity> factory) : base(factory)
        { }

        public CashPaymentRepository(IPersistenceLayer persistenceLayer, 
            IMapper<CashPayment, CashPaymentEntity> factory, RepositoryStrategySet<CashPayment> strategySet)
            : base(persistenceLayer, factory, strategySet)
        { }

        protected override EntityField2 EntityIdField
        {
            get { return CashPaymentFields.CashPaymentId; }
        }

        protected override IPredicate PaymentIdPredicate(long paymentId)
        {
            return CashPaymentFields.PaymentId == paymentId;
        }
        
        public override PaymentType PaymentType
        {
            get { return PaymentType.Cash; }
        }
    }
}