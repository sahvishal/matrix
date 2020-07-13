using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class CallQueueCustomerHelper : ICallQueueCustomerHelper
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ISystemGeneratedCallQueueAssignmentRepository _systemGeneratedCallQueueAssignmentRepository;
        private readonly int _noofdaysToIncludeRemoved;

        public CallQueueCustomerHelper(ICallQueueCustomerRepository callQueueCustomerRepository, ISettings settings, ISystemGeneratedCallQueueAssignmentRepository systemGeneratedCallQueueAssignmentRepository)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _systemGeneratedCallQueueAssignmentRepository = systemGeneratedCallQueueAssignmentRepository;

            _noofdaysToIncludeRemoved = settings.NoOfDaysToIncludeRemovedFromQueue;
        }

        public void SaveCallQueueCustomer(IEnumerable<CallQueueCustomer> callQueueCustomers)
        {
            if (callQueueCustomers != null && callQueueCustomers.Any())
            {
                foreach (var callQueueCustomer in callQueueCustomers)
                {
                    if (_callQueueCustomerRepository.IsCallQueueExist(callQueueCustomer.CallQueueId, callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0, callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0, callQueueCustomer.EventId, _noofdaysToIncludeRemoved))
                        continue;

                    callQueueCustomer.IsActive = true;
                    callQueueCustomer.Attempts = 0;
                    callQueueCustomer.DateCreated = DateTime.Now;
                    callQueueCustomer.Status = CallQueueStatus.Initial;
                    callQueueCustomer.CallDate = DateTime.Now;
                    _callQueueCustomerRepository.Save(callQueueCustomer);
                }
            }
        }
        public void SaveCallQueueCustomerForCallBack(IEnumerable<CallQueueCustomer> callQueueCustomers)
        {
            if (callQueueCustomers != null && callQueueCustomers.Any())
            {
                foreach (var callQueueCustomer in callQueueCustomers)
                {
                    if (_callQueueCustomerRepository.IsCallQueueExist(callQueueCustomer.CallQueueId, callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0, callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0, callQueueCustomer.EventId, _noofdaysToIncludeRemoved))
                        continue;

                    callQueueCustomer.IsActive = true;
                    callQueueCustomer.Attempts = 0;
                    callQueueCustomer.DateCreated = DateTime.Now;
                    callQueueCustomer.Status = CallQueueStatus.Initial;
                    //callQueueCustomer.CallDate = DateTime.Now;
                    _callQueueCustomerRepository.Save(callQueueCustomer);
                }
            }
        }

        public void SaveCallQueueCustomerForFillEvent(IEnumerable<CallQueueCustomer> callQueueCustomers, long criteriaId)
        {
            if (callQueueCustomers != null && callQueueCustomers.Any())
            {
                long? eventId = 0;
                List<CallQueueCustomer> existingCustomers = null;
                callQueueCustomers = callQueueCustomers.OrderBy(x => x.EventId);

                foreach (var callQueueCustomer in callQueueCustomers)
                {
                    if (eventId != callQueueCustomer.EventId)
                    {
                        existingCustomers = _callQueueCustomerRepository.GetCallQueueCustomerByEventId(callQueueCustomer.EventId.Value, callQueueCustomer.CallQueueId, _noofdaysToIncludeRemoved).ToList();
                        eventId = callQueueCustomer.EventId;
                    }

                    var prospectId = callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0;
                    var customerId = callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0;
                    var cust = existingCustomers.FirstOrDefault(cq => (cq.ProspectCustomerId == prospectId || cq.CustomerId == customerId));
                    CallQueueCustomer newCallQueueCustomer = null;
                    if (cust == null)
                    {
                        callQueueCustomer.IsActive = true;
                        callQueueCustomer.Attempts = 0;
                        callQueueCustomer.DateCreated = DateTime.Now;
                        callQueueCustomer.Status = CallQueueStatus.Initial;
                        callQueueCustomer.CallDate = DateTime.Now;
                        newCallQueueCustomer = _callQueueCustomerRepository.Save(callQueueCustomer);

                        existingCustomers.Add(callQueueCustomer);
                    }
                    var callQueueCustomerId = cust != null ? cust.Id : 0;

                    if (callQueueCustomerId == 0 && newCallQueueCustomer != null)
                    {
                        callQueueCustomerId = newCallQueueCustomer.Id;
                    }
                    _systemGeneratedCallQueueAssignmentRepository.Save(new SystemGeneratedCallQueueAssignment { CallQueueCustomerId = callQueueCustomerId, CallQueueId = callQueueCustomer.CallQueueId, CriteriaId = criteriaId });
                }
            }
        }
    }
}
