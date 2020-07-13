using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CustomerPhoneNumberListModel
    {
        public IEnumerable<CustomerPhoneNumberUpdateUploadViewModel> Collection { get; set; }
        public CustomerPhoneNumberUpdateModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
