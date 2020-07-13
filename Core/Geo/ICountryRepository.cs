using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        string GetCountryCode(long countryId);
        long GetCountryId(string countryName);
        Country GetCountryByStateId(long stateId);
    }
}
