using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IMedicalVendorInvoiceFactory
    {
        PhysicianInvoice CreateMedicalVendorInvoice(PhysicianInvoiceEntity medicalVendorInvoiceEntity,
            EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities);
        PhysicianInvoice CreateMedicalVendorInvoice(PhysicianInvoiceEntity medicalVendorInvoiceEntity, 
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems);
        PhysicianInvoice CreateNewMedicalVendorInvoice(MedicalVendor medicalVendor, 
            Physician physician, List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems,
            DateTime payPeriodStartDate, DateTime payPeriodEndDate);

        List<PhysicianInvoice> CreateMedicalVendorInvoices(EntityCollection<PhysicianInvoiceEntity> medicalVendorInvoiceEntities,
            EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities);

        PhysicianInvoiceEntity CreateMedicalVendorInvoiceEntity(PhysicianInvoice medicalVendorInvoice);
    }
}
