using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class CdaBodyComponent
    {
        [XmlElement("structuredBody")]
        public StructuredBody StructuredBody { get; set; }
    }
}