using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Impl;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class EventCustomerListFilter : EventCustomerListModelFilter
    {
        public long EventId { get; set; }
    }
}