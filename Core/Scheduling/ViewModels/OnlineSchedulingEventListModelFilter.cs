using System;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnlineSchedulingEventListModelFilter
    {
        public string InvitationCode { get; set; }
        public string ZipCode { get; set; }
        public int? Radius { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long EventId { get; set; }
        public string CorpCode { get; set; }
        public int CutOffHourstoMarkEventforOnlineSelection { get; set; }

        public SortOrderBy OrderBy { get; set; }
        public SortOrderType OrderType { get; set; }
        public int PageNumber { get; set; }
        public string Guid { get; set; }
        public string CouponCode { get; set; }
    }
}