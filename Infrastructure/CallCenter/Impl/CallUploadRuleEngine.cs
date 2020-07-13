using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallUploadRuleEngine : ICallUploadRuleEngine
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallQueueCustomerLockRepository _callQueueCustomerLockRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly ICustomerEligibilityService _customerEligibilityService;

        public CallUploadRuleEngine(ICallQueueCustomerRepository callQueueCustomerRepository, ICallQueueCustomerLockRepository callQueueCustomerLockRepository,
                                    IProspectCustomerRepository prospectCustomerRepository, ICustomerRepository customerRepository, ICustomerService customerService,
                                    ICustomerEligibilityService customerEligibilityService)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callQueueCustomerLockRepository = callQueueCustomerLockRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _customerRepository = customerRepository;
            _customerService = customerService;
            _customerEligibilityService = customerEligibilityService;
        }
        public bool ApplyRuleEngine(CallUploadLog callUploadLog, IEnumerable<Call> calls, ProspectCustomer prospectCustomer, long organizationRoleUserId, long callqueueCustomerId, long callQueueId, out bool isRemovedFromCallQueue, ILogger logger)
        {
            isRemovedFromCallQueue = false;
            if (_callQueueCustomerLockRepository.CheckCustomerLockByCustomerId(callUploadLog.CustomerId)) return false;

            long? callStatus = GetCallStatus(callUploadLog.Outcome);

            long? prospectCustomerTag = GetProspectCustomerTag(callUploadLog.Disposition);

            if (calls.IsNullOrEmpty())
            {
                isRemovedFromCallQueue = UpdateProspectCustomerDisposition(callUploadLog, prospectCustomer, organizationRoleUserId, callqueueCustomerId, callQueueId, callStatus, prospectCustomerTag, logger);
            }
            else
            {
                if (callStatus.Value == (long)CallStatus.Attended || callStatus.Value == (long)CallStatus.IncorrectPhoneNumber || (callStatus.Value == (long)CallStatus.TalkedtoOtherPerson && ((ProspectCustomerTag)prospectCustomerTag.Value) == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers))
                {
                    var callMadeAfterUploadCall = calls.OrderByDescending(x => x.DateCreated).FirstOrDefault(x => x.DateCreated > callUploadLog.OutreachDateTime);

                    if (callMadeAfterUploadCall == null || callMadeAfterUploadCall.Status != (long)CallStatus.Attended)
                    {
                        isRemovedFromCallQueue = UpdateProspectCustomerDisposition(callUploadLog, prospectCustomer, organizationRoleUserId, callqueueCustomerId, callQueueId, callStatus, prospectCustomerTag, logger);
                    }
                }

            }

            return true;
        }

        private bool UpdateProspectCustomerDisposition(CallUploadLog callUploadLog, ProspectCustomer prospectCustomer, long organizationRoleUserId, long callqueueCustomerId, long callQueueId, long? callStatus, long? prospectCustomerTag, ILogger logger)
        {
            prospectCustomer.IsContacted = true;
            prospectCustomer.ContactedDate = callUploadLog.OutreachDateTime;

            prospectCustomer.ContactedBy = organizationRoleUserId;
            bool isRemovedFromCallQueue = false;

            if (prospectCustomerTag.HasValue)
            {
                prospectCustomer.Tag = ((ProspectCustomerTag)prospectCustomerTag);
                prospectCustomer.TagUpdateDate = callUploadLog.OutreachDateTime;
            }

            if (callStatus != null && ((CallStatus)callStatus.Value) == CallStatus.Attended)
            {
                if (prospectCustomerTag.HasValue && IsCustomerDispositionForRemove((ProspectCustomerTag)prospectCustomerTag.Value))
                {
                    _callQueueCustomerRepository.UpdateOtherCustomerAttempt(callqueueCustomerId, callUploadLog.CustomerId, 0, organizationRoleUserId, callUploadLog.OutreachDateTime.Value, true, callQueueId);

                    if (((ProspectCustomerTag)prospectCustomerTag.Value) == ProspectCustomerTag.IncorrectPhoneNumber || ((ProspectCustomerTag)prospectCustomerTag.Value) == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers)
                    {
                        _customerService.UpdateIsIncorrectPhoneNumber(callUploadLog.CustomerId, true, organizationRoleUserId);
                    }

                    if (((ProspectCustomerTag)prospectCustomerTag.Value) == ProspectCustomerTag.NotEligible)
                    {
                        var customer = _customerRepository.GetCustomer(callUploadLog.CustomerId);
                        const bool isEligible = false;
                        _customerService.SaveCustomerOnly(customer, organizationRoleUserId);
                        //always save eligibility after saving customer , because history is maintained by SaveCustomer/SaveCustomerOnly function.
                        _customerEligibilityService.Save(customer.CustomerId, DateTime.Now.Year, isEligible: isEligible, createdBy: organizationRoleUserId, logger: logger);
                    }

                    prospectCustomer.CallBackRequestedDate = null;
                    prospectCustomer.IsQueuedForCallBack = false;

                    isRemovedFromCallQueue = true;
                }
                else if (prospectCustomerTag.HasValue && ((ProspectCustomerTag)prospectCustomerTag.Value) == ProspectCustomerTag.LanguageBarrier)
                {
                    _customerService.UpdateIsLanguageBarrier(callUploadLog.CustomerId, true, organizationRoleUserId);

                    prospectCustomer.CallBackRequestedDate = null;
                    prospectCustomer.IsQueuedForCallBack = false;
                }
            }
            else if (callStatus != null && ((((CallStatus)callStatus.Value) == CallStatus.IncorrectPhoneNumber) || ((((CallStatus)callStatus.Value) == CallStatus.TalkedtoOtherPerson) && ((ProspectCustomerTag)prospectCustomerTag.Value) == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers)))
            {
                _customerService.UpdateIsIncorrectPhoneNumber(callUploadLog.CustomerId, true, organizationRoleUserId);

                _callQueueCustomerRepository.UpdateOtherCustomerAttempt(callqueueCustomerId, callUploadLog.CustomerId, 0, organizationRoleUserId, callUploadLog.OutreachDateTime.Value, true, callQueueId);
                prospectCustomer.CallBackRequestedDate = null;
                prospectCustomer.IsQueuedForCallBack = false;
                isRemovedFromCallQueue = true;
            }
            else if (callStatus != null && ((((CallStatus) callStatus.Value) == CallStatus.TalkedtoOtherPerson && (prospectCustomerTag.HasValue && IsCustomerDispositionForRemove((ProspectCustomerTag) prospectCustomerTag.Value)))))
            {
                _customerService.UpdateIsIncorrectPhoneNumber(callUploadLog.CustomerId, true, organizationRoleUserId);
                isRemovedFromCallQueue = true;
            }

            ((IUniqueItemRepository<ProspectCustomer>)_prospectCustomerRepository).Save(prospectCustomer);

            return isRemovedFromCallQueue;
        }

        private bool IsCustomerDispositionForRemove(ProspectCustomerTag prospectCustomerTag)
        {
            return //prospectCustomerTag == ProspectCustomerTag.RecentlySawDoc ||
                   prospectCustomerTag == ProspectCustomerTag.NotInterested ||
                   prospectCustomerTag == ProspectCustomerTag.HomeVisitRequested
                   || prospectCustomerTag == ProspectCustomerTag.DoNotCall ||
                   prospectCustomerTag == ProspectCustomerTag.Deceased ||
                   prospectCustomerTag == ProspectCustomerTag.MovedRelocated
                   || prospectCustomerTag == ProspectCustomerTag.NoLongeronInsurancePlan ||
                   prospectCustomerTag == ProspectCustomerTag.MobilityIssue ||
                   prospectCustomerTag == ProspectCustomerTag.InLongTermCareNursingHome ||
                   prospectCustomerTag == ProspectCustomerTag.IncorrectPhoneNumber ||
                   prospectCustomerTag == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers ||
                   prospectCustomerTag == ProspectCustomerTag.NotEligible ||
                   prospectCustomerTag == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther ||
                   prospectCustomerTag == ProspectCustomerTag.DebilitatingDisease;
        }

        private long? GetProspectCustomerTag(string disposition)
        {
            if (string.IsNullOrEmpty(disposition)) return null;

            var orderedPairs = (ProspectCustomerTag.HomeVisitRequested).GetNameValuePairs();
            var enumPair = orderedPairs.FirstOrDefault(x => x.SecondValue.ToLower() == disposition.ToLower());

            var prospectCustomerTag = (ProspectCustomerTag)enumPair.FirstValue;

            var isDefined = Enum.IsDefined(typeof(ProspectCustomerTag), prospectCustomerTag);

            return isDefined ? (long?)prospectCustomerTag : null;
        }

        private long? GetCallStatus(string status)
        {
            if (string.IsNullOrEmpty(status)) return null;

            var orderedPairs = (CallStatus.Attended).GetNameValuePairs();
            var enumPair = orderedPairs.FirstOrDefault(x => x.SecondValue.ToLower() == status.ToLower());

            var callStatus = (CallStatus)enumPair.FirstValue;

            var isDefined = Enum.IsDefined(typeof(CallStatus), callStatus);

            return isDefined ? (long?)callStatus : null;
        }


    }
}