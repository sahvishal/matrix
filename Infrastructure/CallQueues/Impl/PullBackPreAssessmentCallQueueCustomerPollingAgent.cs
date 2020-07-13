using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
     [DefaultImplementation]
    public class PullBackPreAssessmentCallQueueCustomerPollingAgent : IPullBackPreAssessmentCallQueueCustomerPollingAgent
    {

         private readonly IPreAssessmentCallQueueCustomerLockRepository _preAssessmentCallQueueCustomerLockRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ILogger _logger;

        private readonly int _pullBackInterval;

        public PullBackPreAssessmentCallQueueCustomerPollingAgent(ISettings settings, ILogManager logManager, IPreAssessmentCallQueueCustomerLockRepository callQueueCustomerLockRepository, ICallCenterCallRepository callCenterCallRepository)
        {

            _preAssessmentCallQueueCustomerLockRepository = callQueueCustomerLockRepository;
            _callCenterCallRepository = callCenterCallRepository;

            _pullBackInterval = settings.PullBackPreAssessmentCallQueueCustomerInterval;

            _logger = logManager.GetLogger<PullBackCallQueueCustomerPollingAgent>();
        }

        public void PollforPullBackPreAssessmentCallQueueCustomer()
        {
            try
            {


                _preAssessmentCallQueueCustomerLockRepository.ReleaseIdPreAssessmentCallQueueCustomerLock(_pullBackInterval);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
