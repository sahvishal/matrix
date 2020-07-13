using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues
{
    public interface IHourlyOutreachCallReportPollingAgent
    {
        void PollForHourlyOutreachCallReport();
    }
}
