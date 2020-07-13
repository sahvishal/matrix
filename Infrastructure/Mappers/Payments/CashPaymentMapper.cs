using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Payments
{
    public class CashPaymentMapper : DomainEntityMapper<CashPayment, CashPaymentEntity>
    {

        protected override void MapDomainFields(CashPaymentEntity entity, CashPayment domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.CashPaymentId;
            domainObjectToMapTo.Amount = entity.Amount;
            domainObjectToMapTo.PaymentId = entity.PaymentId;
        }

        protected override void MapEntityFields(CashPayment domainObject, CashPaymentEntity entityToMapTo)
        {
            // TODO: What should PaymentId be? It's set to two things.
            entityToMapTo.Amount = domainObject.Amount;
            entityToMapTo.PaymentId = domainObject.PaymentId;
            entityToMapTo.CashPaymentId = domainObject.Id;
        }
    }
}