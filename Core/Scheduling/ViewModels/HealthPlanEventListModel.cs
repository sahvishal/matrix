using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class HealthPlanEventListModel : ListModelBase<HealthPlanEventViewModel, EventBasicInfoViewModelFilter>
    {
        public override IEnumerable<HealthPlanEventViewModel> Collection { get; set; }
        public override EventBasicInfoViewModelFilter Filter { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public int Date { get; set; }
        public string DefaultCalendarView { get; set; }

        public HealthPlanEventListModel()
        {
            DefaultCalendarView = "month";
            Month = DateTime.Today.Month;
            Year = DateTime.Today.Year;
            Date = DateTime.Today.Day;
        }
    }
}
