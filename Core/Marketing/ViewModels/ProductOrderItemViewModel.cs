namespace Falcon.App.Core.Marketing.ViewModels
{
    public class ProductOrderItemViewModel
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
    }
}