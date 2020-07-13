using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class BatchLabelViewModel
    {
        public Name CustomerName { get; set; }
        public long CustomerId { get; set; }
        public AddressViewModel CustomerAddress { get; set; }
    }
}