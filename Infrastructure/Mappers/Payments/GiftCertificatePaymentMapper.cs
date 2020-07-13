using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Payments
{
    public class GiftCertificatePaymentMapper : DomainEntityMapper<GiftCertificatePayment,
        GiftCertificatePaymentEntity>
    {
        protected override void MapDomainFields(GiftCertificatePaymentEntity entity, 
            GiftCertificatePayment domainObjectToMapTo)
        {
            domainObjectToMapTo.Amount = entity.Amount;
            domainObjectToMapTo.PaymentId = entity.PaymentId;
            domainObjectToMapTo.GiftCertificateId = entity.GiftCertificateId;
        }

        protected override void MapEntityFields(GiftCertificatePayment domainObject,
            GiftCertificatePaymentEntity entityToMapTo)
        {
            entityToMapTo.Amount = domainObject.Amount;
            entityToMapTo.PaymentId = domainObject.PaymentId;
            entityToMapTo.GiftCertificateId = domainObject.GiftCertificateId;
        }
    }
}