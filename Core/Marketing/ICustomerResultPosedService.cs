using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Marketing
{
    public interface ICustomerResultPosedService
    {
        CustomerResultPosted GetCusterResultPosted(long customerId);
    }
}