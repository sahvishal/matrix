using System;
using System.Xml;
using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    [Serializable]
    public class ClinicalDocument
    {
        [XmlElement("realmCode")]
        public RealmCode Realm { get; set; }

        [XmlElement("typeId")]
        public ClinicalRoot Type { get; set; }

        [XmlElement("templateId")]
        public ClinicalRoot Template { get; set; }

        [XmlElement("id")]
        public ClinicalRoot Identifier { get; set; }

        [XmlElement("code")]
        public ClinicalCode ClinicalCode { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("effectiveTime")]
        public DocumentGenerationtime EffectiveTime { get; set; }

        [XmlElement("confidentialityCode")]
        public ClinicalCode ConfidentialityCode { get; set; }

        [XmlElement("languageCode")]
        public LanguageCode LanguageCode { get; set; }

        [XmlElement("setId")]
        public ClinicalRoot SetId { get; set; }

        [XmlElement("versionNumber")]
        public ValueNode Version { get; set; }

        [XmlElement("recordTarget")]
        public RecordTarget RecordTarget { get; set; }

        [XmlElement("documentationOf")]
        public DocumentationOfCcd DocumentationOfCcd { get; set; }

        [XmlElement("component")]
        public CdaBodyComponent CdaBodyComponent { get; set; }

    }

    public class Section
    {
        [XmlElement("templateId")]
        public ClinicalRoot TemplateId { get; set; }

        [XmlElement("code")]
        public ClinicalCode Code { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlIgnore]
        public string HtmlText { get; set; }

        [XmlAnyElement("text")]
        public XmlElement TextElement
        {
            get
            {
                var x = new XmlDocument();
                x.LoadXml(string.Format("<text>{0}</text>", HtmlText));
                return x.DocumentElement;
            }
            set { HtmlText = value.InnerXml; }
        }

        [XmlElement("entry")]
        public Entry[] Entery { get; set; }
    }

    public class Entry
    {
        [XmlAttribute("typeCode")]
        public string TypeCode { get; set; }

        [XmlElement("organizer")]
        public Organizer Organizer { get; set; }
    }
    

    public class Organizer
    {
        [XmlAttribute("classCode")]
        public string ClassCode { get; set; }

        [XmlAttribute("moodCode")]
        public string MoodCode { get; set; }

        [XmlElement("templateId")]
        public ClinicalRoot TemplateId { get; set; }

        [XmlElement("id")]
        public ClinicalRoot Id { get; set; }

        [XmlElement("code")]
        public ClinicalCode Code { get; set; }

        [XmlElement("statusCode")]
        public StatusCode StatusCode { get; set; }

        [XmlElement("component")]
        public Component[] Component { get; set; }

        public Organizer()
        {
            Id = new ClinicalRoot { Root = Guid.NewGuid().ToString() };
        }
    }

    public class Component
    {
        [XmlElement("observation")]
        public Observation Obesrvation { get; set; }
    }

    public class Observation
    {
        [XmlElement("templateId")]
        public ClinicalRoot[] TemplateId { get; set; }

        [XmlElement("id")]
        public ClinicalRoot Id { get; set; }

        [XmlElement("code")]
        public ClinicalCode Code { get; set; }

        [XmlIgnore]
        public string Reference { get; set; }

        [XmlAnyElement("text")]
        public XmlElement TextElement
        {
            get
            {
                var x = new XmlDocument();
                x.LoadXml(string.Format("<text>{0}</text>", Reference));
                return x.DocumentElement;
            }
            set { Reference = value.InnerXml; }
        }

        [XmlElement("statusCode")]
        public StatusCode StatusCode { get; set; }

        [XmlElement("value")]
        public ObservationValue ObservationValue { get; set; }

        public Observation()
        {
            Id = new ClinicalRoot { Root = Guid.NewGuid().ToString() };
        }
    }

    public class ObservationValue
    {
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }
}
