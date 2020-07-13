using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class CustomerConsentDataListModelFilter
    {
        public long AccountId { get; set; }
        public string Tag { get; set; }
        public DateTime? FromDate { get; set; }
    }
}