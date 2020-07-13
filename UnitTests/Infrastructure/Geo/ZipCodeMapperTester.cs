using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Geo
{
    [TestFixture]
    public class ZipCodeMapperTester
    {
        private readonly IMapper<ZipCode, ZipEntity> _mapper = new ZipCodeMapper();

        [Test]
        public void MapMapsEntityZipIdToDomainZipId()
        {
            var zipEntity = new ZipEntity(3);

            ZipCode zipCode = _mapper.Map(zipEntity);

            Assert.AreEqual(zipEntity.ZipId, zipCode.Id);
        }

        [Test]
        public void MapMapsEntityZipCodeToDomainZipCode()
        {
            var zipEntity = new ZipEntity {ZipCode = "12345"};

            ZipCode zipCode = _mapper.Map(zipEntity);
            Assert.AreEqual(zipEntity.ZipCode, zipCode.Zip, "Zips did not match.");
        }

        [Test]
        public void MapMapsLatitudeLongitudeToDoublesInZipCodeObject()
        {
            const float expectedLatitude = -23.23843f;
            const float expectedLongitude = 55.23843f;
            var zipEntity = new ZipEntity {Latitude = expectedLatitude.ToString(), 
                Longitude = expectedLongitude.ToString()};

            ZipCode zipCode = _mapper.Map(zipEntity);

            Assert.AreEqual(expectedLatitude, zipCode.Latitude, "Latitudes did not match.");
            Assert.AreEqual(expectedLongitude, zipCode.Longitude, "Longitudes did not match.");
        }

        [Test]
        public void MapSetsIsDaylightSavingsToTrueWhenYGiven()
        {
            var zipEntity = new ZipEntity {DayLightSaving = "Y"};

            ZipCode zipCode = _mapper.Map(zipEntity);

            Assert.IsTrue(zipCode.IsInDaylightSavingsTime);
        }
        
        [Test]
        public void MapSetsIsDaylightSavingsToFalseWhenNGiven()
        {
            var zipEntity = new ZipEntity {DayLightSaving = "N"};

            ZipCode zipCode = _mapper.Map(zipEntity);

            Assert.IsFalse(zipCode.IsInDaylightSavingsTime);
        }

        [Test]
        public void MapSetsTimeZoneToNegatedValueOfEntityTimeZone()
        {
            const TimeZone expectedTimeZone = TimeZone.Eastern;
            var zipEntity = new ZipEntity {TimeZone = "5"};

            ZipCode zipCode = _mapper.Map(zipEntity);

            Assert.AreEqual(expectedTimeZone, zipCode.TimeZone);
        }
    }
}