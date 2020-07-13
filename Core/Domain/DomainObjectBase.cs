using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Domain
{
    public abstract class DomainObjectBase
    {
        [IgnoreAudit]
        public long Id { get; set; }

        protected DomainObjectBase()
        { }

        protected DomainObjectBase(long id)
        {
            Id = id;
        }
    }
}