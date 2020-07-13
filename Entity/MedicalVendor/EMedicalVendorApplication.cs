using System;
using Falcon.Entity.Other;

namespace Falcon.Entity.MedicalVendor
{
    public class EMedicalVendorApplication
    {

        private int m_iMedicalVendorApplicationID;
        private EMedicalVendorType medicalvendortype;
        private EMVUserSpecialization medicalspecialization;
        private EApplication application;
        private string businessphone;
        private string businessfax;
        private string resume;
        private EWFStage m_objWFStage;
        private EWFStageTrigger m_objWFStageTrigger;
        private int m_iWFStageActivityTriggerID;
        private DateTime datecreated;

        /// <summary>
        /// 
        /// </summary>        
        public EWFStage WFStage
        {
            get
            {
                return m_objWFStage;
            }
            set
            {
                m_objWFStage = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public EWFStageTrigger WFStageTrigger
        {
            get
            {
                return m_objWFStageTrigger;
            }
            set
            {
                m_objWFStageTrigger = value;
            }
        }
        
        public int WFStageActivityTriggerID
        {
            get
            {
                return m_iWFStageActivityTriggerID;
            }
            set
            {
                m_iWFStageActivityTriggerID = value;
            }
        }
        
        public EMedicalVendorType MedicalVendorType
        {
            get { return medicalvendortype; }
            set { medicalvendortype = value; }
        }

        
        public EMVUserSpecialization MedicalSpecialization
        {
            get { return medicalspecialization; }
            set { medicalspecialization = value; }
        }

        
        public EApplication Application
        {
            get { return application; }
            set { application = value; }
        }

        /// <summary>
        /// To Get/Set MedicalVendorApplicationID
        /// </summary>        
        public int MedicalVendorApplicationID
        {
            get { return this.m_iMedicalVendorApplicationID; }
            set { this.m_iMedicalVendorApplicationID = value; }
        }
        
        
        public string BusinessPhone
        {
            get { return businessphone; }
            set { businessphone = value; }
        }

        
        public string BusinessFax
        {
            get { return businessfax; }
            set { businessfax = value; }
        }

        
        public string Resume
        {
            get { return resume; }
            set { resume = value; }
        }

        
        public DateTime DateCreated
        {
            get { return datecreated; }
            set { datecreated = value; }
        }
    }
}
