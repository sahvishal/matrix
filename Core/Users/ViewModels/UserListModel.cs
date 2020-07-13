using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class UserListModel : ListModelBase<UserBasicInfoModel, UserListModelFilter>
    {
        public override IEnumerable<UserBasicInfoModel> Collection { get; set; }

        public override UserListModelFilter Filter { get; set; }
    }
}
