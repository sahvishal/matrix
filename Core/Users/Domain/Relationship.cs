using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class Relationship : DomainObjectBase
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }

        public Relationship(long relationshipId)
            : base(relationshipId)
        {

        }

        public Relationship()
        {

        }
    }
}
