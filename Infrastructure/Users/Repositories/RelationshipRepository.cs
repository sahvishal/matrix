using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class RelationshipRepository : PersistenceRepository, IRelationshipRepository
    {
        public Relationship GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from r in linqMetaData.Relationship where r.RelationshipId == id select r).SingleOrDefault();

                return entity == null ? null : Mapper.Map<RelationshipEntity, Relationship>(entity);
            }
        }

        public Relationship GetByCode(string code)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from r in linqMetaData.Relationship where r.Code == code select r).SingleOrDefault();

                return entity == null ? null : Mapper.Map<RelationshipEntity, Relationship>(entity);
            }
        }

        public Relationship Save(Relationship domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = Mapper.Map<Relationship, RelationshipEntity>(domain);

                entity.RelationshipId = (from r in linqMetaData.Relationship select r.RelationshipId).Max() + 1;

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<RelationshipEntity, Relationship>(entity);
            }
        }

        public IEnumerable<Relationship> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from r in linqMetaData.Relationship select r);

                return Mapper.Map<IEnumerable<RelationshipEntity>, IEnumerable<Relationship>>(entities);
            }
        }

        public IEnumerable<Relationship> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from r in linqMetaData.Relationship where ids.Contains(r.RelationshipId) select r);

                return Mapper.Map<IEnumerable<RelationshipEntity>, IEnumerable<Relationship>>(entities);
            }
        }
    }
}
