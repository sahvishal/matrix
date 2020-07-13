using Falcon.App.Core.Medicare.ViewModels;

namespace Falcon.App.Core.Medicare
{
    public interface INewResultFlowStateService
    {
        bool SyncReadyForCodingForVisit(EhrReadyforCodingViewModel readyforCodingModel, long orgRoleId, string callingMethod);
        bool RunTaskReadyForCodingForVisit(EhrReadyforCodingViewModel readyforCodingViewModel, long orgId, string callingMethod);
        bool SyncReadyForEvaluation(EhrReadyForReEvaluation model, long orgId, string callingMethod);
        bool RunTaskSyncHraCanUnsignForVisit(MedicareCanUnsignViewModel model, long orgId, string callingMethod);
    }
}
