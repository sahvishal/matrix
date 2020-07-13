namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareRapsListModel
    {
        public string OrganizationName { get; set; }
        public string TimeToken { get; set; }
        public MedicareRapsViewModel[] Raps { get; set; }
    }
}
