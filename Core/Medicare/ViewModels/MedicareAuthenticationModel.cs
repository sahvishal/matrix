namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareAuthenticationModel
    {
        public string UserToken { get; set; }
        public long CustomerId { get; set; }
        public string OrgName { get; set; }
        public string Tag { get; set; }
        public bool IsForAdmin { get; set; }
        public string RoleAlias { get; set; }
    }
}
