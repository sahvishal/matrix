using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallQueueCustomerCallDetailsEditModel
    {
        public long CallQueueCustomerId { get; set; }
        public string Disposition { get; set; }
        public long CallStatusId { get; set; }
        public DateTime? CallbackDate { get; set; }
        public bool IsCallSkipped { get; set; }
        public long CallQueueId { get; set; }
        public long ModifiedByOrgRoleUserId { get; set; }
        public long CallQueueStatus { get; set; }
        public DateTime? CallDate { get; set; }
        public int Attempt { get; set; }
    }
}
