using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorInvoiceItemRepository
    {
        List<MedicalVendorInvoiceItem> GetMedicalVendorInvoiceItems(long medicalVendorMedicalVendorUserId, 
            DateTime startDate, DateTime endDate);      
    }
}