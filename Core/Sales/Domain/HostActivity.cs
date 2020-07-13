using System.Collections.Generic;

namespace Falcon.App.Core.Sales.Domain
{
    public class HostActivity
    {
        public long HostId { get; set; }
        public List<long> ActivityId { get; set; }        
    }
}

