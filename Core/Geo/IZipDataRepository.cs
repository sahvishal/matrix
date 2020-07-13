using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface  IZipDataRepository
    {
        ZipData GetZipData(string zipCode, string city, string stateCode);
        IEnumerable<ZipData> GetZipData(string zipCode, string stateCode);
        ZipData GetZipDataByZipCodeCity(string zipCode, string city);
    }
}
