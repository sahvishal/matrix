using System.Collections.Generic;
using API.Areas.Finance.Models;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class CustomerOrderDetail : ResponseBaseModel
    {
        public long OrderId { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public bool IsShippingPurchased { get; set; }
        public ShippingOptionDetail[] ShippingOptions { get; set; }
        public long? ProductId { get; set; }
        public SourceCodeApplyEditModel SourceCode { get; set; }
        public PackageModel PackageModel { get; set; }
        public IEnumerable<TestModel> AlaCarteTests { get; set; }
        public AddressEditModel ShippingAddresss { get; set; }

        public PaymentEditModel PaymentModel { get; set; }
    }

    [NoValidationRequired]
    public class ShippingOptionDetail
    {
        public long Id { get; set; }
        public decimal Price { get; set; }

    }

    [NoValidationRequired]
    public class EventPackageTestModel : ResponseBaseModel
    {
        public IEnumerable<PackageModel> AvilablePackages { get; set; }
        public IEnumerable<TestModel> AvilableAlaCarteTests { get; set; }
    }
}