using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PackageSelectionViewData
    {
        public long SelectedPackageId { get; set; }
        public string SelectedPackageName { get; set; }
        public string SelectedPackageDescription { get; set; }
        public List<long> SelectedPackageTestIds { get; set; }

        public List<long> SelectedTestIds { get; set; }
        
        public List<long> IndependentTestIds { get; set; }
        public List<string> IndependentTestNames { get; set; }

        public decimal RetailPrice
        {
            get
            {
                return !SelectedTestIds.IsNullOrEmpty()
                           ? Math.Round(
                                 _testViewData.Where(t => SelectedTestIds.Contains(t.TestId)).Sum(t => t.RetailPrice), 2)
                           : 0m;
            }
        }

        public decimal TotalSavings
        {
            get
            {
                return !SelectedTestIds.IsNullOrEmpty() ? Math.Round(RetailPrice - OfferPrice, 2) : 0m;
            }
        }

        public decimal OfferPrice { get; set; }

        public List<PackageViewData> PackageViewData { get; set; }

        public PackageViewData SelectedPackageViewData
        {
            get
            {
                return SelectedPackageId > 0 ? PackageViewData.Single(pvd => pvd.PackageId == SelectedPackageId) : null;
            }
        }

        public List<TestViewData> SelectedPackageTestViewData
        {
            get
            {
                if (!_testViewData.IsNullOrEmpty() && !SelectedTestIds.IsNullOrEmpty())
                    return _testViewData.Where(t => SelectedTestIds.Contains(t.TestId) && !IndependentTestIds.Contains(t.TestId)).ToList();
                return null;
            }
        }

        public List<TestViewData> SelectedIndependentTestViewData
        {
            get
            {
                if (!_testViewData.IsNullOrEmpty() && !IndependentTestIds.IsNullOrEmpty())
                    return _testViewData.Where(t => IndependentTestIds.Contains(t.TestId)).ToList();
                return  null;
            }
        }

        private List<TestViewData> _testViewData;
        public List<TestViewData> TestViewData
        {
            get
            {
                if (!_testViewData.IsNullOrEmpty() && !SelectedTestIds.IsNullOrEmpty())
                    return _testViewData.Where(t => !SelectedTestIds.Contains(t.TestId)).ToList();
                return !_testViewData.IsNullOrEmpty() ? _testViewData : new List<TestViewData>();
            }
            set
            {
                _testViewData = value;
            }
        }

        public string PackageChangeMessage { get; set; }
        public string RecommendationMessage { get; set; }
    }
}