using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class RefundMapperTester
    {
        private MockRepository _mocks;
        private IMapper<Refund, RefundEntity> _refundFactory;
        private IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _dataRecorderMetaDataFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();
            _refundFactory = new RefundMapper(_dataRecorderMetaDataFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _refundFactory = null;
        }

        private static Refund GetValidRefund()
        {
            return GetValidRefund(0);
        }

        private static Refund GetValidRefund(long refundId)
        {
            return new Refund(refundId) {DataRecorderMetaData = new DataRecorderMetaData {DataRecorderCreator = new OrganizationRoleUser()}};
        }

        [Test]
        public void MapSetsIdCorrectly()
        {
            const int expectedRefundId = 24;

            Refund refund = _refundFactory.Map(new RefundEntity(expectedRefundId));

            Assert.AreEqual(expectedRefundId, refund.Id, "Refund ID mapped incorrectly.");
        }

        [Test]
        public void MapSetsNotesCorrectly()
        {
            const string expectedNotes = "Some Notes";

            Refund refund = _refundFactory.Map(new RefundEntity { Notes = expectedNotes });

            Assert.AreEqual(expectedNotes, refund.Notes, "Refund Notes mapped incorrectly.");
        }

        [Test]
        public void MapSetsRefundReasonCorrectly()
        {
            const RefundReason expectedRefundReason = RefundReason.Other;

            Refund refund = _refundFactory.Map(new RefundEntity { ReasonId = (short)expectedRefundReason });

            Assert.AreEqual(expectedRefundReason, refund.RefundReason, "Refund RefundReason mapped incorrectly.");
        }

        [Test]
        public void MapSetsDataRecorderMetaDataToReturnedObjectOfMetaDataFactoryCall()
        {
            const int organizationRoleUserCreatorId = 3;
            var dateCreated = new DateTime(2003, 1, 1);
            var refundEntity = new RefundEntity { OrganizationRoleUserCreatorId = 
                organizationRoleUserCreatorId, DateCreated = dateCreated };
            var expectedDataRecorderMetaData = new DataRecorderMetaData
            {
                DataRecorderCreator = new OrganizationRoleUser(organizationRoleUserCreatorId),
                DateCreated = dateCreated
            };
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData
                (organizationRoleUserCreatorId, dateCreated)).Return(expectedDataRecorderMetaData);

            _mocks.ReplayAll();
            Refund refund = _refundFactory.Map(refundEntity);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedDataRecorderMetaData, refund.DataRecorderMetaData, 
                "Refund DataRecorderMetaData mapped incorrectly.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenNullEntityGiven()
        {
            _refundFactory.Map((RefundEntity)null);
        }

        [Test]
        public void MapMapsRefundIdToEntityRefundId()
        {
            const int expectedRefundId = 43;

            RefundEntity refundEntity = _refundFactory.Map(GetValidRefund(expectedRefundId));

            Assert.AreEqual(expectedRefundId, refundEntity.RefundId, 
                "RefundEntity RefundID mapped incorrectly.");
        }

        [Test]
        public void MapMapsRefundReasonToEntityRefundReasonId()
        {
            const RefundReason expectedRefundReason = RefundReason.Other;
            Refund refund = GetValidRefund();
            refund.RefundReason = expectedRefundReason;

            RefundEntity refundEntity = _refundFactory.Map(refund);

            Assert.AreEqual((short)expectedRefundReason, refundEntity.ReasonId, 
                "RefundEntity ReasonID mapped incorrectly.");
        }

        [Test]
        public void MapMapsNotesToEntitynotes()
        {
            const string expectedNotes = "Some Notes";
            Refund refund = GetValidRefund();
            refund.Notes = expectedNotes;

            RefundEntity refundEntity = _refundFactory.Map(refund);

            Assert.AreEqual(expectedNotes, refundEntity.Notes, "RefundEntity Notes mapped incorrectly.");
        }

        [Test]
        public void MapSetsIsNewToTrueWhenGivenIdIs0()
        {
            Refund newRefund = GetValidRefund(0);

            RefundEntity refundEntity = _refundFactory.Map(newRefund);

            Assert.IsTrue(refundEntity.IsNew, "RefundEntity IsNew set to false when ID of 0 given.");
        }

        [Test]
        public void MapSetsIsNewToFalseWhenGivenIdIsNot0()
        {
            Refund oldRefund = GetValidRefund(12);

            RefundEntity refundEntity = _refundFactory.Map(oldRefund);

            Assert.IsFalse(refundEntity.IsNew, 
                "RefundEntity IsNew set to true when ID that was not 0 given.");
        }

        [Test]
        public void MapSetsDateCreatedToMetaDataDateCreated()
        {
            var expectedDateCreated = new DateTime(2001, 1, 1);
            Refund refund = GetValidRefund();
            refund.DataRecorderMetaData.DateCreated = expectedDateCreated;

            RefundEntity refundEntity = _refundFactory.Map(refund);

            Assert.AreEqual(expectedDateCreated, refundEntity.DateCreated, 
                "RefundEntity DateCreated mapped incorrectly.");
        }

        [Test]
        public void MapSetsOrganizationRoleUserCreatorIdToDataRecorderCreatorId()
        {
            const int expectedOrganizationRoleUserCreatorId = 32882;
            Refund refund = GetValidRefund();
            refund.DataRecorderMetaData.DataRecorderCreator.Id = expectedOrganizationRoleUserCreatorId;

            RefundEntity refundEntity = _refundFactory.Map(refund);

            Assert.AreEqual(expectedOrganizationRoleUserCreatorId, refundEntity.
                OrganizationRoleUserCreatorId, 
                "RevenueEntity OrganizationRoleUserCreatorId mapped incorrectly.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenRefundHasNullMetaData()
        {
            Refund refund = GetValidRefund();
            refund.DataRecorderMetaData = null;

            _refundFactory.Map(refund);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenRefundHasNullDataRecorderCreator()
        {
            Refund refund = GetValidRefund();
            refund.DataRecorderMetaData.DataRecorderCreator = null;

            _refundFactory.Map(refund);
        }
    }
}