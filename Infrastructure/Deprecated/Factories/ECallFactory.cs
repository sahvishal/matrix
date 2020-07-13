using System;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.Entity.CallCenter;
using Falcon.Data.EntityClasses;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Deprecated.Factories
{
    public class ECallFactory
    {
        public ECall Create(OrderedPair<CallsEntity, string> entityOrderedPair)
        {
            var entity = entityOrderedPair.FirstValue;

            return new ECall()
                       {
                           CallBackNumber = entity.CallBackNumber,
                           CallCenterCallCenterUserID = entity.CreatedByOrgRoleUserId,
                           CalledCustomerID = entity.CalledCustomerId != null ? entity.CalledCustomerId.Value : 0,
                           CallersPhoneNumber = entity.CallersPhoneNumber,
                           CallID = entity.CallId,
                           EventID = entity.EventId != null ? entity.EventId.Value : 0,
                           IncomingPhoneLine = entity.IncomingPhoneLine,
                           IsNewCustomer = entity.IsNewCustomer != null ? entity.IsNewCustomer.Value : false,
                           CallStatus = entity.CallStatus,
                           OutBound = entity.OutBound != null ? entity.OutBound.Value : false,
                           TimeCreated = entity.TimeCreated != null ? entity.TimeCreated.ToString() : string.Empty,
                           SourceCode = entityOrderedPair.SecondValue
                       };
        }
    }
}
