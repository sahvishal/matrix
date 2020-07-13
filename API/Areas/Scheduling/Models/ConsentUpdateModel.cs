using Falcon.App.Core.Application.Attributes;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class ConsentUpdateModel
    {
        public long EventCustomerId { get; set; }
        public short Status { get; set; }
    }
}