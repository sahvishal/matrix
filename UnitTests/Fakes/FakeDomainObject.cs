using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace HealthYes.Web.UnitTests.Fakes
{
    public class FakeDomainObject : DomainObjectBase
    {
        public FakeDomainObject()
        { }

        public FakeDomainObject(long id)
            : base(id)
        { }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData;
    }
}