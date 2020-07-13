using System.Collections.Generic;

namespace Falcon.Entity.Other
{    
    public class ECustomerSurveyQuestion
    {
        private int m_iCustomerSurveyQuestionID = 0;
        private string m_strQuestion = string.Empty;
        private bool m_boolIsActive = false;
        private string m_strDateCreated = string.Empty;
        private string m_strDateModified = string.Empty;
        private List<ECustomerSurveyQuestionAnswer> m_objAnswer = null;

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
        /// Question
        /// </summary>        
        public string Question
        {
            get
            {
                return m_strQuestion;
            }
            set
            {
                m_strQuestion = value;
            }
        }

        /// <summary>
        /// Is Active
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
        /// Date Created
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
        /// Date Modified
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
        /// List of answers
        /// </summary>        
        public List<ECustomerSurveyQuestionAnswer> Answer
        {
            get
            {
                return m_objAnswer;
            }
            set
            {
                m_objAnswer = value;
            }
        }
    }
}
