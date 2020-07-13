using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class CallCenterNotesRepository : PersistenceRepository, ICallCenterNotesRepository
    {
        public IEnumerable<CallCenterNotes> GetByCallIds(IEnumerable<long> callIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccn in linqMetaData.CallCenterNotes
                                where ccn.CallId.HasValue && callIds.Contains(ccn.CallId.Value)
                                select ccn).ToArray();

                return Mapper.Map<IEnumerable<CallCenterNotesEntity>, IEnumerable<CallCenterNotes>>(entities);
            }
        }

        public CallCenterNotes GetByCallId(long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccn in linqMetaData.CallCenterNotes
                                where ccn.CallId.HasValue && callId == ccn.CallId.Value
                                orderby ccn.CallCenterNotesId descending
                                select ccn).FirstOrDefault();

                return Mapper.Map<CallCenterNotesEntity, CallCenterNotes>(entities);
            }
        }

        public CallCenterNotes Save(CallCenterNotes call)
        {
            if (call.CallId <= 0)
                return null;

            var inDbCallCenterNotes = GetByCallId(call.CallId);

            if (inDbCallCenterNotes != null)
            {
                call.NotesSequence = inDbCallCenterNotes.NotesSequence + 1;
            }

            call.DateCreated = DateTime.Now;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallCenterNotes, CallCenterNotesEntity>(call);
                adapter.SaveEntity(entity, true);
                return Mapper.Map<CallCenterNotesEntity, CallCenterNotes>(entity);
            }
        }

        public IEnumerable<CallCenterNotes> GetCallCenterNotesByCallId(long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccn in linqMetaData.CallCenterNotes
                                where ccn.CallId.HasValue && ccn.CallId.Value == callId
                                select ccn).ToArray();

                return Mapper.Map<IEnumerable<CallCenterNotesEntity>, IEnumerable<CallCenterNotes>>(entities);
            }
        }
    }
}
