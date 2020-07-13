namespace Falcon.App.Core.Medicare.ViewModels
{
    public class EhrNpReEvaluationModel
    {
        public EhrReadyForReEvaluation ReEvalModel { get; set; }
        public string AuthToken { get; set; }
        public string OrganizationName { get; set; }
    }
}