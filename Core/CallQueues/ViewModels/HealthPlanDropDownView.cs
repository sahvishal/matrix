using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HealthPlanDropDownView
    {
        public long Id { get; set; }
        public string HealthPlanName { get; set; }
        public string CorporateTag { get; set; }
        public IEnumerable<CorporateCustomTagDropDownView> CorporateCustomTag { get; set; }
    }
}