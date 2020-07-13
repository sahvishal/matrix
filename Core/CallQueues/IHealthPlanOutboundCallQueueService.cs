using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanOutboundCallQueueService
    {
        OutboundCallQueueListModel GetOutboundCallRoundCallQueue(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);

        OutboundCallQueueListModel GetOutboundFillEventCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);

        OutboundCallQueueListModel GetnOutboundNoshowCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);

        OutboundCallQueueListModel GetnOutboundZipRadiusCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);

        OutboundCallQueueListModel GetnOutboundUncontactedCustomersCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);

        OutboundCallQueueListModel GetOutboundMailRoundCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);

        OutboundCallQueueListModel GetOutboundLanuageBarrierCallQueueListModel(OutboundCallQueueFilter filter, CallQueue callQueue, int pageSize, long criteriaId, out int totalRecords);

        void GetAccountCallQueueSettingForCallQueue(OutboundCallQueueFilter filter);
    }
}