using System.Xml.Serialization;

namespace Falcon.App.Core.CCD.ViewModels
{
    public class ClinicalRoot
    {
        [XmlAttribute("extension")]
        public string Extension { get; set; }

        [XmlAttribute("root")]
        public string Root { get; set; }

        public ClinicalRoot()
        {

        }

        public ClinicalRoot(string ext, string root)
        {
            Extension = ext;
            Root = root;
        }
        //public ClinicalRoot(string root)
        //{
        //    Root = root;
        //}
    }

    public class StatusCode
    {
        [XmlAttribute("code")]
        public string Code { get; set; }
    }
}