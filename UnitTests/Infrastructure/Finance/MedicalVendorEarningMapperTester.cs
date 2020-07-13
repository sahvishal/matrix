//using System;
//using Falcon.App.Core.Application;
//using Falcon.App.Core.Domain;
//using Falcon.App.Core.Finance.Domain;
//using Falcon.App.Core.Interfaces;
//using Falcon.App.Core.Users.Domain;
//using Falcon.App.Infrastructure.Mappers;
//using Falcon.Data.EntityClasses;
//using NUnit.Framework;
//using Rhino.Mocks;

//namespace Falcon.Web.UnitTests.Infrastructure.Finance
//{
//    [TestFixture]
//    public class MedicalVendorEarningMapperTester
//    {
//        private MockRepository _mocks;
//        private IDataRecorderMetaDataFactory _mockedFactory;
    
//        private IMapper<MedicalVendorEarning, MVEarningEntity> _mapper;

//        [SetUp]
//        public void SetUp()
//        {
//            _mocks = new MockRepository();
//            _mockedFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();

//            _mapper = new MedicalVendorEarningMapper(_mockedFactory);
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            _mocks = null;
//            _mapper = null;
//        }
        
//        [Test]
//        public void MapMapsEntityPropertiesToDomainProperties()
//        {
//            const int medicalVendorEarningId = 24;
//            const decimal medicalVendorAmountEarned = 33.22m;
//            var expectedDataRecorderMetaData = new DataRecorderMetaData();
//            var medicalVendorEarningEntity = new MVEarningEntity(medicalVendorEarningId) 
//                { MvamountEarned = medicalVendorAmountEarned };
//            Expect.Call(_mockedFactory.CreateDataRecorderMetaData(0, new DateTime(), null, null)).
//                IgnoreArguments().Return(expectedDataRecorderMetaData);

//            _mocks.ReplayAll();
//            MedicalVendorEarning medicalVendorEarning = _mapper.Map(medicalVendorEarningEntity);
//            _mocks.VerifyAll();

//            Assert.AreEqual(medicalVendorEarningId, medicalVendorEarning.Id);
//            Assert.AreEqual(expectedDataRecorderMetaData, medicalVendorEarning.DataRecorderMetaData);
//        }

//        [Test]
//        public void MapMapsPropertiesToEntityProperties()
//        {
//            var medicalVendorEarning = new MedicalVendorEarning
//            {
//                OrganizationRoleUserId = 3,
//                MedicalVendorUserAmountEarned = 4.55m,
//                DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = 
//                    new OrganizationRoleUser(), DateCreated = new DateTime(2001, 3, 4) }
//            };

//            MVEarningEntity medicalVendorEarningEntity = _mapper.Map(medicalVendorEarning);

//            Assert.AreEqual(medicalVendorEarning.OrganizationRoleUserId, 
//                medicalVendorEarningEntity.OrganizationRoleUserId);
//            Assert.AreEqual(medicalVendorEarning.MedicalVendorUserAmountEarned, 
//                medicalVendorEarningEntity.MvuserAmountEarned);
//            Assert.AreEqual(medicalVendorEarning.DataRecorderMetaData.DateCreated,
//                medicalVendorEarningEntity.DateCreated);
//        }

//        [Test]
//        public void CreateMedicalVendorEarningEntityMapsMedicalVendorUserAmountEarnedToMvAmountEarned()
//        {
//            var medicalVendorEarning = new MedicalVendorEarning
//            {
//                MedicalVendorUserAmountEarned = 2.33m,
//                DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = 
//                    new OrganizationRoleUser(), DateCreated = new DateTime(2001, 3, 4) }
//            };

//            MVEarningEntity medicalVendorEarningEntity = _mapper.Map(medicalVendorEarning);

//            Assert.AreEqual(medicalVendorEarning.MedicalVendorUserAmountEarned, 
//                medicalVendorEarningEntity.MvamountEarned);
//        }
//    }
//}