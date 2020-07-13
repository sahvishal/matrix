using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class MedicalVendorInvoiceBaseFactory : IMedicalVendorInvoiceBaseFactory
    {
        public void SetMedicalVendorInvoiceBaseFields(PhysicianInvoiceBase baseObjectToSet, PhysicianInvoiceEntity physicianInvoiceEntity)
        {
            if (baseObjectToSet == null)
            {
                throw new ArgumentNullException("baseObjectToSet");
            }
            if (physicianInvoiceEntity == null)
            {
                throw new ArgumentNullException("physicianInvoiceEntity");
            }
            baseObjectToSet.ApprovalGuid = physicianInvoiceEntity.ApprovalGuid;
            baseObjectToSet.ApprovalStatus = (ApprovalStatus)physicianInvoiceEntity.ApprovalStatus;
            baseObjectToSet.PhysicianName = physicianInvoiceEntity.PhysicianName;
            baseObjectToSet.PhysicianId = physicianInvoiceEntity.PhysicianId;
            baseObjectToSet.DateApproved = physicianInvoiceEntity.DateApproved;
            baseObjectToSet.DateGenerated = physicianInvoiceEntity.DateGenerated;
            baseObjectToSet.MedicalVendorAddress = physicianInvoiceEntity.MedicalVendorAddress;
            if (physicianInvoiceEntity.PhysicianProfile != null)
                baseObjectToSet.MedicalVendorId = physicianInvoiceEntity.PhysicianProfile.PhysicianId;
            baseObjectToSet.MedicalVendorName = physicianInvoiceEntity.MedicalVendorName;
            baseObjectToSet.PaymentStatus = (PaymentStatus)physicianInvoiceEntity.PaymentStatus;
            baseObjectToSet.PayPeriodStartDate = physicianInvoiceEntity.PayPeriodStartDate;
            baseObjectToSet.PayPeriodEndDate = physicianInvoiceEntity.PayPeriodEndDate;
            baseObjectToSet.DatePaid = physicianInvoiceEntity.DatePaid;
        }
    }
}