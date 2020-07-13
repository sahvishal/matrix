using System;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Insurance.Repositories
{
    [DefaultImplementation]
    public class ClaimRepository : PersistenceRepository, IClaimRepository
    {
        public Claim Save(Claim domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var isNew = true;

                var existingDomain = GetById(domain.Id);
                if (existingDomain != null)
                {
                    domain.DateCreated = existingDomain.DateCreated;
                    domain.DateModified = DateTime.Now;
                    isNew = false;
                }

                var entity = Mapper.Map<Claim, ClaimEntity>(domain);

                entity.IsNew = isNew;
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<ClaimEntity, Claim>(entity);
            }
        }

        public Claim GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from e in linqMetaData.Claim where e.ClaimId == id select e).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<ClaimEntity, Claim>(entity);
            }
        }
    }
}
