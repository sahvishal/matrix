using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestPerformedListModel : ListModelBase<TestPerformedViewModel, TestPerformedListModelFilter>
    {
        public override IEnumerable<TestPerformedViewModel> Collection { get; set; }

        public override TestPerformedListModelFilter Filter { get; set; }
    }
}
