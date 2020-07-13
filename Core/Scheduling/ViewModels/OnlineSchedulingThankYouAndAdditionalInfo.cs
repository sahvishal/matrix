using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class OnlineSchedulingThankYouAndAdditionalInfo : ViewModelBase
    {
        private OnlineSchedulingProcessAndCartViewModel _processAndCartViewModel;
        public OnlineSchedulingProcessAndCartViewModel ProcessAndCartViewModel
        {
            get
            {
                if (_processAndCartViewModel == null) _processAndCartViewModel = new OnlineSchedulingProcessAndCartViewModel();
                _processAndCartViewModel.CurrentStep = OnlineSchedulingProcessStep.Checkin;
                return _processAndCartViewModel;
            }
            set { _processAndCartViewModel = value; }
        }

        public EventCustomerOrderSummaryModel EventCustomerOrderSummaryModel { get; set; }
        public HealthAssessmentEditModel AssessmentQuestionEditModel { get; set; }
        public GoogleAnalyticsEnableReportingDataModel GoogleAnalyticsReportingDataModel { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime? DateofBirth { get; set; }

        public int? Gender { get; set; }

        public int Race { get; set; }

        public decimal? Waist { get; set; }

        public bool IsKynPurchased
        {
            get
            {
                return AssessmentQuestionEditModel != null && AssessmentQuestionEditModel.IsKynPurchased;
            }
        }

        public PrimaryCarePhysicianEditModel Pcp { get; set; }

        public bool EnterPcpDetail { get; set; }

        public bool CaptureHafOnline { get; set; }

        public OnlineSchedulingThankYouAndAdditionalInfo()
        {
            Pcp = new PrimaryCarePhysicianEditModel();
        }

    }
}