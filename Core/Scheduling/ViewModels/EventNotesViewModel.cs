using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventNotesViewModel : ViewModelBase
    {
        public long Id { get; set; }

        public string Note { get; set; }

        public string SelectedEventIds { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public long? HealthPlanId { get; set; }
        public DateTime? EventDateFrom { get; set; }
        public DateTime? EventDateTo { get; set; }
        public long? PodId { get; set; }

        public bool IsPublished { get; set; }
    }
}
