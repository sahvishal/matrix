using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class Criteria : DomainObjectBase
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Criteria()
        { }

        public Criteria(long id)
            : base(id)
        { }
    }
}
