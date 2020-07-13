using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class AddNotesViewModel : ViewModelBase
    {
        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public string HostName { get; set; }

        public IEnumerable<string> Pods { get; set; }

        public string HealthPlan { get; set; }

        public string PodNames()
        {
            return Pods != null ? string.Join(", ", Pods) : string.Empty;
        }

        public bool IsSelected { get; set; }
    }
}
