using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Infrastructure.Mappers.Payments;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    public class GiftCertificatePaymentRepository : PaymentInstrumentRepository<GiftCertificatePayment, GiftCertificatePaymentEntity>
    {
        public GiftCertificatePaymentRepository()
            : this(new GiftCertificatePaymentMapper())
        {}

        public GiftCertificatePaymentRepository(IMapper<GiftCertificatePayment, 
            GiftCertificatePaymentEntity> factory)
            : base(factory)
        {}

        protected override EntityField2 EntityIdField
        {
            get { return GiftCertificatePaymentFields.GiftCertificateId; }
        }

        protected override IPredicate PaymentIdPredicate(long paymentId)
        {
            return GiftCertificatePaymentFields.PaymentId == paymentId;
        }

        public override PaymentType PaymentType
        {
            get { return PaymentType.GiftCertificate; }
        }
    }
}