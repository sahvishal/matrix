using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCustomerContactService
    {
        CustomerContactViewModel Get(long callQueueCustomerId, long callId, long orgRoleUserId);
        ScreeningInfoViewModel GetCustomerMedicalHistory(long customerId);
        bool UpdateCustomerData(CallQueueCustomerEditModel model, long createdByOrgRoleUserId);
        bool EndActiveCall(CallQueueCustomer callQueueCustomer, long callId, bool isCallQueueRequsted, long orgainizationRoleId, bool isRemoveFromQueueRequested, long? callOutcomeId = null, string skipCallNotes = "");
        CustomerContactViewModel GetByCustomerId(long customerId, long callId, long orgRoleUserId);
        long StartCall(long orgRoleUserId, long customerId, long callId = 0);
        IEnumerable<CallQueueCustomer> GetSingleCustomerFromCallQueue(OutboundCallQueueFilter filter, int pageSizeForContactCustomer, CallQueue callQueue);
        CustomerContactViewModel GetCustomerContactViewModelByAttempt(long callQueueCustomerId, long attemptId, long orgRoleUserId);

        bool SetCallQueueCustomerStatus(CallQueueCustomer callQueueCustomer, CallQueueStatus status, long orgainizationRoleId, bool isCallQueueRequsted, long? callOutcomeId, DateTime? callDate = null);
        long StartCallForDailer(long orgRoleUserId, long customerId, long callQueueId, long callId = 0);
        long StartCallForAppointmentConfirmation(long orgRoleUserId, long customerId, long eventId, long callQueueId, long callId = 0);
        CallQueuePatientInfomationViewModel PatientInfoPhoneModelForConsentUpdateCcRep(Customer customer, long callId, long orgRoleUserId);
        long StartOutboundCallForCustomerNotInCallQueue(long customerId, long orgRoleUserId);
    }
}