using Falcon.App.Core.Operations;
using Falcon.App.Infrastructure.Repositories.Shipping;
using NUnit.Framework;
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
    [TestFixture]
    public class ShippingOptionRepositoryTester
    {
        private readonly IShippingOptionRepository _shippingOptionRepository = new ShippingOptionRepository();

        [Test]
        public void GetAllShippingOptions()
        {
            List<ShippingOption> allShippingOptions = _shippingOptionRepository.GetAllShippingOptions();

            Assert.IsNotNull(allShippingOptions, "Null collection of Pods returned.");
            Assert.IsNotEmpty(allShippingOptions, "Empty collection of pods returned.");
        }
        
    }
}