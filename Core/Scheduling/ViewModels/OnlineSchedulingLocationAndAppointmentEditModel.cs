using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnlineSchedulingLocationAndAppointmentEditModel : ViewModelBase
    {
        private OnlineSchedulingProcessAndCartViewModel _processAndCartViewModel;
        public OnlineSchedulingProcessAndCartViewModel ProcessAndCartViewModel
        {
            get
            {
                if (_processAndCartViewModel == null) 
                    _processAndCartViewModel = new OnlineSchedulingProcessAndCartViewModel();
                _processAndCartViewModel.CurrentStep = OnlineSchedulingProcessStep.LocationAndAppointmentSlot;
                return _processAndCartViewModel;
            }
            set { _processAndCartViewModel = value; }
        }

        public OnlineSchedulingEventListModel Events { get; set; }
        public OnlineSchedulingEventViewModel SelectedEvent { get; set; }

        public string CouponCode { get; set; }
        public int Version { get; set; }
    }


    [DefaultImplementation(Interface = typeof(IValidator<OnlineSchedulingLocationAndAppointmentEditModel>))]
    public class OnlineSchedulingLocationAndAppointmentEditModelValidator : AbstractValidator<OnlineSchedulingLocationAndAppointmentEditModel>
    {

    }


    [DefaultImplementation(Interface = typeof(IValidator<OnlineSchedulingEventListModel>))]
    public class OnlineSchedulingEventListModelValidator : AbstractValidator<OnlineSchedulingEventListModel>
    {

    }
}