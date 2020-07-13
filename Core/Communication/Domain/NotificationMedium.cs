using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public class NotificationMedium : DomainObjectBase
    {
        public NotificationMedium(long id) : base(id)
        { }

        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string Medium { get; set; }
    }
}