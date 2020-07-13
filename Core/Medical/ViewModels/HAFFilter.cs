using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class HafFilter
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }

        public bool SetChildQuestion { get; set; }
        public int VersionNumber { get; set; }

        public HafFilter()
        {
            SetChildQuestion = true;
            VersionNumber = 0;
        }
    }
}