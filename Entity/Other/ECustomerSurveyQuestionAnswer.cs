namespace Falcon.Entity.Other
{   
    public class ECustomerSurveyQuestionAnswer
    {
        private int m_iCustomerSurveyQuestionAnswerID = 0;
        private int m_iCustomerSurveyQuestionID = 0;
        private string m_strAnswer = string.Empty;
        private bool m_boolIsActive = false;
        private string m_strDateCreated = string.Empty;
        private string m_strDateModified = string.Empty;
        private bool m_bolIsShowTextBox = false;

        /// <summary>
        /// Customer Survey Question Answer ID
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
        /// Customer Survey Question ID
        /// </summary>        
        public int CustomerSurveyQuestionID
        {
            get
            {
                return m_iCustomerSurveyQuestionID;
            }
            set
            {
                m_iCustomerSurveyQuestionID = value;
            }
        }

        /// <summary>
        /// Answer
        /// </summary>        
        public string Answer
        {
            get
            {
                return m_strAnswer;
            }
            set
            {
                m_strAnswer = value;
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
                m_boolIsActive = true;
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

        
        public bool IsShowTextBox
        {
            get
            {
                return m_bolIsShowTextBox;
            }
            set
            {
                m_bolIsShowTextBox = value;
            }
        }
    }
}
