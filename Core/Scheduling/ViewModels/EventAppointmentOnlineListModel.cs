using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class EventAppointmentOnlineListModel
    {
        public IEnumerable<EventAppointmentOnlineModel> MorningSlots { get; set; }
        public IEnumerable<EventAppointmentOnlineModel> AfterNoonSlots { get; set; }
        public IEnumerable<EventAppointmentOnlineModel> EveningSlots { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public bool IsAdditionalTestAvailable { get; set; }

        public bool UpsellTestAvailable { get; set; }
        public long SelectedSlotId { get; set; }
        public string Guid { get; set; }
    }

}
