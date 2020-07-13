using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.Data.Linq;
using Falcon.Data.HelperClasses;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    // What is this class? It is not versioned but is apparently necessary?
    
    public class CombinedPaymentInstrumentRepository : PersistenceRepository, IPaymentInstrumentRepository
    {
        private readonly IPaymentInstrumentFactory _paymentInstrumentFactory;

        public CombinedPaymentInstrumentRepository()
        {
            _paymentInstrumentFactory = new PaymentInstrumentFactory();
        }

        public CombinedPaymentInstrumentRepository(IPersistenceLayer persistenceLayer, IPaymentInstrumentFactory paymentInstrumentFactory)
            : base(persistenceLayer)
        {
            _paymentInstrumentFactory = paymentInstrumentFactory;
        }

        public List<PaymentInstrument> GetPaymentInstrumentsForPayment(long medicalVendorPaymentId)
        {
            var checkEntities = new EntityCollection<CheckEntity>();
            var bucket = new RelationPredicateBucket();
            bucket.Relations.Add(CheckEntity.Relations.MVPaymentCheckDetailsEntityUsingCheckId);
            bucket.Relations.Add(MVPaymentCheckDetailsEntity.Relations.PhysicianPaymentEntityUsingMvpaymentId);
            bucket.PredicateExpression.Add(PhysicianPaymentFields.PhysicianPaymentId == medicalVendorPaymentId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(checkEntities, bucket);
            }
            return _paymentInstrumentFactory.CreatePaymentInstruments(checkEntities);
        }

        public List<PaymentInstrument> GetPaymentInstrumentsForInvoice(long medicalVendorInvoiceId)
        {
            var medicalVendorPaymentEntities = new EntityCollection<PhysicianPaymentEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PhysicianInvoiceId == medicalVendorInvoiceId);
            bucket.Relations.Add(PhysicianPaymentEntity.Relations.PhysicianPaymentInvoiceEntityUsingPhysicianPaymentId);
            bucket.Relations.Add(PhysicianInvoiceEntity.Relations.PhysicianPaymentInvoiceEntityUsingPhysicianInvoiceId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(medicalVendorPaymentEntities, bucket);
            }

            var paymentInstruments = new List<PaymentInstrument>();
            foreach (long medicalVendorPaymentId in medicalVendorPaymentEntities.Select(mvpe => mvpe.PhysicianPaymentId))
            {
                paymentInstruments.AddRange(GetPaymentInstrumentsForPayment(medicalVendorPaymentId));
            }
            return paymentInstruments;
        }

        public List<PaymentInstrument> GetPaymentInstrumentsForOrder(long orderId)
        {
            IEnumerable<long> paymentIds;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                paymentIds = linqMetaData.PaymentOrder.Where(po => po.OrderId == orderId).
                    Select(po => po.PaymentId).ToList();
            }
            var paymentInstruments = new List<PaymentInstrument>();
            foreach (var paymentId in paymentIds)
            {
                paymentInstruments.AddRange(new CashPaymentRepository().GetByPaymentId(paymentId));
                paymentInstruments.AddRange(new CheckPaymentRepository().GetByPaymentId(paymentId));
                paymentInstruments.AddRange(new ECheckPaymentRepository().GetByPaymentId(paymentId));
                paymentInstruments.AddRange(new ChargeCardPaymentRepository().GetByPaymentId(paymentId));
                paymentInstruments.AddRange(new GiftCertificatePaymentRepository().GetByPaymentId(paymentId));
            }
            return paymentInstruments;
        }
    }
}