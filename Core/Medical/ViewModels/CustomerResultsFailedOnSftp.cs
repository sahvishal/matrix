using System.Collections.Generic;
using System.Xml.Serialization;

namespace Falcon.App.Core.Medical.ViewModels
{
    [XmlRoot("CustomerFailedOnSftp")]
    public class CustomerResultsFailedOnSftp
    {
        [XmlArray("EventCustomerIds")]
        [XmlArrayItem("EventCustomerId")]
        public List<long> EventCustomerIds { get; set; }
    }
}
