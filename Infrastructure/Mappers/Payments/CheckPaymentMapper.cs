using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Payments
{
    public class CheckPaymentMapper : DomainEntityMapper<CheckPayment, CheckPaymentEntity>
    {
        protected override void MapDomainFields(CheckPaymentEntity entity, CheckPayment domainObjectToMapTo)
        {
            domainObjectToMapTo.CheckStatus = (CheckPaymentStatus) entity.Status;
            domainObjectToMapTo.CheckId = entity.CheckId;
            domainObjectToMapTo.PaymentId = entity.PaymentId;
        }

        protected override void MapEntityFields(CheckPayment domainObject, CheckPaymentEntity entityToMapTo)
        {
            entityToMapTo.PaymentId = domainObject.PaymentId;
            entityToMapTo.CheckId = domainObject.CheckId;
            entityToMapTo.Status = (byte)domainObject.CheckStatus;
        }
    }
}