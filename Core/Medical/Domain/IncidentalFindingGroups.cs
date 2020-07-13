using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class IncidentalFindingGroup : DomainObjectBase
    {
        
        public DisplayControlType DisplayControlType { get; set; }
        public List<IncidentalFindingGroupItem> GroupItems { get; set; }
        
        public IncidentalFindingGroup()
        { }

        public IncidentalFindingGroup(long id)
            : base(id)
        { }

    }

}