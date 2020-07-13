using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueReportModel : ViewModelBase
    {
        [Hidden]
        public long AssignedToOrgRoleUserId { get; set; }

        [DisplayName("Agent Name")]
        public string AgentName { get; set; }

        [DisplayName("Queue name")]
        public string QueueName { get; set; }

        [DisplayName("Total Customer Assigned")]
        public long TotalCustomerAssigned { get; set; }

        [DisplayName("Total Customer Contacted")]
        public long TotalCustomerContacted { get; set; }
    }
}
