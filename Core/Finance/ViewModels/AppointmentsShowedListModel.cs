using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class AppointmentsShowedListModel : ListModelBase<AppointmentsShowedViewModel, CallCenterBonusFilter>
    {
        public override IEnumerable<AppointmentsShowedViewModel> Collection { get; set; }
        public override CallCenterBonusFilter Filter { get; set; }
    }


}