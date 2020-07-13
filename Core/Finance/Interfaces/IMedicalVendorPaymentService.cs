using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorPaymentService
    {
        List<PhysicianInvoice> GenerateInvoicesForMedicalVendor(long medicalVendorId, DateTime payPeriodStartDate,
            DateTime payPeriodEndDate);
        PhysicianInvoice GenerateInvoice(long medicalVendorId, long medicalVendorMedicalVendorUserId, DateTime payPeriodStartDate, 
            DateTime payPeriodEndDate);
    }
}