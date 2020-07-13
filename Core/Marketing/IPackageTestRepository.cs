using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Marketing
{
    public interface IPackageTestRepository : IRepository<PackageTest>
    {
        IEnumerable<PackageTest> GetbyPackageId(long packageId);
        PackageTest GetbyTestAndPackageId(long packageId, long testId);
        IEnumerable<PackageTest> Save(IEnumerable<PackageTest> domainObjects);
    }
}