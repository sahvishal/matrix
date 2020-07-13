using Falcon.App.Core.CallQueues.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues
{
    public interface IPreAssessmentCallQueueCustomerLockRepository
    {
        PreAssessmentCallQueueCustomerLock SavePreAssessmentCallQueueCustomerLock(PreAssessmentCallQueueCustomerLock callQueueCustomerLock);
        void UpdatePreAssessmentCallQueueCustomerLock(PreAssessmentCallQueueCustomerLock callQueueCustomerLock);
        void RelasePreAssessmentCallQueueCustomerLock(long callQueueCustomerId);
        void ReleaseIdPreAssessmentCallQueueCustomerLock(int interval);
    }
}
