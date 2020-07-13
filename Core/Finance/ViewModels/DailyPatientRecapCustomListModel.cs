using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DailyPatientRecapCustomListModel: ListModelBase<DailyPatientRecapCustomModel, DailyPatientRecapModelFilter>
    {
        public override IEnumerable<DailyPatientRecapCustomModel> Collection { get; set; }
        public override DailyPatientRecapModelFilter Filter { get; set; }
    }
}
