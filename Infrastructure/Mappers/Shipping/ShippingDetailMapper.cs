using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Geo;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Shipping
{
    public class ShippingDetailMapper : DomainEntityMapper<ShippingDetail, ShippingDetailEntity>
    {
        private readonly IMapper<ShippingOption, ShippingOptionEntity> _shippingOptionMapper;
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;
        private readonly IAddressFactory _addressFactory;

        public ShippingDetailMapper()
            : this(new ShippingOptionMapper(), new DataRecorderMetaDataFactory(), new AddressFactory())
        { }

        public ShippingDetailMapper(IMapper<ShippingOption, ShippingOptionEntity> shippingOptionMapper,
            IDataRecorderMetaDataFactory dataRecorderMetaDataFactory, IAddressFactory addressFactory)
        {
            _shippingOptionMapper = shippingOptionMapper;
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
            _addressFactory = addressFactory;
        }

        protected override void MapDomainFields(ShippingDetailEntity entity,
            ShippingDetail domainObjectToMapTo)
        {
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                    CreateDataRecorderMetaData(entity.OrganizationRoleUserCreatorId, entity.DateCreated, entity.ModifiedBy, entity.DateModified);

            domainObjectToMapTo.Id = entity.ShippingDetailId;

            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;

            domainObjectToMapTo.ShipmentDate = entity.ShipmentDate;


            domainObjectToMapTo.ShippingOption = entity.ShippingOption != null
                                                     ? _shippingOptionMapper.Map(entity.ShippingOption)
                                                     : new ShippingOption(entity.ShippingOptionId);

            domainObjectToMapTo.ShippingAddress = entity.Address != null
                ? _addressFactory.CreateAddressDomain(entity.Address) : new Address(entity.ShippingAddressId);
            domainObjectToMapTo.Status = (ShipmentStatus)entity.Status;

            domainObjectToMapTo.ActualPrice = entity.ActualPrice;
            domainObjectToMapTo.IsExclusivelyRequested = entity.IsExclusivelyRequested;
            domainObjectToMapTo.ShippedByOrgRoleUserId = entity.ShippedByOrgRoleUserId;
        }

        protected override void MapEntityFields(ShippingDetail domainObject, ShippingDetailEntity entityToMapTo)
        {
            entityToMapTo.ShippingDetailId = domainObject.Id;
            entityToMapTo.ShipmentDate = domainObject.Status == ShipmentStatus.Shipped ? DateTime.Now : domainObject.Status == ShipmentStatus.Processing ? null : domainObject.ShipmentDate;
            entityToMapTo.Fields["ShipmentDate"].IsChanged = true;

            entityToMapTo.ShippingOptionId = domainObject.ShippingOption.Id;
            entityToMapTo.ShippingAddressId = domainObject.ShippingAddress.Id;
            entityToMapTo.Status = (short)domainObject.Status;

            entityToMapTo.ActualPrice = domainObject.ActualPrice;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.OrganizationRoleUserCreatorId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            entityToMapTo.IsExclusivelyRequested = domainObject.IsExclusivelyRequested;

            entityToMapTo.ShippedByOrgRoleUserId = domainObject.ShippedByOrgRoleUserId;
            if (domainObject.DataRecorderMetaData.DataRecorderModifier != null)
                entityToMapTo.ModifiedBy = domainObject.DataRecorderMetaData.DataRecorderModifier.Id;
            entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified;
        }
    }
}