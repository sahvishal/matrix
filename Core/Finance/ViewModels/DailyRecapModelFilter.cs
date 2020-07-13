using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DailyRecapModelFilter : ModelFilterBase
    {
        public DateTime? EventDateFrom { get; set; }
        public DateTime? EventDateTo { get; set; }
        public string Pod { get; set; }
        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }
        public bool IsHealthPlan { get; set; }
    }
}
