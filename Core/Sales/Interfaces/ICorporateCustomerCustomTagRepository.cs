using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using System;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface ICorporateCustomerCustomTagRepository
    {
        CorporateCustomerCustomTag GetByCustomerAndTag(long customerId, string tag);
        CorporateCustomerCustomTag Save(CorporateCustomerCustomTag corporateTag);
        IEnumerable<CorporateCustomerCustomTag> GetByCustomerIds(IEnumerable<long> customerIds, DateTime? fromDate = null, DateTime? toDate = null);
        IEnumerable<CorporateCustomerCustomTag> GetByCustomerId(long customerId);

        void UpdateCorporateCustomerTag(IEnumerable<long> tagId, bool isActive, long updatedBy);

        IEnumerable<OrderedPair<string, long>> GetCustomerCountByTag(IEnumerable<string> tags);

    }
}