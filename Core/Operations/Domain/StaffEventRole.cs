using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class StaffEventRole : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public IEnumerable<long> AllowedTestIds { get; set; }

        public StaffEventRole()
        { }

        public StaffEventRole(long eventRoleId)
            : base(eventRoleId)
        { }


    }
}