using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class PcpAppointmentListModel : ListModelBase<PcpAppointmentViewModel, PcpAppointmentListModelFilter>
    {
        public override IEnumerable<PcpAppointmentViewModel> Collection { get; set; }
       public override PcpAppointmentListModelFilter Filter { get; set; }
    }
}
