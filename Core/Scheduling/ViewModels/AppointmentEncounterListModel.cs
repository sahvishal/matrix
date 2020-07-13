using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentEncounterListModel : ListModelBase<AppointmentEncounterModel, AppointmentEncounterFilter>
    {
        public override IEnumerable<AppointmentEncounterModel> Collection { get; set; }
        public override AppointmentEncounterFilter Filter { get; set; }
    }
}