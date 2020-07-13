using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using NUnit.Framework;
using Rhino.Mocks;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Web.UnitTests.Infrastructure.Application
{
    [TestFixture]
    public class ConfigurationSettingRepositoryTester
    {
        private MockRepository _mocks;
        private IPersistenceLayer _persistenceLayer;
        private IDataAccessAdapter _dataAccessAdapter;

        private IConfigurationSettingRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _persistenceLayer = _mocks.StrictMock<IPersistenceLayer>();
            _dataAccessAdapter = _mocks.StrictMock<IDataAccessAdapter>();

            _repository = new ConfigurationSettingRepository(_persistenceLayer);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
            _repository = null;
        }

        readonly string _expectedDateString = new DateTime(2001, 1, 1).ToString();
        private delegate bool FetchEntityCollectionDelegate(IEntityCollection2 collection, IRelationPredicateBucket bucket);
        private bool FetchEntityCollection(IEntityCollection2 collection, IRelationPredicateBucket bucket)
        {
            if (collection != null)
            {
                collection.Add(new GlobalConfigurationEntity 
                                   { Name = ConfigurationSettingName.EpochDate.ToString(), Value = _expectedDateString });
            }
            return true;
        }

        [Test]
        public void GetConfigurationValueReturnsEpochDateWhenEpochNameSettingGiven()
        {
            Expect.Call(_persistenceLayer.GetDataAccessAdapter()).Return(_dataAccessAdapter);
            Expect.Call(() => _dataAccessAdapter.FetchEntityCollection(null, null)).IgnoreArguments().
                Callback(new FetchEntityCollectionDelegate(FetchEntityCollection));
            Expect.Call(_dataAccessAdapter.Dispose);

            _mocks.ReplayAll();
            string epochDateString = _repository.GetConfigurationValue(ConfigurationSettingName.EpochDate);
            _mocks.VerifyAll();

            var epochDate = DateTime.Parse(epochDateString);

            Assert.AreEqual(DateTime.Parse(_expectedDateString), epochDate);
        }
    }
}