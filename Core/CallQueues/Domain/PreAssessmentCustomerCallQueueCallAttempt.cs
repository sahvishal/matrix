using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class PreAssessmentCustomerCallQueueCallAttempt
    {
        public long PreAssessmentCallAttemptID { get; set; }
        public long? CallId { get; set; }
        public long CustomerId { get; set; }
        public bool IsCallSkipped { get; set; }
        public bool IsNotesReadAndUnderstood { get; set; }
        public long? NotInterestedReasonId { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
        public string SkipCallNote { get; set; }
    }
}
