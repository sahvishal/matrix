using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Infrastructure.Marketing.Interfaces
{
    public interface IPackageSelectionViewDataFactory
    {
        PackageSelectionViewData Create(long selectedPackageId, List<long> packageTestIds,
                                        List<long> independentTestIds, List<Package> packages, List<Test> tests);
    }
}