using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Marketing.Repositories
{
    [DefaultImplementation]
    public class DirectMailTypeRepository : PersistenceRepository, IDirectMailTypeRepository
    {
        private IEnumerable<DirectMailType> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<DirectMailTypeEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var directMailTypes = Mapper.Map<IEnumerable<DirectMailTypeEntity>, IEnumerable<DirectMailType>>(entities);

                return directMailTypes.OrderBy(x => x.DateModified).ToArray();
            }
        }

        public DirectMailType GetById(long id)
        {
            var relationPredicateBucket = new RelationPredicateBucket(DirectMailTypeFields.Id == id);

            return Get(relationPredicateBucket).SingleOrDefault();
        }

        public DirectMailType GetByDirectMailName(string directMailName)
        {
            var relationPredicateBucket = new RelationPredicateBucket(DirectMailTypeFields.Name == directMailName.Trim());

            return Get(relationPredicateBucket).SingleOrDefault();
        }

        public IEnumerable<DirectMailType> GetAll()
        {
            var relationPredicateBucket = new RelationPredicateBucket();

            return Get(relationPredicateBucket);
        }
    }
}
