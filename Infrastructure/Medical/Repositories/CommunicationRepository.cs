using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    //TODO: NEED to refactor this repository and create an interface.
    [DefaultImplementation(Interface = typeof(ICommunicationRepository))]
    public class CommunicationRepository : PersistenceRepository, ICommunicationRepository
    {
        // Not Considering, a single role type can initiate second thread for a single EventCustomer
        // before the previous one was replied for.
        public void SaveCommunicationDetails(string notes, OrganizationRoleUser updatedBy, long customerId, long eventId)
        {

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventCustomerResult =
                    linqMetaData.EventCustomerResult.Where(
                        customerEventTest =>
                        customerEventTest.CustomerId == customerId && customerEventTest.EventId == eventId).SingleOrDefault();

                var parentRoleId = linqMetaData.Role.Where(r => r.RoleId == updatedBy.RoleId && r.IsActive).Select(r => r.ParentId).SingleOrDefault();

                var eventCustomerResultId = eventCustomerResult == null ? 0 : eventCustomerResult.EventCustomerResultId;

                var customerResultScreeningCommunication = linqMetaData.CustomerResultScreeningCommunication.Where(customerResultCommunication =>
                    customerResultCommunication.EventCustomerResultId == eventCustomerResultId).ToList().LastOrDefault();

                bool createNew = true;
                if (updatedBy.RoleId == (long)Roles.FranchiseeAdmin || updatedBy.RoleId == (long)Roles.Technician || updatedBy.RoleId == (long)Roles.FranchisorAdmin || parentRoleId == (long)Roles.FranchiseeAdmin
                    || parentRoleId == (long)Roles.Technician || parentRoleId == (long)Roles.FranchisorAdmin)
                {
                    if (customerResultScreeningCommunication != null && customerResultScreeningCommunication.FranchiseeAdminOrgRoleUserId == null)
                    {
                        customerResultScreeningCommunication.FranchiseeAdminOrgRoleUserId = updatedBy.Id;
                        customerResultScreeningCommunication.FranchiseeComment = notes;
                        customerResultScreeningCommunication.DateResponded = DateTime.Now;
                        customerResultScreeningCommunication.IsNew = false;
                        createNew = false;
                    }
                }
                else
                {
                    if (customerResultScreeningCommunication != null && customerResultScreeningCommunication.PhysicianOrgRoleUserId == null)
                    {
                        customerResultScreeningCommunication.PhysicianOrgRoleUserId = updatedBy.Id;
                        customerResultScreeningCommunication.PhysicianComment = notes;
                        customerResultScreeningCommunication.DateResponded = DateTime.Now;
                        customerResultScreeningCommunication.IsNew = false;
                        createNew = false;
                    }
                }

                if (createNew)
                {
                    customerResultScreeningCommunication = new CustomerResultScreeningCommunicationEntity
                                                               {
                                                                   EventCustomerResultId = eventCustomerResultId,
                                                                   CommunicationInitiatedByOrgRoleUserId = updatedBy.Id
                                                               };

                    if (updatedBy.RoleId == (long)Roles.FranchiseeAdmin || updatedBy.RoleId == (long)Roles.Technician
                        || parentRoleId == (long)Roles.FranchiseeAdmin || parentRoleId == (long)Roles.Technician)
                    {
                        customerResultScreeningCommunication.FranchiseeAdminOrgRoleUserId = updatedBy.Id;
                        customerResultScreeningCommunication.FranchiseeComment = notes;
                    }
                    else
                    {
                        customerResultScreeningCommunication.PhysicianOrgRoleUserId = updatedBy.Id;
                        customerResultScreeningCommunication.PhysicianComment = notes;
                    }

                    customerResultScreeningCommunication.DateCreated = DateTime.Now;
                    customerResultScreeningCommunication.IsNew = true;
                }

                if (!myAdapter.SaveEntity(customerResultScreeningCommunication, false, true))
                {
                    throw new PersistenceFailureException();
                }
            }
        }



        public string GetCommentsforPhysician(long customerId, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventCustomerResult =
                    linqMetaData.EventCustomerResult.
                    Where(
                        customerEventTest =>
                        customerEventTest.CustomerId == customerId && customerEventTest.EventId == eventId).SingleOrDefault();

                var eventCustomerResultId = eventCustomerResult == null ? 0 : eventCustomerResult.EventCustomerResultId;

                var customerResultScreeningCommunications = linqMetaData.CustomerResultScreeningCommunication.Where(customerResultCommunication =>
                    customerResultCommunication.EventCustomerResultId == eventCustomerResultId).ToList();

                var customerResultScreeningCommunication = customerResultScreeningCommunications.LastOrDefault();

                if (customerResultScreeningCommunication != null)
                    return customerResultScreeningCommunication.FranchiseeComment;

                return string.Empty;
            }
        }
        public string GetCommentsforPhysician(long customerId, long eventId, long physicianId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventCustomerResult =
                    linqMetaData.EventCustomerResult.
                    Where(
                        customerEventTest =>
                        customerEventTest.CustomerId == customerId && customerEventTest.EventId == eventId).SingleOrDefault();

                var eventCustomerResultId = eventCustomerResult == null ? 0 : eventCustomerResult.EventCustomerResultId;

                var customerResultScreeningCommunications = linqMetaData.CustomerResultScreeningCommunication.Where(customerResultCommunication =>
                    customerResultCommunication.EventCustomerResultId == eventCustomerResultId && customerResultCommunication.PhysicianOrgRoleUserId == physicianId).ToList();

                var customerResultScreeningCommunication = customerResultScreeningCommunications.LastOrDefault();

                if (customerResultScreeningCommunication != null)
                    return customerResultScreeningCommunication.FranchiseeComment;

                return string.Empty;
            }
        }

        public OrderedPair<long, string> GetPhysicianandCommentsforFranchisee(long customerId, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventCustomerResult =
                    linqMetaData.EventCustomerResult.Where(
                        customerEventTest =>
                        customerEventTest.CustomerId == customerId && customerEventTest.EventId == eventId).SingleOrDefault();

                var customerEventTestId = eventCustomerResult == null ? 0 : eventCustomerResult.EventCustomerResultId;

                var customerResultScreeningCommunications = linqMetaData.CustomerResultScreeningCommunication.Where(customerResultCommunication =>
                    customerResultCommunication.EventCustomerResultId == customerEventTestId).ToList();

                var customerResultScreeningCommunication = customerResultScreeningCommunications.LastOrDefault();

                if (customerResultScreeningCommunication != null && customerResultScreeningCommunication.PhysicianOrgRoleUserId.HasValue)
                    return new OrderedPair<long, string>(customerResultScreeningCommunication.PhysicianOrgRoleUserId.Value, customerResultScreeningCommunication.PhysicianComment); ;

                return new OrderedPair<long, string>(0, string.Empty);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetPhysicianCommentsforgivenEventCustomers(IEnumerable<long> eventCustomerIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return linqMetaData.CustomerResultScreeningCommunication.Where(crc =>
                    eventCustomerIds.Contains(crc.EventCustomerResultId) && crc.PhysicianOrgRoleUserId.HasValue && crc.PhysicianOrgRoleUserId.Value == crc.CommunicationInitiatedByOrgRoleUserId && !crc.FranchiseeAdminOrgRoleUserId.HasValue).
                    Select(ec => new OrderedPair<long, string>(ec.EventCustomerResultId, ec.PhysicianComment)).ToArray();
            }
        }

        public string GetNotesForReversal(long eventcustomerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventCustomerResult = linqMetaData.EventCustomerResult.Single(customerEventTest => customerEventTest.EventCustomerResultId == eventcustomerId);
                if (eventCustomerResult != null)
                {
                    var customerResultScreeningCommunications = linqMetaData.CustomerResultScreeningCommunication.
                        Where(customerResultCommunication => customerResultCommunication.EventCustomerResultId == eventcustomerId
                        && customerResultCommunication.DateCreated > eventCustomerResult.DateModified).ToList();

                    var customerResultScreeningCommunication = customerResultScreeningCommunications.LastOrDefault();

                    if (customerResultScreeningCommunication != null)
                        return customerResultScreeningCommunication.PhysicianComment;
                }

                return string.Empty;
            }
        }
    }
}
