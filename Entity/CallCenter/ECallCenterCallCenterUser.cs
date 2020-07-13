using System;
using Falcon.Entity.Other;

namespace Falcon.Entity.CallCenter
{
    [Serializable]
    public class ECallCenterCallCenterUser
    {
        private int m_iCallCenterCallCenterUserID = 0;
        private bool m_bolActive = true;
        private bool m_bolDefault = true;
        private ERole m_objRole;
        private ECallCenter m_objCallCenter;

        private string m_strJoiningDate;
        private string m_teminationdate;
        /// <summary>
        /// unique callcentercalcenter user id
        /// </summary>
        public int CallCenterCallCenterUserID
        {
            get
            {
                return m_iCallCenterCallCenterUserID;
            }
            set
            {
                m_iCallCenterCallCenterUserID = value;
            }
        }

        /// <summary>
        /// status of callcentercallcenter user
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
        public bool Default
        {
            get
            {
                return m_bolDefault;
            }
            set
            {
                m_bolDefault = value;
            }
        }
        /// <summary>
        /// call center object for mapping callcentercallcenter with callcenter
        /// </summary>
        public ECallCenter CallCenter
        {
            get
            {
                return m_objCallCenter;
            }
            set
            {
                m_objCallCenter = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ERole UserRole
        {
            get { return m_objRole; }
            set { m_objRole = value; }
        }


        /// <summary>
        /// CallCenter Callcenter user joining date
        /// </summary>
        public string JoiningDate
        {
            get { return m_strJoiningDate; }
            set { m_strJoiningDate = value; }
        }

        /// <summary>
        /// CallCenter Callcenter user Termination Date
        /// </summary>
        public string TerminationDate
        {
            get { return m_teminationdate; }
            set { m_teminationdate = value; }
        }
    }
}
