namespace Falcon.App.Core.Medicare.ViewModels
{
    public class EhrToggleReadyForCodingSyncModel
    {
        public EhrReadyforCodingViewModel ReadyForCodingModel { get; set; }
        public string AuthToken { get; set; }
        public string OrganizationName { get; set; }
    }
}