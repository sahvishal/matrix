using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class MassAgentAssignmentViewModel
    {
        public IEnumerable<CallQueueAssignmentEditModel> SuccessAssignments { get; set; }
        public bool IsRecordsFailed { get; set; }
        public string LogFileName { get; set; }
        public string UploadedCsvFileName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
