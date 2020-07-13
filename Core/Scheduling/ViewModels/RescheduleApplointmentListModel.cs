using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class RescheduleApplointmentListModel : ListModelBase<RescheduleApplointmentModel, RescheduleApplointmentListModelFilter>
    {
        public override IEnumerable<RescheduleApplointmentModel> Collection { get; set; }
        public override RescheduleApplointmentListModelFilter Filter { get; set; }
    }
}
