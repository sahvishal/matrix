using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Service;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class ShoppingCartServiceTester
    {
        private const long VALID_EVENT_ID = 1926;
        private const long VALID_ROLE_ID = (long)Roles.CallCenterRep;
        private const long VALID_PACKAGE_ID = 84;
        private const long VALID_TEST_ID = 28;

        private readonly IShoppingCartService _shoppingCartService = new ShoppingCartService();

        //[Test]
        //public void GetPackageSelectionViewDataReturnsDefaultDataIfNoSelectionIsDone()
        //{
        //    var viewData = _shoppingCartService.GetPackageSelectionViewData(VALID_EVENT_ID, VALID_ROLE_ID, 0, null);

        //    Assert.LessOrEqual(viewData.SelectedPackageId, 0);
        //    Assert.IsEmpty(viewData.SelectedTestIds);
        //}

        //[Test]
        //public void GetPackageSelectionViewDataReturnsPackageIdAndItsTestIfPackageIdIsGiven()
        //{
        //    var viewData = _shoppingCartService.GetPackageSelectionViewData(VALID_EVENT_ID, VALID_ROLE_ID, VALID_PACKAGE_ID, null);

        //    Assert.GreaterOrEqual(viewData.SelectedPackageId, 0);
        //    Assert.IsNotEmpty(viewData.SelectedTestIds);
        //}

        //[Test]
        //public void GetPackageSelectionViewDataReturnsPackageIdAndItsTestIfTestIdsAreGiven()
        //{
        //    var testIds = new List<long> { 1, 2, 20, 24 };
        //    var viewData = _shoppingCartService.GetPackageSelectionViewData(VALID_EVENT_ID, VALID_ROLE_ID, 0, testIds);

        //    Assert.GreaterOrEqual(viewData.SelectedPackageId, 0);
        //    Assert.IsNotEmpty(viewData.SelectedTestIds);
        //}

        //[Test]
        //public void GetPackageSelectionViewDataReturnsPackageIdAndItsTestPlusAddiotionalTestIfTestIdsAreGiven()
        //{
        //    var testIds = new List<long> { 1, 2, 20, 24, VALID_TEST_ID };
        //    var viewData = _shoppingCartService.GetPackageSelectionViewData(VALID_EVENT_ID, VALID_ROLE_ID, 0, testIds);

        //    Assert.GreaterOrEqual(viewData.SelectedPackageId, 0);
        //    Assert.IsNotEmpty(viewData.SelectedTestIds);
        //}

        //[Test]
        //public void GetPackageSelectionViewDataReturnsRecommendationIfTestIdsAreGivenWithMorePrice()
        //{
        //    var testIds = new List<long> { 1, 2 };
        //    var viewData = _shoppingCartService.GetPackageSelectionViewData(VALID_EVENT_ID, VALID_ROLE_ID, 0, testIds);

        //    Assert.LessOrEqual(viewData.SelectedPackageId, 0);
        //    Assert.IsNotEmpty(viewData.SelectedTestIds);
        //    Assert.IsNotEmpty(viewData.RecommendationMessage);
        //}

        //[Test]
        //public void GetPackageSelectionViewDataReturnsRecommendationIfTestIdsAreGivenWithLessPrice()
        //{
        //    var testIds = new List<long> { 2, 20 };
        //    var viewData = _shoppingCartService.GetPackageSelectionViewData(VALID_EVENT_ID, VALID_ROLE_ID, 0, testIds);

        //    Assert.LessOrEqual(viewData.SelectedPackageId, 0);
        //    Assert.IsNotEmpty(viewData.SelectedTestIds);
        //    Assert.IsNotEmpty(viewData.RecommendationMessage);
        //}
    }
}