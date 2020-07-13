using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.UI.Controllers;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.UI.Geo
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class TerritoryControllerTester
    {
        private const long SALES_REP_ID_WITH_TERRITORIES = 179;
        const long VALID_FRANCHISEE_ID = 97;

        private readonly ITerritoryController _territoryController = new TerritoryController();

        [Test]
        public void GetTerritoriesAndAssignmentsForSalesRepReturnsTerritories()
        {
            List<OrderedPair<SalesRepTerritory, SalesRepTerritoryAssignment>> territoriesAndAssignmentsForSalesRep =
                _territoryController.GetTerritoriesAndAssignmentsForSalesRep(SALES_REP_ID_WITH_TERRITORIES);

            Assert.IsNotNull(territoriesAndAssignmentsForSalesRep, "Null collection of territories and assignments returned.");
            Assert.IsNotEmpty(territoriesAndAssignmentsForSalesRep, "Empty collection of territories and assignments returned.");
        }

        [Test]
        public void GetTerritoryViewDataAvailableForSalesRepReturnsViewData()
        {
            var territories = _territoryController.GetTerritoryViewDataAvailableForSalesRep(VALID_FRANCHISEE_ID, SALES_REP_ID_WITH_TERRITORIES);

            Assert.IsNotNull(territories, "Null collection of territories returned.");
            Assert.IsNotEmpty(territories, "Empty collection of territories and assignments returned.");
        }
    }
}