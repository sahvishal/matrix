

namespace HealthYes.Web.Core.Domain.PrintOrder.Interfaces
{
    public interface IPrintOrderItemShippingStatusRepository
    {
        PrintOrderItemShippingStatus GetById(long printOrderItemId);
        void Save(PrintOrderItemShippingStatus printOrderItemShippingStatus);
      
    }
}
