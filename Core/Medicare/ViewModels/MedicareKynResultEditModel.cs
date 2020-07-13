namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareKynResultEditModel
    {
        public long CustomerId{ get; set; }
        public long EventId { get; set; }
        public int ResultState { get; set; }
        public int? KynTotalCholestrol { get; set; }
        public int? TryGlycerides { get; set; }
        public int? Hdl { get; set; }
    }
}
