using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerDashboardCustomerViewData
    {
        public long CustomerId { get; set; }

        public Name CustomerName { get; set; }

        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public bool CriticalMarkedByPhysician { get; set; }

        public string ResultSummary { get; set; }
    }
}
