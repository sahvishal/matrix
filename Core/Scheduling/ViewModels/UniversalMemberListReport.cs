using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class UniversalMemberListReport : ListModelBase<UniversalMemberViewModel, UniversalMemberListModelFilter>
    {
        public override IEnumerable<UniversalMemberViewModel> Collection
        {
            get;
            set;
        }

        public override UniversalMemberListModelFilter Filter
        {
            get;
            set;
        }
    }
}