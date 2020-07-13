
using HealthYes.Data.EntityClasses;
using HealthYes.Web.Core.Domain;
using HealthYes.Web.Core.Domain.PrintOrder;
using HealthYes.Web.Core.Impl;
using HealthYes.Web.Core.Interfaces;
using HealthYes.Web.Core.Domain.PrintOrder.Enum;
namespace HealthYes.Web.Infrastructure.Mappers.PrintOrder
{
    public class PrintOrderItemShippingStatusMapper : DomainEntityMapper<PrintOrderItemShippingStatus, PrintOrderItemShippingStatusEntity>
    {
        private readonly IDataRecorderMetaDataFactory _factory;

        public PrintOrderItemShippingStatusMapper()
            : this(new DataRecorderMetaDataFactory())
        { }

        private PrintOrderItemShippingStatusMapper(IDataRecorderMetaDataFactory factory)
        {
            _factory = factory;
        }

        protected override void MapDomainFields(PrintOrderItemShippingStatusEntity entity, PrintOrderItemShippingStatus domainObjectToMapTo)
        {
            domainObjectToMapTo.ConfirmationMode = (ItemConfirmationMode)entity.ConfirmationMode;
            domainObjectToMapTo.CreatedDate = entity.DateCreated; 
            domainObjectToMapTo.Notes = entity.Notes;
            domainObjectToMapTo.PrintOrderItemId = entity.PrintOrderItemId;
            domainObjectToMapTo.Status =(ItemShippingStatus) entity.Status;
            domainObjectToMapTo.PaymentRecordedBy = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId);
                                  
         
        }

        protected override void MapEntityFields(PrintOrderItemShippingStatus domainObject, PrintOrderItemShippingStatusEntity entityToMapTo)
        {
         
            entityToMapTo.ConfirmationMode = domainObject.ConfirmationMode !=null? (long) domainObject.ConfirmationMode:(long?) null;
            entityToMapTo.DateCreated = domainObject.CreatedDate;
            entityToMapTo.Notes = domainObject.Notes;
            entityToMapTo.PrintOrderItemId = domainObject.PrintOrderItemId;
            entityToMapTo.Status = (long)domainObject.Status;
            entityToMapTo.CreatedByOrgRoleUserId = domainObject.PaymentRecordedBy.Id;
           
        }
    }
}