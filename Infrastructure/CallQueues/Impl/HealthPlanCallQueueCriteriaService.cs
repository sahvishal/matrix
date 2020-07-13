using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanCallQueueCriteriaService : IHealthPlanCallQueueCriteriaService
    {
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly int _noPastAppointmentInDays;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueListModelFactory _callQueueListModelFactory;
        private readonly IHealthPlanCriteriaAssignmentRepository _healthPlanCriteriaAssignmentRepository;
        private readonly IHealthPlanCallQueueCriteriaEditModelFactory _healthPlanCallQueueCriteriaEditModelFactory;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ISessionContext _sessionContext;
        private readonly IMediaRepository _mediaRepository;
        private readonly IHealthPlanCriteriaAssignmentUploadRepository _healthPlanCriteriaAssignmentUploadRepository;
        private readonly IHealthPlanCriteriaTeamAssignmentRepository _healthPlanCriteriaTeamAssignmentRepository;
        private readonly ICallCenterTeamRepository _callCenterTeamRepository;
        private readonly ICustomerCallQueueCallAttemptService _customerCallQueueCallAttemptService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IHealthPlanCriteriaDirectMailRepository _healthPlanCriteriaDirectMailRepository;
        private readonly IHealthPlanCriteriaDirectMailService _healthPlanCriteriaDirectMailService;

        private const string DefaultLanguageForConfirmation = "English";

        public HealthPlanCallQueueCriteriaService(IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, ISettings settings,
             ICorporateAccountRepository corporateAccountRepository, ICallQueueRepository callQueueRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ICallQueueListModelFactory callQueueListModelFactory,
            IHealthPlanCriteriaAssignmentRepository healthPlanCriteriaAssignmentRepository, IHealthPlanCallQueueCriteriaEditModelFactory healthPlanCallQueueCriteriaEditModelFactory,
            ICampaignRepository campaignRepository, IUniqueItemRepository<File> fileRepository, ISessionContext sessionContext, IMediaRepository mediaRepository,
            IHealthPlanCriteriaAssignmentUploadRepository healthPlanCriteriaAssignmentUploadRepository, IHealthPlanCriteriaTeamAssignmentRepository healthPlanCriteriaTeamAssignmentRepository,
            ICallCenterTeamRepository callCenterTeamRepository, ICustomerCallQueueCallAttemptService customerCallQueueCallAttemptService, IOrganizationRepository organizationRepository, ILanguageRepository languageRepository, IHealthPlanCriteriaDirectMailRepository healthPlanCriteriaDirectMailRepository, IHealthPlanCriteriaDirectMailService healthPlanCriteriaDirectMailService)
        {
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _noPastAppointmentInDays = settings.NoPastAppointmentInDays;

            _corporateAccountRepository = corporateAccountRepository;
            _callQueueRepository = callQueueRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callQueueListModelFactory = callQueueListModelFactory;
            _healthPlanCriteriaAssignmentRepository = healthPlanCriteriaAssignmentRepository;
            _healthPlanCallQueueCriteriaEditModelFactory = healthPlanCallQueueCriteriaEditModelFactory;
            _campaignRepository = campaignRepository;
            _fileRepository = fileRepository;
            _sessionContext = sessionContext;
            _mediaRepository = mediaRepository;
            _healthPlanCriteriaAssignmentUploadRepository = healthPlanCriteriaAssignmentUploadRepository;
            _healthPlanCriteriaTeamAssignmentRepository = healthPlanCriteriaTeamAssignmentRepository;
            _callCenterTeamRepository = callCenterTeamRepository;
            _customerCallQueueCallAttemptService = customerCallQueueCallAttemptService;
            _organizationRepository = organizationRepository;
            _languageRepository = languageRepository;
            _healthPlanCriteriaDirectMailRepository = healthPlanCriteriaDirectMailRepository;
            _healthPlanCriteriaDirectMailService = healthPlanCriteriaDirectMailService;
        }

        public HealthPlanCallQueueCriteria GetSystemGeneratedCallQueueCriteria(long callQueueId, long healthPlanId, long? organizationUserRoleId, long campaignId, long? criterialId = null)
        {
            var callQueue = _callQueueRepository.GetById(callQueueId);
            HealthPlanCallQueueCriteria criteria = null;

            if (callQueue.Category == HealthPlanCallQueueCategory.LanguageBarrier)
            {
                criteria = _healthPlanCallQueueCriteriaRepository.GetQueueCriteriaForQueue(callQueueId, healthPlanId);
            }
            else
            {
                criteria = criterialId.HasValue
                    ? _healthPlanCallQueueCriteriaRepository.GetById(criterialId.Value)
                    : _healthPlanCallQueueCriteriaRepository.GetQueueCriteria(callQueueId, organizationUserRoleId, healthPlanId, DateTime.Today);
            }

            return criteria;
        }

        public IEnumerable<HealthPlanCallQueueCriteria> GetHealthPlanCallQueueCriteriaNotGenerated(long callQueueId)
        {

            return _healthPlanCallQueueCriteriaRepository.GetHealthPlanCallQueueCriteriaNotGenerated(callQueueId);
        }

        public HealthPlanCallQueueCriteria Save(HealthPlanCallQueueCriteria criteria)
        {
            return _healthPlanCallQueueCriteriaRepository.Save(criteria);
        }

        public ListModelBase<HealthPlanCallQueueViewModel, HealthPlanCallQueueListModelFilter> GetHealthPlanCallQueueList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var assignmentFilter = filter as HealthPlanCallQueueListModelFilter ??
                                   new HealthPlanCallQueueListModelFilter();

            var healthPlanCallQueuesCriteria = _healthPlanCallQueueCriteriaRepository.GetHealthPlanCallQueueCriteria(filter as HealthPlanCallQueueListModelFilter, pageNumber, pageSize, out totalRecords);

            if (healthPlanCallQueuesCriteria == null && !healthPlanCallQueuesCriteria.Any())
            {
                totalRecords = 0;
                return null;
            }

            var callQueueIds = healthPlanCallQueuesCriteria.Select(cq => cq.CallQueueId).ToArray();

            var healthPlanIds = healthPlanCallQueuesCriteria.Where(x => x.HealthPlanId.HasValue).Select(s => s.HealthPlanId.Value).ToArray();

            IEnumerable<CorporateAccount> healthPlans = null;
            if (healthPlanIds != null && healthPlanIds.Any())
            {
                healthPlans = _corporateAccountRepository.GetByIds(healthPlanIds);
            }

            IEnumerable<CallQueue> healthPlanCallQueues = null;

            if (callQueueIds != null && callQueueIds.Any())
            {
                healthPlanCallQueues = _callQueueRepository.GetByIds(callQueueIds, false, true);
            }

            var assignOrgRoleIds = healthPlanCallQueuesCriteria.Select(a => a.DataRecorderMetaData.DataRecorderCreator.Id).Distinct().ToArray();

            var modifiedBy = healthPlanCallQueuesCriteria.Where(x => x.DataRecorderMetaData.DataRecorderModifier != null).Select(a => a.DataRecorderMetaData.DataRecorderModifier.Id).Distinct().ToArray();

            if (modifiedBy != null && modifiedBy.Any())
                assignOrgRoleIds = assignOrgRoleIds.Concat(modifiedBy).ToArray();

            var criteriaIds = healthPlanCallQueuesCriteria.Select(s => s.Id).ToArray();

            IEnumerable<HealthPlanCriteriaAssignment> healthPlanCriteriaAssignment = null;
            IEnumerable<HealthPlanCriteriaTeamAssignment> healthPlanCriteriaTeamAssignment = null;

            var campaignIds = healthPlanCallQueuesCriteria.Where(s => s.CampaignId.HasValue).Select(x => x.CampaignId.Value).ToArray();

            var campaigns = _campaignRepository.GetByIds(campaignIds);

            if (criteriaIds != null && criteriaIds.Any())
            {
                healthPlanCriteriaAssignment = _healthPlanCriteriaAssignmentRepository.GetByCriteriaIds(criteriaIds);
                healthPlanCriteriaTeamAssignment = _healthPlanCriteriaTeamAssignmentRepository.GetByCriteriaIds(criteriaIds);

                if (healthPlanCriteriaAssignment != null && healthPlanCriteriaAssignment.Any())
                {
                    var assignAssignmentRoleUserIds = healthPlanCriteriaAssignment.Select(s => s.AssignedToOrgRoleUserId).Distinct().ToArray();

                    if (assignAssignmentRoleUserIds != null && assignAssignmentRoleUserIds.Any())
                    {
                        assignOrgRoleIds = assignOrgRoleIds.Concat(assignAssignmentRoleUserIds).ToArray();
                    }

                    var assignmentBy = healthPlanCriteriaAssignment.Select(s => s.CreatedBy).Distinct().ToArray();

                    if (assignmentBy.Any())
                    {
                        assignOrgRoleIds = assignOrgRoleIds.Concat(assignmentBy).ToArray();
                    }
                }
            }

            IEnumerable<OrderedPair<long, string>> teamIdNamePairs = null;
            if (!healthPlanCriteriaTeamAssignment.IsNullOrEmpty())
            {
                teamIdNamePairs = _callCenterTeamRepository.GetIdNamePairOfTeams(healthPlanCriteriaTeamAssignment.Select(x => x.TeamId).ToArray());

                var assignmentBy = healthPlanCriteriaTeamAssignment.Select(s => s.CreatedBy).Distinct().ToArray();

                if (assignmentBy.Any())
                {
                    assignOrgRoleIds = assignOrgRoleIds.Concat(assignmentBy).ToArray();
                }
            }

            assignOrgRoleIds = assignOrgRoleIds.Distinct().ToArray();

            var agentIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(assignOrgRoleIds);

            var criteriaCustomerCountPairs = new List<OrderedPair<long, long>>();

            if (assignmentFilter.ShowAssignmentMetaData)
            {
                foreach (var criteria in healthPlanCallQueuesCriteria)
                {
                    var count = _customerCallQueueCallAttemptService.CustomerCountForHealthPlanCriteria(criteria, healthPlanCallQueues);
                    criteriaCustomerCountPairs.Add(new OrderedPair<long, long>(criteria.Id, count));
                }
            }

            var criteriaDirectMailDates = _healthPlanCriteriaDirectMailService.GetDirectMailDatesByCriteriaIds(criteriaIds);

            return _callQueueListModelFactory.CreateHealthPlanCallQueueList(healthPlanCallQueuesCriteria, agentIdNamePairs, healthPlanCallQueues, healthPlans, healthPlanCriteriaAssignment, campaigns, healthPlanCriteriaTeamAssignment,
                teamIdNamePairs, criteriaCustomerCountPairs, criteriaDirectMailDates, assignmentFilter.ShowAssignmentMetaData);
        }

        public HealthPlanCallQueueCriteriaEditModel SaveHealthPlanCallQueueCriteria(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId, bool isCriteriaSameAsPervious)
        {
            var callQueue = _callQueueRepository.GetCallQueueByCategory(model.CallQueue);
            model.CallQueueId = callQueue.Id;

            model.IsCriteriaSameAsPervious = isCriteriaSameAsPervious;

            if (model.CallQueue == HealthPlanCallQueueCategory.MailRound)
            {
                model.IsCriteriaSameAsPervious = true;
                var healthPlanCallQueueCriterias = new List<HealthPlanCallQueueCriteria>();

                HealthPlanCallQueueCriteria existingCriteria = model.Id > 0 ? _healthPlanCallQueueCriteriaRepository.GetById(model.Id) : null;

                foreach (var campaign in model.CampaignDirectMailDates)
                {
                    var criteria = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCallQueueCriteriaForMailRound(model, campaign.CampaignId, orgRoleId);

                    if (existingCriteria != null)
                    {
                        if (existingCriteria.CampaignId.HasValue && model.CampaignDirectMailDates.Any(x => x.CampaignId == existingCriteria.CampaignId.Value))
                        {
                            if (campaign.CampaignId == existingCriteria.CampaignId.Value)
                            {
                                criteria.Id = model.Id;
                                criteria.IsQueueGenerated = existingCriteria.IsQueueGenerated;
                            }
                        }
                        else
                        {
                            if (campaign.CampaignId == model.CampaignDirectMailDates.First().CampaignId)
                                criteria.Id = model.Id;
                        }
                    }
                    if (criteria.Id > 0)
                    {
                        var directmailActivities = _healthPlanCriteriaDirectMailRepository.GetByCriteriaId(criteria.Id);

                        if (directmailActivities.IsNullOrEmpty() && !campaign.DirectMailDateActivities.IsNullOrEmpty())
                        {
                            criteria.IsQueueGenerated = false;
                            model.IsCriteriaSameAsPervious = false;
                        }
                        else if (!directmailActivities.IsNullOrEmpty() && campaign.DirectMailDateActivities.IsNullOrEmpty())
                        {
                            criteria.IsQueueGenerated = false;
                            model.IsCriteriaSameAsPervious = false;
                        }
                        else if (!directmailActivities.IsNullOrEmpty() && !campaign.DirectMailDateActivities.IsNullOrEmpty())
                        {
                            if (directmailActivities.Count() != campaign.DirectMailDateActivities.Count())
                            {
                                criteria.IsQueueGenerated = false;
                                model.IsCriteriaSameAsPervious = false;
                            }
                            else
                            {
                                var activtyIdsInDB = directmailActivities.Select(x => x.CampaignActivityId);
                                var activityIdsInModel = campaign.DirectMailDateActivities.Select(x => x.ActivityId);

                                if (!(activtyIdsInDB.All(activityIdsInModel.Contains) && activityIdsInModel.All(activtyIdsInDB.Contains)))
                                {
                                    criteria.IsQueueGenerated = false;
                                    model.IsCriteriaSameAsPervious = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        criteria.IsQueueGenerated = false;
                        model.IsCriteriaSameAsPervious = false;
                    }


                    criteria = _healthPlanCallQueueCriteriaRepository.Save(criteria);

                    if (!campaign.DirectMailDateActivities.IsNullOrEmpty())
                    {
                        var activityIds = campaign.DirectMailDateActivities.Select(x => x.ActivityId);
                        _healthPlanCriteriaDirectMailRepository.Save(activityIds, criteria.Id);
                    }

                    healthPlanCallQueueCriterias.Add(criteria);
                }

                if (!model.IsTeamAssignment)
                {
                    foreach (var healthPlanCallQueueCriteria in healthPlanCallQueueCriterias)
                    {
                        SaveFileInfoForCsvUpload(model, healthPlanCallQueueCriteria);
                    }
                    if (!model.Assignments.IsNullOrEmpty())
                    {
                        var assignments = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCriteriaAssignmentForMailRound(model.Assignments, healthPlanCallQueueCriterias, orgRoleId);
                        _healthPlanCriteriaAssignmentRepository.Save(model.HealthPlanId, model.CallQueueId, model.Id, assignments);
                    }
                }
                else
                {
                    if (!model.CallCenterTeamAssignments.IsNullOrEmpty())
                    {
                        var assignments = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCriteriaTeamAssignmentForMailRound(model.CallCenterTeamAssignments, healthPlanCallQueueCriterias, orgRoleId);
                        _healthPlanCriteriaTeamAssignmentRepository.Save(assignments);
                    }
                }
            }
            else if (model.CallQueue == HealthPlanCallQueueCategory.LanguageBarrier)
            {
                var healthPlanCallQueueCriteria = _healthPlanCallQueueCriteriaRepository.GetQueueCriteriaForQueue(model.CallQueueId, model.HealthPlanId);

                if (!model.IsTeamAssignment)
                {
                    if (!model.Assignments.IsNullOrEmpty())
                    {
                        SaveFileInfoForCsvUpload(model, healthPlanCallQueueCriteria);
                        var assignments = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCriteriaAssignment(model.Assignments, healthPlanCallQueueCriteria.Id, orgRoleId);
                        _healthPlanCriteriaAssignmentRepository.Save(model.HealthPlanId, model.CallQueueId, model.Id, assignments);
                    }
                }
                else
                {
                    if (!model.CallCenterTeamAssignments.IsNullOrEmpty())
                    {
                        var assignments = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCriteriaTeamAssignment(model.CallCenterTeamAssignments, healthPlanCallQueueCriteria, orgRoleId);
                        _healthPlanCriteriaTeamAssignmentRepository.Save(assignments);
                    }
                }
            }
            else if (model.CallQueue == HealthPlanCallQueueCategory.AppointmentConfirmation)
            {
                var healthPlanCallQueueCriteria = model.Id > 0 ? _healthPlanCallQueueCriteriaRepository.GetById(model.Id) : _healthPlanCallQueueCriteriaRepository.GetQueueCriteriaForQueueByLanguage(model.CallQueue, model.HealthPlanId, model.LanguageId);

                var organization = _organizationRepository.GetOrganizationbyId(model.HealthPlanId);
                var language = model.LanguageId.HasValue ? _languageRepository.GetById(model.LanguageId.Value) : null;
                model.CriteriaName = organization.Name + " Confirmation" + (language != null ? " for " + language.Name : "");
                if (healthPlanCallQueueCriteria == null)
                {
                    healthPlanCallQueueCriteria = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCallQueueCriteriaForConfirmation(model, orgRoleId);
                    healthPlanCallQueueCriteria = _healthPlanCallQueueCriteriaRepository.Save(healthPlanCallQueueCriteria);
                }
                else
                {
                    /*if (healthPlanCallQueueCriteria.LanguageId != model.LanguageId)
                        healthPlanCallQueueCriteria.IsQueueGenerated = false;*/
                    healthPlanCallQueueCriteria.LanguageId = model.LanguageId;
                    healthPlanCallQueueCriteria.CriteriaName = model.CriteriaName;
                    healthPlanCallQueueCriteria = _healthPlanCallQueueCriteriaRepository.Save(healthPlanCallQueueCriteria);
                }

                if (!model.IsTeamAssignment)
                {
                    if (!model.Assignments.IsNullOrEmpty())
                    {
                        SaveFileInfoForCsvUpload(model, healthPlanCallQueueCriteria);
                        var assignments = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCriteriaAssignment(model.Assignments, healthPlanCallQueueCriteria.Id, orgRoleId);
                        _healthPlanCriteriaAssignmentRepository.Save(model.HealthPlanId, model.CallQueueId, model.Id, assignments);
                    }
                }
                else
                {
                    if (!model.CallCenterTeamAssignments.IsNullOrEmpty())
                    {
                        var assignments = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCriteriaTeamAssignment(model.CallCenterTeamAssignments, healthPlanCallQueueCriteria, orgRoleId);
                        _healthPlanCriteriaTeamAssignmentRepository.Save(assignments);
                    }
                }
            }
            else
            {
                HealthPlanCallQueueCriteria criteria = null;

                if (!isCriteriaSameAsPervious)
                {
                    if (model.CallQueue == HealthPlanCallQueueCategory.FillEventsHealthPlan)
                    {
                        criteria = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCallQueueCriteriaForFillEvent(model, orgRoleId);
                    }
                    #region not in use
                    //switch (model.CallQueue)
                    //{
                    //    //case HealthPlanCallQueueCategory.CallRound:
                    //    //    criteria = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCallQueueCriteriaForCallRound(model, orgRoleId);
                    //    //    break;
                    //    case HealthPlanCallQueueCategory.FillEventsHealthPlan:
                    //        criteria = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCallQueueCriteriaForFillEvent(model, orgRoleId);
                    //        break;
                    //    //case HealthPlanCallQueueCategory.NoShows:
                    //    //    criteria = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCallQueueCriteriaForNoShow(model, orgRoleId);
                    //    //    break;
                    //    //case HealthPlanCallQueueCategory.ZipRadius:
                    //    //    criteria = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCallQueueCriteriaForZipRadius(model, orgRoleId);
                    //    //    break;
                    //}
                    #endregion
                    _healthPlanCallQueueCriteriaRepository.MarkForDelete(model.Id, true);
                    criteria = _healthPlanCallQueueCriteriaRepository.Save(criteria);
                    model.Id = criteria.Id;
                }
                else if (model.Id > 0)
                {
                    criteria = _healthPlanCallQueueCriteriaRepository.GetById(model.Id);
                    criteria.DataRecorderMetaData.DateModified = DateTime.Now;
                    criteria.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleId);
                    criteria.CriteriaName = model.CriteriaName;
                    criteria = _healthPlanCallQueueCriteriaRepository.Save(criteria);
                }

                if (!model.IsTeamAssignment)
                {
                    SaveFileInfoForCsvUpload(model, criteria);

                    if (!model.Assignments.IsNullOrEmpty())
                    {
                        var assignments = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCriteriaAssignment(model.Assignments, model.Id, orgRoleId);
                        _healthPlanCriteriaAssignmentRepository.Save(model.HealthPlanId, model.CallQueueId, model.Id, assignments);
                    }
                }
                else
                {
                    if (!model.CallCenterTeamAssignments.IsNullOrEmpty())
                    {
                        var assignments = _healthPlanCallQueueCriteriaEditModelFactory.GetHealthPlanCriteriaTeamAssignment(model.CallCenterTeamAssignments, criteria, orgRoleId);
                        _healthPlanCriteriaTeamAssignmentRepository.Save(assignments);
                    }

                }

            }

            if (!model.IsTeamAssignment)
            {
                if (model.Assignments != null && model.Assignments.Any())
                {
                    var list = new List<CallQueueAssignmentEditModel>();
                    foreach (var assignment in model.Assignments)
                    {
                        assignment.IsExistInOtherCriteria = false;
                        list.Add(assignment);
                    }
                    model.Assignments = list;
                }
                return model;
            }
            else
            {
                model.IsTeamAssignment = true;
                model.Assignments = null;
                return model;
            }
        }

        public HealthPlanCallQueueCriteriaEditModel GetCriteriaEditModel(long criteriaId = 0)
        {
            bool isTeamAssignment = false;
            IEnumerable<HealthPlanCriteriaAssignment> criteriaAssignments = null;
            IEnumerable<HealthPlanCriteriaTeamAssignment> teamAssignments = null;

            if (criteriaId <= 0)
            {
                var defaultLanguageForConfirmation = _languageRepository.GetByName(DefaultLanguageForConfirmation);
                var emptyModel = new HealthPlanCallQueueCriteriaEditModel();
                if (defaultLanguageForConfirmation != null)
                    emptyModel.LanguageId = defaultLanguageForConfirmation.Id;
                return emptyModel;
            }

            var criteria = _healthPlanCallQueueCriteriaRepository.GetById(criteriaId);
            var callQueue = _callQueueRepository.GetById(criteria.CallQueueId);

            var model = _healthPlanCallQueueCriteriaEditModelFactory.DomainToModel(criteria);
            criteriaAssignments = _healthPlanCriteriaAssignmentRepository.GetByCriteriaId(model.Id);
            if (!criteriaAssignments.Any())
            {
                teamAssignments = _healthPlanCriteriaTeamAssignmentRepository.GetTeamAssignments(model.Id);

                isTeamAssignment = teamAssignments.Any();
            }

            if (!isTeamAssignment)
            {
                var callQueueAssignmentEditModel = new List<CallQueueAssignmentEditModel>();

                if (criteriaAssignments != null && criteriaAssignments.Any())
                {
                    var assignedToIds = criteriaAssignments.Select(x => x.AssignedToOrgRoleUserId).ToArray();
                    var nameIdPairs = _organizationRoleUserRepository.GetNameIdPairofUsers(assignedToIds);
                    foreach (var assignedTo in assignedToIds)
                    {
                        var criteriaAssignment = criteriaAssignments.First(x => x.AssignedToOrgRoleUserId == assignedTo);
                        callQueueAssignmentEditModel.Add(new CallQueueAssignmentEditModel
                        {
                            Name = nameIdPairs.First(x => x.FirstValue == assignedTo).SecondValue,
                            AssignedOrgRoleUserId = assignedTo,
                            StartDate = criteriaAssignment.StartDate,
                            EndDate = criteriaAssignment.EndDate
                        });
                    }
                }
                model.Assignments = callQueueAssignmentEditModel;
                model.CallCenterTeamAssignments = null;
                model.IsTeamAssignment = false;
            }
            else
            {
                var teamAssignmentEditModel = new List<HealthPlanCriteriaTeamAssignmentEditModel>();
                var idnamePairOfTeams = _callCenterTeamRepository.GetIdNamePairOfTeams(teamAssignments.Select(x => x.TeamId).ToArray());

                foreach (var healthPlanCriteriaTeamAssignment in teamAssignments)
                {
                    var idnamePairOfTeam = idnamePairOfTeams.FirstOrDefault(x => x.FirstValue == healthPlanCriteriaTeamAssignment.TeamId);
                    if (idnamePairOfTeam == null) continue;
                    var assignmentEditModel = new HealthPlanCriteriaTeamAssignmentEditModel
                    {
                        TeamId = healthPlanCriteriaTeamAssignment.TeamId,
                        Name = idnamePairOfTeam.SecondValue,
                        StartDate = healthPlanCriteriaTeamAssignment.StartDate,
                        EndDate = healthPlanCriteriaTeamAssignment.EndDate
                    };
                    teamAssignmentEditModel.Add(assignmentEditModel);
                }

                model.CallCenterTeamAssignments = teamAssignmentEditModel;
                model.Assignments = null;
                model.IsTeamAssignment = true;
            }

            model.CallQueue = callQueue.Category;
            model.CallQueueId = callQueue.Id;

            if (callQueue.Category == HealthPlanCallQueueCategory.MailRound)
            {

                //var healthPlanCallQueueCriterias = _healthPlanCallQueueCriteriaRepository.GetCriteriaByHealthPlanCallQueue(model.HealthPlanId, HealthPlanCallQueueCategory.MailRound);
                var healthPlanCallQueueCriteria = _healthPlanCallQueueCriteriaRepository.GetById(criteriaId);
                //var campaigns = _campaignRepository.GetByIds(healthPlanCallQueueCriterias.Where(x => x.CampaignId.HasValue).Select(x => x.CampaignId.Value));
                //var campaignIds = new List<long>();

                //campaignIds.Add(healthPlanCallQueueCriteria.CampaignId.Value);
                //foreach (var campaign in campaigns)
                //{
                //    campaignIds.Add(campaign.Id);
                //}
                //model.Campaigns = campaignIds;
                var campaignDirectMailDates = new List<CampaignDirectMailDatesEditModel>();

                var directMailDates = _healthPlanCriteriaDirectMailService.GetDirectMailDateEditModel(criteriaId);
                campaignDirectMailDates.Add(new CampaignDirectMailDatesEditModel
                {
                    CampaignId = healthPlanCallQueueCriteria.CampaignId.Value,
                    DirectMailDateActivities = directMailDates
                });
                model.CampaignDirectMailDates = campaignDirectMailDates;
            }

            return model;
        }

        public IEnumerable<CallQueueAssignmentEditModel> GetCallQueueAssignment(long criteriaId)
        {
            var entityModel = _healthPlanCriteriaAssignmentRepository.GetByCriteriaId(criteriaId);
            if (!entityModel.IsNullOrEmpty())
            {
                var callQueueAssignmentEditModel = new List<CallQueueAssignmentEditModel>();

                var assignedToIds = entityModel.Select(x => x.AssignedToOrgRoleUserId).ToArray();
                var nameIdPairs = _organizationRoleUserRepository.GetNameIdPairofUsers(assignedToIds);
                foreach (var assignedTo in assignedToIds)
                {
                    var criteriaAssignment = entityModel.First(x => x.AssignedToOrgRoleUserId == assignedTo);
                    callQueueAssignmentEditModel.Add(new CallQueueAssignmentEditModel
                    {
                        Name = nameIdPairs.First(x => x.FirstValue == assignedTo).SecondValue,
                        AssignedOrgRoleUserId = assignedTo,
                        HealthPlanCriteriaId = criteriaAssignment.HealthPlanCriteriaId,
                        StartDate = criteriaAssignment.StartDate,
                        EndDate = criteriaAssignment.EndDate
                    });
                }
                return callQueueAssignmentEditModel.OrderBy(x => x.Name);
            }
            return null;
        }

        private void SaveFileInfoForCsvUpload(HealthPlanCallQueueCriteriaEditModel model, HealthPlanCallQueueCriteria criteria)
        {
            if (!model.UploadFileName.IsNullOrEmpty())
            {
                var file = new FileInfo(_mediaRepository.GetTempMediaFileLocation().PhysicalPath + model.UploadFileName);
                var files = new File
                {
                    Path = file.Name,
                    FileSize = file.Length,
                    Type = FileType.Csv,
                    UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                    UploadedOn = file.CreationTime,
                    IsArchived = false
                };
                files = _fileRepository.Save(files);

                var healthPlanCriteriaAssignmentUpload = new HealthPlanCriteriaAssignmentUpload
                {
                    FileId = files.Id,
                    UploadTime = file.CreationTime,
                    UploadedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                    CriteriaId = criteria.Id
                };
                _healthPlanCriteriaAssignmentUploadRepository.Save(healthPlanCriteriaAssignmentUpload);
                model.UploadFileName = null;
                System.IO.File.Copy(_mediaRepository.GetTempMediaFileLocation().PhysicalPath + file.Name, _mediaRepository.GetMassAgentAssignmentUploadMediaFileLocation().PhysicalPath + file.Name);
            }
        }

        public IEnumerable<HealthPlanCriteriaTeamEditModel> GetTeamAssignementEditModel(long criteriaId)
        {
            var teamAssignement = _healthPlanCriteriaTeamAssignmentRepository.GetTeamAssignments(criteriaId);
            if (teamAssignement.IsNullOrEmpty())
            { return null; }
            var teamIds = teamAssignement.Select(x => x.TeamId);

            var teamNameIdPair = _callCenterTeamRepository.GetIdNamePairOfTeams(teamIds);
            var criteria = _healthPlanCallQueueCriteriaRepository.GetById(criteriaId);
            var callQueue = _callQueueRepository.GetById(criteria.CallQueueId);

            var agentTeamIdPairs = _callCenterTeamRepository.GetAgentTeamIdPairs(teamIds);

            var list = (from team in teamAssignement
                        let teamName = teamNameIdPair.First(x => x.FirstValue == team.TeamId)
                        let agents = agentTeamIdPairs.Where(x => x.FirstValue == team.TeamId).Select(x => x.SecondValue).OrderBy(x => x)
                        select new HealthPlanCriteriaTeamEditModel
                        {
                            Name = teamName.SecondValue,
                            Id = team.TeamId,
                            IsFillEventCallQueue = callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan,
                            CriteriaId = team.HealthPlanCriteriaId,
                            CallQueueId = callQueue.Id,
                            HealthPlanId = criteria.HealthPlanId.Value,
                            EndDate = team.EndDate,
                            StartDate = team.StartDate,
                            IsStartDateEditable = team.StartDate > DateTime.Today,
                            Agents = agents
                        }).ToList();

            return list;
        }

        public void UpdateTeamAssignment(HealthPlanCriteriaTeamListEditModel model)
        {
            if (!model.Collection.IsNullOrEmpty())
            {
                foreach (var item in model.Collection)
                {
                    _healthPlanCriteriaTeamAssignmentRepository.UpdateTeamAssignment(item);
                }
            }
        }
    }
}