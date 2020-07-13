using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestNotPerformedListModel : ListModelBase<TestNotPerformedViewModel, TestNotPerformedListModelFilter>
    {
        public override IEnumerable<TestNotPerformedViewModel> Collection { get; set; }

        public override TestNotPerformedListModelFilter Filter { get; set; }
    }
}