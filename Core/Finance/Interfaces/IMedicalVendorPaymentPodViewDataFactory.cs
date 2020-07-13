using System.Collections.Generic;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorPaymentPodViewDataFactory
    {
        List<MedicalVendorPaymentPodViewData> CreatePodViewData(List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems);
    }
}