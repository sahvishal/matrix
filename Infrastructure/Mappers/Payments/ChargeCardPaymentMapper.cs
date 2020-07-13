using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Payments
{
    [DefaultImplementation(Interface = typeof(IMapper<ChargeCardPayment, ChargeCardPaymentEntity>))]
    public class ChargeCardPaymentMapper : DomainEntityMapper<ChargeCardPayment, ChargeCardPaymentEntity>
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public ChargeCardPaymentMapper(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        protected override void MapDomainFields(ChargeCardPaymentEntity entity,
            ChargeCardPayment domainObjectToMapTo)
        {
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(entity.OrganizationRoleUserCreatorId,
                                           entity.DateCreated);

            domainObjectToMapTo.Id = entity.ChargeCardPaymentId;
            domainObjectToMapTo.Amount = entity.Amount;
            domainObjectToMapTo.ChargeCardId = entity.ChargeCardId;
            domainObjectToMapTo.ChargeCardPaymentStatus = (ChargeCardPaymentStatus)entity.Status;
            domainObjectToMapTo.ProcessorResponse = entity.ProcessorResponse;
            domainObjectToMapTo.PaymentId = entity.PaymentId;
            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;
        }

        protected override void MapEntityFields(ChargeCardPayment domainObject,
            ChargeCardPaymentEntity entityToMapTo)
        {
            entityToMapTo.ChargeCardPaymentId = domainObject.Id;
            entityToMapTo.ChargeCardPaymentId = domainObject.Id;
            entityToMapTo.Amount = domainObject.Amount;
            entityToMapTo.ChargeCardId = domainObject.ChargeCardId;
            entityToMapTo.Status = (byte)domainObject.ChargeCardPaymentStatus;
            entityToMapTo.ProcessorResponse = domainObject.ProcessorResponse;
            entityToMapTo.PaymentId = domainObject.PaymentId;
            entityToMapTo.OrganizationRoleUserCreatorId = domainObject.
                DataRecorderMetaData.DataRecorderCreator.Id;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
        }
    }
}