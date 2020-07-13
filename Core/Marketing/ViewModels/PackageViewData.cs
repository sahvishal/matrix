namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PackageViewData
    {
        public long PackageId { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public decimal OfferPrice { get; set; }
        public decimal RetailPrice { get; set; }
    }
}