using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class MyBioCheckCustomerModelFilter : ModelFilterBase
    {
        [Display(Name = "Event Id")]
        public long EventId { get; set; }
    }
}