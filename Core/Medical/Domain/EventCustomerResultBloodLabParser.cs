using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Medical.Domain
{
    public class EventCustomerResultBloodLabParser
    {
        public long EventCustomerResultId { get; set; }
        public long BloodLabId { get; set; } 
        public bool IsActive { get; set; } 
    }
}
