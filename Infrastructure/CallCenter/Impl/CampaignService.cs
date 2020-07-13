using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICampaignActivityRepository _campaignActivityRepository;
        private readonly ICampaignAssignmentRepository _campaignAssignmentRepository;
        private readonly ICampaignActivityAssignmentRepository _campaignActivityAssignmentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICampaignListModelFactory _campaignListModelFactory;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IRandomStringGenerator _randomStringGenerator;
        private readonly IDirectMailTypeRepository _directMailTypeRepository;

        private const int DEFAULT_CAMPAIGN_CODE_LENGTH = 7;
        public CampaignService(ICampaignRepository campaignRepository, ICampaignActivityRepository campaignActivityRepository,
            ICampaignAssignmentRepository campaignAssignmentRepository, ICampaignActivityAssignmentRepository campaignActivityAssignmentRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, ICampaignListModelFactory campaignListModelFactory, ICorporateAccountRepository corporateAccountRepository, IRandomStringGenerator randomStringGenerator, IDirectMailTypeRepository directMailTypeRepository)
        {
            _campaignRepository = campaignRepository;
            _campaignActivityRepository = campaignActivityRepository;
            _campaignAssignmentRepository = campaignAssignmentRepository;
            _campaignActivityAssignmentRepository = campaignActivityAssignmentRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _campaignListModelFactory = campaignListModelFactory;
            _corporateAccountRepository = corporateAccountRepository;
            _randomStringGenerator = randomStringGenerator;
            _directMailTypeRepository = directMailTypeRepository;
        }

        public CampaignEditModel GetEditModel(long campaignId)
        {
            if (campaignId <= 0) return new CampaignEditModel();

            var campaign = _campaignRepository.GetById(campaignId);
            var campaignActivities = _campaignActivityRepository.GetByCampaignId(campaignId);
            var campaignAssignment = _campaignAssignmentRepository.GetByCampaignId(campaignId);
            var campaignActivityAssignment = _campaignActivityAssignmentRepository.GetByCampaignId(campaignId);

            var model = CampaignDomainToModel(campaign);

            model.Assignments = GetCampaignAssignments(campaignId, campaignAssignment);

            if (campaignActivities != null && campaignActivities.Any())
            {
                var activityList = new List<CampaignActivityEditModel>();
                foreach (var activity in campaignActivities)
                {
                    var activityEditModel = CampaignActivityDomainToModel(activity);

                    var activityAssignments = campaignActivityAssignment.Where(x => x.CampaignActivityId == activity.Id);

                    activityEditModel.Assignments = GetActivityAssignment(activityAssignments, campaignActivityAssignment, activity);

                    activityList.Add(activityEditModel);

                    model.CampaignActivity = activityList;
                }
            }

            return model;
        }

        private IEnumerable<CampaignActivityAssignmentEditModel> GetActivityAssignment(IEnumerable<CampaignActivityAssignment> activityAssignments, IEnumerable<CampaignActivityAssignment> campaignActivityAssignment, CampaignActivity activity)
        {
            var activityAssigmentList = new List<CampaignActivityAssignmentEditModel>();
            if (activityAssignments != null && campaignActivityAssignment.Any())
            {
                var assignedUserNamePair =
                    _organizationRoleUserRepository.GetNameIdPairofUsers(
                        activityAssignments.Select(x => x.AssignedToOrgRoleUserId).ToArray());

                activityAssigmentList.AddRange(assignedUserNamePair.Select(assignment => new CampaignActivityAssignmentEditModel
                {
                    AssignedOrgRoleUserId = assignment.FirstValue,
                    Name = assignment.SecondValue,
                    CampaignActivityId = activity.Id
                }));
            }

            return activityAssigmentList;
        }

        private IEnumerable<CampaignAssignmentEditModel> GetCampaignAssignments(long campaignId, IEnumerable<CampaignAssignment> campaignAssignment)
        {
            var list = new List<CampaignAssignmentEditModel>();
            if (campaignAssignment != null && campaignAssignment.Any())
            {

                var assignedUserNamePair =
                    _organizationRoleUserRepository.GetNameIdPairofUsers(
                        campaignAssignment.Select(x => x.AssignedToOrgRoleUserId).ToArray());

                list.AddRange(assignedUserNamePair.Select(assignment => new CampaignAssignmentEditModel
                {
                    AssignedOrgRoleUserId = assignment.FirstValue,
                    Name = assignment.SecondValue,
                    CampaignId = campaignId
                }));
            }
            return list;
        }

        private CampaignEditModel CampaignDomainToModel(Campaign campaign)
        {
            return new CampaignEditModel
             {
                 CampaignId = campaign.Id,
                 Name = campaign.Name,
                 CampaignCode = campaign.CampaignCode,
                 StartDate = campaign.StartDate,
                 EndDate = campaign.EndDate,
                 TypeId = campaign.TypeId,
                 ModeId = campaign.ModeId,

                 AccountId = campaign.AccountId,
                 CustomTags = string.IsNullOrEmpty(campaign.CustomTags) ? null : campaign.CustomTags.Split(','),
                 Description = campaign.Description,
                 IsPublished = campaign.IsPublished
             };
        }

        private CampaignActivityEditModel CampaignActivityDomainToModel(CampaignActivity activity)
        {
            return new CampaignActivityEditModel
            {
                ActivityId = activity.Id,
                ActivityDate = activity.ActivityDate,
                Sequence = activity.Sequence,
                ActivityType = activity.TypeId,
                DirectMailType = activity.DirectMailTypeId ?? 0,
                Name = EnumExtension.GetDescription(((CampaignActivityType)activity.TypeId))
            };
        }

        public void Save(CampaignEditModel model, long orgRoleId)
        {
            Campaign campaign = null;
            if (model.CampaignId > 0)
            {
                campaign = _campaignRepository.GetById(model.CampaignId);
            }

            campaign = GetModelToDomain(model, campaign, orgRoleId);
            campaign = _campaignRepository.Save(campaign);

            if (model.Assignments != null && model.Assignments.Any())
            {
                _campaignAssignmentRepository.Save(campaign.Id, model.Assignments.Select(x => x.AssignedOrgRoleUserId).ToArray());
            }

            var campaignActivity = _campaignActivityRepository.GetByCampaignId(model.CampaignId);

            if (campaignActivity != null && campaignActivity.Any() && (model.CampaignActivity == null || !model.CampaignActivity.Any()))
            {
                _campaignActivityRepository.DeleteByCampaignActivityIds(campaignActivity.Select(x => x.Id).ToArray());
            }

            if (model.CampaignActivity != null && model.CampaignActivity.Any())
            {
                var campaignActivityIds = new List<long>();
                if (campaignActivity != null && campaignActivity.Any())
                    campaignActivityIds = campaignActivity.Select(x => x.Id).ToList();

                var idsToPersist = model.CampaignActivity.Where(x => x.ActivityId > 0).Select(x => x.ActivityId).ToArray();

                var activitiesToBeDelete = campaignActivityIds.Where(x => !idsToPersist.Contains(x)).Select(x => x);

                _campaignActivityRepository.DeleteByCampaignActivityIds(activitiesToBeDelete.ToArray());

                SaveCampaignActivities(model.CampaignActivity, orgRoleId, campaign.Id);
            }

        }

        private void SaveCampaignActivities(IEnumerable<CampaignActivityEditModel> activityList, long orgRoleId, long campaignId)
        {
            foreach (var model in activityList)
            {
                SaveActivity(orgRoleId, campaignId, model);
            }
        }

        private void SaveActivity(long orgRoleId, long campaignId, CampaignActivityEditModel model)
        {
            CampaignActivity campaignActivity = null;
            if (model.ActivityId > 0)
            {
                campaignActivity = _campaignActivityRepository.GetById(model.ActivityId);
            }

            var activity = GetCampaignActivityModeltoDomain(campaignActivity, model, orgRoleId, campaignId);
            activity = _campaignActivityRepository.Save(activity);
            _campaignActivityAssignmentRepository.DeleteByCampaignId(activity.Id);
            if (model.Assignments != null && model.Assignments.Any())
            {
                _campaignActivityAssignmentRepository.Save(activity.Id, model.Assignments.Select(x => x.AssignedOrgRoleUserId));
            }
        }

        private CampaignActivity GetCampaignActivityModeltoDomain(CampaignActivity domain, CampaignActivityEditModel model, long orgRoleId, long campaignId)
        {
            domain = domain ?? new CampaignActivity
            {
                DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, DateTime.Now)
            };

            domain.Sequence = model.Sequence;
            domain.TypeId = model.ActivityType;
            domain.DirectMailTypeId = (model.ActivityType == (long)CampaignActivityType.DirectMail) ? (long?)model.DirectMailType : null;
            if (model.ActivityDate.HasValue)
                domain.ActivityDate = model.ActivityDate.Value;
            domain.CampaignId = campaignId;
            domain.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleId);
            domain.DataRecorderMetaData.DateModified = DateTime.Now;
            return domain;
        }

        private Campaign GetModelToDomain(CampaignEditModel model, Campaign inPersistence, long orgRoleId)
        {
            inPersistence = inPersistence ?? new Campaign { DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, DateTime.Now) };

            inPersistence.Name = model.Name;
            inPersistence.CampaignCode = model.CampaignCode;
            inPersistence.StartDate = model.StartDate.Value;
            inPersistence.EndDate = model.EndDate.Value;
            inPersistence.TypeId = model.TypeId;
            inPersistence.ModeId = model.ModeId;
            inPersistence.AccountId = model.AccountId;
            inPersistence.CustomTags = GetCustomTagString(model.CustomTags);
            inPersistence.Description = model.Description;
            inPersistence.IsPublished = model.IsPublished;
            inPersistence.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleId);
            inPersistence.DataRecorderMetaData.DateModified = DateTime.Now;

            return inPersistence;
        }

        private string GetCustomTagString(string[] customTags)
        {
            if (customTags == null || !customTags.Any()) return string.Empty;
            return string.Join(",", customTags);
        }

        public CampaignListModel GetCampaignDetails(int pageNumber, int pageSize, CampaignListModelFilter filter, out int totalRecords)
        {
            var campaigns = _campaignRepository.GetCampaignDetails(pageNumber, pageSize, filter, out totalRecords);

            if (campaigns == null || !campaigns.Any()) return null;

            var campaignIds = campaigns.Select(x => x.Id).ToArray();

            //IEnumerable<CampaignAssignment> campaignAssignment = null;

            //if (campaignIds != null && campaignIds.Any())
            //{
            //    campaignAssignment = _campaignAssignmentRepository.GetByCampaignIds(campaignIds);
            //}

            var campaignCreatedByIds = campaigns.Select(cg => cg.DataRecorderMetaData.DataRecorderCreator.Id).ToArray();

            var campaignModifiedByIds = campaigns.Select(cg => cg.DataRecorderMetaData.DataRecorderModifier.Id).ToArray();

            if (campaignCreatedByIds != null && campaignCreatedByIds.Any())
            {
                campaignCreatedByIds = campaignCreatedByIds.Concat(campaignModifiedByIds).ToArray();
            }

            var campaignActivity = _campaignActivityRepository.GetByCampaignIds(campaignIds);

            IEnumerable<CampaignActivityAssignment> campaignActivityAssignment = null;

            if (campaignActivity != null && campaignActivity.Any())
            {
                var campaignActivityIds = campaignActivity.Select(x => x.Id).ToArray();

                if (campaignActivityIds != null && campaignActivityIds.Any())
                {
                    campaignActivityAssignment = _campaignActivityAssignmentRepository.GetByCampaignActivityIds(campaignActivityIds).ToArray();

                    if (campaignActivityAssignment != null && campaignActivityAssignment.Any())
                    {
                        var activityAssignmentOrgRoleIds = campaignActivityAssignment.Select(x => x.AssignedToOrgRoleUserId).Distinct().ToArray();

                        campaignCreatedByIds = campaignCreatedByIds.Concat(activityAssignmentOrgRoleIds).ToArray();
                    }
                }
            }

            IEnumerable<OrderedPair<long, string>> campaignCreatedByAgentNameIdPair = null;

            if (campaignCreatedByIds != null && campaignCreatedByIds.Any())
            {
                campaignCreatedByAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(campaignCreatedByIds).ToArray();
            }

            var directMailTypes = _directMailTypeRepository.GetAll();

            var corporateAccounts = _corporateAccountRepository.GetAllHealthPlan();

            return _campaignListModelFactory.Create(campaigns, campaignCreatedByAgentNameIdPair, corporateAccounts, campaignActivity, campaignActivityAssignment, directMailTypes);
        }

        public CampaignActivityEditModel GetActivityEditModel(long activityId, long campaignId)
        {
            CampaignActivity activity = null;
            if (activityId > 0)
                activity = _campaignActivityRepository.GetById(activityId);

            var campaign = _campaignRepository.GetById(campaignId);

            var model = activity != null ? CampaignActivityDomainToModel(activity) : new CampaignActivityEditModel();

            model.CampaigndId = campaignId;
            model.CampaignStartDate = campaign.StartDate;
            model.CampaignEndDate = campaign.EndDate;

            if (activityId > 0)
            {
                var activityAssignments = _campaignActivityAssignmentRepository.GetByCampaignActivityId(model.ActivityId);
                if (activityAssignments != null && activityAssignments.Any())
                {
                    var assignedUserNamePair = _organizationRoleUserRepository.GetNameIdPairofUsers(activityAssignments.Select(x => x.AssignedToOrgRoleUserId).ToArray());
                    model.Assignments = GetCampaignAssignments(assignedUserNamePair, model.ActivityId);
                }
            }


            return model;
        }

        private IEnumerable<CampaignActivityAssignmentEditModel> GetCampaignAssignments(IEnumerable<OrderedPair<long, string>> assignedUserNamePair, long activityId)
        {
            var list = new List<CampaignActivityAssignmentEditModel>();

            list.AddRange(assignedUserNamePair.Select(assignment => new CampaignActivityAssignmentEditModel
            {
                AssignedOrgRoleUserId = assignment.FirstValue,
                Name = assignment.SecondValue,
                CampaignActivityId = activityId
            }));

            return list;
        }

        public CallQueueCampaignListModel GetCampaignListModel(CampaignCallQueueFilter filter, int pageSize, out int totalRecords)
        {
            var campaigns = _campaignRepository.GetCampaignIdsForCallQueue(filter, pageSize, out totalRecords);

            var healthPlan = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(filter.HealthPlanId);

            var campaignBasic = new List<CampaignBasicInfo>();


            var campaignIdCriteriaIdPair = _campaignRepository.GetCriteriaIdsForCampaigns(campaigns.Select(x => x.Id));

            if (!campaigns.IsNullOrEmpty() && !campaignIdCriteriaIdPair.IsNullOrEmpty())
            {
                campaignBasic.AddRange(campaigns.Select(campaign => new CampaignBasicInfo
                {
                    Id = campaign.Id,
                    Name = campaign.Name,
                    StartDate = campaign.StartDate,
                    EndDate = campaign.EndDate,
                    HealthPlanTag = healthPlan.Tag,
                    CriteriaId = campaignIdCriteriaIdPair.First(x => x.FirstValue == campaign.Id).SecondValue
                }));
            }

            return new CallQueueCampaignListModel
            {
                Campaign = campaignBasic,
                Filter = filter,
                PagingModel = new PagingModel(filter.PageNumber, pageSize, totalRecords, null)
            };
        }

        public string GetRandomUniqueCampaignCodeInstance()
        {
            string sourceCode;

            do
            {
                sourceCode = _randomStringGenerator.GetRandomUpperCaseNumericString(DEFAULT_CAMPAIGN_CODE_LENGTH);
            } while (!_campaignRepository.IsCampaignCodeUnique(sourceCode, 0));

            return sourceCode;
        }

        public CampaignAcivityDetailViewModel GetCampaignActivity(long campaignId)
        {
            var campaignActivities = _campaignActivityRepository.GetByCampaignId(campaignId);

            IEnumerable<CampaignActivityAssignment> campaignActivityAssignments = null;
            var campaignCreatedByIds = new long[0];

            if (campaignActivities != null && campaignActivities.Any())
            {
                var campaignActivityIds = campaignActivities.Select(x => x.Id).ToArray();

                if (campaignActivityIds != null && campaignActivityIds.Any())
                {
                    campaignActivityAssignments = _campaignActivityAssignmentRepository.GetByCampaignActivityIds(campaignActivityIds).ToArray();

                    if (campaignActivityAssignments != null && campaignActivityAssignments.Any())
                    {
                        var activityAssignmentOrgRoleIds = campaignActivityAssignments.Select(x => x.AssignedToOrgRoleUserId).Distinct().ToArray();

                        campaignCreatedByIds = campaignCreatedByIds.Concat(activityAssignmentOrgRoleIds).ToArray();
                    }
                }
            }

            IEnumerable<OrderedPair<long, string>> campaignCreatedByAgentNameIdPair = null;

            if (campaignCreatedByIds != null && campaignCreatedByIds.Any())
            {
                campaignCreatedByAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(campaignCreatedByIds).ToArray();
            }

            var campaign = _campaignRepository.GetById(campaignId);

            var directMailTypes = _directMailTypeRepository.GetAll();

            var activityViewModels = _campaignListModelFactory.GetCampaignActivityViewModel(campaignId, campaignActivities, campaignActivityAssignments, campaignCreatedByAgentNameIdPair, directMailTypes, campaign.IsPublished);

            var model = new CampaignAcivityDetailViewModel()
            {
                Campaign = campaign,
                CampaignActivity = activityViewModels
            };

            return model;
        }

        public void EditActivity(long orgRoleId, CampaignActivityEditModel model)
        {
            SaveActivity(orgRoleId, model.CampaigndId, model);
        }

        public UpdatePublishedCampaignEditModel GetPublishedCampaignEditModel(long campaignId)
        {
            var campaign = _campaignRepository.GetById(campaignId);
            return new UpdatePublishedCampaignEditModel
            {
                CampaignId = campaignId,
                CampaignStartDate = campaign != null ? campaign.StartDate : (DateTime?)null,
                CampaignEndDate = campaign != null ? campaign.EndDate : (DateTime?)null,
            };
        }

        public void EditPublishedCampaign(UpdatePublishedCampaignEditModel model)
        {
            Campaign campaign = null;
            if (model.CampaignId > 0)
            {
                campaign = _campaignRepository.GetById(model.CampaignId);
            }

            campaign.EndDate = model.CampaignEndDate.Value;
            campaign = _campaignRepository.Save(campaign);
        }
    }
}
