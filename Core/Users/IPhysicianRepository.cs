using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IPhysicianRepository
    {
        Physician GetPhysician(long orgRoleUserId);
        Physician GetResultEvaluatingPhysician(long customerId, long eventId);
        bool CanSeeEarnings(long physicianId);
        bool IsAuthorizationPending(long physicianId);
        long[] GetAllPhysicianIdsforaMedicalVendor(long medicalVendorId);
        decimal GetCurrentPayrate(long physicianId);
        Physician SavePhysician(Physician physician);
        IEnumerable<OrderedPair<long, string>> GetPhysicianSpecilizationIdNamePairs();
        IEnumerable<OrderedPair<long, string>> GetAvailablePhysiciansIdNamePairForEvent(long eventId);
        IEnumerable<OrderedPair<long, string>> GetAvailablePhysiciansIdNamePairForCustomer(long eventCustomerId);
        PhysicianEvaluationQueueSummary GetEventCustomerIdForPhysicianEvaluation(long physicianId);
        PhysicianEvaluationQueueSummary GetEventCustomerIdForOverReadPhysicianEvaluation(long physicianId);
        long GetOverreadPhysician(long eventCustomerId);
        IEnumerable<long> GetPermittedTestIdsForPhysician(long physicianId);
        bool IsValidPhysicianAssignmentForEvent(long physicianId, long? overReadPhysicianId, long eventId);

        bool IsValidPhysicianAssignmentForEventCustomer(long physicianId, long? overReadPhysicianId,
                                                        long eventCustomerId);

        bool IsDefaultPhysicianAssignedForStates(IEnumerable<long> stateIds, long currentPhysicianId);
        long GetDefaultPhysicianforEvent(long eventId);

        int GetReviewsCountByPhysicianId(long physicianId, PhysicianReviewSummaryListModelFilter filter, bool isReEvelaued);
        int GetOverReadsCountByPhysicianId(long physicianId, PhysicianReviewSummaryListModelFilter filter, bool isReEvelaued);
        int GetAvailablePrimaryEvaluationCountByPhysicianId(long physicianId);
        int GetAvailableOverReadEvaluationCountByPhysicianId(long physicianId);
        int GetPriorityPrimaryEvaluationCountByPhysicianId(long physicianId);
        int GetPriorityOverReadEvaluationCountByPhysicianId(long physicianId);
        bool IsPhysicianAssignedForFutureEvent(long physicianId);

        IEnumerable<PhysicianQueueListItem> GetQueueforFilter(int pageNumber, int pageSize, PhysicianQueueListModelFilter filter, out int totalRecords);
        IEnumerable<PhysicianEventQueueListItem> GetEventQueueforFilter(int pageNumber, int pageSize, PhysicianEventQueueListModelFilter filter, out int totalRecords);
        PhysicianTestReviewStats GetTestReviewedCountPairsByPhysicianId(long physicianId, PhysicianTestReviewListModelFilter filter);

        bool IsValidPhysicianAssignmentForRestrictedEvaluationOnEvent(long eventId, IEnumerable<PhsicianEventTestViewModel> selectedTests);
    }
}
