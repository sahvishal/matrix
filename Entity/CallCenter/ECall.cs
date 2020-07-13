using System;
using System.Collections.Generic;

namespace Falcon.Entity.CallCenter
{
    [Serializable]
    public class ECall
    {
        public ECall()
        {
            OutBound = false;
            SourceCode = string.Empty;
            CallersPhoneNumber = string.Empty;
            IncomingPhoneLine = string.Empty;
            CallBackNumber = string.Empty;
            DateModified = string.Empty;
            DateCreated = string.Empty;
            EventID = 0;
            CallStatus = string.Empty;
            TimeEnd = string.Empty;
            TimeCreated = string.Empty;
            CalledCustomerID = 0;
            IsNewCustomer = true;
            CallCenterCallCenterUserID = 0;
            CallID = 0;
            TotalCalls = 0;
        }

        public long Status { get; set; }
        public int TotalCalls { get; set; }
        public long CallID { get; set; }
        public long CallCenterCallCenterUserID { get; set; }
        public bool IsNewCustomer { get; set; }
        public long CalledCustomerID { get; set; }
        public string TimeCreated { get; set; }
        public string TimeEnd { get; set; }
        public string CallStatus { get; set; }
        public long EventID { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string CallBackNumber { get; set; }
        public List<ECallCenterNotes> CallNotes { get; set; }
        public string IncomingPhoneLine { get; set; }
        public string CallersPhoneNumber { get; set; }
        public string SourceCode { get; set; }
        public bool OutBound { get; set; }
    }
}
