using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales
{
    public interface IContactRepository
    {
        Contact GetContactForHost(long hostId);
    }
}
