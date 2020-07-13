using System;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnlineSchedulingSelectPackageEditModel : ViewModelBase
    {
        private OnlineSchedulingProcessAndCartViewModel _processAndCartViewModel;
        public OnlineSchedulingProcessAndCartViewModel ProcessAndCartViewModel
        {
            get
            {
                if (_processAndCartViewModel == null) _processAndCartViewModel = new OnlineSchedulingProcessAndCartViewModel();
                _processAndCartViewModel.CurrentStep = OnlineSchedulingProcessStep.Package;
                return _processAndCartViewModel;
            }
            set { _processAndCartViewModel = value; }
        }

        public OrderPlaceEditModel PackageSelectionEditModel { get; set; }
        public SourceCodeApplyEditModel SourceCodeApplyEditModel { get; set; }
        public EventCustomerOrderSummaryModel EventCustomerOrderSummaryModel { get; set; }

        public AppointmentSelectionEditModel Appointments { get; set; }

        public bool IsDynamicScheduling { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime? PreliminarySelectedTime { get; set; }

        public PackageSelectionInfoEditModel PackageSelectionInfo { get; set; }
        public int PackageSelectionVersion { get; set; }
        public bool HasPackages { get; set; }

        public bool AskPreQualificationQuestion { get; set; }

        public bool RecommendPackage { get; set; }

        public bool AgreedWithPrequalificationQuestion { get; set; }

        public bool SkipPreQualificationQuestion { get; set; }
    }
}