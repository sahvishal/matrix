using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class SurveyQuestion : DomainObjectBase
    {
        public string Question { get; set; }
        public DisplayControlType Type { get; set; }
        public Gender Gender { get; set; }
        public int Index { get; set; }
        public string ControlValues { get; set; }
        public string ControlValueDelimiter { get; set; }
        public long? ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}
