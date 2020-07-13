using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Domain.ViewData
{
    public class EventCustomerPackageTestDetailViewData
    {
        public Package Package { get; set; }
        public List<Test> Tests { get; set; }
        public ElectronicProduct ElectronicProduct { get; set; }
    }
}
