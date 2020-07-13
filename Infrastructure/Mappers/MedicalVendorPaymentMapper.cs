using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class MedicalVendorPaymentMapper : DomainEntityMapper<MedicalVendorPayment, PhysicianPaymentEntity>
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public MedicalVendorPaymentMapper(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        protected override void MapDomainFields(PhysicianPaymentEntity entity, 
            MedicalVendorPayment domainObjectToMapTo)
        {
            var dataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData
                (entity.DataRecoderCreatorId, entity.DateCreated);

            domainObjectToMapTo.Id = entity.PhysicianPaymentId;
            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;
            domainObjectToMapTo.Notes = entity.Notes;
            domainObjectToMapTo.PaymentStatus = (PaymentStatus)entity.PaymentStatus;
            domainObjectToMapTo.ReferenceNumber = entity.ReferenceNumber;
        }

        protected override void MapEntityFields(MedicalVendorPayment domainObject, 
            PhysicianPaymentEntity entityToMapTo)
        {
            OrganizationRoleUser dataRecorderModifier = domainObject.DataRecorderMetaData.
                DataRecorderModifier;
            long? dataRecoderModifierId = null;
            if (dataRecorderModifier != null)
            {
                dataRecoderModifierId = dataRecorderModifier.Id;
            }
            entityToMapTo.PhysicianPaymentId = domainObject.Id;
            entityToMapTo.Notes = domainObject.Notes;
            entityToMapTo.PaymentStatus = (byte) domainObject.PaymentStatus;
            entityToMapTo.ReferenceNumber = domainObject.ReferenceNumber;
            entityToMapTo.DataRecoderCreatorId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.DataRecoderModifierId = dataRecoderModifierId;
            entityToMapTo.DateModifed = domainObject.DataRecorderMetaData.DateModified;
        }
    }
}