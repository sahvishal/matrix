using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DailyPatientRecapListModel : ListModelBase<DailyPatientRecapModel, DailyPatientRecapModelFilter>
    {
        public override IEnumerable<DailyPatientRecapModel> Collection { get; set; }
        public override DailyPatientRecapModelFilter Filter { get; set; }
    }
}
