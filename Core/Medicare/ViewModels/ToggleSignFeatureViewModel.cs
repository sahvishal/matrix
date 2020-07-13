namespace Falcon.App.Core.Medicare.ViewModels
{
    public class ToggleSignFeatureViewModel
    {
        public MedicareCanUnsignViewModel CanUnsignModel { get; set; }
        public string AuthToken { get; set; }
        public string OrganizationName { get; set; }
    }
}