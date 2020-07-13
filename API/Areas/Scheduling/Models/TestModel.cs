using Falcon.App.Core.Application.Attributes;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class TestModel
    {
        public long TestId { get; set; }
        public string TestName { get; set; }
        public decimal TestPrice { get; set; }
        public string Descriptoin { get; set; }
        public long EventTestId { get; set; }
        public decimal WithPackagePrice { get; set; }
    }
}