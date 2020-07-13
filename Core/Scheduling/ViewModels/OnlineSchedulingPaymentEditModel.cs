using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnlineSchedulingPaymentEditModel : ViewModelBase
    {
        private OnlineSchedulingProcessAndCartViewModel _processAndCartViewModel;
        public OnlineSchedulingProcessAndCartViewModel ProcessAndCartViewModel
        {
            get
            {
                if (_processAndCartViewModel == null) _processAndCartViewModel = new OnlineSchedulingProcessAndCartViewModel();
                _processAndCartViewModel.CurrentStep = OnlineSchedulingProcessStep.Info;
                return _processAndCartViewModel;
            }
            set { _processAndCartViewModel = value; }
        }

        public bool AcceptTerms { get; set; }
        public bool UseSameAddressforBilling { get; set; }
        public bool RequestForNewsLetter { get; set; }
        public string RequestForNewsLetterDescription { get; set; }

        public PaymentEditModel PaymentEditModel { get; set; }
        public SourceCodeApplyEditModel SourceCodeApplyEditModel { get; set; }
        public EventCustomerOrderSummaryModel EventCustomerOrderSummaryModel { get; set; }

        public OnlineSchedulingPaymentEditModel()
        {
            UseSameAddressforBilling = true;
        }
    }
}