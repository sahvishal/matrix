using System;

namespace Falcon.Entity.Other
{
    //TODO Remove this (Reffered in Customer Details)
    [Serializable]
    public class EAddress
    {        
        
        private string m_strAddress1 = string.Empty;
        private string m_strAddress2 = string.Empty;
        private int m_iCityID = 0;
        private string m_iCity = string.Empty;
        private int m_iStateID = 0;
        private string m_iState = string.Empty;
        private int m_iCountryID = 0;
        private string m_iCountry = string.Empty;
        private int m_iZipID = 0;
        private string m_strPhoneNumber;
        
        private string m_iZip = string.Empty;
        private bool m_bolActive = true;
        private string m_Fax = string.Empty;
        private bool m_bolIsMailing = false;
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool? IsManuallyVerified { get; set; }
        public bool UseLatLogForMapping { get; set; }
        public string GoogleAddressVerifiedBy { get; set; }

        /// <summary>
        /// unique address id
        /// </summary>        
        public long AddressID
        {
            get;
            set;
            
        }        
        
        public string Address1
        {
            get
            {
                return m_strAddress1;
            }
            set
            {
                m_strAddress1 = value;
            }
        }
        
        public string Address2
        {
            get
            {
                return m_strAddress2;
            }
            set
            {
                m_strAddress2 = value;
            }
        }

        /// <summary>
        /// unique city id
        /// </summary>        
        public int CityID
        {
            get
            {
                return m_iCityID;
            }
            set
            {
                m_iCityID = value;
            }
        }
        /// <summary>
        /// unique country id
        /// </summary>        
        public int CountryID
        {
            get
            {
                return m_iCountryID;
            }
            set
            {
                m_iCountryID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string PhoneNumber
        {
            get { return m_strPhoneNumber; }
            set { m_strPhoneNumber = value; }
        }
    
        /// <summary>
        /// unique state id
        /// </summary>        
        public int StateID
        {
            get
            {
                return m_iStateID;
            }
            set
            {
                m_iStateID = value;
            }
        }

        /// <summary>
        /// unique zip id
        /// </summary>        
        public int ZipID
        {
            get
            {
                return m_iZipID;
            }
            set
            {
                m_iZipID = value;
            }
        }

        /// <summary>
        /// unique city 
        /// </summary>        
        public string City
        {
            get
            {
                return m_iCity;
            }
            set
            {
                m_iCity = value;
            }
        }
        /// <summary>
        /// unique country 
        /// </summary>        
        public string Country
        {
            get
            {
                return m_iCountry;
            }
            set
            {
                m_iCountry = value;
            }
        }

        /// <summary>
        /// unique state 
        /// </summary>        
        public string State
        {
            get
            {
                return m_iState;
            }
            set
            {
                m_iState = value;
            }
        }

        /// <summary>
        /// unique zip id
        /// </summary>        
        public string Zip
        {
            get
            {
                return m_iZip;
            }
            set
            {
                m_iZip = value;
            }
        }


        /// <summary>
        /// status address
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
        /// fax address
        /// </summary>        
        public string Fax
        {
            get
            {
                return m_Fax;
            }
            set
            {
                m_Fax = value;
            }
        }

        /// <summary>
        /// Address type [Billing / Mailling ]
        /// </summary>        
        public bool IsMailing
        {
            get
            {
                return m_bolIsMailing;
            }
            set
            {
                m_bolIsMailing = value;
            }
        }
    }
}
