using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.Domain
{
    public class NotificationSubscriber : DomainObjectBase
    {
        public NotificationSubscriber(long id)
            : base(id)
        { }

        public string Name { get; set; }
        public Email Email { get; set; }
        public PhoneNumber Phone { get; set; }
        public PhoneNumber CellNumber { get; set; }
        public long? UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public int NotificationTypeId { get; set; }
    }
}