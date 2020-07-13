using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CriteriaInfoViewModel : ViewModelBase
    {
        public string HealthPlan { get; set; }

        public string CallQueue { get; set; }

        public string Category { get; set; }

        public string CriteriaName { get; set; }

        public decimal Percentage { get; set; }

        public int Days { get; set; }

        public int TotalRecords { get; set; }
    }
}
