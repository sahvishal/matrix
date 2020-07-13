using System;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class DistanceCalculatorTester
    {
        private readonly IDistanceCalculator _distanceCalculator = new DistanceCalculator();

        [Test]
        public void DistanceBetweenTwoPointsReturns0WhenOriginMatchesDestination()
        {
            const double expectedDistance = 0;
            const float latitude = 0f;
            const float longitude = 0f;

            double distance = _distanceCalculator.DistanceBetweenTwoPoints(latitude, longitude, latitude, longitude);

            Assert.AreEqual(expectedDistance, distance, "Incorrect distance returned.");
        }

        [Test]
        public void DistanceBetweenTwoPointsReturnsExpectedDistance()
        {
            const int numberOfDigitsToRound = 2;
            double expectedDistance = Math.Round(27.2983361244703, numberOfDigitsToRound);
            const float originLatitude = 30.271158f;
            const float originLongitude = -97.741701f;
            const float destinationLatitude = 30.665248f;
            const float destinationLongitude = -97.704835f;

            double distance = _distanceCalculator.DistanceBetweenTwoPoints(originLatitude, originLongitude, 
                destinationLatitude, destinationLongitude);

            Assert.AreEqual(expectedDistance, Math.Round(distance, numberOfDigitsToRound), 
                "Incorrect distance returned.");
        }
    }
}