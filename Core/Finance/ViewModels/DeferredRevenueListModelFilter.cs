using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DeferredRevenueListModelFilter:ModelFilterBase
    {
        public DateTime? FromEventDate { get; set; }
        public DateTime? ToEventDate { get; set; }
        
        public long EventId { get; set; }
        public string Pod { get; set; }

        public DateTime? FromRegistrationDate { get; set; }
        public DateTime? ToRegistrationDate { get; set; }

        public bool PaidCustomers { get; set; }
        public bool UnPaidCustomers { get; set; }

        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }

        public DeferredRevenueListModelFilter()
        {
            PaidCustomers = true;
        }
    }
}
