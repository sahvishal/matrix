using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Models
{
    public class EventFilter : EventBasicInfoViewModelFilter
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool ShowUpcoming { get; set; }
    }
}