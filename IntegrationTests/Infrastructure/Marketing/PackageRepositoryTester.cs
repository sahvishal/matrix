using System.Linq;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    //[Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class PackageRepositoryTester
    {
        private const long VALID_EVENT_ID = 1724;

        private readonly IPackageRepository _packageRepository = new PackageRepository();

        [Test]
        public void GetPackageCustomerCountForEventReturnValidCountWhenGivenValidId()
        {
            var pairs = _packageRepository.GetPackageCustomerCountForEvent(VALID_EVENT_ID);

            Assert.IsNotNull(pairs);
        }
        
    }
}