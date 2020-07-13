using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DailyRecapListModel : ListModelBase<DailyRecapModel, DailyRecapModelFilter>
    {
        public override IEnumerable<DailyRecapModel> Collection { get; set; }
        public override DailyRecapModelFilter Filter { get; set; }
    }
}
