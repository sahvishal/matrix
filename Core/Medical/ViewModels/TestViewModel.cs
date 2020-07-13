using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        public long TestId { get; set; }

        public string Name { get; set; }

        [DisplayName("Status")]
        public bool IsActive { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Default Package Price")]
        public decimal PackagePrice { get; set; }

        [DisplayName("Refund Price")]
        public decimal RefundPrice { get; set; }

        [DisplayName("Default Package Refund Price")]
        public decimal PackageRefundPrice { get; set; }

        public long Gender { get; set; }
    }
}
