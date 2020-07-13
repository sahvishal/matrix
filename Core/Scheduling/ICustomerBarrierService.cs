using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomerBarrierService
    {
        BarrierEditModel GetCustomerBarrier(long eventCustomerId);
        void Save(BarrierEditModel model);
    }
}
