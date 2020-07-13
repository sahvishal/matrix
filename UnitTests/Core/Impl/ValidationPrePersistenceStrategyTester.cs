using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class ValidationPrePersistenceStrategyTester
    {
        private MockRepository _mocks;

        private IValidator<FakeDomainObject> _mockedValidator;
        private IPrePersistenceStrategy<FakeDomainObject> _prePersistenceStrategy;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedValidator = _mocks.StrictMock<IValidator<FakeDomainObject>>();
            _prePersistenceStrategy = new ValidationPrePersistenceStrategy<FakeDomainObject>(_mockedValidator);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
            _prePersistenceStrategy = null;
        }

        [Test]
        public void ApplyStrategyDoesNotThrowExceptionWhenValidatorReturnsTrue()
        {
            Expect.Call(_mockedValidator.IsValid(null)).Return(true);

            _mocks.ReplayAll();
            _prePersistenceStrategy.ApplyStrategy(null);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(InvalidObjectException<FakeDomainObject>))]
        public void ApplyStrategyThrowsExceptionWhenValidatorReturnsFalse()
        {
            Expect.Call(_mockedValidator.IsValid(null)).Return(false);
            Expect.Call(_mockedValidator.GetBrokenRuleErrorMessages()).Return(new List<string>());

            _mocks.ReplayAll();
            _prePersistenceStrategy.ApplyStrategy(null);
            _mocks.VerifyAll();
        }
    }
}