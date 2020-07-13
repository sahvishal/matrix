using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerResultEditModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }

        public long EventId { get; set; }
        public DateTime EventDate { get; set; }
        public IEnumerable<TestResultEditModel> TestResults { get; set; }
    }
}