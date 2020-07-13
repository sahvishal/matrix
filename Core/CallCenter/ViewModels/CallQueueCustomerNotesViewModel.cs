using System.Collections.Generic;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallQueueCustomerNotesViewModel
    {
        public IEnumerable<CallHistoryViewModel> CallHistory { get; set; }
        public IEnumerable<CustomerCallNotesViewModel> CustomerCallNotes { get; set; }

        public IEnumerable<DirectMailViewModel> DirectMail { get; set; }
    }
}