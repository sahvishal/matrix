using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class MemberStatusListModel : ListModelBase<MemberStatusModel, MemberStatusListModelFilter>
    {
        public override IEnumerable<MemberStatusModel> Collection
        {
            get;
            set;
        }

        public override MemberStatusListModelFilter Filter
        {
            get;
            set;
        }
    }
}