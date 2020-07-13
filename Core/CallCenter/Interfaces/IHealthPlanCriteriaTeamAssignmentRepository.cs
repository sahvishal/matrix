using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter.Interfaces
{
    public interface IHealthPlanCriteriaTeamAssignmentRepository
    {
        void Save(IEnumerable<HealthPlanCriteriaTeamAssignment> domain);
        IEnumerable<HealthPlanCriteriaTeamAssignment> GetTeamAssignments(long healthPlanCriteriaId);
        void DeleteAssignmentsForCriteria(long criteriaId);
        IEnumerable<HealthPlanCriteriaTeamAssignment> GetByCriteriaIds(IEnumerable<long> criteriaIds);
        bool IsTeamOverlapped(HealthPlanCriteriaTeamEditModel model);
        void UpdateTeamAssignment(HealthPlanCriteriaTeamEditModel model);
    }
}