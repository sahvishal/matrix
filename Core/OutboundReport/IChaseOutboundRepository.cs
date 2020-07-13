using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IChaseOutboundRepository
    {
        ChaseOutbound GetByCustomerId(long customerId);

        IEnumerable<ChaseOutbound> GetByCustomerIds(IEnumerable<long> customerIds);

        ChaseOutbound Save(ChaseOutbound domain);

        ChaseOutbound GetByIndividualIdNumber(string individulaIdNumber, string consumerId);
        
        ChaseOutbound GetByClientIdAndContractNumber(string clientId, string contractNumber);
        
        ChaseOutbound GetByClientId(string clientId);

        IEnumerable<ChaseOutbound> GetAllByCustomerIds(IEnumerable<long> customerIds);
    }
}
