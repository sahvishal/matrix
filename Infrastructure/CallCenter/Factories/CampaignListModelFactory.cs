using System;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.CallCenter.Factories
{
    [DefaultImplementation]
    public class CampaignListModelFactory : ICampaignListModelFactory
    {
        public CampaignListModel Create(IEnumerable<Campaign> campaigns, IEnumerable<OrderedPair<long, string>> campaignCreatedByAgentNameIdPair, IEnumerable<CorporateAccount> corporateAccounts,
            IEnumerable<CampaignActivity> campaignActivity, IEnumerable<CampaignActivityAssignment> campaignActivityAssignments, IEnumerable<DirectMailType> directMailTypes)
        {
            var model = new CampaignListModel();
            var collection = new List<CampaignViewModel>();
            campaigns.ToList().ForEach(cg =>
            {
                var createdBy = "N/A";
                var modifiedBy = "N/A";

                if (campaignCreatedByAgentNameIdPair != null && campaignCreatedByAgentNameIdPair.Any())
                {
                    createdBy = campaignCreatedByAgentNameIdPair.Single(ap => ap.FirstValue == cg.DataRecorderMetaData.DataRecorderCreator.Id).SecondValue;
                    modifiedBy = campaignCreatedByAgentNameIdPair.Single(ap => ap.FirstValue == cg.DataRecorderMetaData.DataRecorderModifier.Id).SecondValue;
                }

                var corporateAccountName = string.Empty;
                if (corporateAccounts != null && corporateAccounts.Any())
                {
                    corporateAccountName = corporateAccounts.Where(x => x.Id == cg.AccountId).Select(x => x.Name).FirstOrDefault();
                }

                var campaignActivityCollection = GetCampaignActivityViewModel(cg.Id, campaignActivity, campaignActivityAssignments, campaignCreatedByAgentNameIdPair, directMailTypes, cg.IsPublished);

                var campaignViewModel = new CampaignViewModel
                {
                    Id = cg.Id,
                    Name = cg.Name,
                    CampaignType = ((CampaignType)cg.TypeId).ToString(),
                    CampaignMode = ((CampaignMode)cg.ModeId).ToString(),
                    StartDate = cg.StartDate,
                    EndDate = cg.EndDate,
                    IsPublish = cg.IsPublished,
                    CreatedOn = cg.DataRecorderMetaData.DateCreated,
                    CreatedBy = createdBy,
                    ModifiedOn = cg.DataRecorderMetaData.DateModified,
                    ModifiedBy = modifiedBy,
                    CorporateAccount = corporateAccountName,
                    CustomTags = string.IsNullOrEmpty(cg.CustomTags) ? "" : string.Join(", ", cg.CustomTags.Split(',').ToArray()),
                    CampaignActivity = campaignActivityCollection
                };

                collection.Add(campaignViewModel);
            });

            model.Collection = collection;
            return model;
        }

        public List<CampaignActivityViewModel> GetCampaignActivityViewModel(long campaignId, IEnumerable<CampaignActivity> campaignActivity, IEnumerable<CampaignActivityAssignment> campaignActivityAssignments, IEnumerable<OrderedPair<long, string>> campaignCreatedByAgentNameIdPair, IEnumerable<DirectMailType> directMailTypes, bool isPublished)
        {
            var campaignActivityCollection = new List<CampaignActivityViewModel>();
            if (campaignActivity != null && campaignActivity.Any())
            {
                var campaignActivityDeatils = campaignActivity.Where(x => x.CampaignId == campaignId).ToList();
                if (campaignActivityDeatils != null && campaignActivityDeatils.Any())
                {
                    foreach (var item in campaignActivityDeatils)
                    {
                        var agents = ActivityAssignmentAgent(item.Id, campaignActivityAssignments, campaignCreatedByAgentNameIdPair);

                        var directMailType = "N/A";

                        if (item.DirectMailTypeId.HasValue)
                        {
                            directMailType = directMailTypes.Single(it => it.Id == item.DirectMailTypeId.Value).Name;
                        }

                        var activity = new CampaignActivityViewModel
                        {
                            ActivityId = item.Id,
                            ActivityType = ((CampaignActivityType)item.TypeId),
                            ActivityDate = item.ActivityDate,
                            AssignmentAgent = agents,
                            DirectMailType = directMailType,
                            IsEditable = isPublished && item.ActivityDate > DateTime.Today
                        };

                        campaignActivityCollection.Add(activity);
                    }
                }
            }
            return campaignActivityCollection;
        }

        private List<string> ActivityAssignmentAgent(long activityId, IEnumerable<CampaignActivityAssignment> campaignActivityAssignments, IEnumerable<OrderedPair<long, string>> campaignCreatedByAgentNameIdPair)
        {
            var collection = new List<string>();
            if (campaignActivityAssignments != null && campaignActivityAssignments.Any())
            {
                var assignmentIds = campaignActivityAssignments.Where(x => x.CampaignActivityId == activityId).Select(s => s.AssignedToOrgRoleUserId).ToArray();

                if (assignmentIds != null && assignmentIds.Any())
                {
                    if (campaignCreatedByAgentNameIdPair != null && campaignCreatedByAgentNameIdPair.Any())
                    {
                        foreach (var item in assignmentIds)
                        {
                            var agent = campaignCreatedByAgentNameIdPair.Single(ap => ap.FirstValue == item).SecondValue;
                            collection.Add(agent);
                        }
                    }
                }
            }
            return collection;
        }
    }
}

