using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using NUnit.Framework;

namespace Falcon.UnitTests.Core.Domain.Marketing
{
    [TestFixture]
    public class SourceCodeTester
    {
        private SourceCode _sourceCode1;

        [SetUp]
        public void SetupSourceCode()
        {
            _sourceCode1 = new SourceCode
            {
                DiscountType = DiscountType.PerPackage,
                DiscountValueType = DiscountValueType.Money,
                CouponValue = 10m
            };
        }

        [Test]
        public void CalculateDiscount_TenPercentDiscountOn100DollarReturns10()
        {
            var sourceCode = new SourceCode
                                 {
                                     DiscountType = DiscountType.PerOrder,
                                     DiscountValueType = DiscountValueType.Percent,
                                     CouponValue = 10m
                                 };

            var returnValue = sourceCode.CalculateDiscount(100m);

            Assert.AreEqual(10m,returnValue);
        }

        [Test]
        public void CalculateDiscount_TenDollarDiscountOn100DollarReturns10()
        {
            var sourceCode = new SourceCode
            {
                DiscountType = DiscountType.PerOrder,
                DiscountValueType = DiscountValueType.Money,
                CouponValue = 10m
            };

            var returnValue = sourceCode.CalculateDiscount(100m);

            Assert.AreEqual(10m, returnValue);
        }


        [Test]
        public void CalculateDiscount_Package1TenDollarDiscountGivesNoDiscountIfPackage2IsSelected()
        {
            var packageDiscounts = new List<SourceCodeItemWiseDiscount>();

            packageDiscounts.Add(new SourceCodeItemWiseDiscount { Id = 1, DiscountValueType = DiscountValueType.Money, DiscountAmount = 10m });
            

            var sourceCode = new SourceCode
            {
                DiscountType = DiscountType.PerPackage,
                DiscountValueType = DiscountValueType.Money,               
                CouponValue = 10m
            };

            var selectedPackageId = 2;

            var returnValue = sourceCode.CalculateDiscount(100m,selectedPackageId);

            Assert.AreEqual(0m, returnValue);
        }

        [Test]
        public void CalculateDiscount_Package1TenDollarDiscountGives10DiscountIfPackage2IsSelected()
        {
            var packageDiscounts = new List<SourceCodeItemWiseDiscount>();
            packageDiscounts.Add(new SourceCodeItemWiseDiscount { Id = 1, DiscountValueType = DiscountValueType.Money, DiscountAmount = 10m });

            _sourceCode1.PackageDiscounts = packageDiscounts;

            var selectedPackageId = 1;

            var returnValue = _sourceCode1.CalculateDiscount(100m, selectedPackageId);

            Assert.AreEqual(10m, returnValue);
        }

        [Test]
        public void CalculateDiscount_Package1TenDollarDiscount_And_Package2_15DollarDiscount_GivesCorrectDiscountsForEachPackage()
        {
            var packageDiscounts = new List<SourceCodeItemWiseDiscount>();
            packageDiscounts.Add(new SourceCodeItemWiseDiscount { Id = 1, DiscountValueType = DiscountValueType.Money, DiscountAmount = 10m });
            packageDiscounts.Add(new SourceCodeItemWiseDiscount { Id = 2, DiscountValueType = DiscountValueType.Money, DiscountAmount = 15m });

            _sourceCode1.PackageDiscounts = packageDiscounts;

            var selectedPackageId1 = 1;
            var selectedPackageId2 = 2;
            var returnValue1 = _sourceCode1.CalculateDiscount(100m, selectedPackageId1);
            var returnValue2 = _sourceCode1.CalculateDiscount(100m, selectedPackageId2);


            //assert
            Assert.AreEqual(10m, returnValue1);
            Assert.AreEqual(15m, returnValue2);
        }

        [Test]
        public void CalculateDiscount_Package1TenDollarDiscount_And_Package2_15PercentDiscount_GivesCorrectDiscountsForEachPackage()
        {
            var packageDiscounts = new List<SourceCodeItemWiseDiscount>();
            packageDiscounts.Add(new SourceCodeItemWiseDiscount { Id = 1, DiscountValueType = DiscountValueType.Money, DiscountAmount = 10m });
            packageDiscounts.Add(new SourceCodeItemWiseDiscount { Id = 2, DiscountValueType = DiscountValueType.Percent, DiscountAmount = 15m });

            _sourceCode1.PackageDiscounts = packageDiscounts;

            var selectedPackageId1 = 1;
            var selectedPackageId2 = 2;
            var returnValue1 = _sourceCode1.CalculateDiscount(200m, selectedPackageId1);
            var returnValue2 = _sourceCode1.CalculateDiscount(200m, selectedPackageId2);


            //assert
            Assert.AreEqual(10m, returnValue1);
            Assert.AreEqual(30m, returnValue2);
        }

        [Test]
        public void CalculateDiscount_ShoudReturnNoDiscountIfPackageIdIsNotApplicable()
        {
            var packageDiscounts = new List<SourceCodeItemWiseDiscount>();
            packageDiscounts.Add(new SourceCodeItemWiseDiscount { Id = 1, DiscountValueType = DiscountValueType.Money, DiscountAmount = 10m });
            packageDiscounts.Add(new SourceCodeItemWiseDiscount { Id = 2, DiscountValueType = DiscountValueType.Percent, DiscountAmount = 15m });

            _sourceCode1.PackageDiscounts = packageDiscounts;

            var selectedPackageId = 6;            
            var returnValue = _sourceCode1.CalculateDiscount(200m, selectedPackageId);            

            //assert
            Assert.AreEqual(0m, returnValue);            
        }
    }
}