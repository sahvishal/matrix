using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Sales
{
    public interface IActivityRepository
    {
        bool DeleteActivity(ActivityType activityType, long activityId);
        bool MarkActivity(ActivityType activityType, long activityId, bool markActivity);
    }
}