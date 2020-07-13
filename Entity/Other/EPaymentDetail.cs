using System.Collections.Generic;
using Falcon.App.Core;

namespace Falcon.Entity.Other
{    
    
    public class EPaymentDetail
    {
        //TODO Need to refactor this piece of code
        
        public List<OrderedPair<string, string>> GiftCertificate { get; set; }

        
        public string CancelationReason { get; set; }

        
        public float TotalPayment { get; set; }

        
        public float PaymentNet { get; set; }


        
        public float UnpaidAmount { get; set; }

        
        public float PaidAmount { get; set; }

        
        public int PaymentDetailID { get; set; }


        
        public ECreditCardPaymentDetail CreditCardPaymentDetail { get; set; }


        
        public ECashPaymentDetail CashPayment { get; set; }

        
        public EChequePaymentDetail ChequePayment { get; set; }

        
        public string FromDate { get; set; }

        
        public string ToDate { get; set; }

        
        public string PayDate { get; set; }

        
        public float Amount { get; set; }

        
        public EPaymentType PaymentType { get; set; }

        
        public string PaymentVia { get; set; }

        
        public bool IsPaid { get; set; }

        
        public bool DrOrCr { get; set; }

        
        public EECheckPaymentDetails ECheckPaymentDetail { get; set; }
    }
}
