using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
﻿using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class PreAssessmentCustomerContactViewModel
    {
        public CallQueuePatientInfomationViewModel PatientInfomation { get; set; }

        public IEnumerable<CallHistoryViewModel> CallHistory { get; set; }

        public CallOutcomeViewModel CallOutcome { get; set; }
        public string MemberIdLabel { get; set; }
        public IEnumerable<string> PreApprovedTests { get; set; }

        public PreAssessmentCustomerCallQueueCallAttempt CallQueueCustomerAttempt { get; set; }

        public bool IsCallEnded { get; set; }

        public IEnumerable<OrderedPair<string, string>> AdditionalFields { get; set; }

        public IEnumerable<string> PreApprovedPackages { get; set; }

        public RegisteredEventViewModel EventInformation { get; set; }

        public CriteriaInfoViewModel CriteriaInfo { get; set; }

        public long CallId { get; set; }

        public long HealthPlanId { get; set; }

        public CallQueueCustomerEditModel PatientInfoEditModel { get; set; }


        public CallQueueCustomerEditModel PatientInfoEditViewModel { get; set; }

        public bool HasError { get; set; }

        public string CallQueueCategory { get; set; }

        public bool IsCalledForVici { get; set; }

        public bool WarmTransfer { get; set; }

        public IEnumerable<string> RequiredTests { get; set; }
    }
}
