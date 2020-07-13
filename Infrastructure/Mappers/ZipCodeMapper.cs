using System;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class ZipCodeMapper : DomainEntityMapper<ZipCode, ZipEntity>
    {
        protected override void MapDomainFields(ZipEntity entity, ZipCode domainObjectToMapTo)
        {
            int timeZoneNumber;
            double latitude;
            double longitude;
            int.TryParse(entity.TimeZone, out timeZoneNumber);
            double.TryParse(entity.Latitude, out latitude);
            double.TryParse(entity.Longitude, out longitude);

            domainObjectToMapTo.Id = entity.ZipId;
            domainObjectToMapTo.Zip = entity.ZipCode;
            domainObjectToMapTo.Latitude = (float)latitude;
            domainObjectToMapTo.Longitude = (float)longitude;
            domainObjectToMapTo.IsInDaylightSavingsTime = (entity.DayLightSaving == "Y" ? true : false);
            domainObjectToMapTo.TimeZone = (Core.Enum.TimeZone)(-timeZoneNumber);
            domainObjectToMapTo.CityId = entity.CityId != null ? entity.CityId.Value : 0;
        }

        protected override void MapEntityFields(ZipCode domainObject, ZipEntity entityToMapTo)
        {
            entityToMapTo.ZipId = domainObject.Id;
            entityToMapTo.ZipCode = domainObject.Zip;
            entityToMapTo.Latitude = domainObject.Latitude.ToString();
            entityToMapTo.Longitude = domainObject.Longitude.ToString();
            entityToMapTo.DayLightSaving = domainObject.IsInDaylightSavingsTime ? "Y" : "N";
            entityToMapTo.TimeZone = (-1 * (int)domainObject.TimeZone).ToString();
            entityToMapTo.CityId = domainObject.CityId > 0 ? (long?)domainObject.CityId : null;
            entityToMapTo.IsActive = true;
            entityToMapTo.DateModified = DateTime.Now;
            if (entityToMapTo.ZipId == 0)
                entityToMapTo.DateCreated = DateTime.Now;
        }
    }
}