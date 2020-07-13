using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class VitalSignsComponent
    {
        [XmlElement("section")]
        public VitalSection Section { get; set; }

        public VitalSignsComponent()
        {

        }

        public VitalSignsComponent(VitalSection vitalSection)
        {
            Section = vitalSection;
        }
    }
}