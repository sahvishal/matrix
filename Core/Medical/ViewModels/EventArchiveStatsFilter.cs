using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class EventArchiveStatsFilter : ModelFilterBase
    {
        public long EventId { get; set; }

        public DateTime? UploadDateFrom { get; set; }
        public DateTime? UploadDateTo { get; set; }

        public long UploadedBy { get; set; }

        public long UploadStatus { get; set; }

        public long PodId { get; set; }
    }
}
