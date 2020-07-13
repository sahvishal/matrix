namespace Falcon.App.Core.Operations
{
    public interface ICustomerShippingService
    {
        void AddFreeShippingForCustomer(long customerId, long eventId);
    }
}