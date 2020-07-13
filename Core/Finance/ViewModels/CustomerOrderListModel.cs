using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CustomerOrderListModel:ViewModelBase
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<CustomerOrderModel> Orders { get; set; }
    }
}
