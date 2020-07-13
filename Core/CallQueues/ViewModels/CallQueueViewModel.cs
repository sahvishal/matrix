using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueViewModel : ViewModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        public long TotalCustomersInQueue { get; set; }
        public decimal CustomerContacted { get; set; }

        public IEnumerable<CallQueueCriteriaViewModel> Criterias { get; set; }

        public IEnumerable<CallQueueAssignmentViewModel> Assignments { get; set; }
    }
}
