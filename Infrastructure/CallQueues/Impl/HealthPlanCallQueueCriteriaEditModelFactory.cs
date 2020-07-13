using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanCallQueueCriteriaEditModelFactory : IHealthPlanCallQueueCriteriaEditModelFactory
    {

        public HealthPlanCallQueueCriteriaEditModel DomainToModel(HealthPlanCallQueueCriteria domain)
        {
            return new HealthPlanCallQueueCriteriaEditModel
            {
                Id = domain.Id,
                CallQueueId = domain.CallQueueId,
                HealthPlanId = domain.HealthPlanId.HasValue ? domain.HealthPlanId.Value : 0,
                Radius = domain.Radius.HasValue ? domain.Radius.Value : 0,
                Zipcode = domain.ZipCode,
                NoOfDays = domain.NoOfDays,
                NoOfDaysOfEvents = domain.NoOfDays,
                RoundOfCalls = domain.RoundOfCalls,
                StartDate = domain.StartDate,
                EndDate = domain.EndDate,
                Percentage = (int)domain.Percentage,
                CriteriaName = domain.CriteriaName,
                LanguageId = domain.LanguageId
            };
        }

        public HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForFillEvent(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId)
        {
            return new HealthPlanCallQueueCriteria
            {
                CallQueueId = model.CallQueueId,
                DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, DateTime.Now),
                HealthPlanId = model.HealthPlanId,
                IsQueueGenerated = false,
                NoOfDays = model.NoOfDaysOfEvents.HasValue ? model.NoOfDaysOfEvents.Value : -1,
                Percentage = model.Percentage.HasValue ? model.Percentage.Value : 0,
                CriteriaName = model.CriteriaName
            };
        }

        public HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForCallRound(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId)
        {
            return new HealthPlanCallQueueCriteria
            {
                CallQueueId = model.CallQueueId,
                DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, DateTime.Now),
                HealthPlanId = model.HealthPlanId,
                IsQueueGenerated = false,
                NoOfDays = model.NoOfDays.HasValue ? model.NoOfDays.Value : 0,
                RoundOfCalls = model.RoundOfCalls.HasValue ? model.RoundOfCalls.Value : -1,
                CriteriaName = model.CriteriaName
            };
        }

        public HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForZipRadius(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId)
        {
            return new HealthPlanCallQueueCriteria
            {
                CallQueueId = model.CallQueueId,
                DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, DateTime.Now),
                HealthPlanId = model.HealthPlanId,
                IsQueueGenerated = false,
                Radius = model.Radius,
                ZipCode = model.Zipcode,
                CriteriaName = model.CriteriaName
            };
        }

        public HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForNoShow(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId)
        {
            return new HealthPlanCallQueueCriteria
            {
                CallQueueId = model.CallQueueId,
                DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, DateTime.Now),
                HealthPlanId = model.HealthPlanId,
                IsQueueGenerated = false,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CriteriaName = model.CriteriaName
            };
        }

        public IEnumerable<HealthPlanCriteriaAssignment> GetHealthPlanCriteriaAssignment(IEnumerable<CallQueueAssignmentEditModel> assignments, long healthplanCriteriaId, long orgRoleUserId)
        {
            if (!assignments.IsNullOrEmpty())
            {
                var healthPlanCriteriaAssignments = new List<HealthPlanCriteriaAssignment>();
                assignments.ToList().ForEach(x => healthPlanCriteriaAssignments.Add(new HealthPlanCriteriaAssignment()
                {
                    AssignedToOrgRoleUserId = x.AssignedOrgRoleUserId,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                    HealthPlanCriteriaId = healthplanCriteriaId,
                    DateCreated = DateTime.Now,
                    CreatedBy = orgRoleUserId
                }));
                return healthPlanCriteriaAssignments;
            }
            return null;
        }

        public IEnumerable<HealthPlanCriteriaAssignment> GetHealthPlanCriteriaAssignmentForMailRound(IEnumerable<CallQueueAssignmentEditModel> assignments, IEnumerable<HealthPlanCallQueueCriteria> healthPlanCallQueueCriterias, long orgRoleUserId)
        {
            if (!assignments.IsNullOrEmpty() && !healthPlanCallQueueCriterias.IsNullOrEmpty())
            {
                var healthPlanCriteriaAssignments = new List<HealthPlanCriteriaAssignment>();
                foreach (var healthPlanCallQueueCriteria in healthPlanCallQueueCriterias)
                {
                    foreach (var assignment in assignments)
                    {
                        healthPlanCriteriaAssignments.Add(new HealthPlanCriteriaAssignment()
                        {
                            AssignedToOrgRoleUserId = assignment.AssignedOrgRoleUserId,
                            StartDate = assignment.StartDate,
                            EndDate = assignment.EndDate,
                            HealthPlanCriteriaId = healthPlanCallQueueCriteria.Id,
                            DateCreated = DateTime.Now,
                            CreatedBy = orgRoleUserId
                        });
                    }
                }

                return healthPlanCriteriaAssignments;
            }
            return null;
        }

        public IEnumerable<HealthPlanCriteriaTeamAssignment> GetHealthPlanCriteriaTeamAssignmentForMailRound(IEnumerable<HealthPlanCriteriaTeamAssignmentEditModel> teamAssignment, IEnumerable<HealthPlanCallQueueCriteria> healthPlanCallQueueCriterias,
            long orgRoleUserId)
        {
            if (!teamAssignment.IsNullOrEmpty())
            {
                var healthPlanCriteriaTeamAssignments = new List<HealthPlanCriteriaTeamAssignment>();
                foreach (var healthPlanCallQueueCriteria in healthPlanCallQueueCriterias)
                {
                    foreach (var assignment in teamAssignment)
                    {
                        var data = new HealthPlanCriteriaTeamAssignment
                        {
                            HealthPlanCriteriaId = healthPlanCallQueueCriteria.Id,
                            TeamId = assignment.TeamId,
                            StartDate = assignment.StartDate,
                            EndDate = assignment.EndDate,
                            DateCreated = DateTime.Now,
                            CreatedBy = orgRoleUserId
                        };
                        healthPlanCriteriaTeamAssignments.Add(data);
                    }
                }
                return healthPlanCriteriaTeamAssignments;
            }
            return null;
        }

        public IEnumerable<HealthPlanCriteriaTeamAssignment> GetHealthPlanCriteriaTeamAssignment(IEnumerable<HealthPlanCriteriaTeamAssignmentEditModel> teamAssignment, HealthPlanCallQueueCriteria criteria, long orgRoleUserId)
        {
            var collection = new List<HealthPlanCriteriaTeamAssignment>();
            foreach (var assignment in teamAssignment)
            {
                var data = new HealthPlanCriteriaTeamAssignment
                {
                    HealthPlanCriteriaId = criteria.Id,
                    TeamId = assignment.TeamId,
                    StartDate = assignment.StartDate,
                    EndDate = assignment.EndDate,
                    DateCreated = DateTime.Now,
                    CreatedBy = orgRoleUserId
                };
                collection.Add(data);
            }
            return collection;
        }

        public HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForConfirmation(HealthPlanCallQueueCriteriaEditModel model, long orgRoleId)
        {
            return new HealthPlanCallQueueCriteria
            {
                CallQueueId = model.CallQueueId,
                DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, DateTime.Now),
                HealthPlanId = model.HealthPlanId,
                IsQueueGenerated = false,
                CriteriaName = model.CriteriaName,
                LanguageId = model.LanguageId
            };
        }

        public HealthPlanCallQueueCriteria GetHealthPlanCallQueueCriteriaForMailRound(HealthPlanCallQueueCriteriaEditModel model, long campaignId, long orgRoleId)
        {
            return new HealthPlanCallQueueCriteria
                {
                    CallQueueId = model.CallQueueId,
                    DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, DateTime.Now),
                    HealthPlanId = model.HealthPlanId,
                    IsQueueGenerated = true,
                    CampaignId = campaignId
                };
        }
    }
}
