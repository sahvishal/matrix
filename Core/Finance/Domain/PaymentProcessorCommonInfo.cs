using System;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class PaymentProcessorCommonInfo
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }

        public String BillingAddress { get; set; }
        public String BillingCity { get; set; }
        public String BillingState { get; set; }
        public String BillingPostalCode { get; set; }
        public String BillingCountry { get; set; }

        public String IpAddress { get; set; }
        public String Currency { get; set; }
        public String Price { get; set; }

        public String CustomerId { get; set; }
        public String OrderId { get; set; }
        public String Description { get; set; }

        public ProcessorRequestType RequestType { get; set; }
    }
}

