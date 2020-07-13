using System;
using Falcon.App.Infrastructure.Repositories.PrintOrder;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    [Ignore("The database must be in a stable state to run these tests.")]
    public class PrintOrderItemRepositoryTester
    {

        [Test]
        public void SourceCodeAssociatedForPrintOrderItem()
        {
            var repository = new PrintOrderItemRepository();
            repository.SourceCodeAssociatedForPrintOrderItem("F1831F");

        }

       
        [Test]
        public void ConfirmPrintOrderStatus()
        {
            var repository = new PrintOrderItemRepository();
            const string sourceCode = "P1838B";
            repository.ConfirmPrintOrderStatus(sourceCode);

        }
        [Test]
        public void GetPrintOrderItemTrackingDetail()
        {
            var repository = new PrintOrderItemTrackingRepository();
            const Int64 printOrderItemId = 1682;
            repository.GetPrintOrderItemTrackingDetail(printOrderItemId);

        }
       
        [Test]
        public void IsPrintOrderItemEditable()
        {
            var repository = new PrintOrderItemRepository();
            ///,1718 

            const Int64 eventCampaignId1 = 1409;
            Assert.IsFalse(repository.IsPrintOrderItemEditable(eventCampaignId1));
            const Int64 eventCampaignId2 = 1410;
            Assert.IsTrue(repository.IsPrintOrderItemEditable(eventCampaignId2));

            const Int64 eventCampaignId3 = 1410000;
            Assert.IsTrue(repository.IsPrintOrderItemEditable(eventCampaignId3));

        }


        [Test]
        public void IsAdvocateHaveAssignedPrintOrderItem()
        {
            var repository = new PrintOrderItemRepository();

            const Int64 eventId = 1880;
            const Int64 advocateId1 = 2;
            Assert.IsTrue(repository.IsAdvocateHaveAssignedPrintOrderItem(advocateId1, eventId));
            const Int64 advocateId2 = 28395;
            Assert.IsFalse(repository.IsAdvocateHaveAssignedPrintOrderItem(advocateId2, eventId));

        }
        [Test]
        public void GetPrintOrderItemAdvocate()
        {
            var repository = new PrintOrderItemRepository();

            const Int64 printOrderItemId = 1760;

            Assert.IsNotNull(repository.GetPrintOrderItemAdvocate(printOrderItemId));
    

        }
        [Test]
        public void GetPrintOrderPdfPathForEventCampaign()
        {
            var repository = new PrintOrderItemRepository();

            const Int64 eventCampaignId = 1663;

           var pdfTemplatePath= repository.GetPrintOrderPdfPathForEventCampaign(eventCampaignId);
           

        }

         
      
    }
}
