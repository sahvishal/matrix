using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnlineSchedulingEventListModel
    {
        public IEnumerable<OnlineSchedulingEventViewModel> Events { get; set; }
        public OnlineSchedulingEventListModelFilter Filter { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public int SortOrderBy { get; set; }
        public int SortOrderType { get { return (int)Enum.SortOrderType.Ascending; } }
    }
}