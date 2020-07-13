using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain.ViewData;

namespace Falcon.App.Core.Operations
{
    public interface IPodPerformanceController
    {
        List<MedicalVendorPaymentPodViewData> GetPodViewDataForInvoice(long medicalVendorInvoiceId);
        List<MedicalVendorPaymentPodViewData> GetPodViewDataForDateRange(DateTime startDate, DateTime endDate);
    }
}