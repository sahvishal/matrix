using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    [NoValidationRequired]
    public class CorporateAccountCustomerListModelFilter : ModelFilterBase
    {
        public long EventId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        public DateTime? DateOfBirthFrom { get; set; }
        public DateTime? DateOfBirthTo { get; set; }

        [DisplayName("Customer ID")]
        public long CustomerId { get; set; }

        [DisplayName("Member ID")]
        public string MemberId { get; set; }

        public string HICN { get; set; }
    }
}
