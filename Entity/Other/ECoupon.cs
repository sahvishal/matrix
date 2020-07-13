using System;
using System.Collections.Generic;

namespace Falcon.Entity.Other
{
    public class ECoupon
    {
        private int m_iCouponID = 0;
     
        private bool m_bolGlobal = false;
        private bool m_bolPercentage = false;
        private Decimal m_dblCouponValue = 0.00m;
        private bool m_bolFree = false;
        private bool m_bolEventBased =false;
        private Decimal m_dblMinPurchaseAmount = 0.00M;
        private Int64 m_iCreatedbyID = 0;
        private string m_dtValidityStartDate = string.Empty;
        private string m_dtValidityEndDate = string.Empty;
        private string m_dtDateCreated = string.Empty;
        private string m_dtDateModified = string.Empty;
        private Int64 m_iMaximumNumberTimesUsed = 0;
        private string m_strCouponCode = string.Empty;
        private string m_strCouponDesciption = string.Empty;
        private bool m_bolActive = true;
        private List<EEventCoupon> m_objEventCoupon = null;
        private ECouponType m_objCouponType = null;
        private Decimal m_dblCouponAmount = 0.00m;

        /// <summary>
        /// 
        /// </summary>        
        public List<Int16> ListSignUpMode { get; set; }


        /// <summary>
        /// Sets eiher of three values. 0,1 or 2.
        /// 0 -- All Customers,
        /// 1 -- Existing Customers,
        /// 2 -- New Customers
        /// </summary>        
        public Int16 CustomerRange { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public List<EPackageCouponMapping> PackageSourceCodeDiscount { get; set; }
        
        /// <summary>
        /// Tells whether a Coupon to be applied packagewise or not.
        /// </summary>        
        public bool IsDiscountTypePackageWise { get; set; }

        /// <summary>
        /// unique Coupon id
        /// </summary>        
        public int CouponID
        {
            get { return m_iCouponID; }
            set { m_iCouponID = value; }
        }       

        /// <summary>
        /// IsGlobal status
        /// </summary>        
        public bool IsGlobal
        {
            get
            {

                return m_bolGlobal;
            }
            set
            {
                m_bolGlobal = value;
            }
        }
             
        /// <summary>
        /// IsPercentage status
        /// </summary>        
        public bool IsPercentage
        {
            get
            {

                return m_bolPercentage;
            }
            set
            {
                m_bolPercentage = value;
            }
        }

        /// <summary>
        /// CouponValue status
        /// </summary>        
        public Decimal CouponValue
        {
            get
            {return m_dblCouponValue;
            }
            set
            {
             m_dblCouponValue = value;
            }
        }
               
        /// <summary>
        /// IsPercentage status
        /// </summary>        
        public bool IsFree
        {
            get
            {

                return m_bolFree;
            }
            set
            {
                m_bolFree = value;
            }
        }

        /// <summary>
        /// IsEventBased status
        /// </summary>        
        public bool IsEventBased
        {
            get
            {

                return m_bolEventBased;
            }
            set
            {
                m_bolEventBased = value;
            }
        }

        /// <summary>
        /// MinPurchaseAmount status
        /// </summary>        
        public Decimal MinPurchaseAmount
        {
            get
            {
                return m_dblMinPurchaseAmount;
            }
            set
            {
                m_dblMinPurchaseAmount = value;
            }
        }
        /// <summary>
        /// created by user id
        /// </summary>        
        public Int64 CreatedbyUserID
        {
            get { return m_iCreatedbyID; }
            set { m_iCreatedbyID = value; }
        }

        /// <summary>
        /// Validity Start Date
        /// </summary>        
        public string ValidityStartDate
        {
            get
            {
                return m_dtValidityStartDate;
            }
            set
            {
                m_dtValidityStartDate = value;
            }
        }

        /// <summary>
        /// Validity End Date
        /// </summary>       
        public string ValidityEndDate
        {
            get
            {
                return m_dtValidityEndDate;
            }
            set
            {
                m_dtValidityEndDate = value;
            }
        }
        
       
        /// <summary>
        /// Maximum Number Times Used
        /// </summary>        
        public Int64 MaximumNumberTimesUsed
        {
            get { return m_iMaximumNumberTimesUsed; }
            set { m_iMaximumNumberTimesUsed = value; }
        }
        
       
        /// <summary>
        /// CouponCode
        /// </summary>       
        public string CouponCode
        {
            get
            {
                return m_strCouponCode;
            }
            set
            {
                m_strCouponCode = value;
            }
        }

       
        public string CouponDes
        {
            get
            {
                return m_strCouponDesciption;
            }
            set
            {
                m_strCouponDesciption = value;
            }
        }


        /// <summary>
        /// CouponType status
        /// </summary>        
        public bool Active
        {
            get
            {

                return m_bolActive;
            }
            set
            {
                m_bolActive = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>        
        public List<EEventCoupon> EventCoupon
        {
            get { return m_objEventCoupon; }
            set { m_objEventCoupon = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public ECouponType CouponType
        {
            get { return m_objCouponType; }
            set { m_objCouponType = value; }
        }


        /// <summary>
        /// This is the net amount of the coupon 
        /// calculated with package cost.it can be same with
        /// coupon value if discount is in fixed value
        /// </summary>        
        public Decimal CouponAmount
        {
            get
            {
                return m_dblCouponAmount;
            }
            set
            {
                m_dblCouponAmount = value;
            }
        }
    }
}
