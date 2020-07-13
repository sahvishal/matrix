using Falcon.App.Core.Application.Attributes;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class ExitUrlEditModel
    {
        public string PageUrl { get; set; }
        public string Guid { get; set; }
    }
}