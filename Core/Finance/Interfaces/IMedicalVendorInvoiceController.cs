using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorInvoiceController
    {
        PhysicianInvoice GetMedicalVendorInvoice(long medicalVendorInvoiceId);
        MedicalVendorInvoiceStatistic GetMedicalVendorInvoiceStatistic(long medicalVendorInvoiceId);
        List<ComboBoxPair> GetAllComboBoxInvoiceStatistics();
    }
}