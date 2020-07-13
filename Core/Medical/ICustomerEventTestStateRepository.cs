using System.Collections.Generic;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerEventTestStateRepository
    {
        IEnumerable<CustomerEventTestState> GetCustomerEventTestState(long[] customerEventScreeningTestId);

        IEnumerable<CustomerEventTestState> GetForLabInboundReport(LabsInboundFilter filter, int pageNumber, int pageSize, out int totalRecords);

        bool IsPatientCritical(long eventCustomerId);

        bool IsPatientCriticalForHIPTest(long eventId, long customerId);
    }
}