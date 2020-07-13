using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Domain;
using NUnit.Framework;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Impl;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class DataRecorderMetaDataFactoryTester
    {
        private MockRepository _mocks;
        private ICalendar _calendar;
        private IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _calendar = _mocks.StrictMock<ICalendar>();
            _dataRecorderMetaDataFactory = new DataRecorderMetaDataFactory(_calendar);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        public void CreateDataRecorderMetaDataCreatesOrganizationRoleUserForDataCreator()
        {
            var dataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData(3);

            Assert.IsNotNull(dataRecorderMetaData.DataRecorderCreator);
            Assert.IsInstanceOf<OrganizationRoleUser>(dataRecorderMetaData.DataRecorderCreator);
        }

        [Test]
        public void CreateDataRecorderMetaDataAssignsGivenDataCreatorIdToDataCreatorObject()
        {
            const long expectedDataRecorderCreatorId = 3;

            var dataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData(expectedDataRecorderCreatorId);

            Assert.AreEqual(expectedDataRecorderCreatorId, dataRecorderMetaData.DataRecorderCreator.Id);
        }

        [Test]
        public void CreateDataRecorderMetaDataAssignsDatesGivenToCorrectProperties()
        {
            var expectedDateCreated = new DateTime(2001, 1, 1);
            var expectedDateModified = new DateTime(2001, 3, 3);

            var dataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData
                (1, expectedDateCreated, 2, expectedDateModified);

            Assert.AreEqual(expectedDateCreated, dataRecorderMetaData.DateCreated);
            Assert.AreEqual(expectedDateModified, dataRecorderMetaData.DateModified);
        }

        [Test]
        public void CreateDataRecorderMetaDataAssignsDateModifiedToNullWhenNullGiven()
        {
            var dataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData(1, new DateTime(), 1, null);

            Assert.IsNull(dataRecorderMetaData.DateModified);
        }

        [Test]
        public void CreateDataRecorderMetaDataSetsDataRecorderModifierToNullWhenNullIdGiven()
        {
            var dataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData(1, new DateTime(), null, null);

            Assert.IsNull(dataRecorderMetaData.DataRecorderModifier);
        }

        [Test]
        public void CreateDataRecorderMetaDataSetsDataRecorderModifierIdToGivenModifierId()
        {
            const long expectedDataRecorderModifierId = 4;

            var dataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData
                (1, new DateTime(), expectedDataRecorderModifierId, new DateTime());

            Assert.AreEqual(expectedDataRecorderModifierId, dataRecorderMetaData.DataRecorderModifier.Id);
        }

        [Test]
        public void CreateDataRecorderMetaDataDefaultsDateCreatedToCalendarNow()
        {
            DateTime expectedDateCreated = DateTime.Now;
            Expect.Call(_calendar.Now).Return(expectedDateCreated);

            _mocks.ReplayAll();
            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.CreateDataRecorderMetaData(0);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedDateCreated, dataRecorderMetaData.DateCreated, "DateCreated did not default to Calendar's Now DateTime.");
        }
    }
}