using System.Collections.Generic;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class OrderViewData
    {
        // Customer Data.
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }

        // EventCustomer Data.
        public long EventCustomerId { get; set; }

        // OrderDetail Data.
        public string OrderDetailDateCreated { get; set; }
        public string OrderDetailType { get; set; }
        public string OrderDetailStatus { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal TotalCost
        {
            get { return Price * Quantity; }
        }

        public string CreatorName { get; set; }
        public string CreatorRole { get; set; }
        public string CreationMode { get; set; }

        public SourceCodeViewData SourceCode { get; set; }

        private List<ShippingDetailViewData> _shippingDetails;
        public List<ShippingDetailViewData> ShippingDetails
        {
            get
            {
                if (_shippingDetails == null)
                    _shippingDetails = new List<ShippingDetailViewData>();
                return _shippingDetails;
            }
            set
            {
                _shippingDetails = value;
            }
        }

        //PackageData
        public string Description { get; set; }
    }
}
