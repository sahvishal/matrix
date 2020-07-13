using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CorporateAccountDashboardCriticalResults
    {
        public long CustomerId { get; set; }

        public Name CustomerName { get; set; }

        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public bool CriticalMarkedByPhysician { get; set; }

        public string ResultSummary { get; set; }
    }
}
