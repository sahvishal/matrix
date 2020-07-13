

namespace HealthYes.Web.Core.Domain.PrintOrder.Interfaces
{
    public interface IPrintOrderRepository
    {
        PrintOrderItemShipping GetById(long printOrderItemShippingId);
        void Save(PrintOrderItemShipping printOrderItemShipping);

    }
}
