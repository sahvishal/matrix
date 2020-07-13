using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventBasicInfoViewModelFilter : ModelFilterBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Pod { get; set; }

        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Radius { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public long AccountId { get; set; }

        public long AgentOrganizationId { get; set; }
    }
}