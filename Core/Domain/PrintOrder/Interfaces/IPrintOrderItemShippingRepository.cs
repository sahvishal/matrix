

namespace HealthYes.Web.Core.Domain.PrintOrder.Interfaces
{
    public interface IPrintOrderItemShippingRepository
    {
        PrintOrderItemTracking GetById(long printOrderItemShippingId);
        void Save(PrintOrderItemTracking printOrderItemShipping);

    }
}
