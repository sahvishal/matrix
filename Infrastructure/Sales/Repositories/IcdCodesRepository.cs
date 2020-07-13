using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class IcdCodesRepository : PersistenceRepository, IIcdCodesRepository
    {

        public IcdCode GetIcdCodebyId(long id)
        {
            try
            {
                return GetIcdCodes(new RelationPredicateBucket(IcdCodesFields.Id == id)).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<IcdCodesFields>(id);
            }
        }

        private IEnumerable<IcdCode> GetIcdCodes(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<IcdCodesEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var icdCodes = Mapper.Map<IEnumerable<IcdCodesEntity>, IEnumerable<IcdCode>>(entities);

                return icdCodes.ToArray().OrderBy(x => x.CodeName);
            }
        }

        public IcdCode GetIcdByCodeName(string codeName)
        {
            var expresion = new RelationPredicateBucket(IcdCodesFields.IcdCode == codeName);

            return GetIcdCodes(expresion).SingleOrDefault();
        }

        public IEnumerable<IcdCode> GetIcdByCodeNames(IEnumerable<string> codeName)
        {
            var expresion = new RelationPredicateBucket(IcdCodesFields.IcdCode == codeName.ToArray());

            return GetIcdCodes(expresion);
        }

        public IcdCode Save(IcdCode icdCode)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<IcdCode, IcdCodesEntity>(icdCode);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();

                }

                return Mapper.Map<IcdCodesEntity, IcdCode>(entity);
            }
        }

        public void Save(IEnumerable<IcdCode> icdCode)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<IcdCode>, IEnumerable<IcdCodesEntity>>(icdCode);

                var collection = new EntityCollection<IcdCodesEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        public IEnumerable<IcdCode> GetIcdByIds(IEnumerable<long> ids)
        {
            var expresion = new RelationPredicateBucket(IcdCodesFields.Id == ids.ToArray());

            return GetIcdCodes(expresion);
        }
    }
}