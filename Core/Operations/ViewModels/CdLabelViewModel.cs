using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CdLabelViewModel
    {
        public DateTime TestDate { get; set; }
        public Name CustomerName { get; set; }
        public long CustomerId { get; set; }
    }
}
