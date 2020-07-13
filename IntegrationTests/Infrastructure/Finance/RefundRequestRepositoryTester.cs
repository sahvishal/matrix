using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;
using Falcon.App.DependencyResolution;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    public class RefundRequestRepositoryTester
    {
        private IRepository<RefundRequest> _repository;
        private IRefundRequestRepository _refundRequestRepository;

        private const long ValidOrderId = 1;
        private const long ValidRequestId = 9;

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _repository = IoC.Resolve<IRepository<RefundRequest>>();
            _refundRequestRepository = (IRefundRequestRepository)_repository;

            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
        }

        [Test]
        public void SaveRequestTest()
        {
            var refundRequest = new RefundRequest();
            refundRequest.RequestStatus = (long)RequestStatus.Pending;
            refundRequest.OrderId = ValidOrderId;
            refundRequest.Reason = "Cancelled Appointment";
            refundRequest.RefundRequestType = RefundRequestType.CustomerCancellation;
            refundRequest.RequestedByOrgRoleUserId = 1;
            refundRequest.RequestedOn = DateTime.Now;
            refundRequest.RequestedRefundAmount = 25.00m;

            refundRequest = _repository.Save(refundRequest);
            Assert.IsNotNull(refundRequest);
            Assert.Greater(refundRequest.Id, 0);
        }

        [Test]
        public void SaveRequestwithResultTest()
        {
            var refundRequest = new RefundRequest();
            refundRequest.RequestStatus = (long)RequestStatus.Resolved;
            refundRequest.OrderId = ValidOrderId;
            refundRequest.Reason = "Cancelled Appointment";
            refundRequest.RefundRequestType = RefundRequestType.CustomerCancellation;
            refundRequest.RequestedByOrgRoleUserId = 1;
            refundRequest.RequestedOn = DateTime.Now;
            refundRequest.RequestedRefundAmount = 25.00m;

            var requestResult = new RefundRequestResult();
            requestResult.Notes = "Resolved";
            requestResult.RefundAmount = 20;
            requestResult.RequestResultType = RequestResultType.IssueRefund;
            requestResult.ProcessedOn = DateTime.Now;
            requestResult.ProcessedByOrgRoleUserId = 1;

            refundRequest.RefundRequestResult = requestResult;

            refundRequest = _repository.Save(refundRequest);
            Assert.IsNotNull(refundRequest);
            Assert.Greater(refundRequest.Id, 0);
        }

        [Test]
        public void GetbyId()
        {
            var refundRequest = _refundRequestRepository.Get(ValidRequestId);
            Assert.IsNotNull(refundRequest);
            Assert.Greater(refundRequest.Id, 0);
            Assert.Greater(refundRequest.OrderId, 0);
            Assert.Greater(refundRequest.EventId, 0);
            Assert.Greater(refundRequest.CustomerId, 0);

            Assert.AreEqual(refundRequest.Id, ValidRequestId);
        }


        [Test]
        public void GetbyOrderId()
        {
            var refundRequests = _refundRequestRepository.GetbyOrderId(4);
            Assert.IsNotNull(refundRequests);

            var refundRequest = refundRequests.FirstOrDefault();
            Assert.Greater(refundRequest.Id, 0);
            Assert.Greater(refundRequest.OrderId, 0);
            Assert.Greater(refundRequest.EventId, 0);
            Assert.Greater(refundRequest.CustomerId, 0);

            Assert.AreEqual(refundRequest.OrderId, 4);
        }

        [Test]
        public void GetPagedwithFilterbyDateTypeasRequestDate()
        {
            var filter = new RefundRequestListModelFilter
                             {
                                 CustomerName = "John",
                                 DateType = (int)FilterDateType.RequestDate,
                                 FromDate = DateTime.Now.AddDays(-5),
                                 ToDate = DateTime.Now.AddDays(5)
                             };

            int totalRecords;
            var requests = _refundRequestRepository.Get(1, 10, filter, out totalRecords);
            Assert.IsNotNull(requests);
            Assert.IsNotEmpty(requests.ToArray());
        }


        [Test]
        public void GetPagedwithFilterbyDateTypeasEventDate()
        {
            var filter = new RefundRequestListModelFilter
            {
                CustomerName = "John",
                DateType = (int)FilterDateType.EventDate,
                FromDate = DateTime.Now.AddDays(-5),
                ToDate = DateTime.Now.AddDays(25)
            };

            int totalRecords;
            var requests = _refundRequestRepository.Get(1, 10, filter, out totalRecords);
            Assert.IsNotNull(requests);
            Assert.IsNotEmpty(requests.ToArray());
        }



        [Test]
        public void GetPagedwithFilterbyDateTypeasOrderDate()
        {
            var filter = new RefundRequestListModelFilter
            {
                CustomerName = "John",
                DateType = (int)FilterDateType.TransactionDate,
                FromDate = DateTime.Now.AddDays(-30),
                ToDate = DateTime.Now.AddDays(5)
            };

            int totalRecords;
            var requests = _refundRequestRepository.Get(1, 10, filter, out totalRecords);
            Assert.IsNotNull(requests);
            Assert.IsNotEmpty(requests.ToArray());
        }

    }
}