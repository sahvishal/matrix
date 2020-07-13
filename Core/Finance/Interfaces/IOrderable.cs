using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderable
    {
        long Id { get; }

        decimal Price { get; }
        string  Description { get; }
        
        OrderItemType OrderItemType { get; }
    }
}