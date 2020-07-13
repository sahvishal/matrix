using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Interfaces
{
    public interface IShoppingCartRecommendationService
    {
        long RecommendPackage(long packageId, ICollection<long> packageTestIds, ICollection<long> independentTestIds,
                              List<Package> packages);

        string RecommendPackageUpgrade(PackageSelectionViewData packageSelectionViewData, List<Package> packages);
    }
}