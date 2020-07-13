using System;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallCenterRepMetricDetailViewData
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }

        public string Customer { get; set; }
        public long CustomerId { get; set; }
        public Address CustomerAddress { get; set; }

        public DateTime EventSignUp { get; set; }

        public string Package { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool IsPrePaid { get; set; }

        public string AttendedState { get; set; }
        public string CallCenterRep { get; set; }

    }
}
