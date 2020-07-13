using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues
{
   public  interface IPreAssessmentCallQueueService
    {
      // void GetDataFromAPI(PreAssessmentCallQueueModel preAssessmentCallQueueModel);
       long StartCallForPreAssessment(long orgRoleUserId, long customerId, long eventId, long callQueueId, long callId = 0);
       PreAssessmentCustomerContactViewModel GetByCustomerId(long customerId, long callId, long orgRoleUserId);
       bool UpdateCustomerData(CallQueueCustomerEditModel model, long createdByOrgRoleUserId);
       bool EndActiveCall(long callQueueCustomer, long callId, bool isCallQueueRequsted, long orgainizationRoleId, bool isRemoveFromQueueRequested, long? callOutcomeId = null, string skipCallNotes = "");
       
    }
}
