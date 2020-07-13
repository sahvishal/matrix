using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.PrintOrder
{
    public class PrintOrderItemTrackingMapper : DomainEntityMapper<PrintOrderItemTracking, PrintOrderItemTrackingEntity>
    {
        private readonly IDataRecorderMetaDataFactory _factory;

        public PrintOrderItemTrackingMapper()
            : this(new DataRecorderMetaDataFactory())
        { }

        private PrintOrderItemTrackingMapper(IDataRecorderMetaDataFactory factory)
        {
            _factory = factory;
        }

        protected override void MapDomainFields(PrintOrderItemTrackingEntity entity, PrintOrderItemTracking domainObjectToMapTo)
        {
            domainObjectToMapTo.PrintOrderItemShippingId = entity.PrintOrderItemShippingId;
            domainObjectToMapTo.PrintOrderItemId = entity.PrintOrderItemId;
            domainObjectToMapTo.TrackingNumber = entity.TrackingNumber;
            domainObjectToMapTo.ScheduledDeliveryDate = entity.ScheduledDeliveryDate;
            
            domainObjectToMapTo.ShippedToAddress1 = entity.Address1;
            domainObjectToMapTo.ShippedToAddress2 = entity.Address2;
            domainObjectToMapTo.ShippedToCity = entity.City;
            domainObjectToMapTo.ShippedToState = entity.State;
            domainObjectToMapTo.ShippedToZip = entity.Zip;
            domainObjectToMapTo.ShipToName = entity.ShipToName;
            domainObjectToMapTo.ShipToAttentionOf = entity.ShipToAttentionOf;
            domainObjectToMapTo.ShippingService = entity.ShippingService;
           //// domainObjectToMapTo.ShippingStatus =(ItemStatus) entity.ShippingStatus;
            /////domainObjectToMapTo.ConfirmationState = entity.ConfirmationState;
            domainObjectToMapTo.ConfirmationMode =entity.ConfirmationMode!=null ?(ItemConfirmationMode) entity.ConfirmationMode:(ItemConfirmationMode?) null;
            domainObjectToMapTo.PackageReference1 = entity.PackageReference1;
            domainObjectToMapTo.PackageReference2 = entity.PackageReference2;
            domainObjectToMapTo.PackageReference3 = entity.PackageReference3;
           
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DateUpdated =  entity.DateUpdated;
            domainObjectToMapTo.CreatedByOrgRoleUser = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId);
            domainObjectToMapTo.ActualDeliveryDate = entity.ActualDeliveryDate;
            domainObjectToMapTo.ConfirmedBy = entity.ConfirmedBy;
           //// domainObjectToMapTo.UpdatedByOrgRoleUser = new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId!=null?entity.UpdatedByOrgRoleUserId:null);
           
        }

        protected override void MapEntityFields(PrintOrderItemTracking domainObject, PrintOrderItemTrackingEntity entityToMapTo)
        {
            entityToMapTo.PrintOrderItemShippingId = domainObject.PrintOrderItemShippingId;
            entityToMapTo.PrintOrderItemId = domainObject.PrintOrderItemId;
            entityToMapTo.TrackingNumber = domainObject.TrackingNumber;
            entityToMapTo.ScheduledDeliveryDate = domainObject.ScheduledDeliveryDate;
            
            entityToMapTo.Address1 = domainObject.ShippedToAddress1;
            entityToMapTo.Address2 = domainObject.ShippedToAddress2;
            entityToMapTo.City = domainObject.ShippedToCity;
            entityToMapTo.State = domainObject.ShippedToState;
            entityToMapTo.Zip = domainObject.ShippedToZip;
            entityToMapTo.ShipToName = domainObject.ShipToName;
            entityToMapTo.ShipToAttentionOf = domainObject.ShipToAttentionOf;
            entityToMapTo.ShippingService = domainObject.ShippingService;
            ////entityToMapTo.ShippingStatus = (long)domainObject.ShippingStatus;
            /////entityToMapTo.ConfirmationState = domainObject.ConfirmationState;
            entityToMapTo.ConfirmationMode =domainObject.ConfirmationMode!=null? (long) domainObject.ConfirmationMode:(long?) null;
            entityToMapTo.PackageReference1 = domainObject.PackageReference1;
            entityToMapTo.PackageReference2 = domainObject.PackageReference2;
            entityToMapTo.PackageReference3 = domainObject.PackageReference3;
            entityToMapTo.DateCreated = domainObject.DateCreated;
            entityToMapTo.DateUpdated = domainObject.DateUpdated;
            entityToMapTo.CreatedByOrgRoleUserId = domainObject.CreatedByOrgRoleUser.Id;
            entityToMapTo.UpdatedByOrgRoleUserId = domainObject.UpdatedByOrgRoleUser.Id;
            entityToMapTo.ActualDeliveryDate = domainObject.ActualDeliveryDate;
            entityToMapTo.ConfirmedBy = domainObject.ConfirmedBy;
          
            entityToMapTo.IsNew = domainObject.PrintOrderItemShippingId == 0;
        }
    }
}