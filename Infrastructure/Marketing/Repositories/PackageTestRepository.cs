using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Marketing.Repositories
{
    [DefaultImplementation(Interface = typeof(IPackageTestRepository))]
    public class PackageTestRepository : PersistenceRepository, IPackageTestRepository
    {
        public IEnumerable<PackageTest> GetbyPackageId(long packageId)
        {
            var queryable = Get(pt => pt.PackageId == packageId);
            var entities = queryable.ToArray();
            return Mapper.Map<IEnumerable<PackageTestEntity>, IEnumerable<PackageTest>>(entities);
        }
        
        public PackageTest GetbyTestAndPackageId(long packageId, long testId)
        {
            var queryable = Get(pt => pt.PackageId == packageId && pt.TestId == testId);
            var entity = queryable.SingleOrDefault();
            return Mapper.Map<PackageTestEntity, PackageTest>(entity);
        }

        private IEnumerable<PackageTestEntity> Get(Func<PackageTestEntity, bool> expression)
        {
            using (var adapter =  PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.PackageTest.Where(expression).ToArray();
            }
        }
        
        public PackageTest Save(PackageTest domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PackageTest, PackageTestEntity>(domainObject);
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<PackageTestEntity, PackageTest>(entity);
            }
        }

        public IEnumerable<PackageTest> Save(IEnumerable<PackageTest> domainObjects)
        {
            if (domainObjects == null || domainObjects.Count() < 1) return null;
            
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("PackageTestEntity", new RelationPredicateBucket(PackageTestFields.PackageId == domainObjects.First().PackageId));

                var entities = Mapper.Map<IEnumerable<PackageTest>, IEnumerable<PackageTestEntity>>(domainObjects);
                var entitycollection = new EntityCollection<PackageTestEntity>();
                entitycollection.AddRange(entities);
                adapter.SaveEntityCollection(entitycollection, true, false);
                return Mapper.Map<IEnumerable<PackageTestEntity>, IEnumerable<PackageTest>>(entities);
            }
        }

        public void Delete(PackageTest domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<PackageTest> domainObjects)
        {
            throw new NotImplementedException();
        }
    }
}
