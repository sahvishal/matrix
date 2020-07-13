using Falcon.App.Core.ValueTypes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValueTypes
{
    [TestFixture]
    public class WeightTester
    {
        private const double NUMBER_OF_GRAMS_IN_ONE_POUND = 453.592;

        [Test]
        public void TotalPoundsIs0When0PassedToConstructor()
        {
            const double expectedTotalPounds = 0;

            var weight = new Weight(expectedTotalPounds);
            
            Assert.AreEqual(expectedTotalPounds, weight.TotalPounds);
        }

        [Test]
        public void TotalPoundsIs1When1PassedToConstructor()
        {
            const double expectedTotalPounds = 1;

            var weight = new Weight(expectedTotalPounds);

            Assert.AreEqual(expectedTotalPounds, weight.TotalPounds);
        }

        [Test]
        public void TotalPoundsIsEqualToValuePassedIntoConstructor()
        {
            for (int i = 2; i < 10; i++)
            {
                double totalPounds = new Weight(i).TotalPounds;
                Assert.AreEqual(i, totalPounds, "Expected {0} TotalPounds but got {1}.", i, totalPounds);
            }
        }

        [Test]
        public void GramsIs0WhenEnteredWeightIs0Pounds()
        {
            const double totalPounds = 0;
            const double expectedGrams = 0;

            var weight = new Weight(totalPounds);

            Assert.AreEqual(expectedGrams, weight.Grams);
        }

        [Test]
        public void GramsIs453Point592WhenTotalPoundsIs1()
        {
            const double totalPounds = 1;
            const double expectedGrams = NUMBER_OF_GRAMS_IN_ONE_POUND;

            var weight = new Weight(totalPounds);

            Assert.AreEqual(expectedGrams, weight.Grams);
        }

        [Test]
        public void GramsIsExpectedAmountWhenTotalPoundsIs5()
        {
            const double totalPounds = 5;
            const double expectedGrams = NUMBER_OF_GRAMS_IN_ONE_POUND*5;

            var weight = new Weight(totalPounds);

            Assert.AreEqual(expectedGrams, weight.Grams);
        }

        [Test]
        public void KilogramsIs0WhenGramsIs0()
        {
            const double grams = 0;
            const double pounds = grams / NUMBER_OF_GRAMS_IN_ONE_POUND;
            const double expectedKilograms = 0;

            var weight = new Weight(pounds);

            Assert.AreEqual(expectedKilograms, weight.Kilograms);
        }

        [Test]
        public void KilogramsIsOneOneThousandthWhenGramsIs1()
        {
            const double grams = 1;
            const double pounds = grams / NUMBER_OF_GRAMS_IN_ONE_POUND;
            const double expectedKilograms = .001;

            var weight = new Weight(pounds);

            Assert.AreEqual(expectedKilograms, weight.Kilograms);
        }

        [Test]
        public void KilogramsIs1WhenGramsIs1000()
        {
            const double grams = 1000;
            const double pounds = grams / NUMBER_OF_GRAMS_IN_ONE_POUND;
            const double expectedKilograms = 1;

            var weight = new Weight(pounds);

            Assert.AreEqual(expectedKilograms, weight.Kilograms);
        }

        [Test]
        public void TotalOuncesIs0WhenTotalPoundsIs0()
        {
            const double totalPounds = 0;
            const double expectedTotalOunces = 0;

            var weight = new Weight(totalPounds);

            double ounces = weight.TotalOunces;
            Assert.AreEqual(expectedTotalOunces, ounces);
        }

        [Test]
        public void TotalOuncesIs1WhenTotalPoundsIsOneSixteenth()
        {
            const double totalPounds = .0625;
            const double expectedTotalOunces = 1;

            var weight = new Weight(totalPounds);

            Assert.AreEqual(expectedTotalOunces, weight.TotalOunces);
        }

        [Test]
        public void TotalOuncesIs16WhenTotalPoundsIs1()
        {
            const double totalPounds = 1;
            const double expectedTotalOunces = 16;

            var weight = new Weight(totalPounds);

            Assert.AreEqual(expectedTotalOunces, weight.TotalOunces);
        }

        [Test]
        public void PoundsIs0WhenTotalOuncesIs0()
        {
            const double expectedPounds = 0;
            const double totalOunces = 0;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedPounds, weight.Pounds);
        }

        [Test]
        [Ignore]
        public void PoundsIs0WhenTotalOuncesIs1()
        {
            const double expectedPounds = 0;
            const double totalOunces = 1;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedPounds, weight.Pounds);
        }

        [Test]
        [Ignore]
        public void PoundsIs0WhenTotalOuncesIs15()
        {
            const double expectedPounds = 0;
            const double totalOunces = 15;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedPounds, weight.Pounds);
        }

        [Test]
        public void PoundsIs1WhenTotalOuncesIs16()
        {
            const double expectedPounds = 1;
            const double totalOunces = 16;
            
            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedPounds, weight.Pounds);
        }

        [Test]
        [Ignore]
        public void PoundsIs1WhenTotalOuncesIs17()
        {
            const double expectedPounds = 1;
            const double totalOunces = 17;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedPounds, weight.Pounds);
        }

        [Test]
        [Ignore]
        public void PoundsIs1WhenTotalOuncesIs31()
        {
            const double expectedPounds = 1;
            const double totalOunces = 31;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedPounds, weight.Pounds);
        }

        [Test]
        public void PoundsIs2WhenTotalOuncesIs32()
        {
            const double expectedPounds = 2;
            const double totalOunces = 32;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedPounds, weight.Pounds);
        }

        [Test]
        public void OuncesIs0WhenTotalOuncesIs0()
        {
            const double expectedOunces = 0;
            const double totalOunces = 0;

            var weight = new Weight(totalOunces/16);

            Assert.AreEqual(expectedOunces, weight.Ounces);
        }

        [Test]
        public void OuncesIs1WhenTotalOuncesIs1()
        {
            const double expectedOunces = 1;
            const double totalOunces = 1;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedOunces, weight.Ounces);
        }

        [Test]
        public void OuncesIs15WhenTotalOuncesIs15()
        {
            const double expectedOunces = 15;
            const double totalOunces = 15;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedOunces, weight.Ounces);
        }

        [Test]
        public void OuncesIs0WhenTotalOuncesIs16()
        {
            const double expectedOunces = 0;
            const double totalOunces = 16;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedOunces, weight.Ounces);
        }

        [Test]
        public void OuncesIs1WhenTotalOuncesIs17()
        {
            const double expectedOunces = 1;
            const double totalOunces = 17;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedOunces, weight.Ounces);
        }

        [Test]
        public void OuncesIs15WhenTotalOuncesIs31()
        {
            const double expectedOunces = 15;
            const double totalOunces = 31;

            var weight = new Weight(totalOunces / 16);

            Assert.AreEqual(expectedOunces, weight.Ounces);
        }

        [Test]
        public void MetricWeightReturnsKilogramsWithKgAbbreviation()
        {
            const double kilograms = 12;
            const double totalPounds = (kilograms * 1000) / NUMBER_OF_GRAMS_IN_ONE_POUND;
            string expectedString = kilograms + " Kg";
            
            var weight = new Weight(totalPounds);

            Assert.AreEqual(expectedString, weight.MetricWeight);
        }

        [Test]
        [Ignore]
        public void EnglishWeightContainsPoundsOuncesAndAbbreviations()
        {
            const double pounds = 5;
            const double ounces = 3;
            const double totalPounds = pounds + (ounces/16);
            string expectedString = pounds + " lb, " + ounces + " oz";

            var weight = new Weight(totalPounds);

            Assert.AreEqual(expectedString, weight.EnglishWeight);
        }
    }
}