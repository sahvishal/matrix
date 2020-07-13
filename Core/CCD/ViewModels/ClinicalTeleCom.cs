using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class ClinicalTeleCom
    {
        [XmlAttribute(AttributeName = "use")]
        public string PhoneNumberUse { get; set; }


        public bool PhoneNumberUseSpecified
        {
            get { return !string.IsNullOrEmpty(PhoneNumberUse); }
        }

        [XmlAttribute("value")]
        public string Telecom { get; set; }

        public ClinicalTeleCom()
        {

        }

        public ClinicalTeleCom(string use, string value)
        {
            PhoneNumberUse = use;
            Telecom = !string.IsNullOrEmpty(use) ? "tel:" + value : "mailto://" + value;
        }
    }
}