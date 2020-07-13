using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class TestNotPerformedReason : DomainObjectBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
