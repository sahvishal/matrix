using System.Collections.Generic;

namespace Falcon.App.Core.Users.ViewModels
{
    public class OrganizationListModel
    {
        public IEnumerable<OrganizationBasicInfoModel> Organizations { get; set; }
    }
}