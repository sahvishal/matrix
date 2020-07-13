using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class PatientLeftPostModel
    {
        public long EventCustomerId { get; set; }

        public long? LeftWithoutScreeningReasonId { get; set; }

        public string Notes { get; set; }
    }
}
