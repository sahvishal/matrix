using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Infrastructure.Service
{
    public class ShoppingCartRecommendationService : IShoppingCartRecommendationService
    {

        public long RecommendPackage(long packageId, ICollection<long> packageTestIds,
            ICollection<long> independentTestIds, List<Package> packages)
        {
            var selectedTestIds = new List<long>();
            if (!packageTestIds.IsNullOrEmpty())
                selectedTestIds.AddRange(packageTestIds);
            if (!independentTestIds.IsNullOrEmpty())
                selectedTestIds.AddRange(independentTestIds);

            // Get the package if its selected.
            var selectedPackage = packages.SingleOrDefault(p => p.Id == packageId);

            // Get the testIds which are included in the selected package if any.
            var selectedPackageTestIds = selectedPackage == null
                                             ? null
                                             : selectedPackage.Tests.Select(t => t.Id).ToList();

            // If selected package exist and if all the package tests are included in the selected tests then.
            // the package still exists else the selected package is out of scope, so remove the package.
            if (selectedPackage != null && !packageTestIds.IsNullOrEmpty() &&
                !selectedPackageTestIds.All(packageTestIds.Contains))
                selectedPackage = null;

            if (packageTestIds.IsNullOrEmpty() && !selectedPackageTestIds.IsNullOrEmpty())
                selectedTestIds.AddRange(selectedPackageTestIds);

            // Get the new packages which includes any subset of selected tests.
            var newPackages = packages.Where(
                p =>
                (selectedPackage == null || p.Id != selectedPackage.Id) &&
                p.Tests.Select(t => t.Id).All(selectedTestIds.Contains)).ToList();

            // If no packages found then return the previously selected package.
            if (newPackages.IsNullOrEmpty()) return selectedPackage != null ? selectedPackage.Id : 0;

            // Get the minimum number of tests not in the current selected package,
            // If currently no package exist then it will be 0.
            var minNumberOfTestsNotInPackage = selectedPackage == null
                                                   ? 0
                                                   : selectedTestIds.Count(ti => !selectedPackageTestIds.Contains(ti));

            // This will be the package which contains maximum number of tests which are selected by user.
            // Initially keep it to the selected package.
            Package maxSetPackage = selectedPackage;

            // Loop through the newpackages found.
            // This loop will get the package which has maximum subset of the selected tests.
            foreach (var newPackage in newPackages)
            {
                Package package = newPackage;

                // Get the number of tests not in the current package.
                var numberOfTestLeft = selectedTestIds.Count(ti => !package.Tests.Select(t => t.Id).Contains(ti));

                // If there are no tests left then this is the package return back.
                // If the number of tests remaining in the currently selected package is equal to the new package the we shd return the selected package only.
                if (numberOfTestLeft == 0)
                {
                    if (selectedPackage != null && selectedTestIds.Count(ti => !selectedPackageTestIds.Contains(ti)) == 0)
                        return selectedPackage.Id;
                    return package.Id;
                }

                // Find if the current number of tests left are less than the previous one.
                // We will take out this package.
                minNumberOfTestsNotInPackage = minNumberOfTestsNotInPackage == 0 && selectedPackage == null
                                                ? numberOfTestLeft
                                                : minNumberOfTestsNotInPackage;

                if (minNumberOfTestsNotInPackage >= numberOfTestLeft)
                {
                    if (minNumberOfTestsNotInPackage == numberOfTestLeft && maxSetPackage != null && maxSetPackage.Price > package.Price)
                    {
                        maxSetPackage = package;
                        continue;
                    }
                    maxSetPackage = newPackage;
                    minNumberOfTestsNotInPackage = numberOfTestLeft;
                }
            }
            // If the number of tests remaining in the currently selected package is equal to the new package the we shd return the selected package only.
            if (selectedPackage != null && selectedTestIds.Count(ti => !selectedPackageTestIds.Contains(ti)) == minNumberOfTestsNotInPackage)
                return selectedPackage.Id;

            return maxSetPackage != null ? maxSetPackage.Id : 0;
        }

        public string RecommendPackageUpgrade(PackageSelectionViewData packageSelectionViewData,
            List<Package> packages)
        {
            // This is the delta amount we will consider for extra payment from the current selected price.
            const decimal packageUpgradeDelta = 10m;

            // Find out if there is a package which contains all the selected tests, 
            // and has few more tests available, 
            // and its price is less than or equal to the (current selected tests price + delta amount)
            if (packages.Any(p => (p.Price <= packageSelectionViewData.OfferPrice + packageUpgradeDelta) &&
                (p.Id != packageSelectionViewData.SelectedPackageId) &&
                (packageSelectionViewData.SelectedPackageId <= 0 || p.Price > packageSelectionViewData.OfferPrice) &&
                (packageSelectionViewData.SelectedTestIds.All(st => p.Tests.Select(t => t.Id).Contains(st)))))
            {
                // Get the packages which meet our criteria.
                var upgradePackageOptions =
                    packages.Where(p => (p.Price <= packageSelectionViewData.OfferPrice + packageUpgradeDelta) &&
                                        (p.Id != packageSelectionViewData.SelectedPackageId) &&
                                        (packageSelectionViewData.SelectedPackageId <= 0 ||
                                         p.Price > packageSelectionViewData.OfferPrice) &&
                                        (packageSelectionViewData.SelectedTestIds.All(
                                            st => p.Tests.Select(t => t.Id).Contains(st)))).ToList();

                // If there are more than packages in our new list and there is one package which falls 
                // in our upsell category and its price is more than the current selection then we will 
                // take this out.
                if (!upgradePackageOptions.IsNullOrEmpty() && upgradePackageOptions.Any(p => p.Price <= packageSelectionViewData.OfferPrice + packageUpgradeDelta && p.Price > packageSelectionViewData.OfferPrice))
                    upgradePackageOptions.RemoveAll(p => p.Price <= packageSelectionViewData.OfferPrice);

                // This will be the package to which we will recommend to upgrade.
                Package upgradePackage = null;

                // This will be the price to which we can recommend to upgrade.
                var minimumUpgradePrice = packageSelectionViewData.OfferPrice + packageUpgradeDelta;


                // We will take out the package whcih falls into the set criteria and has minimum price with in that limit.
                foreach (var upgradePackageOption in upgradePackageOptions)
                {
                    if (minimumUpgradePrice >= upgradePackageOption.Price)
                    {
                        upgradePackage = upgradePackageOption;
                        minimumUpgradePrice = upgradePackageOption.Price;
                    }
                }

                // Get the tests included in the package which is to be recommended with the tests which are not currently selected.
                // And the additional cost the user has to pay.
                if (upgradePackage != null)
                {
                    var upgradePackageTestIds = upgradePackage.Tests.Select(t => t.Id);
                    var testIdsToBeAdded =
                        upgradePackageTestIds.Where(t => !packageSelectionViewData.SelectedTestIds.Contains(t));
                    var testNamesToBeAdded =
                        packageSelectionViewData.TestViewData.Where(t => testIdsToBeAdded.Contains(t.TestId)).Select(
                            t => t.TestName).ToArray();

                    if (upgradePackage.Price > packageSelectionViewData.OfferPrice)
                        return string.Format(
                            "With additional ${0}, you can buy {1} (Discounted) and you can get screened for {2} also!",
                            Math.Round(minimumUpgradePrice - packageSelectionViewData.OfferPrice, 2),
                            upgradePackage.Name, string.Join(",", testNamesToBeAdded));
                    if (upgradePackage.Price < packageSelectionViewData.OfferPrice)
                        return string.Format(
                            "Your current order costs ${0}. We recommend you buy {1} as it will cost ${2} less. Further it will include your current selection of tests and {3}.",
                            Math.Round(packageSelectionViewData.OfferPrice, 2),
                            upgradePackage.Name,
                            Math.Round(packageSelectionViewData.OfferPrice - minimumUpgradePrice, 2),
                            string.Join(",", testNamesToBeAdded));
                    if (upgradePackage.Price == packageSelectionViewData.OfferPrice)
                        return string.Format(
                            "With same price i.e. ${0}, you can buy {1} (Discounted) and can get screened for {2} also!",
                            Math.Round(packageSelectionViewData.OfferPrice, 2), upgradePackage.Name,
                            string.Join(",", testNamesToBeAdded));
                }
            }

            return string.Empty;
        }
    }
}