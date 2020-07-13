using System.Collections.Generic;

namespace Falcon.App.Core.Users.ViewModels
{
    public class RoleListModel
    {
        public IEnumerable<RoleViewModel> Collection { get; set; }

        public RoleListModelFilter Filter { get; set; }
    }
}