using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using NUnit.Framework;
using Falcon.App.Core.Users;

namespace Falcon.Web.IntegrationTests.Infrastructure.Sales
{
    [TestFixture]
    //[Ignore]
    public class ProspectCustomerRepositoryTester
    {
        private IProspectCustomerRepository _prospectCustomerRepository;
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
        }

        [Test]
        public void GetProspectCustomerReturnsNullForNonexistentProspectId()
        {
            const long nonexistentProspectId = 0;
            ProspectCustomer prospectCustomer = _prospectCustomerRepository.GetProspectCustomer(nonexistentProspectId);
            Assert.IsNull(prospectCustomer);
        }

        [Test]
        public void GetProspectCustomerReturnsProspectCustomerForExistingProspectId()
        {
            const long testProspectCustomerId = 12732;

            ProspectCustomer prospectCustomer = _prospectCustomerRepository.GetProspectCustomer(testProspectCustomerId);

            Assert.IsNotNull(prospectCustomer);
            Assert.AreEqual("Test", prospectCustomer.FirstName);
            Assert.AreEqual("238382", prospectCustomer.Address.StreetAddressLine1);
        }

        [Test]
        public void GetProspectCustomersDoesNotIncludeUnspecifiedProspectCustomers()
        {
            long[] prospectCustomerIds = Enumerable.Range(1, 10).Select(i => (long)i).ToArray();

            List<ProspectCustomer> prospectCustomers = _prospectCustomerRepository.GetProspectCustomers(prospectCustomerIds);
            Assert.AreEqual(prospectCustomerIds.Count(), prospectCustomers.Count());

            foreach (var prospectCustomer in prospectCustomers)
            {
                Assert.Contains(prospectCustomer.Id, prospectCustomerIds);
            }
        }

        [Test]
        public void GetProspectCustomersReturnsListOfExpectedProspectCustomers()
        {
            long[] prospectCustomerIds = { 12722, 12723, 12724, 12725, 12726, 12727 };
            long[] unoutrankedProspectCustomerIds = { 12723, 12724, 12725 };

            List<ProspectCustomer> prospectCustomers = _prospectCustomerRepository.GetProspectCustomers(prospectCustomerIds);
            foreach (int prospectCustomerId in unoutrankedProspectCustomerIds)
            {
                Assert.That(prospectCustomers.Where(p => p.Id == prospectCustomerId).Any());
            }
        }

        [Test]
        public void GetAbandonedProspectCustomerwithoutFiltersTest()
        {
            int totalRecords;
            var prospectCustomers = _prospectCustomerRepository.GetAbandonedProspectCustomer(1, 10, null, out totalRecords);
            Assert.IsNotNull(prospectCustomers);
            Assert.IsNotEmpty(prospectCustomers.ToArray());
            Assert.Greater(totalRecords, 0);
        }

        [Test]
        public void GetAbandonedProspectCustomerWithFiltersTest()
        {
            int totalRecords;
            var prospectCustomers = _prospectCustomerRepository.GetAbandonedProspectCustomer(1, 10, new ProspectCustomerListModelFilter()
                                                                                                        {
                                                                                                            Tag = ProspectCustomerTag.OnlineSignup.ToString()
                                                                                                        }, out totalRecords);
            Assert.IsNotNull(prospectCustomers);
            Assert.IsNotEmpty(prospectCustomers.ToArray()); 
            Assert.Greater(totalRecords, 0);
        }
    }
}