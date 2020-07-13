using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICommunicationRepository
    {
        void SaveCommunicationDetails(string notes, OrganizationRoleUser updatedBy, long customerId, long eventId);
        string GetCommentsforPhysician(long customerId, long eventId);
        string GetCommentsforPhysician(long customerId, long eventId, long physicianId);
        OrderedPair<long, string> GetPhysicianandCommentsforFranchisee(long customerId, long eventId);
        IEnumerable<OrderedPair<long, string>> GetPhysicianCommentsforgivenEventCustomers(IEnumerable<long> eventCustomerIds);
        string GetNotesForReversal(long eventcustomerId);
    }
}