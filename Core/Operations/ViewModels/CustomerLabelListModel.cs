using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CustomerLabelListModel
    {
        public IEnumerable<CustomerLabelBasicModel> CustomerLabelBasicModels { get; set; }
        [UIHint("Hidden")]
        public long EventId { get; set; }

        public int ShippingStatus { get; set; }
    }
}