namespace Falcon.Entity.Other
{   
    
    public class ETestParameter
    {
        private int m_iTestParameterID;
        private int m_iTestID;
        private string m_strParameterName;
        private string m_strParameterValue;
        private string m_strParameterDescription;


        /// <summary>
        /// 
        /// </summary>
        
        public int TestParameterID
        {
            get { return m_iTestParameterID; }
            set { m_iTestParameterID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public int TestID
        {
            get { return m_iTestID; }
            set { m_iTestID = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public string ParameterName
        {
            get { return m_strParameterName; }
            set { m_strParameterName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string ParameterValue
        {
            get { return m_strParameterValue; }
            set { m_strParameterValue = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string ParameterDescription
        {
            get { return m_strParameterDescription; }
            set { m_strParameterDescription = value; }
        }


    }
}
