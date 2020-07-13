using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Factories.Users;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    class CustomerProfileHistoryRepository : PersistenceRepository, ICustomerProfileHistoryRepository
    {
        private readonly ICustomerProfileHistoryFactory _customerProfileHistoryFactory;

        public CustomerProfileHistoryRepository()
            : this(new CustomerProfileHistoryFactory())
        {

        }

        public CustomerProfileHistoryRepository(ICustomerProfileHistoryFactory customerProfileHistoryFactory)
        {
            _customerProfileHistoryFactory = customerProfileHistoryFactory;
        }

        public long CreateCustomerHistory(long customerId, long orgRoleId, CustomerEligibility customerEligibility)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEntity = linqMetaData.CustomerProfile.SingleOrDefault(cp => cp.CustomerId == customerId);

                var userEntity = (from oru in linqMetaData.OrganizationRoleUser
                                  join user in linqMetaData.User on oru.UserId equals user.UserId
                                  where oru.OrganizationRoleUserId == customerId
                                  select user).WithPath(p => p.Prefetch(prefetch => prefetch.Role)).FirstOrDefault();

                var customerWarmTransfer = (from cwt in linqMetaData.CustomerWarmTransfer
                                            where cwt.CustomerId == customerId && cwt.WarmTransferYear == DateTime.Today.Year
                                            select cwt).SingleOrDefault();

                if (customerWarmTransfer == null)
                {
                    customerWarmTransfer = (from cwt in linqMetaData.CustomerWarmTransfer
                                            where cwt.CustomerId == customerId
                                            orderby cwt.Id descending
                                            select cwt).FirstOrDefault();
                }

                var customerTargeted = (from ct in linqMetaData.CustomerTargeted
                                        where ct.CustomerId == customerId && ct.ForYear == DateTime.Today.Year
                                        select ct).FirstOrDefault();
                if (customerTargeted == null)
                {
                    customerTargeted = (from ct in linqMetaData.CustomerTargeted
                                        where ct.CustomerId == customerId
                                        orderby ct.Id descending
                                        select ct).FirstOrDefault();
                }

                var customerHistory = _customerProfileHistoryFactory.CustomerProfileHistoryEntity(customerEntity, userEntity, orgRoleId, customerEligibility, customerWarmTransfer, customerTargeted);

                if (!adapter.SaveEntity(customerHistory, true))
                    throw new PersistenceFailureException();

                return customerHistory.Id;
            }
        }

        public IEnumerable<CustomerProfileHistory> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cph in linqMetaData.CustomerProfileHistory
                                where cph.CustomerId == customerId
                                orderby cph.DateCreated descending
                                select cph).ToArray();
                return Mapper.Map<IEnumerable<CustomerProfileHistoryEntity>, IEnumerable<CustomerProfileHistory>>(entities);
            }
        }

        public IEnumerable<CustomerProfileHistory> GetByDateRange(DateTime dateLowerBound, DateTime dateUpperBound, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cph in linqMetaData.CustomerProfileHistory
                                where cph.DateCreated.GetStartOfDay() <= dateUpperBound && cph.DateCreated.GetStartOfDay() >= dateLowerBound
                                && cph.CustomerId == customerId
                                select cph).ToArray();
                return Mapper.Map<IEnumerable<CustomerProfileHistoryEntity>, IEnumerable<CustomerProfileHistory>>(entities);
            }
        }
    }
}