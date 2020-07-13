using Falcon.App.Core.Application.ViewModels;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class TextReminderViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }
        
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Opted SMS Reminder")]
        public string OptedForSmsStaus { get; set; }

        [DisplayName("Agent Name")]
        public string AgentName { get; set; }
    }
}
