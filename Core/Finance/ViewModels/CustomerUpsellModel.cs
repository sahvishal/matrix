using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CustomerUpsellModel : ViewModelBase
    {
        public string Pod { get; set; }
        //[DisplayName("Hub")]
        //public string Territory { get; set; }

        [Format("MM/dd/yyyy")]
        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }
        
        [Hidden]
        public long CustomerId { get; set; }
        
        [DisplayName("Customer Id")]
        public long CustomerCode { get; set; }

        public Name Name { get; set; }

        [DisplayName("Scheduled Package")]
        public string ScheduledPackage { get; set; }
        [DisplayName("Scheduled Cost")]
        public decimal ScheduledCost { get; set; }
        [DisplayName("Event Package")]
        public string EventPackage { get; set; } // Not be confused with the Packages for an Event, but the actual Package Customer availed on the time of screening.
        [DisplayName("Revised Cost")]
        public decimal RevisedCost { get; set; }
        public decimal Difference
        {
            get
            {
                return RevisedCost - ScheduledCost;
            }
        }

        [DisplayName("Agent")]
        public string ChangingAgent { get; set; }
    }
}
