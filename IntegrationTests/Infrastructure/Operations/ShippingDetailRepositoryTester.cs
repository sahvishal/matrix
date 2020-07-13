using System;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Infrastructure.Repositories.Shipping;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class ShippingDetailRepositoryTester
    {
        private readonly IShippingDetailRepository _shippingDetailRepository = new ShippingDetailRepository();

        private const ShipmentStatus VALID_SHIPMENT_STATUS = ShipmentStatus.Processing;
        private const long VALID_SHIPPING_OPTION_ID = 6;
        private const long VALID_EVENT_ID = 1803;
        private const long VALID_POD_ID = 31;
        private readonly DateTime _validEventStartDate = new DateTime(2010, 4, 1, 00, 00, 00);
        private readonly DateTime _validEventEndDate = new DateTime(2010, 4, 20, 00, 00, 00);
        private const int START_INDEX = 0;
        private const int RECORD_COUNT = 25;

       
    }
}