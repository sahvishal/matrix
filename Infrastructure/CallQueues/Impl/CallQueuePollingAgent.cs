using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.CallQueues.Domain;
using System;
using System.Linq;
using Falcon.App.Core.CallQueues.Enum;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class CallQueuePollingAgent : ICallQueuePollingAgent
    {
        
        private readonly ICallQueueAssignmentRepository _callQueueAssignmentRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IOutboundCallQueueService _outboundCallQueueService;
        private readonly ISettings _settings;
        private readonly ILogger _logger;

        public CallQueuePollingAgent(ICallQueueAssignmentRepository callQueueAssignmentRepository,  ICallQueueCustomerRepository callQueueCustomerRepository,ICallQueueRepository callQueueRepository, 
            IOutboundCallQueueService outboundCallQueueService, ILogManager logManager,ISettings settings)
        {
            _callQueueAssignmentRepository = callQueueAssignmentRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callQueueRepository = callQueueRepository;
            _outboundCallQueueService = outboundCallQueueService;
            _settings = settings;

            _logger = logManager.GetLogger<CallQueuePollingAgent>();
        }

        public void SendCustomersOnCallQueue()
        {
            try
            {
                var callQueues = _callQueueRepository.GetAll().Where(x => x.IsActive && (x.IsQueueGenerated == false || (DateTime.Now >= (x.LastQueueGeneratedDate.HasValue ? x.LastQueueGeneratedDate.Value.AddMinutes(x.QueueGenerationInterval.Value) : DateTime.Now))));

                foreach (CallQueue queue in callQueues)
                {
                    var callAssignMents = _callQueueAssignmentRepository.GetByCallQueueId(queue.Id);

                    _callQueueCustomerRepository.DeleteForInActiveCallQueueCriteria(queue.Id);

                    var customerList = _outboundCallQueueService.GetCallQueueCustomers(queue);

                    //int callsToInsert = customerList.Count > 1000 ? 1000 : customerList.Count;//only this number of calls to be inserted at a time
                    if (!queue.IsQueueGenerated)
                    {
                        //var shortList = customerList.Take(callsToInsert);
                        //customerList = shortList.ToList();
                        _outboundCallQueueService.ChangeAssignmentOfExistingQueue(queue, callAssignMents);
                    }
                    int totalRecords = customerList.Count;

                    //assigning each call centre user with number of customer based on percentage
                    var callDivision = (from ca in callAssignMents
                                        let count = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalRecords * ca.Percentage) / 100))
                                        select new
                                        {
                                            AssignedTo = ca.AssignedOrgRoleUserId,
                                            callCount = count > 0 ? count : 1
                                        }).ToList();
                    int startCount = 0;
                    for (int i = 0; i < callDivision.Count; i++)
                    {
                        int endCount = callDivision[i].callCount;

                        int thresholdCount = customerList.Count < (startCount + endCount) ? customerList.Count : (startCount + endCount);

                        for (int j = startCount; j < thresholdCount; j++)
                        {
                            CallQueueCustomer callQueueCustomer = customerList[j];

                            if (_callQueueCustomerRepository.IsCallQueueExist(queue.Id, callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0, callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0, callQueueCustomer.EventId, _settings.NoOfDaysToIncludeRemovedFromQueue))
                                continue;

                            callQueueCustomer.CallQueueId = queue.Id;

                            callQueueCustomer.IsActive = true;
                            callQueueCustomer.Attempts = 0;
                            callQueueCustomer.DateCreated = DateTime.Now;
                            callQueueCustomer.Status = CallQueueStatus.Initial;
                            callQueueCustomer.AssignedToOrgRoleUserId = callDivision[i].AssignedTo;
                            callQueueCustomer.CallDate = DateTime.Now;
                            _callQueueCustomerRepository.Save(callQueueCustomer);

                        }
                        //Once the quota for 1 user is complete next user will start from that
                        startCount = startCount + endCount;
                    }

                    queue.IsQueueGenerated = true;
                    queue.LastQueueGeneratedDate = DateTime.Now;
                    _callQueueRepository.Save(queue);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
            }
        }
        
    }
}
