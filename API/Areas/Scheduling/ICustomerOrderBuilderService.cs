using API.Areas.Scheduling.Models;

namespace API.Areas.Scheduling
{
    public interface ICustomerOrderBuilderService
    {
        CustomerOrderDetail GetCustomerOrderDetails(long customerId, long eventId);
        EventPackageTestModel GetEventPackageTestModel(long eventId);
    }
}