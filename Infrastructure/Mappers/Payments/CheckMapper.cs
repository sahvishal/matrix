using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Payments
{
    public class CheckMapper : DomainEntityMapper<Check, CheckEntity>
    {
        private readonly IDataRecorderMetaDataFactory _metaDataFactory;

        public CheckMapper()
            : this(new DataRecorderMetaDataFactory())
        {}

        public CheckMapper(IDataRecorderMetaDataFactory metaDataFactory)
        {
            _metaDataFactory = metaDataFactory;
        }

        protected override void MapDomainFields(CheckEntity entity, Check domainObjectToMapTo)
        {
            DataRecorderMetaData metaData = _metaDataFactory.CreateDataRecorderMetaData
                 (entity.DataRecoderCreatorId, entity.DateCreated);
                 
            domainObjectToMapTo.Id = entity.CheckId;
            domainObjectToMapTo.AccountNumber = entity.AccountNumber;
            domainObjectToMapTo.Amount = entity.Amount;
            domainObjectToMapTo.BankName = entity.BankName;
            domainObjectToMapTo.CheckDate = entity.CheckDate;
            domainObjectToMapTo.CheckNumber = entity.CheckNumber;
            domainObjectToMapTo.Memo = entity.Memo;
            domainObjectToMapTo.PayableTo = entity.PayableTo;
            domainObjectToMapTo.RoutingNumber = entity.RoutingNumber;
            domainObjectToMapTo.DataRecorderMetaData = metaData;
            domainObjectToMapTo.AcountHolderName = entity.AccountHolderName;
            domainObjectToMapTo.IsElectronicCheck = entity.IsElectronic;
        }

        protected override void MapEntityFields(Check domainObject, CheckEntity entityToMapTo)
        {
            entityToMapTo.CheckId = domainObject.Id;
            entityToMapTo.AccountNumber = domainObject.AccountNumber;
            entityToMapTo.Amount = domainObject.Amount;
            entityToMapTo.BankName = domainObject.BankName;
            entityToMapTo.CheckDate = domainObject.CheckDate;
            entityToMapTo.CheckNumber = domainObject.CheckNumber;
            entityToMapTo.Memo = domainObject.Memo;
            entityToMapTo.PayableTo = domainObject.PayableTo;
            entityToMapTo.RoutingNumber = domainObject.RoutingNumber;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified;
            entityToMapTo.DataRecoderCreatorId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            entityToMapTo.AccountHolderName = domainObject.AcountHolderName;
            entityToMapTo.IsElectronic = domainObject.IsElectronicCheck;
        }
    }
}