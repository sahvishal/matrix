using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class EventCustomerTestNotPerformedNotification:DomainObjectBase
    {
        public long EventCustomerId { get; set; }
        public long NotificationTypeId { get; set; }
        public long TestId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
