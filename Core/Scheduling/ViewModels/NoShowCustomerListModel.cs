using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class NoShowCustomerListModel : ListModelBase<NoShowCustomerModel, NoShowCustomerModelFilter> {
        public override IEnumerable<NoShowCustomerModel> Collection { get; set; }
        public override NoShowCustomerModelFilter Filter { get; set; }
    }
}