using System.Xml;
using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class ClinicalCode
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("displayName")]
        public string DisplayName { get; set; }

        [XmlAttribute("codeSystem")]
        public string CodeSystem { get; set; }

        [XmlAttribute("codeSystemName")]
        public string CodeSystemName { get; set; }

        [XmlElement("originalText")]
        public string OriginalText { get; set; }

        public bool OriginalTextProvided { get { return !string.IsNullOrWhiteSpace(OriginalText); } }

        public ClinicalCode()
        {

        }

        public ClinicalCode(string code, string displayName, string codeSystem, string codeName)
        {
            Code = code;
            DisplayName = displayName;
            CodeSystem = codeSystem;
            CodeSystemName = codeName;
        }

        public ClinicalCode(string code, string displayName, string codeSystem, string codeName, string originalText)
        {
            Code = code;
            DisplayName = displayName;
            CodeSystem = codeSystem;
            CodeSystemName = codeName;
            OriginalText = originalText;
        }
    }

    
}