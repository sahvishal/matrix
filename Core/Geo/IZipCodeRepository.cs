using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface IZipCodeRepository
    {
        ZipCode GetZipCode(long zipId);
        IEnumerable<ZipCode> GetZipCode(string zipCode);
        ZipCode GetZipCode(string zipCode, long cityId);
        List<ZipCode> GetAllZipCodes();
        List<ZipCode> GetAllExistingZipCodes(List<string> zipCodesToFetch);
        List<ZipCode> GetZipCodesForState(long stateId);
        List<ZipCode> GetZipCodeForCity(long cityId);
        List<ZipCode> GetZipCodesForTerritory(long territoryId);
        List<ZipCode> GetZipCodesInRadius(string zipCode, int rangeInMiles);
        ZipCode GetZipIdByZipCodeCityState(long stateId, long cityId, string zipCode);
        ZipCode Save(ZipCode zip);
        string GetZipIdsInRange(string zipCode, int radius);
        IEnumerable<ZipCode> GetZipCodesByZipCode(string[] zipCodes);
        List<ZipCode> GetZipCodesBetweenTwoRadius(string zipCode, int startRadiusInMiles, int endInMiles);
        List<ZipCode> GetAllZipCodesByCounteryId(long counterId);
    }
}