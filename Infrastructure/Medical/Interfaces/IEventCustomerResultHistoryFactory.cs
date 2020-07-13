using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Interfaces
{
    public interface IEventCustomerResultHistoryFactory
    {
        EventCustomerResultHistoryEntity CreateEnity(EventCustomerResultEntity entity);
        EventCustomerResultHistory CreateDomain(EventCustomerResult domain);
    }
}
