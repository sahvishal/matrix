using System.Collections.Generic;
using System.Xml.Serialization;

namespace Falcon.App.Core.Medical.ViewModels
{
    [XmlRoot("Tag")]
    public class HraResultTags
    {
        public string Name { get; set; }

        [XmlElement("Events")]
        public List<HraResultEvent> Events { get; set; }
    }
}
