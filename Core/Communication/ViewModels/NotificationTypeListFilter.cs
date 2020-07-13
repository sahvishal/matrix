using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Communication.ViewModels
{
    [NoValidationRequired]
    public class NotificationTypeListFilter
    {
        public string Name { get; set; }

        public bool? IsServiceEnabled { get; set; }

        public bool? IsQueuingEnabled { get; set; }

        public int NotificationMedium { get; set; }

        public NotificationTypeListFilter()
        {

        }
    }
}
