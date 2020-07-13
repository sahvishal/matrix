namespace Falcon.App.Core.Users.ViewModels
{
    public class RoleViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public bool IsGlobal { get; set; }
        public bool IsSystemRole { get; set; }

        public long ParentId { get; set; }
        public string ParentRole { get; set; }
        
        public int UserCount { get; set; }
    }
}