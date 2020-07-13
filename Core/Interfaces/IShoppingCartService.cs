using System.Collections.Generic;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Interfaces
{
    public interface IShoppingCartService
    {
        PackageSelectionViewData GetPackageSelectionViewData(long eventId, long roleId, long packageId,
                                                             List<long> packageTestIds, List<long> independentTestIds);
    }
}