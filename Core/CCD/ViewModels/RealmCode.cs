using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class RealmCode
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        public RealmCode()
        {

        }
        public RealmCode(string code)
        {
            Code = code;
        }
    }
}