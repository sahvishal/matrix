namespace Falcon.App.Core.Operations.ViewModels
{
    public class ShippingDetailViewData
    {
        public long ShippingDetailId { get; set; }
        public string ShippingOptionName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string AppliedByName { get; set; }
        public string AppliedByRole { get; set; }
        public string AppliedDate { get; set; }
    }
}