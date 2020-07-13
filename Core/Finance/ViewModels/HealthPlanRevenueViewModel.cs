using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class HealthPlanRevenueViewModel : ViewModelBase
    {
        [Hidden]
        public long HealthPlanId { get; set; }

        [DisplayName("Health Plan")]
        public string HealthPlanName { get; set; }

        [DisplayName("Total Customer")]
        public long TotalCustomer { get; set; }

        [DisplayName("Revenue")]
        public decimal Revenue { get; set; }

        public bool ShowDetails { get; set; }
    }
}