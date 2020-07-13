using Falcon.App.Core.ValueTypes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValueTypes
{
    [TestFixture]
    public class HeightTester
    {
        private const double NUMBER_OF_CENTIMETERS_IN_ONE_INCH = 2.54;

        [Test]
        public void CentimetersShouldBe0When0Feet0InchesGiven()
        {
            const double feet = 0;
            const double inches = 0;
            const double expectedCentimeters = 0;
            
            var height = new Height(feet, inches);

            Assert.AreEqual(expectedCentimeters, height.Centimeters);
        }

        [Test]
        public void CentimetersShouldBe2Point54When0Feet1InchGiven()
        {
            const double feet = 0;
            const double inches = 1;
            const double expectedCentimeters = NUMBER_OF_CENTIMETERS_IN_ONE_INCH;

            var height = new Height(feet, inches);

            Assert.AreEqual(expectedCentimeters, height.Centimeters);
        }

        [Test]
        public void CentimetersShouldBe2Point54Times12When1Foot0InchesGiven()
        {
            const double feet = 1;
            const double inches = 0;
            const double expectedCentimeters = NUMBER_OF_CENTIMETERS_IN_ONE_INCH * 12;

            var height = new Height(feet, inches);

            Assert.AreEqual(expectedCentimeters, height.Centimeters);
        }

        [Test]
        public void TotalInchesShouldBe0When0Feet0InchesGiven()
        {
            const double feet = 0;
            const double expectedTotalInches = 0;

            var height = new Height(feet, expectedTotalInches);

            Assert.AreEqual(expectedTotalInches, height.TotalInches);
        }

        [Test]
        public void TotalInchesShouldBe1When0Feet1InchGiven()
        {
            const double feet = 0;
            const double expectedTotalInches = 1;

            var height = new Height(feet, expectedTotalInches);

            Assert.AreEqual(expectedTotalInches, height.TotalInches);
        }

        [Test]
        public void TotalInchesShouldEqualInputtedInchesWhen0FeetGiven()
        {
            const double feet = 0;

            for (int i = 2; i < 12; i++)
            {
                double totalInches = new Height(feet, i).TotalInches;
                Assert.AreEqual(i, totalInches, "TotalInches was {0} when {1} expected.", totalInches, i);
            }
        }

        [Test]
        public void TotalInchesEquals12When1Foot0InchesGiven()
        {
            const double feet = 1;
            const double totalInches = 0;
            const double expectedTotalInches = 12;

            var height = new Height(feet, totalInches);

            Assert.AreEqual(expectedTotalInches, height.TotalInches);
        }

        [Test]
        public void TotalFeetIs0WhenTotalInchesIs0()
        {
            const double totalInches = 0;
            const double expectedTotalFeet = 0;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedTotalFeet, height.TotalFeet);
        }

        [Test]
        public void TotalFeetIsOneTwelthWhenTotalInchesIs1()
        {
            const double totalInches = 1;
            const double expectedTotalFeet = 0.0833;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedTotalFeet, height.TotalFeet);
        }

        [Test]
        public void TotalFeetIs1WHenTotalInchesIs12()
        {
            const double totalInches = 12;
            const double expectedTotalFeet = 1;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedTotalFeet, height.TotalFeet);
        }

        [Test]
        public void TotalFeetIsEqualToNumberOfFeetEntered()
        {
            for (int i = 0; i < 12; i++)
            {
                double totalFeet = new Height(i, 0).TotalFeet;
                Assert.AreEqual(i, totalFeet, "{0} TotalFeet given when {1} expected.", totalFeet, i);
            }
        }

        [Test]
        public void MetersShouldBe0WhenCentimetersIs0()
        {
            const double centimeters = 0;
            const double expectedMeters = 0;

            var height = new Height(0, centimeters*NUMBER_OF_CENTIMETERS_IN_ONE_INCH);

            Assert.AreEqual(expectedMeters, height.Meters);
        }

        [Test]
        public void MetersShouldBeOneOneHundrethWhenCentimetersIs1()
        {
            const double centimeters = 1;
            const double expectedMeters = .01;

            var height = new Height(0, centimeters / NUMBER_OF_CENTIMETERS_IN_ONE_INCH);

            Assert.AreEqual(expectedMeters, height.Meters);
        }

        [Test]
        public void MetersShouldBe99Over100WhenCentimetersIs99()
        {
            const double centimeters = 99;
            const double expectedMeters = .99;

            var height = new Height(0, centimeters / NUMBER_OF_CENTIMETERS_IN_ONE_INCH);

            Assert.AreEqual(expectedMeters, height.Meters);
        }

        [Test]
        public void MetersShouldBe1WhenCentimetersIs100()
        {
            const double centimeters = 100;
            const double expectedMeters = 1;

            var height = new Height(0, centimeters / NUMBER_OF_CENTIMETERS_IN_ONE_INCH);

            Assert.AreEqual(expectedMeters, height.Meters);
        }

        [Test]
        public void FeetReturns0WhenTotalInchesIs0()
        {
            const double totalInches = 0;
            const double expectedFeet = 0;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedFeet, height.Feet);
        }

        [Test]
        public void FeetReturns0WhenTotalInchesIs1()
        {
            const double totalInches = 1;
            const double expectedFeet = 0;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedFeet, height.Feet);
        }

        [Test]
        public void FeetReturns0WhenTotalInchesIs11()
        {
            const double totalInches = 11;
            const double expectedFeet = 0;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedFeet, height.Feet);
        }

        [Test]
        public void FeetReturns1WhenTotalInchesIs12()
        {
            const double totalInches = 12;
            const double expectedFeet = 1;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedFeet, height.Feet);
        }

        [Test]
        public void InchesReturns0WhenTotalInchesIs0()
        {
            const double totalInches = 0;
            const double expectedInches = 0;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedInches, height.Inches);
        }

        [Test]
        public void InchesReturns1WhenTotalInchesIs1()
        {
            const double totalInches = 1;
            const double expectedInches = 1;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedInches, height.Inches);
        }

        [Test]
        public void InchesReturns11WhenTotalInchesIs11()
        {
            const double totalInches = 11;
            const double expectedInches = 11;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedInches, height.Inches);
        }

        [Test]
        public void InchesReturns0WhenTotalInchesIs12()
        {
            const double totalInches = 12;
            const double expectedInches = 0;

            var height = new Height(0, totalInches);

            Assert.AreEqual(expectedInches, height.Inches);
        }

        [Test]
        public void MetricHeightReturnsNumberOfMetersWithAbbreviation()
        {
            const double meters = 2.4;
            string expectedString = meters + "m";

            var height = new Height(0, meters * 39.3700787);

            Assert.AreEqual(expectedString, height.MetricHeight);
        }

        [Test]
        public void EnglishHeightReturnsNumberOfFeetAndInchesWithAbbreviations()
        {
            const double feet = 3;
            const double inches = 11;
            string expectedString = feet + "'" + inches + "\"";

            var height = new Height(feet, inches);

            Assert.AreEqual(expectedString, height.EnglishHeight);
        }

        [Test]
        public void EnglishHeightReturns4Ft1InWhen3Ft13InGiven()
        {
            const double feet = 3;
            const double inches = 13;
            const string expectedString = "4'1\"";

            var height = new Height(feet, inches);

            Assert.AreEqual(expectedString, height.EnglishHeight);
        }
    }
}