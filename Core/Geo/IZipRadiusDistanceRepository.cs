using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface IZipRadiusDistanceRepository
    {
        IEnumerable<ZipRadiusDistance> GetBySourceZipIdAndRadius(long sourceZipId, int radius);
        IEnumerable<ZipRadiusDistance> GetDistacanceBetweenTwoZip(long sourceZipId, int distinationZipId);
        bool Save(ZipRadiusDistance zipRadiusDistance);
        IEnumerable<ZipRadiusDistance> GetBySourceZipId(long sourceZipId);
    }
}