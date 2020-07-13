using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventProductType
    {
        public long Id { get; set; }
        public long EventID { get; set; }
        public long ProductTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
