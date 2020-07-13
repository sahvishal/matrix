using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class RefundRequestListModel : ListModelBase<RefundRequestBasicInfoModel, RefundRequestListModelFilter>
    {
        public override IEnumerable<RefundRequestBasicInfoModel> Collection { get; set; }

        public override RefundRequestListModelFilter Filter { get; set; }
    }
}