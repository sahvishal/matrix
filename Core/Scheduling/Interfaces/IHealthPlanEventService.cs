using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IHealthPlanEventService
    {
        EventBasicInfoListModel GetEventBasicInfoForCallQueue(FillEventsCallQueueFilter filter, int pageSize, out int totalRecords);

        FillEventCallQueueModel GetEventBasicInfoForCallQueueReport(FillEventsCallQueueFilter filter, int pageSize, out int totalRecords);
    }
}