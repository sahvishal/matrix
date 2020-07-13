using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class PullBackCallQueueCustomerPollingAgent : IPullBackCallQueueCustomerPollingAgent
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallQueueCustomerLockRepository _callQueueCustomerLockRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ILogger _logger;

        private readonly int _pullBackInterval;

        public PullBackCallQueueCustomerPollingAgent(ISettings settings, ICallQueueCustomerRepository callQueueCustomerRepository, ILogManager logManager, ICallQueueCustomerLockRepository callQueueCustomerLockRepository, ICallCenterCallRepository callCenterCallRepository)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callQueueCustomerLockRepository = callQueueCustomerLockRepository;
            _callCenterCallRepository = callCenterCallRepository;

            _pullBackInterval = settings.PullBackCallQueueCustomerInterval;

            _logger = logManager.GetLogger<PullBackCallQueueCustomerPollingAgent>();
        }

        public void PollforPullBackCallQueueCustomer()
        {
            try
            {
                var callQueueCustomers = _callQueueCustomerRepository.PullBackCallQueueCustomer(_pullBackInterval);

                callQueueCustomers = callQueueCustomers.Where(x => x.CustomerId.HasValue);

                foreach (var callqueueCustomer in callQueueCustomers)
                {
                    _callQueueCustomerRepository.ReleaseCallQueueCustomerFromLock(callqueueCustomer.CustomerId.Value, callqueueCustomer.Id);
                }

                _callQueueCustomerLockRepository.ReleaseIdleCallQuequeCustomerLock(_pullBackInterval);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
