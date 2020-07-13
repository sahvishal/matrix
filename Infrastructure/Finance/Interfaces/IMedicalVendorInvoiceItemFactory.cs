using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IMedicalVendorInvoiceItemFactory
    {
        MedicalVendorInvoiceItem CreateMedicalVendorInvoiceItem(MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow);
        MedicalVendorInvoiceItem CreateMedicalVendorInvoiceItem(PhysicianInvoiceItemEntity medicalVendorInvoiceItemEntity);
        List<MedicalVendorInvoiceItem> CreateMedicalVendorInvoiceItems(IEnumerable<MedicalVendorInvoiceItemRow> medicalVendorInvoiceItemRows);
        List<MedicalVendorInvoiceItem> CreateMedicalVendorInvoiceItems(EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities);

        PhysicianInvoiceItemEntity CreateMedicalVendorInvoiceItemEntity(long medicalVendorInvoiceId,
            MedicalVendorInvoiceItem medicalVendorInvoiceItem);
        EntityCollection<PhysicianInvoiceItemEntity> CreateMedicalVendorInvoiceItemEntities(long medicalVendorInvoiceId,
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems);
    }
}