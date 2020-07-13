using System;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;

namespace Falcon.DataAccess.Deprecated
{
    public class CallStatusUpdater
    {
        public void UpdateCallStatus(int eventid, ECall call)
        {
            call.TimeEnd = DateTime.Now.ToString();
            call.EventID = eventid;
            var callcenterDal = new CallCenterDAL();
            callcenterDal.UpdateCall(call);
        }
    }
}