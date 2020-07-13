using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueEstimatedCustomer
    {
        public long TodaysCustomers { get; set; }
        public long TomorrowCustomers { get; set; }
        public long DayAfterTomorrowCustomers { get; set; }
        public long OvermorrowCustomers { get; set; }
    }
}
