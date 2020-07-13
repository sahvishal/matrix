using System;

namespace Falcon.Entity.MedicalVendor
{
    public class EMVPaymentInfo
    {
        /// <summary>
        /// 
        /// </summary>        
        public EMedicalVendor MedicalVendor { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Decimal LastPaymentMade { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string LastPaymentDate { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Decimal TotalAmountDue { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Decimal PayingAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Int64 StartPaymentInfoID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Int64 EndPaymentInfoID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int EvaluationsSinceLastPayment { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int TotalEvaluations { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string InvoiceReference { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string Notes { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string PhysicianString { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string CheckNumber { get; set; }


    }
}
