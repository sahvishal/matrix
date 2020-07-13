using System;
using Falcon.App.Core.Enum;

namespace Falcon.Entity.Other
{
    public class EEventActivityTemplateActivity
    {
        /// <summary>
        /// 
        /// </summary>        
        public Int64 ActivityID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string Notes { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string EmailContent { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Int32 ActivityDay { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public bool ForAfterEvent { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string ResponsibleRoleName { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Int32 ResponsibleRoleID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public Int32 ResponsibleRoleShellID { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string ResponsibleSpecifiedEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string SpecifiedUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public EEventActivity EventActivity { get; set; }

                
    }
}
