using System;
using System.ComponentModel;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventCustomerResultStatusListModelFilter
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }
        [DisplayName("Host")]
        public string Host { get; set; }
        [DisplayName("Event Date")]
        public DateTime? EventDate { get; set; }

        [DisplayName("Customer Id")]
        public long? CustomerId { get; set; }

        public override string ToString()
        {
            string filter = "";
            
            if (EventId > 0) filter += " -- EventId = " + EventId + " -- ";
            if (!string.IsNullOrEmpty(Host)) filter += "-- Host = " + Host + " -- ";
            if (EventDate.HasValue) filter += "-- EventDate = " + EventDate.Value.ToShortDateString() + " -- ";

            return filter;
        }
    }
}