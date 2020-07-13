using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Application.Domain
{
    public class Lookup : DomainObjectBase
    {
        public long LookupTypeId { get; set; }
        public string Alias { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int RelativeOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
