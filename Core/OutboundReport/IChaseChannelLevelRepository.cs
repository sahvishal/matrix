using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IChaseChannelLevelRepository
    {
        ChaseChannelLevel GetById(long id);

        IEnumerable<ChaseChannelLevel> GetByIds(IEnumerable<long> ids);

        ChaseChannelLevel Save(ChaseChannelLevel domain);

        IEnumerable<CustomerChaseChannel> GetCustomerChaseChannelsByCustomerId(long customerId);

        IEnumerable<CustomerChaseChannel> GetCustomerChaseChannelsByChaseChannelId(long chaseChannelId);

        IEnumerable<CustomerChaseChannel> SaveCustomerChaseChannels(IEnumerable<CustomerChaseChannel> domains);
        
        ChaseChannelLevel GetByNameAndLevel(string channelName, int level);
        
        CustomerChaseChannel SaveCustomerChaseChannel(CustomerChaseChannel domain);

        void DeleteByCustomerId(long customerId);
    }
}
