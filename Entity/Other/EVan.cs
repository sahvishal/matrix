
using System;

namespace Falcon.Entity.Other
{   
    
    public class EVan
    {
        private Int64 m_iVanID = 0;
        private string m_strRegistrationNumber = string.Empty;
        private EState m_objState;
        private string m_strVIN = string.Empty;
        private string m_strName = string.Empty;
        private string m_strMake = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        

        /// <summary>
        /// unique Van id
        /// </summary>
        
        public Int64 VanID
        {
            get { return m_iVanID; }
            set { m_iVanID = value; }
        }

        /// <summary>
        /// Van RegistrationNumber
        /// </summary>
        
        public string RegistrationNumber
        {
            get { return m_strRegistrationNumber; }
            set { m_strRegistrationNumber = value; }
        }

        /// <summary>
        /// mapping of van object with state.
        /// </summary>
        
        public EState State
        {
            get { return m_objState; }
            set { m_objState = value; }
        }

        /// <summary>
        /// Van Identification number
        /// </summary>
        
        public string VIN
        {
            get { return m_strVIN; }
            set { m_strVIN = value; }
        }

        /// <summary>
        /// Van name
        /// </summary>
        
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        /// <summary>
        /// Van Make
        /// </summary>
        
        public string Make
        {
            get { return m_strMake; }
            set { m_strMake = value; }
        }

        /// <summary>
        /// Van description
        /// </summary>
        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }

        /// <summary>
        /// Van status
        /// </summary>
        
        public Boolean Active
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

        
    }
}
