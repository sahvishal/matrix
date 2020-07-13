using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class ScriptRepository : PersistenceRepository, IScriptRepository
    {
        public Script GetById(long id)
        {
            try
            {
                return Get(new RelationPredicateBucket(ScriptsFields.ScriptId == id)).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<Script>(id);
            }
        }

        public IEnumerable<Script> GetByIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(ScriptsFields.ScriptId == ids.ToArray()));
        }

        private IEnumerable<Script> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<ScriptsEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var scripts = Mapper.Map<IEnumerable<ScriptsEntity>, IEnumerable<Script>>(entities);

                return scripts.OrderBy(t => t.Name).ToArray();
            }
        }

        public Script Save(Script domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Script, ScriptsEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<ScriptsEntity, Script>(entity);
            }
        }
    }
}
