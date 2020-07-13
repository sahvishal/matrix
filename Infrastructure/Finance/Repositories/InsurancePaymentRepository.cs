using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Infrastructure.Finance.Mappers;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    public class InsurancePaymentRepository : PaymentInstrumentRepository<InsurancePayment, InsurancePaymentEntity>, IInsurancePaymentRepository
    {
        public InsurancePaymentRepository()
            : this(new InsurancePaymentMapper())
        { }

        public InsurancePaymentRepository(IMapper<InsurancePayment, InsurancePaymentEntity> mapper)
            : base(mapper)
        { }

        protected override EntityField2 EntityIdField
        {
            get { return InsurancePaymentFields.InsurancePaymentId; }
        }

        protected override IPredicate PaymentIdPredicate(long paymentId)
        {
            return InsurancePaymentFields.PaymentId == paymentId;
        }

        public override PaymentType PaymentType
        {
            get { return PaymentType.Insurance; }
        }

        public void Delete(long insurancePaymentId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(InsurancePaymentFields.InsurancePaymentId == insurancePaymentId);

                adapter.DeleteEntitiesDirectly(typeof(InsurancePaymentEntity), relationPredicateBucket);
            }
        }
    }
}
