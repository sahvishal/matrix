using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class Patient
    {
        [XmlElement("name")]
        public ClinicalName ClinicalName { get; set; }

        [XmlElement("administrativeGenderCode")]
        public ClinicalCode GenderCode { get; set; }

        [XmlElement("birthTime")]
        public ValueNode BirthTime { get; set; }

        [XmlElement("maritalStatusCode")]
        public ClinicalCode MaritalStatusCode { get; set; }

        [XmlElement("religiousAffiliationCode")]
        public ClinicalCode ReligiousAffiliationCode { get; set; }

        [XmlElement("raceCode")]
        public ClinicalCode RaceCode { get; set; }

        [XmlElement("sdtc:raceCode")]
        public ClinicalCode RaceCodeExtention { get; set; }
    }
}