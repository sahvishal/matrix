using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface IPhysicianEvaluationRepository
    {
        PhysicianEvaluation Save(PhysicianEvaluation physicianEvaluation);
        IEnumerable<PhysicianEvaluation> GetPhysicianEvaluation(long eventCustomerId);
        PhysicianEvaluation GetPhysicianEvaluationinTransaction(long eventCustomerId, long physicianId);
        IEnumerable<PhysicianEvaluation> GetPhysicianEvaluationbyPhysician(long physicianId);
        void SaveCustomerforReviewSkip(long eventCustomerId, long physicianId, long orgRoleUserId, bool isSkipEvaluation);
        bool IsMarkedReviewSkip(long eventCustomerId);
        void DeleteSkipReviewRecord(long eventCustomerId);
        bool AccquirePhysicianEvaluationLock(long eventCustomerId, long physicianId);
        bool ReleasePhysicianEvaluationLock(long eventCustomerId);
        void ReleasePhysicianEvaluationOldLocks();

        void Delete(long eventCustomerId, long physicianId);
        void Delete(long id);

        IEnumerable<long> GetPhysicianIds(int pageNumber, int pageSize, PhysicianReviewSummaryListModelFilter filter, out int totalRecords);

        IEnumerable<OrderedPair<long, double>> GetPhysicianIdAverageReviewTimePair(IEnumerable<long> physicianIds, PhysicianReviewSummaryListModelFilter filter);

        IEnumerable<PhysicianEvaluation> GetEvaluations(int pageNumber, int pageSize, PhysicianReviewListModelFilter filter, out int totalRecords);

        IEnumerable<long> GetPhysicianIdsForTestReviewed(int pageNumber, int pageSize, PhysicianTestReviewListModelFilter filter, out int totalRecords);

        IEnumerable<long> GetEventCustomerIdsForHalfStudy(IEnumerable<long> eventCustomerIds);

        PhysicianEvaluation GetPhysicianEvaluationbyEventIdCustomerId(long eventId, long customerId);
        IEnumerable<PhysicianEvaluation> GetPhysicianEvaluation(IEnumerable<long> eventCustomerIds);
        IEnumerable<CustomerSkipReview> GetCustomerSkipReviews(IEnumerable<long> eventCustomerIds);
    }
}
