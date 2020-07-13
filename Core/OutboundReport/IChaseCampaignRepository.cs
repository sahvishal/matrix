using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IChaseCampaignRepository
    {
        ChaseCampaign GetById(long id);

        IEnumerable<ChaseCampaign> GetByIds(IEnumerable<long> ids);

        ChaseCampaign Save(ChaseCampaign domain);

        IEnumerable<CustomerChaseCampaign> GetCustomerChaseCampaignsByCustomerId(long customerId);

        IEnumerable<CustomerChaseCampaign> GetCustomerChaseCampaignsByCustomerIds(long[] customerIds);

        CustomerChaseCampaign SaveCustomerChaseCampaign(CustomerChaseCampaign domain);
        
        void DeactivateAllCustomerCampaigns(long customerId);
    }
}
