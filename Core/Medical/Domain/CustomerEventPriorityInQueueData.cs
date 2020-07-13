using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class CustomerEventPriorityInQueueData  
    {
        public long CustomerEventScreeningTestID { get; set; }
        public string Note { get; set; } 
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
        public long? ModifiedByOrgRoleUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
