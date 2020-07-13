using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class MedicalVendorPaymentPodViewDataFactoryTester
    {
        private readonly IMedicalVendorPaymentPodViewDataFactory _factory = new MedicalVendorPaymentPodViewDataFactory();

        [Test]
        public void CreatePodViewDataReturnsEmptyListWhenEmptyListGiven()
        {
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>();

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData = 
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.IsNotNull(medicalVendorPaymentPodViewData);
            Assert.IsEmpty(medicalVendorPaymentPodViewData);
        }

        [Test]
        public void CreatePodViewDataReturnsOneObjectWhenOneItemGiven()
        {
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> {new MedicalVendorInvoiceItem()};

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData =
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.IsTrue(medicalVendorPaymentPodViewData.HasSingleItem());
        }

        [Test]
        public void CreatePodViewDataReturnsOneObjectWhenTwoItemsForSamePodGiven()
        {
            var medicalVendorInvoiceItem = new MedicalVendorInvoiceItem {PodId = 2};
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> 
                { medicalVendorInvoiceItem, medicalVendorInvoiceItem };

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData =
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.IsTrue(medicalVendorPaymentPodViewData.HasSingleItem());
        }

        [Test]
        public void CreatePodViewDataReturnsTwoObjectsWhenTwoItemsForTwoPodsGiven()
        {
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>
            {
                new MedicalVendorInvoiceItem { PodId = 2 }, 
                new MedicalVendorInvoiceItem { PodId = 3 }
            };

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData =
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.IsTrue(medicalVendorPaymentPodViewData.Count == 2);
        }

        [Test]
        public void CreatePodViewDataSetsAmountEarnedToSumOfMedicalVendorAmountEarnedForOnePod()
        {
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>
            {
                new MedicalVendorInvoiceItem { PodId = 1, MedicalVendorAmountEarned = 3.22m }, 
                new MedicalVendorInvoiceItem { PodId = 1, MedicalVendorAmountEarned = 4.00m }
            };
            decimal expectAmountEarned = medicalVendorInvoiceItems.Sum(m => m.MedicalVendorAmountEarned);

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData =
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.AreEqual(expectAmountEarned, medicalVendorPaymentPodViewData.Single().AmountEarned);
        }

        [Test]
        public void CreatePodViewDataSetsNumberOfEvaluationsToOneForEachPodItem()
        {
            const int expectedNumberOfEvaluations = 1;
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>
            {
                new MedicalVendorInvoiceItem { PodId = 1 }, 
                new MedicalVendorInvoiceItem { PodId = 2 }
            };

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData =
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.AreEqual(expectedNumberOfEvaluations, medicalVendorPaymentPodViewData[0].NumberOfEvaluations);
            Assert.AreEqual(expectedNumberOfEvaluations, medicalVendorPaymentPodViewData[1].NumberOfEvaluations);
        }

        [Test]
        public void CreatePodViewDataSetsPodIdToGivenPodIdForEachPodData()
        {
            const int expectedPodId = 2;
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>
            {
                new MedicalVendorInvoiceItem { PodId = expectedPodId }, 
            };

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData =
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.AreEqual(expectedPodId, medicalVendorPaymentPodViewData.Single().Pod.Id);
        }

        [Test]
        public void CreatePodViewDataSetsPodNameToGivenPodNameForEachPodData()
        {
            const string expectedPodName = "Bob";
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>
            {
                new MedicalVendorInvoiceItem { PodName = expectedPodName }, 
            };

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData =
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.AreEqual(expectedPodName, medicalVendorPaymentPodViewData.Single().Pod.Name);
        }

        [Test]
        public void CreatePodViewDataSetsPodIdToGivenId()
        {
            const long expectedPodId = 3;
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>
            {
                new MedicalVendorInvoiceItem { PodId = expectedPodId }, 
            };

            List<MedicalVendorPaymentPodViewData> medicalVendorPaymentPodViewData =
                _factory.CreatePodViewData(medicalVendorInvoiceItems);

            Assert.AreEqual(expectedPodId, medicalVendorPaymentPodViewData.Single().Pod.Id);
        }
    }
}