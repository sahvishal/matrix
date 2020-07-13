using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    [Ignore]
    public class CustomCampaignContentRepositoryTester
    {
        //private const int INVALID_CAMPAIGN_ID = 0;
        //private const int VALID_CAMPAIGN_ID = 52;

        //private const int GENERIC_LEFT_MARKETING_MATERIAL_ID = 39;
        //private const int STEP1_LEFT_MARKETING_MATERIAL_ID = 40;

        //private const int NO_STEP = 127;

        //private CustomCampaignContentRepository _repository;

        //[SetUp]        
        //public void SetUp()
        //{
        //    _repository = new CustomCampaignContentRepository();
        //}

        //[Test]
        //public void GetCustomContentReturnsNullWhenCampaignDoesNotExist()
        //{
        //    var marketingMaterial = _repository.GetCustomContent(INVALID_CAMPAIGN_ID, SignupContentPosition.Left);
        //    Assert.IsNull(marketingMaterial);
        //}

        //[Test]
        //public void GetCustomContentReturnsNullWhenCampaignExistsButNoContentForPosition()
        //{
        //    var marketingMaterial = _repository.GetCustomContent(VALID_CAMPAIGN_ID, SignupContentPosition.NoPosition);
        //    Assert.IsNull(marketingMaterial);
        //}

        //[Test]
        //public void GetCustomContentReturnsExpectedMarketingMaterialWhenCampaignExistsAndContentForPosition()
        //{
        //    var marketingMaterial = _repository.GetCustomContent(VALID_CAMPAIGN_ID, SignupContentPosition.Left);
            
        //    Assert.IsNotNull(marketingMaterial);
        //    Assert.AreEqual(GENERIC_LEFT_MARKETING_MATERIAL_ID, marketingMaterial.Id);
        //}

        //[Test]
        //public void GetCustomContentReturnsNullWhenCampaignAndPositionExistButWithDifferentStep()
        //{
        //    var marketingMaterial = _repository.GetCustomContent(VALID_CAMPAIGN_ID, SignupContentPosition.Left, 1);
            
        //    Assert.IsNotNull(marketingMaterial);
        //    Assert.AreEqual(STEP1_LEFT_MARKETING_MATERIAL_ID, marketingMaterial.Id);
        //}
    }
}