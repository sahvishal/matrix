using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class LanguageRepository : PersistenceRepository, ILanguageRepository
    {
        public IEnumerable<Language> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from l in linqMetaData.Language
                                where l.IsActive
                                select l).ToArray();
                if (entities.IsNullOrEmpty())
                    return null;

                return Mapper.Map<IEnumerable<LanguageEntity>, IEnumerable<Language>>(entities);
            }
        }

        public Language GetByName(string name)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from l in linqMetaData.Language
                              where l.IsActive
                              && l.Name.Trim().ToLower() == name
                              select l).SingleOrDefault();
                if (entity == null)
                    return null;

                return Mapper.Map<LanguageEntity, Language>(entity);
            }
        }

        public Language Save(Language domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Language, LanguageEntity>(domain);

                adapter.SaveEntity(entity, true);

                return Mapper.Map<LanguageEntity, Language>(entity);
            }
        }

        public Language GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from l in linqMetaData.Language
                              where l.IsActive && l.Id == id
                              select l).FirstOrDefault();
                if (entity == null)
                    return null;

                return Mapper.Map<LanguageEntity, Language>(entity);
            }
        }

    }
}
