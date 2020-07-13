using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class MergeCustomerUploadLogViewModel: ViewModelBase
    {
        [DisplayName("Customer Id")]
        public string CustomerId { get; set; }

        [DisplayName("Duplicate Customers")]
        public string DuplicateCustomerId { get; set; }

        [DisplayName("Error Message")]
        public string ErrorMessage { get; set; }
    }
}
