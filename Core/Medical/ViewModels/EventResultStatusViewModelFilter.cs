using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventResultStatusViewModelFilter : ModelFilterBase
    {
        public long EventId { get; set; }
        public DateTime? EventDateFrom { get; set; }
        public DateTime? EventDateTo { get; set; }
        public int Status { get; set; }
        public long PodId { get; set; }
    }
}
