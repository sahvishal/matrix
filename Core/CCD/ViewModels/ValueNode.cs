using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class ValueNode
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}