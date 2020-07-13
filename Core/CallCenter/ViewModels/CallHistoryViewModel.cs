using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallHistoryViewModel
    {
        public long CallId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? RequestedCallBack { get; set; }
        public string CallOutcome { get; set; }
        public IEnumerable<NotesViewModel> Notes { get; set; }
        public string Disposition { get; set; }

        public string NotInterestedReason { get; set; }
    }
}
