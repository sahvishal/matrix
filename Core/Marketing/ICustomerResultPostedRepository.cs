using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Marketing
{
    public interface ICustomerResultPostedRepository
    {
        CustomerResultPosted GetByCustomerId(long customerId);
        CustomerResultPosted Save(CustomerResultPosted customerResultPosted);
    }
}
