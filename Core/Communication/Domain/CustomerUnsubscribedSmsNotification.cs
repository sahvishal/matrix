using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public class CustomerUnsubscribedSmsNotification : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long StatusId { get; set; }
        public long SmsReceivedId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}