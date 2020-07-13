using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerEventListModelFilter : ModelFilterBase
    {
        public long EventId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public long HospitalPartnerId { get; set; }

        public int ResultInterpretation { get; set; }

        public int Status { get; set; }

        public bool CriticalMarkedByTechnician { get; set; }

        public long HospitalFacilityId { get; set; }
    }
}
