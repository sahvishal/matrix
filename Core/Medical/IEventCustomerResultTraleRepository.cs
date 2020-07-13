using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerResultTraleRepository
    {
        void Save(EventCustomerResultTrale domainObject);
        EventCustomerResultTrale GetByEventCustomerResultId(long eventcusomerResultId);
        List<EventCustomerResultTrale> GetByEventCustomerResultIds(IEnumerable<long> eventCustomerResultIds);
    }
}