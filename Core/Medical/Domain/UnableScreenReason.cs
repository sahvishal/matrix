using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class UnableScreenReason : DomainObjectBase
    {
        public UnableToScreenReason Reason { get; set; }
        public string DisplayName { get; set; }
        public string ReasonText { get; set; }
        public ReadingSource ReadingSource { get; set; }
        public string Description { get; set; }

        public UnableScreenReason(long id)
            : base(id)
        {

        }

        public UnableScreenReason() { }
    }
}
