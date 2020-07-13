using System;

namespace Falcon.App.Core.Finance.Domain
{
    public class CreditCardProcessorProcessingInfo : PaymentProcessorCommonInfo
    {
        public String CreditCardNo { get; set; }
        public String SecurityCode { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public String CardType { get; set; }
    }
}