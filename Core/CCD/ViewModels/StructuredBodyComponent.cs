using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class StructuredBodyComponent
    {
        [XmlElement("section")]
        public Section Section { get; set; }

        public StructuredBodyComponent()
        {

        }

        public StructuredBodyComponent(Section vitalSection)
        {
            Section = vitalSection;
        }
    }
}