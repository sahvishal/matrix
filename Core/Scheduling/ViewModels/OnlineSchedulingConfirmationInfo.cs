using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class OnlineSchedulingConfirmationInfo
    {
        private OnlineSchedulingProcessAndCartViewModel _processAndCartViewModel;
        public OnlineSchedulingProcessAndCartViewModel ProcessAndCartViewModel
        {
            get
            {
                if (_processAndCartViewModel == null) _processAndCartViewModel = new OnlineSchedulingProcessAndCartViewModel();
                _processAndCartViewModel.CurrentStep = OnlineSchedulingProcessStep.Confirmation;
                return _processAndCartViewModel;
            }
            set { _processAndCartViewModel = value; }
        }

        public AppointmentConfirmationViewModel ConfirmationViewModel { get; set; }

        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public string Zipcode { get; set; }
        public decimal Radius { get; set; }
        public bool IsHaffilled { get; set; }
        public string PrintUrl { get; set; }
        public EventType EventType { get; set; }
    }
}
