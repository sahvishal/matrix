using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class PatientRole
    {

        [XmlElement("id")]
        public ClinicalRoot[] PatientIds { get; set; }

        [XmlElement("addr")]
        public ClinicalAddress PatinetAddress { get; set; }

        [XmlElement("telecom")]
        public ClinicalTeleCom[] TeleCom { get; set; }

        [XmlElement("patient")]
        public Patient Patient { get; set; }

        [XmlElement("providerOrganization")]
        public ProviderOrganization ProviderOrganization { get; set; }

    }

    public class ProviderOrganization
    {
        [XmlElement("id")]
        public ClinicalRoot ProveiderId { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("telecom")]
        public ClinicalTeleCom TeleCom { get; set; }

        [XmlElement("addr")]
        public ClinicalAddress Address { get; set; }
    }
}