using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class EventCustomerResutlViewServiceReport
    {
        public long EventCustomerResultId { get; set; }
        public long CustomerId { get; set; }
        public long EventId { get; set; }
       
        public int ResultState { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}