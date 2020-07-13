using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class LanguageCode
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        public LanguageCode()
        {

        }
        public LanguageCode(string code)
        {
            Code = code;
        }
    }
}