using System;
using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorInvoiceRepository
    {
        List<PhysicianInvoice> GetInvoicesByPaymentStatus(PaymentStatus paymentStatus);
        List<PhysicianInvoice> GetInvoicesForDateRange(DateTime startDate, DateTime endDate);

        PhysicianInvoice GetMedicalVendorInvoice(long medicalVendorInvoiceId);
        PhysicianInvoice GetMedicalVendorInvoice(Guid approvalGuid);
        PhysicianInvoice GetOldestUnapprovedInvoiceForMedicalVendorUser(long medicalVendorMedicalVenderUserId);

        List<OrderedPair<DateTime, DateTime>> GetMedicalVendorInvoicePayPeriods(long organizationRoleUserId,
            PaymentStatus paymentStatus);

        void SaveMedicalVendorInvoice(PhysicianInvoice medicalVendorInvoice);
        void SaveMedicalVendorInvoices(List<PhysicianInvoice> medicalVendorInvoices);

        void ChangeMedicalVendorInvoiceApprovalStatus(long invoiceId, ApprovalStatus approvalStatus);
        void ChangeMedicalVendorInvoicePaymentStatus(long invoiceId, PaymentStatus paymentStatus, DateTime datePaid);

        bool HasInvoicePendingApproval(long medicalVendorMedicalVendorUserId);
    }
}