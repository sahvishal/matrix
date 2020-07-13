using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class ApplyRulesOnLockedCustomersPollingAgent : IApplyRulesOnLockedCustomersPollingAgent
    {
        private readonly ICallUploadLogRepository _callUploadLogRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICallUploadRuleEngine _callUploadRuleEngine;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallUploadHelper _callUploadHelper;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ILogger _logger;
        private readonly bool _isDevEnvironment;
        private const string OutReachType = "Outbound";
        public ApplyRulesOnLockedCustomersPollingAgent(ICallUploadLogRepository callUploadLogRepository, ICallQueueCustomerRepository callQueueCustomerRepository,
            ICallCenterCallRepository callCenterCallRepository, ILogManager logManager, ICallUploadRuleEngine callUploadRuleEngine, IProspectCustomerRepository prospectCustomerRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, ICallUploadHelper callUploadHelper, ICallQueueRepository callQueueRepository, ISettings settings)
        {
            _callUploadLogRepository = callUploadLogRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _callUploadRuleEngine = callUploadRuleEngine;
            _prospectCustomerRepository = prospectCustomerRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callUploadHelper = callUploadHelper;
            _callQueueRepository = callQueueRepository;
            _isDevEnvironment = settings.IsDevEnvironment;
            _logger = logManager.GetLogger("ApplyRulesOnLockedCustomersPollingAgent");
        }

        public void PollForApplyRule()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                _logger.Info("Entering In Apply Rules On Locked Customers PollingAgent");
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    var callUploadLogs = _callUploadLogRepository.GetCustomerForApplyRule(OutReachType);


                    if (callUploadLogs.IsNullOrEmpty())
                    {
                        _logger.Info("No Record Found");
                        return;
                    }
                    var customerIds = callUploadLogs.Select(x => x.CustomerId);
                    var callcenterCalls = _callCenterCallRepository.GetCallDetails(customerIds);
                    var prospectCustomers = _prospectCustomerRepository.GetProspectCustomersByCustomerIds(customerIds.ToArray());

                    var emailIds = callUploadLogs.Select(x => x.Email).Distinct().ToList();
                    var userNames = callUploadLogs.Select(x => x.UserName).Distinct().ToList();

                    var organizationRoleUserEmail = _organizationRoleUserRepository.GetNameIdPairofOrgRoleIdByEmail(emailIds, (long)Roles.CallCenterRep);
                    var organizationRoleUserUserName = _organizationRoleUserRepository.GetNameIdPairofOrgRoleIdByUserNames(userNames, (long)Roles.CallCenterRep);

                    var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.CallRound);

                    var callQueueCustomers = _callQueueCustomerRepository.GetCallQueueCustomersBuCustomerIds(customerIds, callQueue.Id).ToList();

                    foreach (var uploadLog in callUploadLogs)
                    {
                        try
                        {
                            var customerCalls = callcenterCalls.Where(x => x.CalledCustomerId == uploadLog.CustomerId);
                            var prospectCustomer = prospectCustomers.Single(x => x.CustomerId == uploadLog.CustomerId);
                            var orgRoleId = _callUploadHelper.GetOrganizationRoleId(uploadLog, organizationRoleUserEmail, organizationRoleUserUserName);

                            var callQueueCustomer = callQueueCustomers.FirstOrDefault(x => x.CustomerId.HasValue && x.CustomerId.Value == uploadLog.CustomerId);
                            bool isRemovedFromCallQueue;

                            var isRuleApplied = _callUploadRuleEngine.ApplyRuleEngine(uploadLog, customerCalls, prospectCustomer, orgRoleId, callQueueCustomer.Id, callQueueCustomer.CallQueueId, out isRemovedFromCallQueue, _logger);
                            if (isRuleApplied)
                            {
                                if (isRemovedFromCallQueue)
                                {
                                    callQueueCustomer.Status = CallQueueStatus.Removed;
                                    _callQueueCustomerRepository.Save(callQueueCustomer);
                                }

                                uploadLog.IsRuleApplied = isRuleApplied;
                                _callUploadLogRepository.SaveCallUploadLog(uploadLog);

                            }
                        }
                        catch (Exception exception)
                        {
                            _logger.Error("Error on Apply Rule on Locked Customer For CallUploadLogId: " + uploadLog.Id + " Exception: " + exception + "\n Stack Trace:" + exception.StackTrace);
                        }

                    }
                }
                else
                {
                    _logger.Info(string.Format("Apply Rule on Locked Customer can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Error on Apply Rule on Locked Customer Exception: " + exception + "\n Stack Trace:" + exception.StackTrace);
            }


        }


    }
}