using System.Xml.Serialization;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HraResultEvent
    {
         [XmlElement("EventId")]
        public long EventId { get; set; }
        [XmlElement("Snapshot")]
        public HraResultSnapshot Snapshot { get; set; }
         [XmlElement("PreventionPlan")]
        public HraResultPreventionPlan PreventionPlan { get; set; }
        [XmlElement("ResultReport")]
        public HraResultReport ResultReport { get; set; }
    }
}