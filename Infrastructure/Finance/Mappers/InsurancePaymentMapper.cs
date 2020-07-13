using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Finance.Mappers
{
    public class InsurancePaymentMapper : DomainEntityMapper<InsurancePayment, InsurancePaymentEntity>
    {
        protected override void MapDomainFields(InsurancePaymentEntity entity, InsurancePayment domainObjectToMapTo)
        {
            domainObjectToMapTo.AmountToBePaid = entity.AmountToBePaid;
            domainObjectToMapTo.Amount = entity.Amount;
            domainObjectToMapTo.PaymentId = entity.PaymentId;
            domainObjectToMapTo.Id = entity.InsurancePaymentId;
        }

        protected override void MapEntityFields(InsurancePayment domainObject, InsurancePaymentEntity entityToMapTo)
        {
            entityToMapTo.AmountToBePaid = domainObject.AmountToBePaid;
            entityToMapTo.Amount = domainObject.Amount;
            entityToMapTo.PaymentId = domainObject.PaymentId;
            entityToMapTo.InsurancePaymentId = domainObject.Id;
            entityToMapTo.IsNew = domainObject.Id <= 0;
        }
    }
}
