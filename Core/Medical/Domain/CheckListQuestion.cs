using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class CheckListQuestion : DomainObjectBase
    {
        public string Question { get; set; }
        public CheckListQuestionType Type { get; set; }
        public Gender Gender { get; set; }
        public int Index { get; set; }
        public string ControlValues { get; set; }
        public string ControlValueDelimiter { get; set; }
    }
}
