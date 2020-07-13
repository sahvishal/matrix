using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class EventSearchFilterCallQueueCustomer
    {
        public string ZipCode { get; set; }
        public int? Radius { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int PageNumber { get; set; }
        public long HealthPlanId { get; set; }
        public long ToBeFilledEventId { get; set; }
        public CallQueueSortOrderBy SortByOrder { get; set; }
        public SortOrderType SortOrderType { get; set; }
        public int PageSize { get; set; }
        public bool ExcludeCorporateEvents { get; set; }
        public bool ShowFutureEvents { get; set; }
        public bool SearchMammoEvents { get; set; }
        public string CustomerZipCode { get; set; }
        public long AgentOrganizationId { get; set; }

        public bool SearchAllEvents { get; set; }

        //value will be set in Service based on Zip Code Passed from UI
        public long ZipCodeId { get; set; }

        public long CustomerId { get; set; }

    }
}