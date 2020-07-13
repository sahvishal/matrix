using System.Collections.Generic;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IEventCustomerDiagnosisRepository
    {
        IEnumerable<EventCustomerDiagnosis> GetByEventCustomerId(long eventCustomerId);

        IEnumerable<EventCustomerDiagnosis> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);

        EventCustomerDiagnosis Save(EventCustomerDiagnosis domain);

        IEnumerable<EventCustomerDiagnosis> GetForConditionInboundReport(ConditionInboundFilter filter, int pageNumber, int pageSize, out int totalRecords);
    }
}
