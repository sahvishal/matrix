using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class CustomerRepositoryTester
    {
        private const int INVALID_CUSTOMER = 0;
        private const int INVALID_USER = 0;

        private const int VALID_CUSTOMER = 15227;
        private const int VALID_USER     = 16123;

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<Customer>))]
        public void GetCustomerThrowsExceptionWhenInvalidCustomerId()
        {
            ICustomerRepository customerRepository = new CustomerRepository();            
            customerRepository.GetCustomer(INVALID_CUSTOMER);
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<User>))]
        public void GetCustomerByUserIdThrowsExceptionWhenInvalidUserId()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            customerRepository.GetCustomerByUserId(INVALID_USER);
        }

        [Test]
        public void GetCustomerReturnsCustomerWithSameIdsForValidCustomerId()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            Customer user = customerRepository.GetCustomer(VALID_CUSTOMER);

            Assert.AreEqual(VALID_CUSTOMER, user.CustomerId);
            Assert.AreEqual(VALID_USER, user.Id);
        }

        [Test]
        public void GetCustomerByUserIdReturnsCustomerWithSameIdsForValidUserId()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            Customer user = customerRepository.GetCustomerByUserId(VALID_USER);

            Assert.AreEqual(VALID_CUSTOMER, user.CustomerId);
            Assert.AreEqual(VALID_USER, user.Id);
        }

        [Test]
        public void GetCustomersReturnsListOfCustomersWithExpectedCustomers()
        {
            long[] customerIds = {178, 179, 180, 181 };

            long[] expectedUserIds = {1059, 1060, 1063, 1064};
            string[] expectedFirstNames = {"Yasir", "nitesh", "Marland", "Pete"};

            ICustomerRepository customerRepository = new CustomerRepository();
            List<Customer> users = customerRepository.GetCustomers(customerIds);

            Assert.AreEqual(customerIds, users.Select(u => u.CustomerId).ToArray());
            Assert.AreEqual(expectedUserIds, users.Select(u => u.Id).ToArray());
            Assert.AreEqual(expectedFirstNames, users.Select(u => u.Name.FirstName).ToArray());
        }

        [Test]
        public void SearchCustomerReturnListOfCustomers()
        {
            const string firstName = "A";
            const string lastName = "Kum";
            ICustomerRepository customerRepository = new CustomerRepository();
            List<Customer> users = customerRepository.GetCustomerByFilters(firstName, lastName,0,0,"","",null,string.Empty);
            var expectedCustomers =
                users.Where(u => u.Name.FirstName.StartsWith(firstName) && u.Name.LastName.StartsWith(lastName)).ToList();

            Assert.IsTrue(users.Count == expectedCustomers.Count,"Customer list is not as per search criteria");
        }

        [Test]
        public void GetGetMemberForReportTester()
        {
            var filter = new MemberStatusListModelFilter
            {
                EligibleStatus = EligibleFilterStatus.OnlyEligible,
                IncludeDoNotContact = true,
                DoNotContactOnly = false,
                Tag = "Wellmed",
                Year = 2018,
                CallAttemptFilter = CallAttemptFilterStatus.All,
                ConsiderEligibiltyFromHistory = true
            };
            ICustomerRepository customerRepository = new CustomerRepository();
            int totalRecors;
            var reports = customerRepository.GetMemberForReport(1, 100, filter, out totalRecors);

            Assert.IsNotNull(reports);

        }
    }
}