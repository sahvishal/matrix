using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CallCenterAgentTeamLog : DomainObjectBase
    {
        public long TeamId { get; set; }
        public long AgentId { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime? DateRemoved { get; set; }
        public bool IsActive { get; set; }
        public long AssignedByOrgRoleUserId { get; set; }
        public long? RemovedByOrgRoleUserId { get; set; }
    }
}