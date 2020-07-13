using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CustomerCdContentTrackingListModel:ListModelBase<CustomerCdContentTrackingModel,CustomerCdConentTrackingModelFilter>
    {
        public override IEnumerable<CustomerCdContentTrackingModel> Collection { get; set; }

        public override CustomerCdConentTrackingModelFilter Filter { get; set; }
        
    }
}
