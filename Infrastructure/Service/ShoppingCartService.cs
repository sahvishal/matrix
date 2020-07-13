using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Factories.Screening;
using Falcon.App.Infrastructure.Marketing.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IPackageSelectionViewDataFactory _packageSelectionViewDataFactory;
        private readonly IShoppingCartRecommendationService _shoppingCartRecommendationService;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;

        public ShoppingCartService()
            : this(new PackageSelectionViewDataFactory(), new ShoppingCartRecommendationService(), new EventPackageRepository(), new EventTestRepository())
        { }

        public ShoppingCartService(
            IPackageSelectionViewDataFactory packageSelectionViewDataFactory,
            IShoppingCartRecommendationService shoppingCartRecommendationService, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository)
        {
            _packageSelectionViewDataFactory = packageSelectionViewDataFactory;
            _shoppingCartRecommendationService = shoppingCartRecommendationService;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
        }

        public PackageSelectionViewData GetPackageSelectionViewData(long eventId, long roleId, long packageId,
            List<long> packageTestIds, List<long> independentTestIds)
        {
            var eventPackages = _eventPackageRepository.GetPackagesForEventByRole(eventId, roleId).ToList();
            var packages = eventPackages.Select(ep => ep.Package).ToList();

            var currentSelectedPackage = packages.SingleOrDefault(p => p.Id == packageId);

            var eventTests = _eventTestRepository.GetTestsForEventByRole(eventId, roleId);
            var tests = eventTests.Select(et => et.Test).ToList();
            tests = AdjustAndSortTests(tests);

            if (!packageTestIds.IsNullOrEmpty() || !independentTestIds.IsNullOrEmpty())
            {
                var selectedPackageId = _shoppingCartRecommendationService.RecommendPackage(packageId, packageTestIds,
                                                                                            independentTestIds, packages);
                var selectedPackage = packages.SingleOrDefault(p => p.Id == selectedPackageId);

                var packageSelectionViewData = _packageSelectionViewDataFactory.Create(selectedPackageId, packageTestIds, independentTestIds, packages, tests);

                packageSelectionViewData.RecommendationMessage =
                    _shoppingCartRecommendationService.RecommendPackageUpgrade(packageSelectionViewData, packages);

                if (selectedPackageId != packageId)
                {
                    if (selectedPackageId > 0 && packageId > 0 && (selectedPackage != null && currentSelectedPackage != null && selectedPackage.Price > currentSelectedPackage.Price))
                    {
                        packageSelectionViewData.PackageChangeMessage = string.Format(
                            "We have changed your package from {0} to {1}. This Package will save you ${2} for the same set of test(s).",
                            currentSelectedPackage.Name, selectedPackage.Name, packageSelectionViewData.TotalSavings);
                    }
                    if (selectedPackageId > 0 && packageId == 0 && selectedPackage != null)
                    {
                        packageSelectionViewData.PackageChangeMessage = string.Format(
                            "We have changed your package to {0}. This Package will save you ${1} for the same set of test(s).",
                            selectedPackage.Name, packageSelectionViewData.TotalSavings);
                    }
                }
                return packageSelectionViewData;
            }
            return _packageSelectionViewDataFactory.Create(packageId, packageTestIds, independentTestIds, packages, tests);
        }

        // TODO: It should be in the data base but as discussion with Bidhan its being hard coded here.
        private List<Test> AdjustAndSortTests(IEnumerable<Test> tests)
        {
            var sortedTests = new List<Test>();
            var strokeTest = tests.SingleOrDefault(t => t.Id == (long)TestType.Stroke);
            if (strokeTest != null)
            {
                strokeTest.Name = "Stroke/Carotid";
                sortedTests.Add(strokeTest);
            }
            var leadTest = tests.SingleOrDefault(t => t.Id == (long)TestType.Lead);
            if (leadTest != null)
            {
                leadTest.Name = "Lead";
                sortedTests.Add(leadTest);
            }
            var aaaTest = tests.SingleOrDefault(t => t.Id == (long)TestType.AAA);
            if (aaaTest != null)
            {
                aaaTest.Name = "Abdominal Aortic Aneurysm/AAA";
                sortedTests.Add(aaaTest);
            }
            var padTest = tests.SingleOrDefault(t => t.Id == (long)TestType.PAD);
            if (padTest != null)
            {
                padTest.Name = "Peripheral Artery Disease/PAD";
                sortedTests.Add(padTest);
            }

            var ekgTest = tests.SingleOrDefault(t => t.Id == (long)TestType.EKG);
            if (ekgTest != null)
            {
                ekgTest.Name = "Electrocardiogram/EKG";
                sortedTests.Add(ekgTest);
            }
            var asiTest = tests.SingleOrDefault(t => t.Id == (long)TestType.ASI);
            if (asiTest != null)
            {
                asiTest.Name = "Arterial Stiffness Index/ASI";
                sortedTests.Add(asiTest);
            }
            var lipidTest = tests.SingleOrDefault(t => t.Id == (long)TestType.Lipid);
            if (lipidTest != null)
            {
                lipidTest.Name = "Lipid Panel + Glucose";
                sortedTests.Add(lipidTest);
            }
            var framinghamTest = tests.SingleOrDefault(t => t.Id == (long)TestType.FraminghamRisk);
            if (framinghamTest != null)
            {
                framinghamTest.Name = "Framingham Risk Score";
                sortedTests.Add(framinghamTest);
            }
            var osteoTest = tests.SingleOrDefault(t => t.Id == (long)TestType.Osteoporosis);
            if (osteoTest != null)
            {
                osteoTest.Name = "Osteoporosis/Bone Density";
                sortedTests.Add(osteoTest);
            }

            var spiroTest = tests.SingleOrDefault(t => t.Id == (long)TestType.Spiro);
            if (spiroTest != null)
            {
                spiroTest.Name = "Spiro";
                sortedTests.Add(spiroTest);
            }
            var liverTest = tests.SingleOrDefault(t => t.Id == (long)TestType.Liver);
            if (liverTest != null)
            {
                liverTest.Name = "Liver Function(ALT/AST)";
                sortedTests.Add(liverTest);
            }
            var crcTest = tests.SingleOrDefault(t => t.Id == (long)TestType.Colorectal);
            if (crcTest != null)
            {
                crcTest.Name = "Colorectal Cancer(take-home test)";
                sortedTests.Add(crcTest);
            }
            return sortedTests;
        }
    }
}