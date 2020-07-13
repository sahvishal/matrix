using Falcon.App.Core.Medical.Domain;
namespace Falcon.App.Core.Medical
{
    public interface IActivityTypeService
    {
        ActivityType CreateActivityType(string activityName, long createdBy);
    }
}
