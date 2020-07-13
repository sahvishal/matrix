//using Falcon.App.Core.Domain;
//using Falcon.App.Core.Domain.MedicalVendors;
//using Falcon.App.Core.Finance.Domain;
//using Falcon.App.Core.Interfaces;
//using Falcon.Data.EntityClasses;

//namespace Falcon.App.Infrastructure.Mappers
//{
//    public class MedicalVendorEarningMapper : DomainEntityMapper<MedicalVendorEarning, MVEarningEntity>
//    {
//        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

//        public MedicalVendorEarningMapper(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
//        {
//            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
//        }

//        protected override void MapDomainFields(MVEarningEntity entity, 
//            MedicalVendorEarning domainObjectToMapTo)
//        {
//            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
//                CreateDataRecorderMetaData(entity.DataRecoderCreatorId, entity.DateCreated,
//                entity.DataRecoderModifierId, entity.DateModifed);

//            domainObjectToMapTo.Id = entity.MvearningId;
//            domainObjectToMapTo.OrganizationRoleUserId = entity.OrganizationRoleUserId;
//            domainObjectToMapTo.MedicalVendorUserEventTestLockId = entity.MvuserEventTestLockId;
//            domainObjectToMapTo.MedicalVendorUserAmountEarned = entity.MvuserAmountEarned;
//            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;
//        }

//        protected override void MapEntityFields(MedicalVendorEarning domainObject, 
//            MVEarningEntity entityToMapTo)
//        {
//            entityToMapTo.OrganizationRoleUserId = domainObject.OrganizationRoleUserId;
//            entityToMapTo.MvuserEventTestLockId = domainObject.MedicalVendorUserEventTestLockId;
//            // TODO: hack (mvamountearned should be same as mvuseramountearned).
//            entityToMapTo.MvamountEarned = domainObject.MedicalVendorUserAmountEarned;
//            entityToMapTo.MvuserAmountEarned = domainObject.MedicalVendorUserAmountEarned;
//            entityToMapTo.DataRecoderCreatorId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
//            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
//        }
//    }
//}