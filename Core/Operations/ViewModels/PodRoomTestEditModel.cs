using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Operations.ViewModels
{
    [NoValidationRequired]
    public class PodRoomTestEditModel
    {
        public long Test { get; set; }
        public bool IsSelected { get; set; }
    }
}
