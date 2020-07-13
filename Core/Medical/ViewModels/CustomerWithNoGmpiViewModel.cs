using System.Collections.Generic;
using System.Xml.Serialization;

namespace Falcon.App.Core.Medical.ViewModels
{
    [XmlRoot("CustomerWithNoGMPI")]
    public class CustomerWithNoGmpiViewModel
    {
        [XmlArray("CustomerIds")]
        [XmlArrayItem("CustomerId")]
        public List<long> CustomerIds { get; set; }
    }
}
