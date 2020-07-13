using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class GapsClosureListModel : ListModelBase<GapsClosureModel, GapsClosureModelFilter>
    {
        public override IEnumerable<GapsClosureModel> Collection { get; set; }
        public override GapsClosureModelFilter Filter { get; set; }
    }
}
