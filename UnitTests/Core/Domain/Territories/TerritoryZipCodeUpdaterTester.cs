using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Interfaces;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.Core.Domain.Territories
{
    [TestFixture]
    public class TerritoryZipCodeUpdaterTester
    {
        private MockRepository _mocks;
        private ITerritoryRepository _territoryRepository;
        private ITerritoryZipCodeUpdater _territoryZipCodeUpdater;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _territoryRepository = _mocks.StrictMock<ITerritoryRepository>();
            _territoryZipCodeUpdater = new TerritoryZipCodeUpdater(_territoryRepository);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        [Test]
        public void GetAllChildrenWithZipCodesReturnsEmptyCollectionWhenGivenParentHasNoChildren()
        {
            const int parentTerritoryId = 33;
            var zipCodes = new List<ZipCode> { new ZipCode(), new ZipCode(), new ZipCode() };
            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).Return(new List<Territory>());

            _mocks.ReplayAll();
            IEnumerable<Territory> childTerritories = _territoryZipCodeUpdater.GetAllChildrenWithZipCodes(zipCodes, parentTerritoryId);
            _mocks.VerifyAll();

            Assert.IsEmpty(childTerritories.ToList(), "Collection of returned child territories should have been empty.");
        }

        [Test]
        public void GetAllChildrenWithZipCodesReturnsEmptyCollectionWhenGivenEmptyCollectionOfZipCodes()
        {
            const int parentTerritoryId = 44;
            var territories = new List<Territory> { new FakeTerritory(), new FakeTerritory(), new FakeTerritory() };
            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).Return(territories);

            _mocks.ReplayAll();
            var childTerritories = _territoryZipCodeUpdater.GetAllChildrenWithZipCodes(new List<ZipCode>(), parentTerritoryId);
            _mocks.VerifyAll();

            Assert.IsEmpty(childTerritories.ToList(), "Collection of returned child territories should have been empty.");
        }

        [Test]
        public void GetAllChildrenWithZipCodesReturnsSingleChildWithMatchingZipCode()
        {
            const int expectedNumberOfChildTerritories = 1;
            const int matchingZipId = 382;
            const int parentTerritoryId = 22;
            Territory expectedChild = new FakeTerritory(400) { ZipCodes = new List<ZipCode> { new ZipCode(matchingZipId) } };

            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).Return(new List<Territory> { expectedChild });
            Expect.Call(_territoryRepository.GetChildTerritories(expectedChild.Id)).Return(new List<Territory>());

            _mocks.ReplayAll();
            var childTerritories = _territoryZipCodeUpdater.GetAllChildrenWithZipCodes(
                new List<ZipCode> { new ZipCode(matchingZipId) }, parentTerritoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedNumberOfChildTerritories, childTerritories.Count(), "Only one child territory should have been returned.");
            Assert.AreEqual(expectedChild, childTerritories.Single(), "The wrong child territory was returned.");
        }

        [Test]
        public void GetAllChildrenWithZipCodesReturnsChildWhereOneOfThreeMatchesGivenZip()
        {
            const int expectedNumberOfChildTerritories = 1;
            const int matchingZipId = 382;
            const int parentTerritoryId = 22;
            Territory expectedChild = new FakeTerritory(400) { ZipCodes = new List<ZipCode>
                { new ZipCode(matchingZipId), new ZipCode(matchingZipId + 1), new ZipCode(matchingZipId + 2) } };

            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).Return(new List<Territory> { expectedChild });
            Expect.Call(_territoryRepository.GetChildTerritories(expectedChild.Id)).Return(new List<Territory>());

            _mocks.ReplayAll();
            var childTerritories = _territoryZipCodeUpdater.GetAllChildrenWithZipCodes(
                new List<ZipCode> { new ZipCode(matchingZipId) }, parentTerritoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedNumberOfChildTerritories, childTerritories.Count(), "Only one child territory should have been returned.");
            Assert.AreEqual(expectedChild, childTerritories.Single(), "The wrong child territory was returned.");
        }

        [Test]
        public void GetAllChildrenWithZipCodesReturnsChildWhereSingleZipMatchesOneOfThreeGivenZips()
        {
            const int expectedNumberOfChildTerritories = 1;
            const int matchingZipId = 382;
            const int parentTerritoryId = 22;
            var zipCodesToCheck = new List<ZipCode> { new ZipCode(matchingZipId), new ZipCode(matchingZipId + 1), new ZipCode(matchingZipId - 1) };
            Territory expectedChild = new FakeTerritory(400) { ZipCodes = new List<ZipCode> { new ZipCode(matchingZipId) } };

            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).Return(new List<Territory> { expectedChild });
            Expect.Call(_territoryRepository.GetChildTerritories(expectedChild.Id)).Return(new List<Territory>());

            _mocks.ReplayAll();
            var childTerritories = _territoryZipCodeUpdater.GetAllChildrenWithZipCodes(
                zipCodesToCheck, parentTerritoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedNumberOfChildTerritories, childTerritories.Count(), "Only one child territory should have been returned.");
            Assert.AreEqual(expectedChild, childTerritories.Single(), "The wrong child territory was returned.");
        }

        [Test]
        public void GetAllChildrenWithZipCodesReturnsOneChildWhenTwoChildrenShareMatchingZip()
        {
            const int expectedNumberOfChildTerritories = 1;
            const int parentTerritoryId = 22;
            var listWithMatchingZip = new List<ZipCode> { new ZipCode(382) };
            Territory expectedChild = new FakeTerritory(400) { ZipCodes = listWithMatchingZip };
            Territory otherChild = new FakeTerritory(expectedChild.Id + 1) { ZipCodes = listWithMatchingZip };

            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).Return(new List<Territory> { expectedChild, otherChild });
            Expect.Call(_territoryRepository.GetChildTerritories(expectedChild.Id)).Return(new List<Territory>());

            _mocks.ReplayAll();
            var childTerritories = _territoryZipCodeUpdater.GetAllChildrenWithZipCodes(listWithMatchingZip, parentTerritoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedNumberOfChildTerritories, childTerritories.Count(), "Only one child territory should have been returned.");
        }

        [Test]
        public void GetAllChildrenWithZipCodesReturnsChildAndGrandchildWithMatchingZip()
        {
            const int expectedNumberOfChildTerritories = 2;
            const int parentTerritoryId = 9;
            var zipCodes = new List<ZipCode> { new ZipCode(44444) };
            Territory expectedChild = new FakeTerritory(8) { ZipCodes = zipCodes };
            Territory expectedGrandchild = new FakeTerritory(7) { ZipCodes = zipCodes };

            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).Return(new List<Territory> { expectedChild });
            Expect.Call(_territoryRepository.GetChildTerritories(expectedChild.Id)).Return(new List<Territory> { expectedGrandchild });
            Expect.Call(_territoryRepository.GetChildTerritories(expectedGrandchild.Id)).Return(new List<Territory>());

            _mocks.ReplayAll();
            var childTerritories = _territoryZipCodeUpdater.GetAllChildrenWithZipCodes(zipCodes, parentTerritoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedNumberOfChildTerritories, childTerritories.Count(), "Returned list did not contain the expected number of children.");
            Assert.Contains(expectedChild, childTerritories.ToList(), "Returned list did not contain expected child territory.");
            Assert.Contains(expectedGrandchild, childTerritories.ToList(), "Returned list did not contain expected grandchild territory.");
        }

        [Test]
        public void GetAllChildrenWithZipCodesReturns2Children1Grandchild()
        {
            const int expectedNumberOfChildren = 3;
            const int parentTerritoryId = 9;
            var listWithMatchingZip = new List<ZipCode> { new ZipCode(12), new ZipCode(1) };
            Territory matchingChild1 = new FakeTerritory(1) { ZipCodes = listWithMatchingZip };
            Territory matchingChild2 = new FakeTerritory(2) { ZipCodes = listWithMatchingZip };
            Territory matchingGrandchild = new FakeTerritory(3) { ZipCodes = listWithMatchingZip };
            Territory nonmatchingChild = new FakeTerritory(4);

            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).
                Return(new List<Territory> { matchingChild1, matchingChild2, nonmatchingChild });
            Expect.Call(_territoryRepository.GetChildTerritories(matchingChild1.Id)).Return(new List<Territory>());
            Expect.Call(_territoryRepository.GetChildTerritories(matchingChild2.Id)).
                Return(new List<Territory> { matchingGrandchild });
            Expect.Call(_territoryRepository.GetChildTerritories(matchingGrandchild.Id)).Return(new List<Territory>());

            _mocks.ReplayAll();
            var childTerritories = _territoryZipCodeUpdater.GetAllChildrenWithZipCodes(listWithMatchingZip, parentTerritoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedNumberOfChildren, childTerritories.Count(), "Returned list did not contain the expected number of children.");
            Assert.IsFalse(childTerritories.Contains(nonmatchingChild), "Returned list included nonmatching territory.");
        }
    }
}