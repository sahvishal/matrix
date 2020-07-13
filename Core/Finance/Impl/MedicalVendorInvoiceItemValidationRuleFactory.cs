using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class MedicalVendorInvoiceItemValidationRuleFactory : IValidationRuleFactory<MedicalVendorInvoiceItem>
    {
        public List<IValidationRule<MedicalVendorInvoiceItem>> CreateValidationRules()
        {
            return new List<IValidationRule<MedicalVendorInvoiceItem>>
            {
                new NumberMustBeInRangeRule<MedicalVendorInvoiceItem, long>(m => m.MedicalVendorInvoiceId, 
                    "Medical Vendor Invoice Id", 1, long.MaxValue),
                new NumberMustBeInRangeRule<MedicalVendorInvoiceItem, long>(m => m.CustomerId, "Customer Id",
                    1, long.MaxValue),
                new NumberMustBeInRangeRule<MedicalVendorInvoiceItem, long>(m => m.EventId, "Event Id",
                    1, long.MaxValue),
                new NumberMustBeInRangeRule<MedicalVendorInvoiceItem, decimal>(m => m.MedicalVendorAmountEarned, 
                    "Medical Vendor Amount Earned", 0m, 100m),
                new NumberMustBeInRangeRule<MedicalVendorInvoiceItem, decimal>(m => m.OrganizationRoleUserAmountEarned, 
                    "Organization Role User Amount Earned", 0m, 100m),
                new StringCannotBeNullOrEmptyRule<MedicalVendorInvoiceItem>(m => m.CustomerName, "Customer Name"),
                new StringCannotBeNullOrEmptyRule<MedicalVendorInvoiceItem>(m => m.EventName, "Event Name"),
                new StringCannotBeNullOrEmptyRule<MedicalVendorInvoiceItem>(m => m.PodName, "Pod Name"),
                new StringCannotBeNullOrEmptyRule<MedicalVendorInvoiceItem>(m => m.PackageName, "Package Name"),
                new DateMustBeInRangeRule<MedicalVendorInvoiceItem>(m => m.EventDate, "Event Date"),
                new DateMustBeInRangeRule<MedicalVendorInvoiceItem>(m => m.ReviewDate, "Review Date"),
                new DateCannotExceedOtherDateRule<MedicalVendorInvoiceItem>(m => m.EventDate, "Event Date",
                    m => m.ReviewDate, "Review Date"),
                new DateMustBeInRangeRule<MedicalVendorInvoiceItem>(m => m.EvaluationStartTime, "Evaluation Start Time"),
                new DateMustBeInRangeRule<MedicalVendorInvoiceItem>(m => m.EvaluationEndTime, "Evaluation End Time"),
                new DateCannotExceedOtherDateRule<MedicalVendorInvoiceItem>(m => m.EvaluationStartTime, "Evaluation Start Time",
                    m => m.EvaluationEndTime, "Evaluation End Time"),
            };
        }
    }
}