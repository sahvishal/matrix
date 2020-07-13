using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OrderRequisitionFormViewModel
    {
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }

        public DateTime EventDate { get; set; }

        public long EventId { get; set; }

    }
}