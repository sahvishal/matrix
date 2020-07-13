using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public class CustomEventNotification : DomainObjectBase
    {
        public long EventId { get; set; }

        public long? AccountId { get; set; }

        public string Body { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CreatedBy { get; set; }

        public long ServiceStatus { get; set; }

        public DateTime? ServiceDate { get; set; }
    }
}
