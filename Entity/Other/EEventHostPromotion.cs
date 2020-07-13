namespace Falcon.Entity.Other
{
    public class EEventHostPromotion
    {

        private int m_iEventPromotionID = 0;
        private int m_iEventID = 0;
        private bool m_bolHostAllowPostersandFlyers = false;
        private int m_iTotalHostPosters = 0;
        private int m_iTotalRepPosters= 0;
        private bool m_bolPosterPlacementDiscussedwithHost = false;
        private bool m_bolHostWillPostAnnouncement = false;
        private string m_strAnnouncementStartDate;
        private string m_strAnnouncementEndDate;
        private bool m_bolHostAllowBulletinInserts = false;
        private string m_strInsertDate1;
        private string m_strInsertDate2;
        private int m_iNumberOfInserts = 0;
        private bool m_bolHostAllowVerbalAnnouncements = false;
        private bool m_bolVerbalAnnouncementbyRepresentative = false;
        private bool m_bolVerbalAnnouncementbySalesRep = false;
        private string m_strVerbalAnnouncementbySalesRepDate;
        private bool m_bolHostAllowDirectMailtoMembers = false;
        private bool m_bolProvidedwithMailingInformation = false;
        private string m_strDirectMailingListArrivalDate;
        private bool m_bolHostAllowMailingtheMembersofOrganisation = false;
        private string m_strDateEmailsProvided;
        private bool m_bolIsActive = false;
        private bool m_bolStandardPromotion = false;
        private int m_iTotalPosters = 0;


        /// <summary>
        /// 
        /// </summary>        
        public int TotalPosters
        {
            get { return m_iTotalPosters; }
            set { m_iTotalPosters = value; }
        }
	
        
        /// <summary>
        /// 
        /// </summary>        
        public bool StandardPromotion
        {
            get { return m_bolStandardPromotion; }
            set { m_bolStandardPromotion = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>        
        public int EventPromotionID
        {
            get { return m_iEventPromotionID; }
            set { m_iEventPromotionID = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int EventID
        {
            get { return m_iEventID; }
            set { m_iEventID = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>        
        public bool HostAllowPostersandFlyers
        {
            get { return m_bolHostAllowPostersandFlyers; }
            set { m_bolHostAllowPostersandFlyers = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int TotalHostPosters
        {
            get { return m_iTotalHostPosters; }
            set { m_iTotalHostPosters = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int TotalRepPosters
        {
            get { return m_iTotalRepPosters; }
            set { m_iTotalRepPosters = value; }
        }

        /// <summary>
        /// 
        /// </summary>                
        public bool PosterPlacementDiscussedwithHost
        {
            get { return m_bolPosterPlacementDiscussedwithHost; }
            set { m_bolPosterPlacementDiscussedwithHost = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>        
        public bool HostWillPostAnnouncement
        {
            get { return m_bolHostWillPostAnnouncement; }
            set { m_bolHostWillPostAnnouncement = value; }
        }

        /// <summary>
        /// 
        /// </summary>              
        public string AnnouncementStartDate
        {
            get { return m_strAnnouncementStartDate; }
            set { m_strAnnouncementStartDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string AnnouncementEndDate
        {
            get { return m_strAnnouncementEndDate; }
            set { m_strAnnouncementEndDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool HostAllowBulletinInserts
        {
            get { return m_bolHostAllowBulletinInserts; }
            set { m_bolHostAllowBulletinInserts = value; }
        }


        /// <summary>
        /// 
        /// </summary>        
        public string InsertDate1
        {
            get { return m_strInsertDate1; }
            set { m_strInsertDate1 = value; }
        }


        /// <summary>
        /// 
        /// </summary>        
        public string InsertDate2
        {
            get { return m_strInsertDate2; }
            set { m_strInsertDate2 = value; }
        }


        /// <summary>
        /// 
        /// </summary>        
        public int NumberOfInserts
        {
            get { return m_iNumberOfInserts; }
            set { m_iNumberOfInserts = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>        
        public bool HostAllowVerbalAnnouncements
        {
            get { return m_bolHostAllowVerbalAnnouncements; }
            set { m_bolHostAllowVerbalAnnouncements = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool VerbalAnnouncementbyRepresentative
        {
            get { return m_bolVerbalAnnouncementbyRepresentative; }
            set { m_bolVerbalAnnouncementbyRepresentative = value; }
        }

        /// <summary>
        /// 
        /// </summary>                
        public bool VerbalAnnouncementbySalesRep
        {
            get { return m_bolVerbalAnnouncementbySalesRep; }
            set { m_bolVerbalAnnouncementbySalesRep = value; }
        }

        /// <summary>
        /// 
        /// </summary>               
        public string VerbalAnnouncementbySalesRepDate
        {
            get { return m_strVerbalAnnouncementbySalesRepDate; }
            set { m_strVerbalAnnouncementbySalesRepDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>                
        public bool HostAllowDirectMailtoMembers
        {
            get { return m_bolHostAllowDirectMailtoMembers; }
            set { m_bolHostAllowDirectMailtoMembers = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool ProvidedwithMailingInformation
        {
            get { return m_bolProvidedwithMailingInformation; }
            set { m_bolProvidedwithMailingInformation = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string DirectMailingListArrivalDate
        {
            get { return m_strDirectMailingListArrivalDate; }
            set { m_strDirectMailingListArrivalDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool HostAllowMailingtheMembersofOrganisation
        {
            get { return m_bolHostAllowMailingtheMembersofOrganisation; }
            set { m_bolHostAllowMailingtheMembersofOrganisation = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>        
        public string DateEmailsProvided
        {
            get { return m_strDateEmailsProvided; }
            set { m_strDateEmailsProvided = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool IsActive
        {
            get { return m_bolIsActive; }
            set { m_bolIsActive = value; }
        }


    }
}
