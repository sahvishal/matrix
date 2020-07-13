namespace Falcon.App.Core.Marketing.ViewModels
{
    public class ShippingOptionOrderItemViewModel
    {
        public long ShippingOptionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Disclaimer { get; set; }
        public decimal Price { get; set; }
    }
}