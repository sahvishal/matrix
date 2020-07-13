using API.Areas.Scheduling.Models;

namespace API.Areas.Scheduling
{
    public interface IUpdateCustomerPackageService
    {
        void ChangePackage(CustomerOrderDetail customerOrderDetail);
    }
}