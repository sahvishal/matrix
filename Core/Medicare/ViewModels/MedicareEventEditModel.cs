using System;

namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareEventEditModel
    {
        public long VisitId { get; set; }
        public long EventId { get; set; }
        public string Tag { get; set; }
        public DateTime VisitDate { get; set; }

        public bool IsFromReschedule { get; set; }
        public long EventCustomerId { get; set; }
    }
}
