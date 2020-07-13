using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class ClinicalAddress
    {
        [XmlAttribute("use")]
        public string AddressUse { get; set; }

        [XmlElement("streetAddressLine")]
        public string StreetAddressLine { get; set; }

        [XmlElement("additionalLocator")]
        public string AdditionalLocator { get; set; }

        public bool AdditionalLocatorSpecified
        {
            get { return !string.IsNullOrEmpty(AdditionalLocator); }
        }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("postalCode")]
        public string PostalCode { get; set; }

        [XmlElement("state")]
        public string State { get; set; }

        [XmlElement("country")]
        public string Countery { get; set; }

    }
}