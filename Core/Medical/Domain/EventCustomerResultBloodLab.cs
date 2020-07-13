using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class EventCustomerResultBloodLab 
    {
        public long EventCustomerResultId { get; set; }
        public bool IsFromNewLab { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedByOrgRoleUserid { get; set; }
    }
}
