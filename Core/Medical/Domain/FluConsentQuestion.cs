using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class FluConsentQuestion : DomainObjectBase
    {
        public string Question { get; set; }

        public long TypeId { get; set; }

        public long Gender { get; set; }

        public long? ParentId { get; set; }

        public string ControlValues { get; set; }

        public string ControlValueDelimiter { get; set; }

        public long Index { get; set; }

        public long FluConsentQuestionType { get; set; }
    }
}
