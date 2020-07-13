using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class StructuredBody
    {
        [XmlElement("component")]
        public StructuredBodyComponent[] VitalSigns { get; set; }
       
    }
}