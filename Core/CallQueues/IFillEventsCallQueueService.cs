
using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.CallQueues
{
    public interface IFillEventsCallQueueService
    {
        IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, SystemGeneratedCallQueueCriteria criteria);

        IEnumerable<OrderedPair<long, long>> GetHealthPlanCallQueueCustomers(long callQueueId, HealthPlanCallQueueCriteria criteria, CorporateAccount healthPlan, int pastAppointmentDays, ILogger logger);
    }
}
