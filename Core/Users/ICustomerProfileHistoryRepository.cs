using System;
using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ICustomerProfileHistoryRepository
    {
        IEnumerable<CustomerProfileHistory> GetByCustomerId(long customerId);
        IEnumerable<CustomerProfileHistory> GetByDateRange(DateTime dateLowerBound, DateTime dateUpperBound, long customerId);
        long CreateCustomerHistory(long customerId, long orgRoleId, CustomerEligibility customerEligibility);
    }
}