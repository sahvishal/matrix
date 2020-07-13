using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Infrastructure.Marketing.Interfaces
{
    public interface IPackageViewDataFactory
    {
        List<PackageViewData> Create(List<Package> packages);
    }
}