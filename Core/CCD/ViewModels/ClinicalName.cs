using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class ClinicalName
    {
        [XmlAttribute("use")]
        public string Use { get; set; }

        [XmlElement("given")]
        public string[] GivenName { get; set; }

        [XmlElement("family")]
        public string LastName { get; set; }

        [XmlElement("suffix")]
        public string Suffix { get; set; }

        public bool SuffixProvide { get { return !string.IsNullOrWhiteSpace(Suffix); } }
    }
}