using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.Impl
{
    [NoValidationRequired]
    public class EventCustomerListModelFilter
    {
        public int AppointmentSlotViewOption { get; set; }
        public int CustomerListFilterOption { get; set; }

        public EventCustomerListModelFilter()
        {
            CustomerListFilterOption = (int)EventCustomerListFilterOption.All;
            AppointmentSlotViewOption = (int)EventSlotListViewOption.Booked;
        }
    }
}