using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    public class TestViewDataFactory : ITestViewDataFactory
    {

        public List<TestViewData> Create(List<Test> tests)
        {
            const string testDescription = "---";

            var testViewData = new List<TestViewData>();
            foreach (var test in tests)
            {
                var testViewDatum = new TestViewData
                                        {
                                            RetailPrice = test.Price,
                                            Description = testDescription,
                                            OfferPrice = 0m,
                                            TestId = test.Id,
                                            TestName = test.Name,
                                            CptCode = test.CPTCode
                                        };
                testViewData.Add(testViewDatum);
            }
            return testViewData;
        }

        public List<TestViewData> Create(List<long> testIds, List<Test> tests)
        {
            const string testDescription = "---";

            var testViewData = new List<TestViewData>();
            foreach (var test in tests)
            {
                var offerPrice = 0m;
                if (testIds.Contains(test.Id))
                    offerPrice = test.Price;

                var testViewDatum = new TestViewData
                                        {
                                            RetailPrice = test.Price,
                                            Description = testDescription,
                                            OfferPrice = offerPrice,
                                            TestId = test.Id,
                                            TestName = test.Name,
                                            CptCode = test.CPTCode
                                        };
                testViewData.Add(testViewDatum);
            }
            return testViewData;
        }

        public List<TestViewData> Create(Package package, List<Test> tests)
        {
            var testViewData = new List<TestViewData>();
            var packageTests = package.Tests.Select(t => t.Id);

            foreach (var test in tests)
            {
                var offerPrice = 0m;
                var testDescription = "---";

                if (packageTests.Contains(test.Id))
                {
                    offerPrice = test.PackagePrice;
                    testDescription = "INCLUDED";
                }
                else
                {
                    offerPrice = test.WithPackagePrice;
                }

                var testViewDatum = new TestViewData
                                        {
                                            RetailPrice = test.Price,
                                            Description = testDescription,
                                            OfferPrice = offerPrice,
                                            TestId = test.Id,
                                            TestName = test.Name,
                                            CptCode = test.CPTCode
                                        };
                testViewData.Add(testViewDatum);
            }
            return testViewData;
        }


        public List<TestViewData> Create(Package package, List<long> testIds, List<Test> tests)
        {
            if (package == null && testIds.IsNullOrEmpty())
                return Create(tests);

            if (package != null && testIds.IsNullOrEmpty())
                return Create(package, tests);

            if (package == null && !testIds.IsNullOrEmpty())
                return Create(testIds, tests);

            var testViewData = new List<TestViewData>();
            var packageTests = package.Tests.Select(t => t.Id);

            foreach (var test in tests)
            {
                var offerPrice = 0m;
                var testDescription = "---";

                if (packageTests.Contains(test.Id))
                {
                    offerPrice = test.PackagePrice;
                    testDescription = "INCLUDED";
                }
                else if (testIds.Contains(test.Id))
                    offerPrice = test.WithPackagePrice;

                var testViewDatum = new TestViewData
                                        {
                                            RetailPrice = test.Price,
                                            Description = testDescription,
                                            OfferPrice = offerPrice,
                                            TestId = test.Id,
                                            TestName = test.Name,
                                            CptCode = test.CPTCode,
                                            DiagnosisCode = test.DiagnosisCode
                                        };
                testViewData.Add(testViewDatum);
            }
            return testViewData;
        }
    }
}