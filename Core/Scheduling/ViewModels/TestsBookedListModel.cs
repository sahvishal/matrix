using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class TestsBookedListModel : ListModelBase<TestsBookedModel, TestsBookedListModelFilter>
    {
        public override IEnumerable<TestsBookedModel> Collection { get; set; }
        public override TestsBookedListModelFilter Filter { get; set; }
    }
}
