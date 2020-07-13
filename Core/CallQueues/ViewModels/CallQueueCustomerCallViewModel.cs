using System;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueCustomerCallViewModel
    {
        public long CallId { get; set; }
        public DateTime CallDateTime { get; set; }
        public long Status { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
        public long CustomerId { get; set; }
        public long ProspectCustomerId { get; set; }
        public string Disposition { get; set; }

        public long? NotInterestedReasonId { get; set; }
    }
}
