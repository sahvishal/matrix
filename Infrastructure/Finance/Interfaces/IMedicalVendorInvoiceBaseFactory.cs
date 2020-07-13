using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IMedicalVendorInvoiceBaseFactory
    {
        void SetMedicalVendorInvoiceBaseFields(PhysicianInvoiceBase baseObjectToSet, PhysicianInvoiceEntity medicalVendorInvoiceEntity);
    }
}