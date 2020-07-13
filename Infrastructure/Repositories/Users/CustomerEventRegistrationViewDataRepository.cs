using System.Collections.Generic;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Factories.Users;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    public class CustomerEventRegistrationViewDataRepository : PersistenceRepository, ICustomerEventRegistrationViewDataRepository
    {
        private readonly ICustomerEventRegistrationViewDataFactory _customerEventRegistrationViewDataFactory;

        public CustomerEventRegistrationViewDataRepository()
            : this(new CustomerEventRegistrationViewDataFactory())
        { }

        public CustomerEventRegistrationViewDataRepository(ICustomerEventRegistrationViewDataFactory customerEventRegistrationViewDataFactory)
        {
            _customerEventRegistrationViewDataFactory = customerEventRegistrationViewDataFactory;
        }

        public List<CustomerEventRegistrationViewData> GetCustomerEventRegistrationViewData(long customerId)
        {
            var customerOrderBasicInfoTypedView = new CustomerOrderBasicInfoTypedView();
            var bucket = new RelationPredicateBucket(CustomerOrderBasicInfoFields.CustomerId == customerId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(customerOrderBasicInfoTypedView, bucket, false);
            }
            return _customerEventRegistrationViewDataFactory.Create(customerOrderBasicInfoTypedView);
        }
    }
}