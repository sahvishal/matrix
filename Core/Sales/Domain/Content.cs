using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class Content : DomainObjectBase
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ContentHtml { get; set; }
        public bool IsActive { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public Content()
            : this(0)
        {
        }

        public Content(long resultContentId)
            : base(resultContentId)
        { IsActive = true; }
    }
}
