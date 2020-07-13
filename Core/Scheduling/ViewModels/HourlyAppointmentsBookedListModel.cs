using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class HourlyAppointmentsBookedListModel : ListModelBase<HourlyAppointmentBookedModel, HourlyAppointmentsBookedListModelFilter>
    {
        public override IEnumerable<HourlyAppointmentBookedModel> Collection { get; set; }

        public override HourlyAppointmentsBookedListModelFilter Filter { get; set; }
    }
}