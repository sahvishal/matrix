using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestListModel : ListModelBase<TestViewModel, TestListModelFilter>
    {
        public override IEnumerable<TestViewModel> Collection { get; set; }

        public override TestListModelFilter Filter { get; set; }
        
    }
}
