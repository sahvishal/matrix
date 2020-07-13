using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianQueueViewModel : ViewModelBase
    {

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        public string Vehicle { get; set; }

        [DisplayName("Screening Package + Test(s)")]
        public string Package { get; set; }

        [DisplayName("Last Updated On")]
        [Format("MM/dd/yyyy")]
        [Hidden]
        public DateTime PreAuditDate { get; set; }

        [DisplayName("Time in Queue")]
        public string TimeInQueue
        {
            get
            {
                var timeGap = DateTime.Now - PreAuditDate;
                if (timeGap.Days > 0)
                {
                    return timeGap.Days + " days  " + (timeGap.Hours > 0 ? timeGap.Hours + " hrs " : "");
                }

                return (timeGap.Hours > 0 ? timeGap.Hours + " hrs  " : "") +
                       (timeGap.Minutes > 0 ? timeGap.Minutes + " mins " : "");

            }
        }

        [DisplayName("Sent Back for Correction")]
        public bool SentBackforCorrection { get; set; }

        [DisplayName("Is Critical")]
        public bool IsCritical { get; set; }

        [DisplayName("Assigned Physician")]
        public string PhysicianName { get; set; }

        [Hidden]
        public long EventCustomerId { get; set; }

        [Hidden]
        public long? InQueuePriority { get; set; }

    }
}