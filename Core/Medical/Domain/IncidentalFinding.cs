using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class IncidentalFinding : DomainObjectBase
    {
        public long CustomerEventTestIncidentalFindingId { get; set; }
        public string Label { get; set; }
        public int LocationCount { get; set; }
        public int Sequence { get; set; }
        public bool IsDefault{ get; set; }

        public List<IncidentalFindingGroup> IncidentalFindingGroups { get; set; }

        public IncidentalFinding()
        { }

        public IncidentalFinding(long id)
            : base(id)
        { }

    }
}