using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    [DefaultImplementation(Interface = typeof(IMapper<Refund, RefundEntity>))]
    public class RefundMapper : DomainEntityMapper<Refund, RefundEntity>
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public RefundMapper()
            : this(new DataRecorderMetaDataFactory())
        { }

        public RefundMapper(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        protected override void MapDomainFields(RefundEntity entity, Refund domainObjectToMapTo)
        {
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(entity.OrganizationRoleUserCreatorId,
                entity.DateCreated);

            domainObjectToMapTo.Id = entity.RefundId;
            domainObjectToMapTo.RefundReason = (RefundReason)entity.ReasonId;
            domainObjectToMapTo.Notes = entity.Notes;
            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;
            domainObjectToMapTo.Price = entity.Amount;
        }

        protected override void MapEntityFields(Refund domainObject, RefundEntity entityToMapTo)
        {
            NullArgumentChecker.CheckIfNull(domainObject.DataRecorderMetaData,
                "refund.DataRecorderMetaData");
            NullArgumentChecker.CheckIfNull(domainObject.DataRecorderMetaData.DataRecorderCreator,
                "refund.DataRecorderMetaData.DataRecorderCreator",
                "The given Refund to convert to an entity requires DataRecorderMetaData with a Creator.");
            entityToMapTo.Amount = domainObject.Price;
            entityToMapTo.RefundId = domainObject.Id;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.ReasonId = (short)domainObject.RefundReason;
            entityToMapTo.Notes = domainObject.Notes;
            entityToMapTo.OrganizationRoleUserCreatorId = domainObject.DataRecorderMetaData.
                DataRecorderCreator.Id;
        }
    }
}