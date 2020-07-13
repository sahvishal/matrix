using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class MedicalVendorInvoiceBaseValidationRuleFactory : IValidationRuleFactory<PhysicianInvoiceBase>
    {
        public List<IValidationRule<PhysicianInvoiceBase>> CreateValidationRules()
        {
            return new List<IValidationRule<PhysicianInvoiceBase>>
            {
                new NumberMustBeInRangeRule<PhysicianInvoiceBase, long>(m => m.MedicalVendorId, "Medical Vendor Id",
                    1, long.MaxValue),
                new NumberMustBeInRangeRule<PhysicianInvoiceBase, long>(m => m.PhysicianId, 
                    "Organization Role User Id", 1, long.MaxValue),
                new DateMustBeInRangeRule<PhysicianInvoiceBase>(m => m.PayPeriodStartDate, "Pay Period Start Date"),
                new DateMustBeInRangeRule<PhysicianInvoiceBase>(m => m.PayPeriodEndDate, "Pay Period End Date"),
                new DateCannotExceedOtherDateRule<PhysicianInvoiceBase>(m => m.PayPeriodStartDate, "Pay Period Start Date",
                    m => m.PayPeriodEndDate, "Pay Period End Date"),
                new DateMustBeInRangeRule<PhysicianInvoiceBase>(m => m.DateApproved, "Date Approved"),
                new DateMustBeInRangeRule<PhysicianInvoiceBase>(m => m.DatePaid, "Date Paid"),
                new DateCannotExceedOtherDateRule<PhysicianInvoiceBase>(m => m.DateApproved, "Date Approved",
                    m => m.DatePaid, "Date Paid"),
                new DateMustBeInRangeRule<PhysicianInvoiceBase>(m => m.DateGenerated, "Date Generated"),
                new ObjectMustBeEnumMemberRule<PhysicianInvoiceBase>(m => m.PaymentStatus),
                new ObjectMustBeEnumMemberRule<PhysicianInvoiceBase>(m => m.ApprovalStatus),
                new StringCannotBeNullOrEmptyRule<PhysicianInvoiceBase>(m => m.MedicalVendorName, "Medical Vendor Name"),
                new StringCannotBeNullOrEmptyRule<PhysicianInvoiceBase>(m => m.MedicalVendorAddress, "Medical Vendor Address"),
                new StringCannotBeNullOrEmptyRule<PhysicianInvoiceBase>(m => m.PhysicianName, "Physician Name"),
                new GuidMustBeValidRule<PhysicianInvoiceBase>(m => m.ApprovalGuid, "Approval Guid")
            };
        }
    }
}