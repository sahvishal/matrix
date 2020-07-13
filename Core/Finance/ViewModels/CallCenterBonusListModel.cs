using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CallCenterBonusListModel : ListModelBase<CallCenterBonusViewModel, CallCenterBonusFilter>
    {
        public override IEnumerable<CallCenterBonusViewModel> Collection { get; set; }
        public override CallCenterBonusFilter Filter { get; set; }
    }
}

