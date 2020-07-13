using Falcon.App.Core.Medical.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerResultBloodLabParserRepository
    {
        EventCustomerResultBloodLabParser Save(EventCustomerResultBloodLabParser domain);
        EventCustomerResultBloodLabParser GetByEventCustomerResultId(long eventCustomerResultId);
        EventCustomerResultBloodLabParser GetByEventIdAndCustomerId(long eventId, long customerId);
    }
}
