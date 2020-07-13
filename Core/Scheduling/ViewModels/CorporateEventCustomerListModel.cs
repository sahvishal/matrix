using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CorporateEventCustomerListModel : ListModelBase<CorporateEventCustomersModel, CorporateEventCustomerModelFilter>
    {
        public override IEnumerable<CorporateEventCustomersModel> Collection
        {
            get;
            set;
        }
        public override CorporateEventCustomerModelFilter Filter
        {
            get;
            set;
        }
    }

}
