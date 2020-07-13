using Falcon.App.Core.Sales.Domain;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Sales
{
    public interface ICustomerPredictedZipRespository
    {
        void Save(List<CustomerPredictedZip> customerPredictedZips);

        List<CustomerPredictedZip> GetByCustomerIdAndDate(IEnumerable<long> customerIds, DateTime? fromDate = null, DateTime? toDate = null);
        IEnumerable<CustomerPredictedZip> GetByCustomerId(long customerId);
    }
}
