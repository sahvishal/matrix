using System.Collections.Generic;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class HospitalPartnerDashboardViewModel
    {
        public long ScheduleEvents { get; set; }
        public long RegisteredCustomers { get; set; }
        public long ScreenedCustomers { get; set; }

        public long CriticalCustomers { get; set; }
        public long NormalCustomers { get; set; }
        public long AbnormalCustomers { get; set; }
        public long UrgentCustomers { get; set; }

        public IEnumerable<HospitalPartnerEventViewModel> RecentMailedEvents { get; set; }

        public HospitalPartnerEventViewModel RecentContactedEvent { get; set; }

        public IEnumerable<HospitalPartnerDashboardCustomerViewData> Customers { get; set; }
    }
}
