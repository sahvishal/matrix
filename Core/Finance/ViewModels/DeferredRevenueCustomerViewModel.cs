using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class DeferredRevenueCustomerViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Contact Number")]
        public PhoneNumber CustomerPhone { get; set; }

        public string Email { get; set; }

        [DisplayName("Customer Address")]
        public AddressViewModel CustomerAddress { get; set; }

        [DisplayName("Registration Date")]
        [Format("MM/dd/yyyy")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Package/Test(s)")]
        public string CustomerOrder { get; set; }

        [Hidden]
        public long OrderId { get; set; }

        [DisplayName("Order Total")]
        public decimal DiscountedTotal { get; set; }

        [DisplayName("Paid")]
        public decimal TotalPayment { get; set; }

        public decimal UnPaid
        {
            get { return (DiscountedTotal > TotalPayment ? (DiscountedTotal - TotalPayment) : 0); }
        }
    }
}
