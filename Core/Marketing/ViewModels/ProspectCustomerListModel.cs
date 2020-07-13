using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class ProspectCustomerListModel : ListModelBase<ProspectCustomerBasicInfoModel, ProspectCustomerListModelFilter>
    {
        public override IEnumerable<ProspectCustomerBasicInfoModel> Collection { get; set; }
        public override ProspectCustomerListModelFilter Filter { get; set; }
    }
}