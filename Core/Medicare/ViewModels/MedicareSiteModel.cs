namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareSiteModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public string ParentOrganizationName { get; set; }
        public bool ShowHraQuestionnaire { get; set; }
        public long AccountId { get; set; }
    }
}
