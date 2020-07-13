namespace Falcon.App.Core.Operations.ViewModels
{
    public class PodTeamEditModel
    {
        public long Id { get; set; }
        public long PodId { get; set; }
        public long OrganizationRoleUserId { get; set; }
        public string Name { get; set; }
        public long EventRoleId { get; set; }
        public string EventRoleName { get; set; }        
    }
}
