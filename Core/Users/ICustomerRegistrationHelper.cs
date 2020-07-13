using System.Collections.Generic;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface ICustomerRegistrationHelper
    {
        List<OrderedPair<long, string>> PrepareNdcPairs(CorporateCustomerEditModel model);
    }
}
