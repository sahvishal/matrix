using System;
using System.Collections.Generic;
using Falcon.Entity.CallCenter;
using Falcon.Entity.MedicalVendor;
using Falcon.Entity.Franchisor;

namespace Falcon.Entity.Other
{
    public class EEventCustomer
    {
        private int m_iCustomerEventTestID =0;
        private ECustomers m_objCustomer = null;
        private EEventPackage m_objEventPackage = null;
        private Int32 m_iEventID;
        private bool m_bolInterpreted = true;
        private int m_iTechnicianID = 0;
        private bool m_bolLocked = true;
        private bool m_bolPaymentOnline=true;
        private bool m_bolTestConducted=true;
        private long m_iAppointmentID=0;
        private bool m_bolPaid;

        public List<ETest> TestsPurchased { get; set; }

        //private EEventPaymentDetail m_objEventPaymentDetail = null;
        private ECallCenterCallCenterUser m_objCCUser = null;
        private EEventAppointment m_objEventAppointment = null;
        private EPaymentDetail m_objPaymentDetail=null;
        private DateTime m_dtDate= DateTime.Now;

        private List<EAAATestResult> m_objAAATestResult = null;
        private List<EASITestResult> m_objASITestResult = null;
        private List<ECarotidArteryTestResult> m_objCarotidTestResult = null;
        private List<EOsteoporosisTestResult> m_objOsteoporosisTestResult = null;
        private List<EPADTestResult> m_objPADTestResult = null;
        private List<EEkgTestResult> _ekgTestResult = null;
        private List<ELiverTestResult> _liverTestResult = null;
        private List<ELipidTestResult> _lipidTestResult = null;

        private bool m_bolReportEmail = false;
        private Decimal m_dblReportEmailAmt = 0.00m;
        private ECoupon m_objCoupon = null;
        private bool m_noshow = false;
        private float m_fpaidamount = 0.00F;
        private float m_fUnpaidAmount = 0.00F;
        private List<EPaymentDetail> m_objListPaymentDetail=null;
        private List<EMVUserEventTestLock> m_objMVUserEventTestLock=null;
        private bool m_bolIsCritical = false;
        private int m_iNextCustomerEventTestID = 0;
        private int m_iEventCustomerID = 0;
        private string m_strEvaluationDate = string.Empty;
        private int m_iCustomerTestStatus = 0;
        private string m_strRegisteredBy = "";
        private string m_strPodName = "";
        private string _marketingSource = string.Empty;
        private string _salesRep = string.Empty;

        public bool IsClinicalFormGenerated { get; set; }
        public bool IsResultPDFGenerated { get; set; }
        public bool IsResultReadyForCustomerViewing { get; set; }
        public bool IsColoractelReady { get; set; }

        public decimal CashPayment { get; set; }
        public decimal CheckPayment { get; set; }
        public decimal EcheckPayment { get; set; }
        public decimal GCPayment { get; set; }
        public decimal CreditCardPayment { get; set; }
        public bool IsShippingApplied { get; set; }
        public string AdditionalTest { get; set; }
        public decimal ShippingCost { get; set; }
        //TODO -- As because event details like event name are putted on user entity (FirstName field) so its will be the major changes on alots of pages.
        private int _eventStatusNumber;
        //TODO -- As because event date are putted on user entity (DOB field) so its will be the major changes on alots of pages and can cause unexcepted build failed.
        private string _eventDateString;

        
        public short HIPAAStatus { get; set; }

        
        public bool IsAuthorized { get; set; }

        
        public string RegisteredBy { get { return m_strRegisteredBy; } set { m_strRegisteredBy = value; } }

        /// <summary>
        /// CustomerTestStatus
        /// </summary>        
        public int CustomerTestStatus
        {
            get
            {
                return m_iCustomerTestStatus;
            }
            set
            {
                m_iCustomerTestStatus = value;
            }
        }
        
        
        public string EvaluationDate
        {
            get { return m_strEvaluationDate; }
            set { m_strEvaluationDate = value; }
        }

        
        public int NextCustomerEventTestID
        {
            get { return m_iNextCustomerEventTestID; }
            set { m_iNextCustomerEventTestID = value; }
        }
	
        /// <summary>
        /// MVUserEventTestLock object for mapping EEventCustomer with MVUserEventTestLock
        /// </summary>        
        public List<EMVUserEventTestLock> MVUserEventTestLock
        {
            get { return m_objMVUserEventTestLock; }
            set { m_objMVUserEventTestLock = value; }
        }

        /// <summary>
        /// added accomodate the latest payment change in db 
        /// </summary>        
        public List<EPaymentDetail> ListPaymentDetail
        {
            get { return m_objListPaymentDetail; }
            set { m_objListPaymentDetail = value; }
        }
	
        
        public float UnpaidAmount
        {
            get { return m_fUnpaidAmount; }
            set { m_fUnpaidAmount = value; }
        }

        
        public float PaidAmount
        {
            get { return m_fpaidamount; }
            set { m_fpaidamount = value; }
        }
	
        
        public EPaymentDetail PaymentDetail
        {
            get { return m_objPaymentDetail; }
            set { m_objPaymentDetail = value; }
        }
	
        
        public EEventAppointment EventAppointment
        {
            get { return m_objEventAppointment; }
            set { m_objEventAppointment = value; }
        }
	
        /// <summary>
        /// unique id
        /// </summary>        
        public int CustomerEventTestID
        {
            get
            {
                return m_iCustomerEventTestID;
            }
            set
            {
                m_iCustomerEventTestID = value;
            }
        }

        /// <summary>
        /// customer object
        /// </summary>        
        public ECustomers Customer
        {
            get
            {
                return m_objCustomer;
            }
            set
            {
                m_objCustomer = value; 
            }
        }
        
        /// <summary>
        /// event package id 
        /// </summary>        
        public EEventPackage EventPackage
        {
            get
            {
                return m_objEventPackage;
            }
            set
            {
                m_objEventPackage = value;
            }
        }

        /// <summary>
        /// event object
        /// </summary>        
        public Int32 EventID
        {
            get
            {
                return m_iEventID;
            }
            set
            {
                m_iEventID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int TechnicianID
        {
            get
            {
                return m_iTechnicianID;
            }
            set
            {
                m_iTechnicianID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool Interpreted
        {
            get
            {
                return m_bolInterpreted;
            }
            set
            {
                m_bolInterpreted = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool Locked
        {
            get
            {
                return m_bolLocked;
            }
            set
            {
                m_bolLocked = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool PaymentOnline
        {
            get
            {
                return m_bolPaymentOnline;
            }
            set
            {
                m_bolPaymentOnline = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool TestConducted
        {
            get
            {
                return m_bolTestConducted;
            }
            set
            {
                m_bolTestConducted = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool Paid
        {
            get
            {
                return m_bolPaid;
            }
            set
            {
                m_bolPaid = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public long AppointmentID
        {
            get
            {
                return m_iAppointmentID;
            }
            set
            {
                m_iAppointmentID = value;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //
        //public EEventPaymentDetail EventPaymentDetail
        //{
        //    get
        //    {
        //        return m_objEventPaymentDetail;
        //    }
        //    set
        //    {
        //        m_objEventPaymentDetail = value;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>        
        public ECallCenterCallCenterUser CallCenterCallCenterUser
        {
            get
            {
                return m_objCCUser;            
            }
            set
            {
                m_objCCUser = value;
            }
        }

        
        public DateTime DateCreated
        {
            get
            {
                return m_dtDate;
            }
            set
            {
                m_dtDate = value;
            }
        }


        
        public List<EPADTestResult> PADTestResult
        {
            get { return m_objPADTestResult; }
            set { m_objPADTestResult = value; }
        }

        
        public List<EOsteoporosisTestResult> OsteoporosisTestResult
        {
            get { return m_objOsteoporosisTestResult; }
            set { m_objOsteoporosisTestResult = value; }
        }

        
        public List<ECarotidArteryTestResult> CarotidTestResult
        {
            get { return m_objCarotidTestResult; }
            set { m_objCarotidTestResult = value; }
        }

        
        public List<EASITestResult> ASITestResult
        {
            get { return m_objASITestResult; }
            set { m_objASITestResult = value; }
        }

        
        public List<EAAATestResult> AAATestResult
        {
            get { return m_objAAATestResult; }
            set { m_objAAATestResult = value; }
        }

        
        public List<EEkgTestResult> EkgTestResult
        {
            get { return _ekgTestResult; }
            set { _ekgTestResult = value; }
        }
        
        public List<ELiverTestResult> LiverTestResult
        {
            get { return _liverTestResult; }
            set { _liverTestResult = value; }
        }
        
        public List<ELipidTestResult> LipidTestResult
        {
            get { return _lipidTestResult; }
            set { _lipidTestResult= value; }
        }

        
        public List<EFraminghamRiskTestResult> FraminghamTestResult
        {
            get;
            set;
        }

        
        public ColorectalTestResult ColorectalTestResult { get; set; }

        
        public bool ReportEmail
        {
            get
            {
                return m_bolReportEmail;
            }
            set
            {
                m_bolReportEmail = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public Decimal ReportEmailAmt
        {
            get
            {
                return m_dblReportEmailAmt;
            }
            set
            {
                m_dblReportEmailAmt = value;
            }
        }

        
        public ECoupon Coupon
        {
            get
            {
                return m_objCoupon;
            }
            set
            {
                m_objCoupon = value;
            }
        }

        
        public bool NoShow
        {
            get
            {
                return m_noshow;
            }
            set
            {
                m_noshow = value;
            }
        }

        
        public bool IsCritical
        {
            get
            {
                return m_bolIsCritical;
            }
            set
            {
                m_bolIsCritical = value;
            }
        }

        /// <summary>
        /// EventCustomerID
        /// </summary>        
        public int EventCustomerID
        {
            get
            {
                return m_iEventCustomerID;
            }
            set
            {
                m_iEventCustomerID = value;
            }
        }

        /// <summary>
        /// PodName
        /// </summary>        
        public string PodName 
        { 
            get { return m_strPodName; }
            set { m_strPodName = value; } 
        }

        /// <summary>
        /// marketing source
        /// </summary>        
        public string MarketingSource
        {
            get { return _marketingSource; }
            set { _marketingSource = value; }
        }

        /// <summary>
        /// marketing source
        /// </summary>        
        public string SalesRep
        {
            get { return _salesRep; }
            set { _salesRep = value; }
        }

        // TODO
        /// <summary>
        /// get event status
        /// </summary>        
        public int EventStatus 
        {
            get { return _eventStatusNumber; }
            set { _eventStatusNumber = value; }
        }

        // TODO
        /// <summary>
        /// get event date
        /// </summary>        
        public string EventDate
        {
            get { return _eventDateString; }
            set { _eventDateString = value; }
        }

        private long? _clickId;

        
        public long? ClickId
        {
            get
            { return _clickId; }

            set
            { _clickId = value; }
        }

    }
}
