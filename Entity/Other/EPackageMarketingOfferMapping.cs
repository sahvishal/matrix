using System;

namespace Falcon.Entity.Other
{   
    
    public class EPackageMarketingOfferMapping
    {
        /// <summary>
        /// 
        /// </summary>
        
        public Int64 PackageSourceCodeDiscountID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public Int64 PackageID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public Int64 CouponID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public decimal DiscountAmount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public bool IsPercentage { get; set; }

    }
}
