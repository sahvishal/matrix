using System;

namespace Falcon.Entity.Other
{
    public class EEndOfDayInfo
    {
        
        public string FirstName { get; set; }
                
        public string LastName { get; set; }
                
        public string MiddleName { get; set; }
                
        public Int64 CustomerID { get; set; }
                
        public bool PCP { get; set; }
                
        public bool Gender { get; set; }
                
        public bool Height { get; set; }
                
        public bool Weight { get; set; }
                
        public bool Race { get; set; }
                
        public bool Phone { get; set; }
                
        public bool DOB { get; set; }              
                
        public bool City { get; set; }
                
        public bool State { get; set; }
                
        public bool Zip { get; set; }
                
        public bool StartTime { get; set; }        
        
        public bool EndTime { get; set; }             

        
        public bool MedicalHistory { get; set; }      
                
        public bool AAAInfo { get; set; }        
        
        public bool StrokeInfo { get; set; }        
        
        public bool PaymentInfo { get; set; }
        
        public short HIPAAStatus { get; set; }
        
        public string AppointmentTime { get; set; }

        /// <summary>
        /// Tech team configuration flag
        /// </summary>        
        public bool TechTeamConfigured { get; set; }

        /// <summary>
        /// Event is signoff by technician
        /// </summary>        
        public bool IsSignOff { get; set; }

        /// <summary>
        /// signoff userid
        /// </summary>        
        public Int64 SignoffByUserId { get; set; }

        /// <summary>
        /// signoff time stamp
        /// </summary>        
        public string SignoffDatetime { get; set; }

        /// <summary>
        /// signoff by 
        /// </summary>        
        public string SignoffBy { get; set; }
       
        /// <summary>
        /// IsAuthorized
        /// </summary>        
        public bool IsAuthorized { get; set; }

    }
   
}
