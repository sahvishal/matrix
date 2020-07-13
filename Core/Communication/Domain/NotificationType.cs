using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public sealed class NotificationType : DomainObjectBase
    {
        public NotificationType(long id)
            : base(id)
        { }

        public string NotificationTypeName { get; set; }

        public string NotificationTypeAlias { get; set; }

        public string Description { get; set; }

        public bool IsServiceEnabled { get; set; }

        public bool IsQueuingEnabled { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public NotificationMedium NotificationMedium { get; set; }

        public int NumberOfAttempts { get; set; }

        public bool IsActive { get; set; }

        public bool AllowTemplateCreation { get; set; }
    }
}