using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface IZipCodeParser
    {
        List<string> ParseStringIntoZipCodes(string zipCodes);
        string ParseZipCodesIntoString(IEnumerable<ZipCode> codes);
    }
}