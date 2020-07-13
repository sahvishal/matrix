using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareEventCustomerModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string EmployeeId { get; set; }
    }
}
