using System;

namespace Falcon.Entity.Franchisee
{
    [Serializable]
    public class ESalesRepMyActivity
    {
        /// <summary>
        /// 
        /// </summary>        
        public Int64 ActivityID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Int64 ProspectID { get; set; }


        /// <summary>
        /// 
        /// </summary>        
        public Int64 ProspectContactID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Int64 ContactID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>        
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string Prospect { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string ContactName { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string ActivityTime { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string ActivityType { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public bool IsHost { get; set; }


        /// <summary>
        /// 
        /// </summary>        
        public Int64 EventId { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string EventName { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int EventStatus { get; set; }

        public bool ActivityMarkedStatus { get; set; }
    }
}
