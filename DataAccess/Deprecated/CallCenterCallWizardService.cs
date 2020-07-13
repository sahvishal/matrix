using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using Falcon.DataAccess.Franchisor;

namespace Falcon.DataAccess.Deprecated
{
    public class CallCenterCallWizardService
    {
        public void BindCurrentCallToProspectCustomer(long callId, long prospectCustomerId, long userIdServicedBy)
        {
            ICallCenterRepository callCenterRepository = new CallCenterRepository();
            bool isCallTiedToTheProspectCustomer = callCenterRepository.IsCallTiedToTheProspectCustomer(callId, prospectCustomerId);

            if (!isCallTiedToTheProspectCustomer)
            {
                if (callId > 0)
                {
                    if (callCenterRepository.IsCallTypeOutbound(callId))
                    {
                        var franchisorDal = new FranchisorDAL();
                        long notificationPhoneId = franchisorDal.GetNotificationPhoneIdforMappingOutboundCall(prospectCustomerId);

                        if (notificationPhoneId > 0)
                        {

                            franchisorDal.UpdateNotificationPhoneStatus(notificationPhoneId, userIdServicedBy);

                            var notificationId = franchisorDal.GetNotificationIdfromNotificationPhoneId(notificationPhoneId);
                            if (notificationId > 0)
                                callCenterRepository.CreateCallNotificationfortheCallStarted(callId, notificationId);
                        }
                        else
                        {
                            callCenterRepository.BindCallToProspectCustomer(callId, prospectCustomerId);
                        }
                    }
                    else
                    {
                        callCenterRepository.BindCallToProspectCustomer(callId, prospectCustomerId);
                    }
                }
            }

        }
    }
}
