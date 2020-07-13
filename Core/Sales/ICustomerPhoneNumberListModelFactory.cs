using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales
{
    public interface ICustomerPhoneNumberListModelFactory
    {
        CustomerPhoneNumberListModel Create(IEnumerable<FileModel> fileModels, IEnumerable<CustomerPhoneNumberUpdateUpload> phoneNumberUploads, IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair);
    }
}
