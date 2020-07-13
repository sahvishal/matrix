using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventMetricsService
    {
        EventMetricsViewData GetEventMetricsViewData(long eventId, long orgRoleUserId);
    }
}