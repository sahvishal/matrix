using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnlineAppointmentConfirmation
    {
        public string Guid { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public bool CaptureHafOnline { get; set; }
        public string PrintUrl { get; set; }
        public EventType EventType { get; set; }
    }
}
