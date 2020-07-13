using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Marketing.Interfaces;
using Falcon.App.Infrastructure.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class PackageSelectionViewDataFactory : IPackageSelectionViewDataFactory
    {
        private readonly ITestViewDataFactory _testViewDataFactory;
        private readonly IPackageViewDataFactory _packageViewDataFactory;

        public PackageSelectionViewDataFactory()
            : this(new TestViewDataFactory(), new PackageViewDataFactory())
        { }

        public PackageSelectionViewDataFactory(ITestViewDataFactory testViewDataFactory,
            IPackageViewDataFactory packageViewDataFactory)
        {
            _testViewDataFactory = testViewDataFactory;
            _packageViewDataFactory = packageViewDataFactory;
        }

        public PackageSelectionViewData Create(long selectedPackageId, List<long> packageTestIds,
            List<long> independentTestIds, List<Package> packages, List<Test> tests)
        {
            var selectedPackage = selectedPackageId > 0
                                      ? packages.Single(p => p.Id == selectedPackageId)
                                      : null;

            var selectedPackageTestIds = selectedPackage != null
                                             ? selectedPackage.Tests.Select(t => t.Id)
                                             : new List<long>();

            if (selectedPackage != null)
                packageTestIds = selectedPackage.Tests.Select(t => t.Id).ToList();

            if(selectedPackage == null && !packageTestIds.IsNullOrEmpty())
            {
                independentTestIds = independentTestIds.IsNullOrEmpty() ? new List<long>() : independentTestIds;
                independentTestIds.AddRange(packageTestIds);
                packageTestIds.Clear();
            }

            var packageName = selectedPackage == null ? string.Empty : selectedPackage.Name;
            var packageDescription = selectedPackage == null ? string.Empty : selectedPackage.Description;

            var selectedTestIds = new List<long>();
            if (!packageTestIds.IsNullOrEmpty())
                selectedTestIds.AddRange(packageTestIds);
            if (!independentTestIds.IsNullOrEmpty())
                selectedTestIds.AddRange(independentTestIds);

            List<string> selectedTestNames = null;

            if (!selectedTestIds.IsNullOrEmpty())
            {
                if (selectedPackage != null)
                    independentTestIds = selectedTestIds.Where(st => !selectedPackageTestIds.Contains(st)).ToList();

                if (!independentTestIds.IsNullOrEmpty())
                    selectedTestNames = tests.Where(t => independentTestIds.Contains(t.Id)).Select(t => t.Name).ToList();
            }

            var packageViewData = _packageViewDataFactory.Create(packages);
            var testViewData = _testViewDataFactory.Create(selectedPackage, selectedTestIds, tests);

            var packageSelectionViewData = new PackageSelectionViewData
                                               {
                                                   PackageViewData = packageViewData,
                                                   TestViewData = testViewData,
                                                   SelectedPackageDescription = packageDescription,
                                                   SelectedPackageId = selectedPackageId,
                                                   SelectedPackageName = packageName,
                                                   SelectedTestIds = selectedTestIds,
                                                   SelectedPackageTestIds = packageTestIds,
                                                   IndependentTestNames = selectedTestNames,
                                                   IndependentTestIds = independentTestIds,
                                                   OfferPrice = Math.Round(testViewData.Sum(tv => tv.OfferPrice), 2)
                                               };

            if (packageSelectionViewData.SelectedPackageId > 0 && selectedPackage != null)
            {
                var packagePrice = selectedPackage.Price;

                var selectedTestsNotInPackage =
                    tests.Where(t => selectedTestIds.Contains(t.Id) && !selectedPackageTestIds.Contains(t.Id)).ToList();
                var testsPrice = selectedTestsNotInPackage.Sum(t => t.Price);

                packageSelectionViewData.OfferPrice = packagePrice + testsPrice;
            }

            return packageSelectionViewData;
        }
    }
}