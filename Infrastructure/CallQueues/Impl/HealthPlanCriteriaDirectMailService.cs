using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanCriteriaDirectMailService : IHealthPlanCriteriaDirectMailService
    {
        private readonly IHealthPlanCriteriaDirectMailRepository _healthPlanCriteriaDirectMailRepository;
        private readonly ICampaignActivityRepository _campaignActivityRepository;

        public HealthPlanCriteriaDirectMailService(IHealthPlanCriteriaDirectMailRepository healthPlanCriteriaDirectMailRepository, ICampaignActivityRepository campaignActivityRepository)
        {
            _healthPlanCriteriaDirectMailRepository = healthPlanCriteriaDirectMailRepository;
            _campaignActivityRepository = campaignActivityRepository;
        }

        public IEnumerable<DirectMailDateEditModel> GetDirectMailDateEditModel(long criteriaId)
        {
            var directMailDate = _healthPlanCriteriaDirectMailRepository.GetByCriteriaId(criteriaId);
            var directMailDateEditModel = new List<DirectMailDateEditModel>();

            if (directMailDate.IsNullOrEmpty()) return directMailDateEditModel;

            var activityIds = directMailDate.Select(x => x.CampaignActivityId).ToArray();
            var activities = _campaignActivityRepository.GetByIds(activityIds);

            directMailDateEditModel.AddRange(from mailDate in directMailDate
                                             let activity = activities.First(x => x.Id == mailDate.CampaignActivityId)
                                             select new DirectMailDateEditModel
                                             {
                                                 ActivityId = mailDate.CampaignActivityId,
                                                 ActivityDate = activity.ActivityDate
                                             });

            return directMailDateEditModel;
        }

        public IEnumerable<DirectMailDateEditModel> GetActivityDateForDropDown(long campaignId)
        {
            var campaignDates = _campaignActivityRepository.GetDirectMailActivityByCampaignId(campaignId);

            if (campaignDates.IsNullOrEmpty()) return null;

            return campaignDates.Select(x => new DirectMailDateEditModel { ActivityId = x.Id, ActivityDate = x.ActivityDate })
                 .ToArray();

        }

        public bool ValidateByCampaign(CampaignDirectMailDatesEditModel model, long criteriaId)
        {
            var activities = _healthPlanCriteriaDirectMailRepository.GetByCampaignId(model.CampaignId);

            if (activities.IsNullOrEmpty())
                return true;

            activities = activities.Where(x => x.CriteriaId != criteriaId);

            if (activities.IsNullOrEmpty())
                return true;

            var activitiesByCount = activities.GroupBy(x => x.CriteriaId).Select(x => new OrderedPair<long, int>() { FirstValue = x.Key, SecondValue = x.Count() });
            var activityCount = model.DirectMailDateActivities.Count();
            var sameCountActivities = activitiesByCount.Where(x => x.SecondValue == activityCount);

            if (sameCountActivities.IsNullOrEmpty())
                return true;

            foreach (var sameCountActivity in sameCountActivities)
            {
                var activityIds = activities.Where(x => x.CriteriaId == sameCountActivity.FirstValue);

                if (!(activityIds.Any(x => !model.DirectMailDateActivities.Select(dmd => dmd.ActivityId).Contains(x.CampaignActivityId))
                    || model.DirectMailDateActivities.Any(x => !activityIds.Select(ai => ai.CampaignActivityId).Contains(x.ActivityId))))
                    return false;
            }

            return true;
        }

        public IEnumerable<OrderedPair<long, DateTime>> GetDirectMailDatesByCriteriaIds(IEnumerable<long> criteriaIds)
        {
            var directMailDate = _healthPlanCriteriaDirectMailRepository.GetByCriteriaIds(criteriaIds.ToArray());
            var directMailDateEditModel = new List<OrderedPair<long, DateTime>>();

            if (directMailDate.IsNullOrEmpty()) return directMailDateEditModel;

            var activityIds = directMailDate.Select(x => x.CampaignActivityId).ToArray();
            var activities = _campaignActivityRepository.GetByIds(activityIds);

            directMailDateEditModel.AddRange(from mailDate in directMailDate
                                             let activity = activities.First(x => x.Id == mailDate.CampaignActivityId)
                                             select new OrderedPair<long, DateTime>
                                             {
                                                 FirstValue = mailDate.CriteriaId,
                                                 SecondValue = activity.ActivityDate
                                             });

            return directMailDateEditModel;
        }
    }
}
