using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DetailOpenOrderListModel : ListModelBase<DetailOpenOrdersModel, DetailOpenOrderModelFilter>
    {
        public override DetailOpenOrderModelFilter Filter { get; set; }
        public override IEnumerable<DetailOpenOrdersModel> Collection { get; set; }
    }
}