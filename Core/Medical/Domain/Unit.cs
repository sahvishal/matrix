using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class Unit : DomainObjectBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool IsActive { get; set; }
    }
}
