using System;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class KynCustomerModelFilter : ModelFilterBase
    {
        [Display(Name = "Event Id")]
        public long EventId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [Display(Name = "Show Only KYN")]
        public bool ShowOnlyKyn { get; set; }

        public DateTime? RegistrationFromDate { get; set; }
        public DateTime? RegistrationToDate { get; set; }

        public string Tag { get; set; }
        public string[] CustomTags { get; set; }

        public string SponseredBy { get; set; }
        public KynCustomerModelFilter()
        {
            ShowOnlyKyn = true;
        }
    }
}
