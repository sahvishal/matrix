using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class OutboundCallQueueListModel
    {
        public IEnumerable<OutboundCallQueueViewModel> OutboundCallQueues { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public bool IsQueueGenerated { get; set; }
        public long CriteriaId { get; set; }
        public bool IsQueueChanged { get; set; }
    }
}
