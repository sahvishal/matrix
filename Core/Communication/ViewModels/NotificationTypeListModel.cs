using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication.ViewModels
{

    public class NotificationTypeListModel
    {
        public IEnumerable<NotificationType> Collection { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }

        public NotificationTypeListFilter Filter { get; set; }
    }
}
