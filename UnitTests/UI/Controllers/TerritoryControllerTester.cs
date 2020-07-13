using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.UI.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.UI.Controllers
{
    [TestFixture]
    public class TerritoryControllerTester
    {
        private readonly MockRepository _mocks = new MockRepository();
        private ITerritoryRepository _territoryRepository;
        private ITerritoryController _territoryController;

        [SetUp]
        public void SetUp()
        {
            _territoryRepository = _mocks.StrictMock<ITerritoryRepository>();
            _territoryController = new TerritoryController(_territoryRepository);
        }

        [TearDown]
        public void TearDown()
        {
            _territoryRepository = null;
        }

        [Test]
        public void GetAllParentTerritoriesReturnsListOfTerritoryViewData()
        {
            const string expectedTerritoryName = "Foo";
            var territories = new List<Territory> {new FranchiseeTerritory(3) {Name = expectedTerritoryName}};
            Expect.Call(_territoryRepository.GetAllParentTerritories()).Return(territories);

            _mocks.ReplayAll();
            List<TerritoryViewData> territoryViewData = _territoryController.GetAllParentTerritoryViewData();
            _mocks.VerifyAll();

            Assert.AreEqual(expectedTerritoryName, territoryViewData.Single().TerritoryName, "Incorrect Territory View Data returned.");
        }

        [Test]
        public void GetTerritoryReturnsWhatRepositoryGetTerritoryReturnsForTerritory()
        {
            const long territoryId = 3;
            Territory expectedTerritory = new SalesRepTerritory(territoryId);
            Expect.Call(_territoryRepository.GetTerritory(territoryId)).Return(expectedTerritory);
            Expect.Call(_territoryRepository.GetOwnerNamesForTerritory(expectedTerritory)).Return(new List<string>());

            _mocks.ReplayAll();
            OrderedPair<Territory, List<string>> territoryAndOwnerNames = _territoryController.
                GetTerritoryAndOwnerNames(territoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedTerritory, territoryAndOwnerNames.FirstValue, "Incorrect territory returned.");
        }

        [Test]
        public void GetTerritorySetsListOfOwnersToWhatGetOwnersRepositoryMethodReturns()
        {
            const long territoryId = 3;
            Territory expectedTerritory = new SalesRepTerritory(territoryId);
            var expectedOwnerNames = new List<string> { "Bob", "Alice" };
            Expect.Call(_territoryRepository.GetTerritory(territoryId)).Return(expectedTerritory);
            Expect.Call(_territoryRepository.GetOwnerNamesForTerritory(expectedTerritory)).Return(expectedOwnerNames);

            _mocks.ReplayAll();
            OrderedPair<Territory, List<string>> territoryAndOwnerNames = _territoryController.
                GetTerritoryAndOwnerNames(territoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedOwnerNames, territoryAndOwnerNames.SecondValue, "Incorrect owner list returned.");
        }

        [Test]
        public void GetChildTerritoriesReturnsListOfChildTerritoryViewData()
        {
            const long parentTerritoryId = 5;
            const long expectedChildTerritoryId = 25;
            var returnedChildTerritories = new List<Territory> {new HospitalPartnerTerritory(expectedChildTerritoryId)};
            Expect.Call(_territoryRepository.GetChildTerritories(parentTerritoryId)).Return(returnedChildTerritories);

            _mocks.ReplayAll();
            List<TerritoryViewData> territories = _territoryController.GetChildTerritories(parentTerritoryId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedChildTerritoryId, territories.Single().TerritoryId, "Incorrect territory returned.");
        }

        [Test]
        public void GetTerritoriesAndAssignmentsForSalesRepSetsReturnedAssignmentToAssignmentOfGivenSalesRep()
        {
            const long expectedSalesRepId = 3;
            var returnedSalesRepTerritories = new List<SalesRepTerritory> { new SalesRepTerritory {
                SalesRepTerritoryAssignments = new List<SalesRepTerritoryAssignment>
                { new SalesRepTerritoryAssignment {SalesRep = new SalesRepresentative {SalesRepresentativeId = expectedSalesRepId}} }}};
            Expect.Call(_territoryRepository.GetTerritoriesForSalesRep(expectedSalesRepId)).Return(
                returnedSalesRepTerritories);

            _mocks.ReplayAll();
            List<OrderedPair<SalesRepTerritory, SalesRepTerritoryAssignment>> territoriesAndAssignmentsForSalesRep =
                _territoryController.GetTerritoriesAndAssignmentsForSalesRep(expectedSalesRepId);
            _mocks.VerifyAll();

            var selectedSalesRepId = territoriesAndAssignmentsForSalesRep.Single().SecondValue.SalesRep.SalesRepresentativeId;
            Assert.AreEqual(expectedSalesRepId, selectedSalesRepId, "Incorrect Sales Rep Territory Assignment returned.");
        }
    }
}