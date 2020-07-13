using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IManualAuditAndEnteryService
    {
        void SetPostAuditEvaluation(PostEvaluationEditModel model);
    }
}
