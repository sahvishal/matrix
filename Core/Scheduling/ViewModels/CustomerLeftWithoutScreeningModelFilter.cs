using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CustomerLeftWithoutScreeningModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }
        public long AccountId { get; set; }
    }
}
