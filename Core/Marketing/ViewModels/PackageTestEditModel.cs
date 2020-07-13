namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PackageTestEditModel
    {
        public long TestId { get; set; }
        public decimal Price { get; set; }
        public decimal RefundPrice { get; set; }
        public bool IsDefault { get; set; }
    }
}