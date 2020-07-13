using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerResultBloodLabRepository
    {
        EventCustomerResultBloodLab GetByEventCustomerResultId(long eventCustomerResultId);
        EventCustomerResultBloodLab GetByEventIdAndCustomerId(long eventId, long customerId);
        EventCustomerResultBloodLab Save(EventCustomerResultBloodLab domain);
    }
}
