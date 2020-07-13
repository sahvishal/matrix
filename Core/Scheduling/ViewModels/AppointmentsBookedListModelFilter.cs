using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentsBookedListModelFilter : ModelFilterBase
    {
        // For the registeration date range
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsHealthPlanEvent { get; set; }

        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }

        // For the event date range
        public DateTime? EventFrom { get; set; }
        public DateTime? EventTo { get; set; }

        public long EventId { get; set; }

        public IEnumerable<string> Zipcodes { get; set; }

        public bool CancelledCustomer { get; set; }

        public long StateId { get; set; }

        public long AccountId { get; set; }

        public string Tag { get; set; }

        public string[] CustomTags { get; set; }

        public int EventStatus { get; set; }

        public bool ExcludeCustomerWithCustomTag { get; set; }

        public bool ShowCustomersWithAppointment { get; set; }

        public long ProductTypeId { get; set; }

        public string GroupName { get; set; }

        public override string ToString()
        {
            var filterApplied = "";
            if (FromDate.HasValue)
                filterApplied += "Registration From Date:" + FromDate.Value.ToShortDateString() + ",  ";

            if (ToDate.HasValue)
                filterApplied += "Registration To Date:" + ToDate.Value.ToShortDateString() + ",  ";

            if (IsRetailEvent || IsCorporateEvent || IsHealthPlanEvent || IsPublicEvent || IsPrivateEvent)
            {
                var eventType = "Event Type:";
                if (IsRetailEvent)
                    eventType += "Retial,";

                if (IsCorporateEvent)
                    eventType += "Corporate,";

                if (IsHealthPlanEvent)
                    eventType += "HealthPlan,";

                if (IsPublicEvent)
                    eventType += "Public,";

                if (IsPrivateEvent)
                    eventType += "Private,";

                eventType = eventType.Substring(0, eventType.Length - 1);

                filterApplied += eventType + ",  ";
            }
            if (EventFrom.HasValue)
                filterApplied += "Event From Date:" + EventFrom.Value.ToShortDateString() + ",  ";

            if (EventTo.HasValue)
                filterApplied += "Event To Date:" + EventTo.Value.ToShortDateString() + ",  ";

            if (EventId > 0)
                filterApplied += "Event Id:" + EventId + ",  ";

            if (CancelledCustomer)
                filterApplied += "Cancelled Customers:Yes,  ";

            if (string.IsNullOrWhiteSpace(filterApplied))
                filterApplied = filterApplied.Substring(0, filterApplied.Length - 3);



            return filterApplied;
        }
    }
}