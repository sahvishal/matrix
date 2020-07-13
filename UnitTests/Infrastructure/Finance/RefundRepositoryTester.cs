using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Finance.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class RefundRepositoryTester
    {
        private readonly IUniqueItemRepository<Refund> _refundRepository = new RefundRepository();
        private readonly IEventCustomerRepository _eventCustomerRepository = new EventCustomerRepository();

        [Test]
        [Ignore("Need access to protected member")]
        public void EntityIdFieldReturnsRefundIdFromRefundFields()
        {
            var result = _eventCustomerRepository.GetEventCustomerCountForHealthPlanRevenueByPackage(1003,
                   DateTime.Today.AddDays(-565), DateTime.Today, new long[] { 399, 437, 438 });
            //EntityField2 expectedEntityIdField = RefundFields.RefundId;
            //string expectedEntityFieldName = string.Format("{0}.{1}", expectedEntityIdField.ContainingObjectName, expectedEntityIdField.Name);

            //EntityField2 entityIdField = _refundRepository.EntityIdField;
            //string entityFieldName = string.Format("{0}.{1}", entityIdField.ContainingObjectName, entityIdField.Name);

            //Assert.AreEqual(expectedEntityFieldName, entityFieldName, "EntityIdField returned incorrect EntityField.");
        }


    }
}