using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventHostListModel
    {
        public IEnumerable<EventHostViewData> Events { get; set; }

        public EventSearchFilterCallQueueCustomer Filter { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}