namespace Falcon.Entity.Other
{    
    public class ECustomerSurvey
    {
        private int m_iCustomerSurveyID = 0;
        private int m_iCustomerID = 0;
        private int m_iCustomerSurveyQuestionAnswerID = 0;
        private bool m_boolIsActive = false;
        private string m_strDateCreated = string.Empty;
        private string m_strDateModified = string.Empty;
        private string m_strTextBoxValue = string.Empty;

        /// <summary>
        /// CustomerSurveyID
        /// </summary>        
        public int CustomerSurveyID
        {
            get
            {
                return m_iCustomerSurveyID;
            }
            set
            {
                m_iCustomerSurveyID = value;
            }
        }

        /// <summary>
        /// CustomerID
        /// </summary>        
        public int CustomerID
        {
            get
            {
                return m_iCustomerID;
            }
            set
            {
                m_iCustomerID = value;
            }
        }

        /// <summary>
        /// CustomerSurveyQuestionAnswerID
        /// </summary>        
        public int CustomerSurveyQuestionAnswerID
        {
            get
            {
                return m_iCustomerSurveyQuestionAnswerID;
            }
            set
            {
                m_iCustomerSurveyQuestionAnswerID = value;
            }
        }

        /// <summary>
        /// IsActive
        /// </summary>        
        public bool IsActive
        {
            get
            {
                return m_boolIsActive;
            }
            set
            {
                m_boolIsActive = value;
            }
        }

        /// <summary>
        /// DateCreated
        /// </summary>        
        public string DateCreated
        {
            get
            {
                return m_strDateCreated;
            }
            set
            {
                m_strDateCreated = value;
            }
        }

        /// <summary>
        /// DateModified
        /// </summary>        
        public string DateModified
        {
            get
            {
                return m_strDateModified;
            }
            set
            {
                m_strDateModified = value;
            }
        }
        /// <summary>
        /// TextBoxValue
        /// </summary>        
        public string TextBoxValue
        {

            get
            {
                return m_strTextBoxValue;
            }
            set
            {
                m_strTextBoxValue = value;
            }
        }
    }
}
