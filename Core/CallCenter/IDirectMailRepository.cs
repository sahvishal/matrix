using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using System;

namespace Falcon.App.Core.CallCenter
{
    public interface IDirectMailRepository
    {
        DirectMail Save(DirectMail domain);
        IEnumerable<DirectMail> GetByCustomerId(long customerId);
        IEnumerable<DirectMail> GetByCustomerIds(IEnumerable<long> customerIds, DateTime? fromDate = null, DateTime? toDate = null);
    }
}