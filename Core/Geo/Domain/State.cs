using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Geo.Domain
{
    public class State : DomainObjectBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public long CountryId { get; set; }

        public State()
        {}

        public State(long stateId)
            : base(stateId)
        {}
    }
}