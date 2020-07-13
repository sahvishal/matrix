using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianEvaluationService
    {
        PhysicianDashboardViewModel GetPhysicianStats(long physicianId);

        ListModelBase<PhysicianReviewSummaryViewModel, PhysicianReviewSummaryListModelFilter> GetPhysicianReviewSummary(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<PhysicianReviewViewModel, PhysicianReviewListModelFilter> GetPhysicianReviews(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<PhysicianQueueViewModel, PhysicianQueueListModelFilter> GetPhysicianQueue(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<PhysicianEventQueueViewModel, PhysicianEventQueueListModelFilter> GetPhysicianEventQueue(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<PhysicianTestReviewViewModel, PhysicianTestReviewListModelFilter> GetPhysicianTestReview(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}