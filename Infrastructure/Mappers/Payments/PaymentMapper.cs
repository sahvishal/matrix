using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Payments
{
    public class PaymentMapper : DomainEntityMapper<Payment, PaymentEntity>
    {
        private readonly IDataRecorderMetaDataFactory _factory;

        public PaymentMapper()
            : this(new DataRecorderMetaDataFactory())
        { }

        private PaymentMapper(IDataRecorderMetaDataFactory factory)
        {
            _factory = factory;
        }

        protected override void MapDomainFields(PaymentEntity entity, Payment domainObjectToMapTo)
        {
            DataRecorderMetaData dataRecorderMetaData = _factory.CreateDataRecorderMetaData
                (entity.OrganizationRoleUserCreatorId, entity.DateCreated);

            domainObjectToMapTo.Id = entity.PaymentId;
            domainObjectToMapTo.Notes = entity.Notes;
            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;
        }

        protected override void MapEntityFields(Payment domainObject, PaymentEntity entityToMapTo)
        {
            long creatorId = 0;
            DateTime dateCreated = DateTime.Now;
            if (domainObject.DataRecorderMetaData != null)
            {
                if (domainObject.DataRecorderMetaData.DataRecorderCreator != null)
                {
                    creatorId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
                }
                dateCreated = domainObject.DataRecorderMetaData.DateCreated;
            }
            entityToMapTo.PaymentId = domainObject.Id;
            entityToMapTo.Notes = domainObject.Notes;
            entityToMapTo.DateCreated = dateCreated;
            entityToMapTo.OrganizationRoleUserCreatorId = creatorId;
        }
    }
}