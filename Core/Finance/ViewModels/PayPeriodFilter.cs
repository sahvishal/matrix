using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    [NoValidationRequired]
    public class PayPeriodFilter : ModelFilterBase
    {
       public DateTime? StartDate { get; set; }
       public long NumberOfWeek  { get; set; }
    }
}
