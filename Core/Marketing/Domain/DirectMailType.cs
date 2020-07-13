using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class DirectMailType : DomainObjectBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
