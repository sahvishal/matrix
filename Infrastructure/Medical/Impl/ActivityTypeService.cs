using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using System;
namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IActivityTypeRepository _activityTypeRepository;

        public ActivityTypeService(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepository = activityTypeRepository;
        }

        public ActivityType CreateActivityType(string activityName, long createdBy)
        {
            ActivityType activityType;
            var activityTypemodel = new ActivityType()
            {
                Name = activityName,
                Alias = activityName,
                CreatedBy = createdBy,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            activityType = _activityTypeRepository.Save(activityTypemodel);
            return activityType;
        }

    }
}
