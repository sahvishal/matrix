using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface ICustomerPhoneNumberUpdateUploadLogRepository
    {
        CustomerPhoneNumberUpdateUploadLog Save(CustomerPhoneNumberUpdateUploadLog domain);
    }
}
