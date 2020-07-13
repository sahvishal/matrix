 
using System;

namespace Falcon.Entity.Other
{    
    public class ECarotidArteryLocationWiseData
    {
        private Int16 m_iLocation = 0;
        private string m_strSize = string.Empty;
        private Int16 m_iSonographicAppreance = 0;
        private string m_strNotes = string.Empty;
        private int m_iCarotidArteryLocationWiseDataID = 0;
        private Int16 m_shtLocationNumber = 0;

        /// <summary>
        /// 
        /// </summary>        
        public Int16 LocationNumber
        {
            get { return m_shtLocationNumber; }
            set { m_shtLocationNumber = value; }
        }


        /// <summary>
        /// 
        /// </summary>        
        public int CarotidArteryLocationWiseDataID
        {
            get { return m_iCarotidArteryLocationWiseDataID; }
            set { m_iCarotidArteryLocationWiseDataID = value; }
        }


        /// <summary>
        /// extra info about the evaluation
        /// </summary>        
        public string Notes
        {
            get { return m_strNotes; }
            set { m_strNotes = value; }
        }

        /// <summary>
        /// SonographicAppreance
        /// </summary>        
        public Int16 SonographicAppreance
        {
            get { return m_iSonographicAppreance; }
            set { m_iSonographicAppreance = value; }
        }

        /// <summary>
        /// size
        /// </summary>        
        public string Size
        {
            get { return m_strSize; }
            set { m_strSize = value; }
        }

        /// <summary>
        /// location of the person concerned
        /// </summary>        
        public Int16 Location
        {
            get { return m_iLocation; }
            set { m_iLocation = value; }
        }
    }
}
