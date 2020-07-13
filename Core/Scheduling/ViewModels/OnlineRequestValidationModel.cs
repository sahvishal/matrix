using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class OnlineRequestValidationModel
    {
        public OnlineRequestStatus RequestStatus { get; set; }
        public TempCart TempCart { get; set; }

        public bool CaptureOnlineHaf { get; set; }

        public bool IsCorporateEvent { get; set; }
    }
}
