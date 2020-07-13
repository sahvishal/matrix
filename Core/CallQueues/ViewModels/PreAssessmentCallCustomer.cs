using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class PreAssessmentCallCustomer
    {
        public long? EventId { get; set; }
        public long? HealthPlanId { get; set; }
        public long? CallId { get; set; }
        public long? CustomerId { get; set; }
        public long? EventCustomerID { get; set; }
    }
}
