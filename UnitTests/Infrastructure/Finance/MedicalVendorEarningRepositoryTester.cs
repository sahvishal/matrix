//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Falcon.App.Core.Application;
//using Falcon.App.Core.Application.Exceptions;
//using Falcon.App.Core.Deprecated;
//using Falcon.App.Core.Finance.Domain;
//using Falcon.App.Core.Finance.Interfaces;
//using Falcon.App.Core.Interfaces;
//using Falcon.App.Infrastructure.Repositories;
//using Falcon.Data.EntityClasses;
//using Falcon.Data.HelperClasses;
//using Falcon.Web.UnitTests.Infrastructure.Application;
//using NUnit.Framework;
//using Rhino.Mocks;

//namespace Falcon.Web.UnitTests.Infrastructure.Finance
//{
//    [TestFixture]
//    public class MedicalVendorEarningRepositoryTester : RepositoryTesterBase
//    {
//        private IValidator<MedicalVendorEarning> _mockedValidator;
//        private IMapper<MedicalVendorEarning, MVEarningEntity> _mockedMapper;

//        private IMedicalVendorEarningRepository _medicalVendorEarningRepository;

//        [SetUp]
//        protected override void SetUp()
//        {
//            base.SetUp();
//            _mockedValidator = _mocks.StrictMock<IValidator<MedicalVendorEarning>>();
//            _mockedMapper = _mocks.StrictMock<IMapper<MedicalVendorEarning, MVEarningEntity>>();
            
//            _medicalVendorEarningRepository = new MedicalVendorEarningRepository(_persistenceLayer,
//                _mockedValidator, _mockedMapper);
//        }

//        [TearDown]
//        protected override void TearDown()
//        {
//            base.TearDown();
//            _medicalVendorEarningRepository = null;
//            _medicalVendorEarningIdsPassedToFactory.Clear();
//        }

//        private readonly List<long> _medicalVendorEarningIdsPassedToFactory = new List<long>();
//        private delegate bool GetMedicalVendorEarningsDelegate(EntityCollection<MVEarningEntity>
//            medicalVendorEarningEntities);
//        private bool GetMedicalVendorEarnings(IEnumerable<MVEarningEntity> medicalVendorEarningEntities)
//        {
//            foreach (var medicalVendorEarningEntity in medicalVendorEarningEntities)
//            {
//                _medicalVendorEarningIdsPassedToFactory.Add(medicalVendorEarningEntity.MvearningId);
//            }
//            return true;
//        }

//        private void ExpectGetMedicalVendorEarnings(IEnumerable<MVEarningEntity> earningEntitiesToReturn)
//        {
//            Expect.Call(_mockedMapper.MapMultiple(earningEntitiesToReturn))
//                .Callback(new GetMedicalVendorEarningsDelegate(GetMedicalVendorEarnings))
//                .Return(new List<MedicalVendorEarning>());
//        }

//        [Test]
//        public void GetEarningsForMedicalVendorUserReturnsEmptyListWhenInvalidIdGiven()
//        {
//            const long invalidMedicalVendorUserId = 0;
//            ExpectGetDataAccessAdapterAndDispose();
//            ExpectFetchEntityCollection();
//            ExpectGetMedicalVendorEarnings(new EntityCollection<MVEarningEntity>());

//            _mocks.ReplayAll();
//            List<MedicalVendorEarning> earnings = _medicalVendorEarningRepository.
//                GetEarningsForMedicalVendorUser(invalidMedicalVendorUserId, new DateTime(), new DateTime());
//            _mocks.VerifyAll();

//            Assert.IsNotNull(earnings);
//            Assert.IsEmpty(earnings);
//        }

//        [Test]
//        public void GetEarningsForMedicalVendorUserPassesOneEntityToFactoryWhenIdHasOneEarning()
//        {
//            const long validMedicalVendorUserId = 1;
//            const int medicalVendorEarningId = 5;
//            var earningEntitiesToReturn = new EntityCollection<MVEarningEntity> {new MVEarningEntity(medicalVendorEarningId)};

//            ExpectGetDataAccessAdapterAndDispose();
//            ExpectFetchEntityCollection(earningEntitiesToReturn);
//            ExpectGetMedicalVendorEarnings(earningEntitiesToReturn);

//            _mocks.ReplayAll();
//            _medicalVendorEarningRepository.GetEarningsForMedicalVendorUser(validMedicalVendorUserId, new DateTime(), new DateTime());
//            _mocks.VerifyAll();

//            const int expectedNumberOfMedicalVendorEarnings = 1;
//            Assert.AreEqual(expectedNumberOfMedicalVendorEarnings, _medicalVendorEarningIdsPassedToFactory.Count);
//            Assert.AreEqual(medicalVendorEarningId, _medicalVendorEarningIdsPassedToFactory.Single());
//        }

//        [Test]
//        [ExpectedException(typeof(DateCannotExceedOtherDateException))]
//        public void GetEarningsForMedicalVendorThrowsExceptionWhenStartDateExceedsEndDate()
//        {
//            var payPeriodStartDate = new DateTime(2001, 1, 1);
//            var payPeriodEndDate = payPeriodStartDate.AddDays(-1);

//            _mocks.ReplayAll();
//            _medicalVendorEarningRepository.GetEarningsForMedicalVendorUser(1, payPeriodStartDate, payPeriodEndDate);
//            _mocks.VerifyAll();
//        }

//        [Test]
//        [ExpectedException(typeof(InvalidObjectException<MedicalVendorEarning>))]
//        public void SaveNewMedicalVendorEarningThrowsExceptionWhenGivenEarningIsInvalid()
//        {
//            var medicalVendorEarning = new MedicalVendorEarning();

//            Expect.Call(_mockedValidator.IsValid(medicalVendorEarning)).Return(false);
//            Expect.Call(_mockedValidator.GetBrokenRuleErrorMessages()).Return(new List<string>());

//            _mocks.ReplayAll();
//            _medicalVendorEarningRepository.SaveMedicalVendorEarning(medicalVendorEarning);
//            _mocks.VerifyAll();
//        }

//        [Test]
//        [ExpectedException(typeof(PersistenceFailureException))]
//        public void SaveNewMedicalVendorEarningThrowsExceptionWhenPersistenceFails()
//        {
//            var medicalVendorEarning = new MedicalVendorEarning();
//            var medicalVendorEarningEntityToSave = new MVEarningEntity();

//            Expect.Call(_mockedValidator.IsValid(medicalVendorEarning)).Return(true);
//            Expect.Call(_mockedMapper.Map(medicalVendorEarning)).Return(medicalVendorEarningEntityToSave);
//            ExpectGetDataAccessAdapterAndDispose();
//            ExpectSaveEntity(false, false, medicalVendorEarningEntityToSave);

//            _mocks.ReplayAll();
//            _medicalVendorEarningRepository.SaveMedicalVendorEarning(medicalVendorEarning);
//            _mocks.VerifyAll();
//        }

//        [Test]
//        public void SaveNewMedicalVendorEarningPersistsEarningWhenValid()
//        {
//            var medicalVendorEarning = new MedicalVendorEarning();
//            var medicalVendorEarningEntityToSave = new MVEarningEntity();

//            Expect.Call(_mockedValidator.IsValid(medicalVendorEarning)).Return(true);
//            Expect.Call(_mockedMapper.Map(medicalVendorEarning)).Return(medicalVendorEarningEntityToSave);
//            ExpectGetDataAccessAdapterAndDispose();
//            ExpectSaveEntity(true, false, medicalVendorEarningEntityToSave);

//            _mocks.ReplayAll();
//            _medicalVendorEarningRepository.SaveMedicalVendorEarning(medicalVendorEarning);
//            _mocks.VerifyAll();
//        }
//    }
//}