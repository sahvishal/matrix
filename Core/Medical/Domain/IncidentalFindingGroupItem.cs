using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{

    public class IncidentalFindingGroupItem : DomainObjectBase
    {
        public long CustomerEventTestGroupItemId { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public int Location { get; set; }

        public DataRecorderMetaData RecorderMetaData { get; set; }
        
        public IncidentalFindingGroupItem()
        { }

        public IncidentalFindingGroupItem(long id)
            : base(id)
        { }
    }
}
