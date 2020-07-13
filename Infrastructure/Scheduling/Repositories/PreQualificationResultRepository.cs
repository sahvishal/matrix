using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class PreQualificationResultRepository : PersistenceRepository, IPreQualificationResultRepository
    {

        public PreQualificationResult Get(long tempCartId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.PreQualificationResult.SingleOrDefault(t => t.TempCartId == tempCartId);
                if (entity == null) return null;

                return Mapper.Map<PreQualificationResultEntity, PreQualificationResult>(entity);
            }
        }

        public PreQualificationResult GetByCallId(long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.PreQualificationResult.SingleOrDefault(t => t.CallId == callId);
                if (entity == null) return null;

                return Mapper.Map<PreQualificationResultEntity, PreQualificationResult>(entity);
            }
        }

        public PreQualificationResult GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.PreQualificationResult.SingleOrDefault(t => t.PreQualificationResultId == id);
                if (entity == null) return null;

                return Mapper.Map<PreQualificationResultEntity, PreQualificationResult>(entity);
            }
        }

        public PreQualificationResult GetByEventIdCustomerId(long evetId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.PreQualificationResult.SingleOrDefault(pqr => pqr.EventId == evetId && pqr.CustomerId == customerId);
                if (entity == null) return null;

                return Mapper.Map<PreQualificationResultEntity, PreQualificationResult>(entity);
            }
        }

        public PreQualificationResult Save(PreQualificationResult domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PreQualificationResult, PreQualificationResultEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();

                return Mapper.Map<PreQualificationResultEntity, PreQualificationResult>(entity);
            }
        }

        public void Delete(PreQualificationResult domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<PreQualificationResult> domainObjects)
        {
            throw new NotImplementedException();
        }
    }
}