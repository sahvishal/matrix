using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomAppointmentsBookedListModel : ListModelBase<CustomAppointmentsBookedModel, CustomAppointmentsBookedListModelFilter>
    {
        public override IEnumerable<CustomAppointmentsBookedModel> Collection { get; set; }
        
        public override CustomAppointmentsBookedListModelFilter Filter { get; set; }
    }
}