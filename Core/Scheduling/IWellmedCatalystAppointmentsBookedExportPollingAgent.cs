using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling
{
   public interface IWellmedCatalystAppointmentsBookedExportPollingAgent
    {
        void PollForAppointmentBookExport();
    }
}
