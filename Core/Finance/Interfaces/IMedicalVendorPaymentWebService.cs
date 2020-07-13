using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorPaymentWebService
    {
        bool HasInvoicesPendingForApproval(long medicalVendorMedicalVendorUserId);
        string GenerateAndPersistInvoicesForMedicalVendor
            (long medicalVendorId, DateTime payPeriodStartDate, DateTime payPeriodEndDate);
        PhysicianInvoice GetInvoice(long invoiceId);
        PhysicianInvoice GetOldestUnapprovedInvoiceForMedicalVendorUser(long medicalVendorMedicalVenderUserId);
        bool ChangeInvoiceApprovalStatus(long invoiceId, int approvalStatus);
        List<PaymentInstrument> GetPaymentInstruments(long medicalVendorInvoiceId);
    }
}