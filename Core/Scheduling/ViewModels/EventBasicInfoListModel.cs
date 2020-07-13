using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventBasicInfoListModel
    {
        public IEnumerable<EventBasicInfoViewModel> Events { get; set; }
        public EventBasicInfoViewModelFilter Filter { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }        
    }
}