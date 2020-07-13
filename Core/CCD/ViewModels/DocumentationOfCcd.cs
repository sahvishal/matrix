using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class DocumentationOfCcd
    {
        [XmlElement("serviceEvent")]
        public ServiceEvent ServiceEvent { get; set; }
       
    }

    public class ServiceEvent
    {
        [XmlAttribute("classCode")]
        public string ClassCode { get; set; }

        [XmlElement("low")]
        public EffectiveTime EffectiveTime { get; set; }

         [XmlElement("performer")]
        public Performer Performer { get; set; }
    }

    public class EffectiveTime
    {
        [XmlElement("low")]
        public DocumentGenerationDate Low { get; set; }

        [XmlElement("high")]
        public DocumentGenerationtime High { get; set; }
    }

    public class Performer
    {
        [XmlAttribute("typeCode")]
        public string TypeCode { get; set; }

        [XmlElement("functionCode")]
        public ClinicalCode FunctionClinicalCode { get; set; }

        [XmlElement("assignedEntity")]
        public AssingnedEntity AssingnedEntity { get; set; }

    }

    public class AssingnedEntity
    {
        [XmlElement("id")]
        public ClinicalRoot AssingedId { get; set; }

        [XmlElement("code")]
        public ClinicalCode AssingnedCode { get; set; }

        [XmlElement("addr")]
        public ClinicalAddress Address { get; set; }

        [XmlElement("telecom")]
        public ClinicalTeleCom ClinicalTeleCom { get; set; }

        [XmlElement("assignedPerson")]
        public AssignedPerson AssignedPerson { get; set; }
    }

    public class AssignedPerson
    {
        [XmlElement("name")]
        public ClinicalName Name { get; set; }
    }

}