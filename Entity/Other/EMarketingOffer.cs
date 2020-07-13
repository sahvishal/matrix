
using System;
using System.Collections.Generic;

namespace Falcon.Entity.Other
{
    public class EMarketingOffer
    {
        private int m_iMarketingOfferID = 0;
     
        private bool m_bolGlobal = false;
        private bool m_bolPercentage = false;
        private Decimal m_dblMarketingOfferValue = 0.00m;
        private bool m_bolFree = false;
        private bool m_bolEventBased =false;
        private Decimal m_dblMinPurchaseAmount = 0.00M;
        private Int64 m_iCreatedbyID = 0;
        private string m_dtValidityStartDate = string.Empty;
        private string m_dtValidityEndDate = string.Empty;
        private string m_dtDateCreated = string.Empty;
        private string m_dtDateModified = string.Empty;
        private Int64 m_iMaximumNumberTimesUsed = 0;
        private string m_strMarketingOffer = string.Empty;
        private string m_strMarketingOfferDesciption = string.Empty;
        private bool m_bolActive = true;
        private List<EEventMarketingOffer> m_objEventMarketingOffer = null;
        private EMarketingOfferType m_objMarketingOfferType = null;
        private Decimal m_dblMarketingOfferAmount = 0.00m;
        private string m_strSignUpType = string.Empty;
        private List<EMarketingOfferRole> m_objMarketingOfferRole = null;
        private List<EMarketingOfferSignUpMode> m_objMarketingOfferSignUpMode = null;

        
        public List<Int16> ListSignUpMode { get; set; }

        
        public List<Int16> ListRole { get; set; }
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
        
        public List<EPackageMarketingOfferMapping> PackageMarketingOfferDiscount { get; set; }
        
        /// <summary>
        /// Tells whether a Coupon to be applied packagewise or not.
        /// </summary>
        
        public bool IsDiscountTypePackageWise { get; set; }

        /// <summary>
        /// unique Coupon id
        /// </summary>
        
        public int MarketingOfferID
        {
            get { return m_iMarketingOfferID; }
            set { m_iMarketingOfferID = value; }
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
        
        public Decimal MarketingOfferValue
        {
            get
            {
                return m_dblMarketingOfferValue;
            }
            set
            {
                m_dblMarketingOfferValue = value;
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
        /// Marketing Offer
        /// </summary>
        
        public string MarketingOffer
        {
            get
            {
                return m_strMarketingOffer;
            }
            set
            {
                m_strMarketingOffer = value;
            }
        }

        
        public string MarketingOfferDes
        {
            get
            {
                return m_strMarketingOfferDesciption;
            }
            set
            {
                m_strMarketingOfferDesciption = value;
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
        
        public List<EEventMarketingOffer> EventMarketingOffer
        {
            get { return m_objEventMarketingOffer; }
            set { m_objEventMarketingOffer = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public EMarketingOfferType MarketingOfferType
        {
            get { return m_objMarketingOfferType; }
            set { m_objMarketingOfferType = value; }
        }


        /// <summary>
        /// This is the net amount of the coupon 
        /// calculated with package cost.it can be same with
        /// coupon value if discount is in fixed value
        /// </summary>
        
        public Decimal MarketingOfferAmount
        {
            get
            {
                return m_dblMarketingOfferAmount;
            }
            set
            {
                m_dblMarketingOfferAmount = value;
            }
        }

        
        public string SignUpType
        {
            get
            {
                return m_strSignUpType;
            }
            set
            {
                m_strSignUpType = value;
            }
        }

        
        public List<EMarketingOfferRole> MarketingOfferRole
        {
            get { return m_objMarketingOfferRole; }
            set { m_objMarketingOfferRole = value; }
        }

        
        public List<EMarketingOfferSignUpMode> MarketingOfferSignUpMode
        {
            get { return m_objMarketingOfferSignUpMode; }
            set { m_objMarketingOfferSignUpMode = value; }
        }

    }
}
