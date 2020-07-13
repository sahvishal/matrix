using Falcon.App.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class PreAssessmentCallQueueCustomerLock : DomainObjectBase
    {
        public long PreAssessmentCustomerId { get; set; }
        public long? CustomerId { get; set; }
        public long? ProspectCustomerId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
