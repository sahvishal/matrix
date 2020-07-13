using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Payments
{
    public class ECheckPaymentMapper : DomainEntityMapper<ECheckPayment, EcheckPaymentEntity>
    {
        protected override void MapDomainFields(EcheckPaymentEntity entity, 
            ECheckPayment domainObjectToMapTo)
        {
            domainObjectToMapTo.ECheckId = entity.EcheckId;
            domainObjectToMapTo.ProcessorResponse = entity.ProcessorResponse;
            domainObjectToMapTo.ECheckPaymentStatus = (ECheckPaymentStatus) entity.Status;
            domainObjectToMapTo.PaymentId = entity.PaymentId;
        }

        protected override void MapEntityFields(ECheckPayment domainObject, 
            EcheckPaymentEntity entityToMapTo)
        {
            entityToMapTo.PaymentId = domainObject.PaymentId;
            entityToMapTo.EcheckId = domainObject.ECheckId;
            entityToMapTo.ProcessorResponse = domainObject.ProcessorResponse;
            entityToMapTo.Status = (byte)domainObject.ECheckPaymentStatus;
        }
    }
}