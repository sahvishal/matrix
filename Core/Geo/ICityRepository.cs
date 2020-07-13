using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface ICityRepository : IUniqueItemRepository<City>
    {
        City GetCity(string cityName);
        City GetCityByZipCode(string zipCode);
        City GetCityByStateAndName(long stateId, string cityName);
        IEnumerable<City> GetbyPrefixTest(string prefixTest);
    }
}