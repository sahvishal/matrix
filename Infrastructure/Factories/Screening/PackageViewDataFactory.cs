using System.Linq;
using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Infrastructure.Marketing.Interfaces;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class PackageViewDataFactory : IPackageViewDataFactory
    {

        public List<PackageViewData> Create(List<Package> packages)
        {
            var packageViewData = new List<PackageViewData>();
            foreach (var package in packages)
            {
                var retailPrice = package.Tests.Sum(t => t.PackagePrice);

                var packageViewDatum = new PackageViewData
                                           {
                                               RetailPrice = retailPrice,
                                               Description = package.Description,
                                               OfferPrice = package.Price,
                                               PackageId = package.Id,
                                               PackageName = package.Name
                                           };
                packageViewData.Add(packageViewDatum);
            }
            return packageViewData;
        }

    }
}