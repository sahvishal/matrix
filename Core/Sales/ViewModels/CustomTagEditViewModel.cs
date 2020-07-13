using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CustomTagEditViewModel : ViewModelBase
    {
        public long TagId { get; set; }

        public string CustomTag { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public long HealthPlanId { get; set; }
    }
}
