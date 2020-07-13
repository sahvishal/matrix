using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerScheduleListModel : ListModelBase<EventCustomerScheduleModel, CustomerScheduleModelFilter>
    {
        public override IEnumerable<EventCustomerScheduleModel> Collection { get; set; }
        public override CustomerScheduleModelFilter Filter { get; set; }
    }
}