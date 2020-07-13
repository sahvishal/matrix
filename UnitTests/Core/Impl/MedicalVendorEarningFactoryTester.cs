using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Domain.MedicalVendors.ViewData;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using NUnit.Framework;
using System;
using Falcon.App.Core.Domain;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class MedicalVendorEarningFactoryTester
    {
        private MockRepository _mocks;
        private IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;
        private IMedicalVendorEarningFactory _medicalVendorEarningFactory;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _dataRecorderMetaDataFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();
            _medicalVendorEarningFactory = new MedicalVendorEarningFactory(_dataRecorderMetaDataFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorEarningThrowsExceptionWhenNullAggregateGiven()
        {
            _medicalVendorEarningFactory.CreateMedicalVendorEarning(null, 0, new DateTime());
        }

        [Test]
        public void CreateMedicalVendorEarningReturnsEarningWhenGivenValidArguments()
        {
            const long dataRecorderCreatorId = 0;
            var dateCreated = new DateTime();
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(dataRecorderCreatorId,
                dateCreated)).Return(new DataRecorderMetaData());

            _mocks.ReplayAll();
            MedicalVendorEarning medicalVendorEarning = _medicalVendorEarningFactory.
                CreateMedicalVendorEarning(new MedicalVendorEarningAggregate(), 
                dataRecorderCreatorId, dateCreated);
            _mocks.VerifyAll();

            Assert.IsNotNull(medicalVendorEarning);
        }

        [Test]
        public void CreateMedicalVendorEarningMapsAggregatePropertiesToEarningPropertiesCorrectly()
        {
            var medicalVendorEarningAggregate = new MedicalVendorEarningAggregate
            {
                MedicalVendorMedicalVendorUserId = 3,
            };
            var dateCreated = new DateTime();
            const long dataRecorderCreatorId = 0;
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData(dataRecorderCreatorId, 
                dateCreated)).Return(new DataRecorderMetaData());

            _mocks.ReplayAll();
            MedicalVendorEarning medicalVendorEarning = _medicalVendorEarningFactory.
                CreateMedicalVendorEarning(medicalVendorEarningAggregate, 
                dataRecorderCreatorId, dateCreated);
            _mocks.VerifyAll();

            Assert.AreEqual(medicalVendorEarningAggregate.MedicalVendorMedicalVendorUserId,
                medicalVendorEarning.OrganizationRoleUserId);
        }
    }
}