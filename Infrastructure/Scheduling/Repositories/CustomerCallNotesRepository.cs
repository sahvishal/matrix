using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class CustomerCallNotesRepository : UniqueItemRepository<CustomerCallNotes, CustomerRegistrationNotesEntity>, ICustomerCallNotesRepository
    {

        public CustomerCallNotesRepository(IMapper<CustomerCallNotes, CustomerRegistrationNotesEntity> mapper)
            : base(mapper) { }

        protected override EntityField2 EntityIdField
        {
            get { return CustomerRegistrationNotesFields.CustomerRegistrationNotesId; }
        }

        public IEnumerable<CustomerCallNotes> GetEventCustomerAppointmentNotes(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var customerRegistrationNotes =
                    linqMetaData.CustomerRegistrationNotes.Where(
                        cr =>
                        cr.CustomerId == customerId && cr.EventId == eventId && cr.IsActive &&
                        cr.NoteType == (int)CustomerRegistrationNotesType.AppointmentNote);

                return Mapper.MapMultiple(customerRegistrationNotes);
            }
        }

        public IEnumerable<CustomerCallNotes> GetCustomerNotes(long customerId, bool includeBlankNotes = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var customerRegistrationNotes = (from crn in linqMetaData.CustomerRegistrationNotes
                                                 where crn.CustomerId == customerId && (includeBlankNotes || crn.Notes.Trim().Length > 0) && crn.IsActive
                                                 orderby crn.DateCreated
                                                 select crn);

                return Mapper.MapMultiple(customerRegistrationNotes);

            }
        }

        public IEnumerable<CustomerCallNotes> GetCustomerNotes(long eventId, IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var customerRegistrationNotes =
                    linqMetaData.CustomerRegistrationNotes.Where(
                        cr => customerIds.Contains(cr.CustomerId) && cr.IsActive);

                var callCenterNotes = (from c in linqMetaData.Calls
                                       join ccn in linqMetaData.CallCenterNotes on c.CallId equals ccn.CallId
                                       where c.CalledCustomerId.HasValue && c.CalledCustomerId.Value > 0 && customerIds.Contains(c.CalledCustomerId.Value) && ccn.Notes.Trim().Length > 0
                                       select
                                           new CustomerCallNotes
                                           {
                                               CustomerId = c.CalledCustomerId.Value,
                                               EventId = c.EventId,
                                               Notes = ccn.Notes,
                                               DataRecorderMetaData = new DataRecorderMetaData
                                               {
                                                   DataRecorderCreator = new OrganizationRoleUser(c.CreatedByOrgRoleUserId),
                                                   DateCreated = ccn.DateCreated,
                                                   DateModified = ccn.DateModified
                                               }
                                           }).ToArray();

                var registrationNotes = Mapper.MapMultiple(customerRegistrationNotes);
                registrationNotes = registrationNotes.Concat(callCenterNotes);

                registrationNotes = registrationNotes.Where(ccn => !ccn.EventId.HasValue || ccn.EventId.Value == eventId).ToArray();

                return registrationNotes;
            }
        }

        public bool Delete(long customerRegistrationNotesId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CustomerRegistrationNotesEntity(customerRegistrationNotesId)
                                 {
                                     IsActive = false
                                 };
                var bucket =
                    new RelationPredicateBucket(CustomerRegistrationNotesFields.CustomerRegistrationNotesId ==
                                                customerRegistrationNotesId);
                return adapter.UpdateEntitiesDirectly(entity, bucket) > 0;
            }
        }

        public void Update(IEnumerable<CustomerCallNotes> customerCallNoteses)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CustomerRegistrationNotesEntity>();
                entities.AddRange(Mapper.MapMultiple(customerCallNoteses));


                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public bool UpdateNotes(long customerRegistrationNotesId, string notes)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CustomerRegistrationNotesEntity(customerRegistrationNotesId)
                                 {
                                     Notes = notes,
                                     DateModified = DateTime.Now
                                 };

                var bucket = new RelationPredicateBucket(CustomerRegistrationNotesFields.CustomerRegistrationNotesId == customerRegistrationNotesId);
                try
                {
                    return (adapter.UpdateEntitiesDirectly(entity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public IEnumerable<CustomerCallNotes> GetNotes(IEnumerable<long> customerIds, CustomerRegistrationNotesType notesType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var notes = (from n in linqMetaData.CustomerRegistrationNotes
                             where n.IsActive && n.NoteType == (int)notesType && customerIds.Contains(n.CustomerId)
                             orderby n.DateCreated descending
                             select n).ToArray();

                return Mapper.MapMultiple(notes);
            }
        }

        public IEnumerable<CustomerCallNotes> GetProspectCustomerNotes(IEnumerable<long> prospectCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var notes = (from pc in linqMetaData.ProspectCustomer
                             join pcc in linqMetaData.ProspectCustomerCall on pc.ProspectCustomerId equals
                                 pcc.ProspectCustomerId
                             join c in linqMetaData.Calls on pcc.CallId equals c.CallId
                             join ccn in linqMetaData.CallCenterNotes on c.CallId equals ccn.CallId
                             where prospectCustomerIds.Contains(pc.ProspectCustomerId)
                                   && pc.DateCreated.Date <= ccn.DateCreated.Date
                                   && ccn.Notes.Trim().Length > 0
                                   && c.Status != (long)CallStatus.CallSkipped
                             select new CustomerCallNotes
                                        {
                                            ProspectCustomerId = pc.ProspectCustomerId,
                                            Notes = ccn.Notes,
                                            DataRecorderMetaData = new DataRecorderMetaData
                                                                       {
                                                                           DataRecorderCreator = new OrganizationRoleUser(c.CreatedByOrgRoleUserId),
                                                                           DateCreated = ccn.DateCreated,
                                                                           DateModified = ccn.DateModified
                                                                       }
                                        }).ToList();

                var customerNotes = (from pc in linqMetaData.ProspectCustomer
                                     join crn in linqMetaData.CustomerRegistrationNotes on pc.CustomerId equals crn.CustomerId
                                     where crn.IsActive
                                     && prospectCustomerIds.Contains(pc.ProspectCustomerId)
                                     && pc.DateCreated.Date <= crn.DateCreated.Date
                                     select new CustomerCallNotes
                                                {
                                                    ProspectCustomerId = pc.ProspectCustomerId,
                                                    Notes = crn.Notes,
                                                    DataRecorderMetaData = new DataRecorderMetaData
                                                                   {
                                                                       DataRecorderCreator = new OrganizationRoleUser(crn.CreatedByOrgRoleUserId),
                                                                       DateCreated = crn.DateCreated,
                                                                       DateModified = crn.DateModified
                                                                   }
                                                }).ToList();
                var notesTobeRemoved = customerNotes.Where(cn => notes.Select(n => n.Notes).Contains(cn.Notes)).Select(cn => cn).ToArray();
                foreach (var removeNote in notesTobeRemoved)
                {
                    customerNotes.Remove(removeNote);
                }

                notes.AddRange(customerNotes);
                return notes;
            }
        }
    }
}
