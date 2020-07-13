using System;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IKynHealthAssessmentHelper
    {
        bool IsKynHafFilled(long eventId, long customerId);
        bool IsKynHafFilled(long eventId, Customer customer);
        bool? IsKynHafPrefilled(long eventId, long customerId, DateTime appointmentTime, bool checkKynOnly=true);
        bool CheckHafPrefilled(long eventId, long customerId, int versionNumber = 0);
    }
}
