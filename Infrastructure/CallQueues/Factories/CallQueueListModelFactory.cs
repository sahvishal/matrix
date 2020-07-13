using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class CallQueueListModelFactory : ICallQueueListModelFactory
    {
        private readonly ISettings _settings;

        public CallQueueListModelFactory(ISettings settings)
        {
            _settings = settings;
        }

        public CallQueueListModel Create(IEnumerable<CallQueue> callQueues, IEnumerable<CallQueueCriteria> callQueueCriterias, IEnumerable<Criteria> criterias, IEnumerable<CallQueueAssignment> callQueueAssignments,
            IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<OrderedPair<long, long>> callQueueIdTotalCustomersInQueuePairs, IEnumerable<OrderedPair<long, long>> callQueueIdTotalCustomersPairs,
            IEnumerable<OrderedPair<long, long>> callQueueIdTotalCustomersContactedPairs)
        {
            var model = new CallQueueListModel();
            var collection = new List<CallQueueViewModel>();

            callQueues.ToList().ForEach(cq =>
            {
                var inQueuePair = callQueueIdTotalCustomersInQueuePairs.SingleOrDefault(pair => pair.FirstValue == cq.Id);
                var totalCustomersPair = callQueueIdTotalCustomersPairs.SingleOrDefault(pair => pair.FirstValue == cq.Id);
                var customersContactedPair = callQueueIdTotalCustomersContactedPairs.SingleOrDefault(pair => pair.FirstValue == cq.Id);
                var percentage = 0m;
                if (totalCustomersPair != null && customersContactedPair != null && totalCustomersPair.SecondValue > 0)
                {
                    percentage = (Convert.ToDecimal(customersContactedPair.SecondValue) / Convert.ToDecimal(totalCustomersPair.SecondValue)) * 100;
                    percentage = Math.Round(percentage, 2);
                }

                var callQueueModel = new CallQueueViewModel
                {
                    Id = cq.Id,
                    Name = cq.Name,
                    Description = cq.Description,
                    DateCreated = cq.DataRecorderMetaData.DateCreated,
                    IsActive = cq.IsActive,
                    TotalCustomersInQueue = inQueuePair != null ? inQueuePair.SecondValue : 0,
                    CustomerContacted = percentage,
                    Criterias = CreateCallQueueCriteriaViewModels(callQueueCriterias, criterias, cq.Id),
                    Assignments = CreateCallQueueAssignmentViewModels(callQueueAssignments, idNamePairs, cq.Id)
                };
                collection.Add(callQueueModel);
            });

            model.Collection = collection;
            return model;
        }

        private IEnumerable<CallQueueCriteriaViewModel> CreateCallQueueCriteriaViewModels(IEnumerable<CallQueueCriteria> callQueueCriterias, IEnumerable<Criteria> criterias, long callQueueId)
        {
            if (callQueueCriterias.IsNullOrEmpty())
                return null;

            var queueCriterias = callQueueCriterias.Where(cqc => cqc.CallQueueId == callQueueId).Select(cqc => cqc).ToArray();
            var criteriaList = new List<CallQueueCriteriaViewModel>();

            foreach (var queueCriteria in queueCriterias)
            {
                var model = new CallQueueCriteriaViewModel()
                {
                    Criteria = criterias.Where(c => c.Id == queueCriteria.CriteriaId).Select(c => c.Name).Single(),
                    Radius = queueCriteria.Radius,
                    Zipcode = queueCriteria.Zipcode,
                    Condition = queueCriteria.Condition
                };

                criteriaList.Add(model);
            }
            return criteriaList;
        }

        private IEnumerable<CallQueueAssignmentViewModel> CreateCallQueueAssignmentViewModels(IEnumerable<CallQueueAssignment> callQueueAssignments, IEnumerable<OrderedPair<long, string>> idNamePairs, long callQueueId)
        {
            if (callQueueAssignments.IsNullOrEmpty())
                return null;

            var queueAssignments = callQueueAssignments.Where(cqa => cqa.CallQueueId == callQueueId).Select(cqa => cqa).ToArray();
            var assignmentList = new List<CallQueueAssignmentViewModel>();

            foreach (var callQueueAssignment in queueAssignments)
            {
                var model = new CallQueueAssignmentViewModel()
                {
                    Name = idNamePairs.Where(inp => inp.FirstValue == callQueueAssignment.AssignedOrgRoleUserId).Select(inp => inp.SecondValue).Single(),
                    Percentage = callQueueAssignment.Percentage
                };
                assignmentList.Add(model);
            }

            return assignmentList;
        }


        public HealthPlanCallQueueListModel CreateHealthPlanCallQueueList(IEnumerable<HealthPlanCallQueueCriteria> healthPlanCallQueueCriterias, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<CallQueue> callQueues, IEnumerable<CorporateAccount> healthPlans, IEnumerable<HealthPlanCriteriaAssignment> healthPlanCriteriaAssignments, IEnumerable<Campaign> campaigns,
            IEnumerable<HealthPlanCriteriaTeamAssignment> healthPlanCriteriaTeamAssignment, IEnumerable<OrderedPair<long, string>> teamIdNamePairs, IEnumerable<OrderedPair<long, long>> criteriaCustomerCountPairs,
            IEnumerable<OrderedPair<long, DateTime>> criteriaDirectMailDates, bool showAssignmentMetaData = false)
        {
            var model = new HealthPlanCallQueueListModel();
            var collection = new List<HealthPlanCallQueueViewModel>();

            healthPlanCallQueueCriterias.ToList().ForEach(hcq =>
           {
               string healthPlan = string.Empty;

               if (hcq.HealthPlanId.HasValue)
                   healthPlan = healthPlans.Single(x => x.Id == hcq.HealthPlanId).Name;

               var healthPlanCallQueue = callQueues.Single(x => x.Id == hcq.CallQueueId).Name;

               var createdBy = string.Empty;
               DateTime? modifiedOn = null;

               if (hcq.DataRecorderMetaData.DataRecorderModifier != null)
               {
                   createdBy = idNamePairs.Single(x => x.FirstValue == hcq.DataRecorderMetaData.DataRecorderModifier.Id).SecondValue;
               }
               else
               {
                   createdBy = idNamePairs.Single(x => x.FirstValue == hcq.DataRecorderMetaData.DataRecorderCreator.Id).SecondValue;
               }

               string[] assignment = null;
               string[] teamAssignment = null;

               if (healthPlanCriteriaAssignments != null && healthPlanCriteriaAssignments.Any())
               {
                   var criteriaAssignements = healthPlanCriteriaAssignments.Where(x => x.HealthPlanCriteriaId == hcq.Id).ToArray();
                   if (criteriaAssignements.Any())
                   {
                       var criteriaAssignementRoleIds = criteriaAssignements.Select(s => s.AssignedToOrgRoleUserId);
                       assignment = idNamePairs.Where(x => criteriaAssignementRoleIds.Contains(x.FirstValue)).Select(s => s.SecondValue).ToArray();
                       teamAssignment = null;

                       if (showAssignmentMetaData)
                       {
                           modifiedOn = criteriaAssignements.Max(x => x.DateCreated);
                           var createdById = criteriaAssignements.First().CreatedBy;
                           createdBy = idNamePairs.Single(x => x.FirstValue == createdById).SecondValue;
                       }
                   }
               }

               if (healthPlanCriteriaTeamAssignment != null && healthPlanCriteriaTeamAssignment.Any())
               {
                   var criteriaAssignementTeams = healthPlanCriteriaTeamAssignment.Where(x => x.HealthPlanCriteriaId == hcq.Id).ToArray();
                   if (criteriaAssignementTeams.Any())
                   {
                       var criteriaAssignementTeamIds = criteriaAssignementTeams.Select(s => s.TeamId);
                       teamAssignment = teamIdNamePairs.Where(x => criteriaAssignementTeamIds.Contains(x.FirstValue)).Select(x => x.SecondValue).ToArray();
                       assignment = null;

                       if (showAssignmentMetaData)
                       {
                           modifiedOn = criteriaAssignementTeams.Max(x => x.DateCreated);
                           var createdById = criteriaAssignementTeams.First().CreatedBy;
                           createdBy = idNamePairs.Single(x => x.FirstValue == createdById).SecondValue;
                       }
                   }
               }


               var category = string.Empty;
               if (callQueues != null && callQueues.Any())
               {
                   category = callQueues.Single(x => x.Id == hcq.CallQueueId).Category;
               }
               Campaign campaign = null;
               if (!campaigns.IsNullOrEmpty() && hcq.CampaignId.HasValue)
               {
                   campaign = campaigns.SingleOrDefault(x => x.Id == hcq.CampaignId.Value);
               }


               DateTime? startDate = null;
               DateTime? endDate = null;

               if (category == HealthPlanCallQueueCategory.NoShows)
               {
                   startDate = hcq.StartDate.HasValue ? hcq.StartDate.Value : DateTime.Now.AddDays(-_settings.NoPastAppointmentInDays);
                   endDate = hcq.EndDate.HasValue ? hcq.EndDate.Value : DateTime.Now;
               }

               var directMailDates = criteriaDirectMailDates.Where(x => x.FirstValue == hcq.Id).Select(x => x.SecondValue);

               var criteriaCustomerCountPair = criteriaCustomerCountPairs.FirstOrDefault(x => x.FirstValue == hcq.Id);

               var criteria = new HealthPlanCallQueueCriteriaViewModel()
               {
                   Category = category,
                   Radius = hcq.Radius.HasValue ? hcq.Radius.Value : 0,
                   Zipcode = hcq.ZipCode,
                   NoOfDays = hcq.NoOfDays,
                   RoundOfCalls = hcq.RoundOfCalls,
                   Percentage = (int)hcq.Percentage,
                   StartDate = startDate,
                   EndDate = endDate,
                   CampaignName = campaign != null ? campaign.Name : string.Empty,
                   CampaignId = campaign != null ? campaign.Id : 0,
                   IsQueueGenerated = hcq.IsQueueGenerated,
                   CriteriaName = hcq.CriteriaName,
                   DirectMailDates = directMailDates
               };
               var dateRecorderMetadata = hcq.DataRecorderMetaData;

               var callQueueModel = new HealthPlanCallQueueViewModel
               {
                   Id = hcq.Id,
                   CallQueueId = hcq.CallQueueId,
                   HealthPlan = healthPlan,
                   HealthPlanCallQueue = healthPlanCallQueue,
                   ModifiedOn = modifiedOn ?? dateRecorderMetadata.DateModified ?? hcq.DataRecorderMetaData.DateCreated,
                   ModifiedBy = createdBy,
                   Criterias = criteria,
                   Assignments = assignment,
                   IsDefault = hcq.IsDefault,
                   TeamAssignment = teamAssignment,
                   CustomerCount = criteriaCustomerCountPair != null ? criteriaCustomerCountPair.SecondValue : 0
               };

               collection.Add(callQueueModel);

           });
            model.Collection = collection;
            return model;
        }

    }
}
