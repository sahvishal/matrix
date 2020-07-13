using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IOutboundCallQueueService
    {
        OutboundCallQueueListModel GetOutboundCallQueueList(long callQueueId, long assignedToOrgRoleUserId, int pageNumber, int pageSize, out int totalRecords);
        Notes RemoveFromQueue(CallQueueCustomer callQueueCustomer, Notes notes);
        List<CallQueueCustomer> GetCallQueueCustomers(CallQueue queue);
        void ChangeAssignmentOfExistingQueue(CallQueue queue, IEnumerable<CallQueueAssignment> callQueueAssignments);

        OutboundCallQueueListModel GetOutboundCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);
        long SetCallDetail(long organizationRoleUserId, long calledCustomerId = 0, string calledInNumber = "", string callerNumber = "", string callStatus = "", long? campaignId = null, long? healthPlanId = null, string customTags = "",
            long? callQueueId = null, long callId = 0, bool readAndUnderstood = false, long eventId = 0, string callQueueCategory = "", long? dialerType = null, long? ProductTypeId = null);

        OutboundCallQueueListModel GetOutboundCallQueueUpsellAndConfirmation(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);
        void SetReadAndUnderstoodNotes(long callId);

        CallQueueCustomerNotesViewModel GetCustomerNotes(long callId, long callQueueCustomerId);
    }
}
