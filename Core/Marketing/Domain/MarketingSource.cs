using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class MarketingSource : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ShowOnline { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public MarketingSource(long id) : base(id)
        {
            
        }

        public MarketingSource()
        {
            
        }
    }
}
