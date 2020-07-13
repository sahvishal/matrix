using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class EventPod : DomainObjectBase
    {
        public long EventId { get; set; }

        public long PodId { get; set; }

        public long? TerritoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool EnableKynIntegration { get; set; }

        public bool IsBloodworkFormAttached { get; set; }
    }
}
