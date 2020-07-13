using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.ValueTypes
{
    [TestFixture]
    public class RepositoryStrategySetTester
    {
        private MockRepository _mocks;
        private IPrePersistenceStrategy<int> _mockedPrePersistenceStrategy;
        private IPostPersistenceStrategy<int> _mockedPostPersistenceStrategy;
        private IPostFetchStrategy<int> _mockedPostFetchStrategy;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedPrePersistenceStrategy = _mocks.StrictMock<IPrePersistenceStrategy<int>>();
            _mockedPostPersistenceStrategy = _mocks.StrictMock<IPostPersistenceStrategy<int>>();
            _mockedPostFetchStrategy = _mocks.StrictMock<IPostFetchStrategy<int>>();
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        public void ConstructorInitializesPrePersistenceStrategyCollection()
        {
            var repositoryStrategySet = new RepositoryStrategySet<int>();

            Assert.IsNotNull(repositoryStrategySet.PrePersistenceStrategies,
                "PrePersistenceStrategies collection uninitialized.");
        }

        [Test]
        public void WithPrePersistenceStrategyAddsGivenStrategyToCollection()
        {
            IPrePersistenceStrategy<int> expectedStrategy = _mockedPrePersistenceStrategy;
            var repositoryStrategySet = new RepositoryStrategySet<int>();

            repositoryStrategySet.WithPrePersistenceStrategy(expectedStrategy);

            Assert.AreEqual(expectedStrategy, repositoryStrategySet.PrePersistenceStrategies.Single(),
                "Given strategy not added to collection of PrePersistenceStrategies.");
        }

        [Test]
        public void WithPrePersistenceStrategyReturnsObjectItWasCalledOn()
        {
            IPrePersistenceStrategy<int> expectedStrategy = _mockedPrePersistenceStrategy;
            var repositoryStrategySet = new RepositoryStrategySet<int>();
            var returnedStrategySet = repositoryStrategySet.WithPrePersistenceStrategy(expectedStrategy);

            Assert.AreSame(returnedStrategySet, returnedStrategySet);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WithPrePersistenceStrategyThrowsExceptionWhenNullStrategyGiven()
        {
            var repositoryStrategySet = new RepositoryStrategySet<int>();

            repositoryStrategySet.WithPrePersistenceStrategy(null);
        }

        [Test]
        public void WithPostPersistenceStrategyAddsGivenStrategyToCollection()
        {
            IPostPersistenceStrategy<int> expectedStrategy = _mockedPostPersistenceStrategy;
            var repositoryStrategySet = new RepositoryStrategySet<int>();

            repositoryStrategySet.WithPostPersistenceStrategy(expectedStrategy);

            Assert.AreEqual(expectedStrategy, repositoryStrategySet.PostPersistenceStrategies.Single(),
                "Given strategy not added to collection of PostPersistenceStrategies.");
        }

        [Test]
        public void WithPostPersistenceStrategyReturnsObjectItWasCalledOn()
        {
            IPostPersistenceStrategy<int> expectedStrategy = _mockedPostPersistenceStrategy;
            var repositoryStrategySet = new RepositoryStrategySet<int>();
            var returnedStrategySet = repositoryStrategySet.WithPostPersistenceStrategy(expectedStrategy);

            Assert.AreSame(returnedStrategySet, returnedStrategySet);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WithPostPersistenceStrategyThrowsExceptionWhenNullStrategyGiven()
        {
            var repositoryStrategySet = new RepositoryStrategySet<int>();

            repositoryStrategySet.WithPostPersistenceStrategy(null);
        }

        [Test]
        public void WithPostFetchStrategyAddsGivenStrategyToCollection()
        {
            IPostFetchStrategy<int> expectedStrategy = _mockedPostFetchStrategy;
            var repositoryStrategySet = new RepositoryStrategySet<int>();

            repositoryStrategySet.WithPostFetchStrategy(expectedStrategy);

            Assert.AreEqual(expectedStrategy, repositoryStrategySet.PostFetchStrategies.Single(),
                "Given strategy not added to collection of PostFetchStrategies.");
        }

        [Test]
        public void WithPostFetchStrategyReturnsObjectItWasCalledOn()
        {
            IPostFetchStrategy<int> expectedStrategy = _mockedPostFetchStrategy;
            var repositoryStrategySet = new RepositoryStrategySet<int>();
            var returnedStrategySet = repositoryStrategySet.WithPostFetchStrategy(expectedStrategy);

            Assert.AreSame(returnedStrategySet, returnedStrategySet);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WithPostFetchStrategyThrowsExceptionWhenNullStrategyGiven()
        {
            var repositoryStrategySet = new RepositoryStrategySet<int>();

            repositoryStrategySet.WithPostFetchStrategy(null);
        }
    }
}