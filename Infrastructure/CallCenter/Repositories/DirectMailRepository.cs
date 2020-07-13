using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class DirectMailRepository : PersistenceRepository, IDirectMailRepository
    {
        public DirectMail Save(DirectMail domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<DirectMail, DirectMailEntity>(domain);

                adapter.SaveEntity(entity, true);

                return Mapper.Map<DirectMailEntity, DirectMail>(entity);
            }
        }

        private IEnumerable<DirectMail> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<DirectMailEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                return Mapper.Map<IEnumerable<DirectMailEntity>, IEnumerable<DirectMail>>(entities).ToArray();


            }
        }
        public IEnumerable<DirectMail> GetByCustomerId(long customerId)
        {
            var relationPredicateBucket = new RelationPredicateBucket(DirectMailFields.CustomerId == customerId);

            return Get(relationPredicateBucket);
        }

        public IEnumerable<DirectMail> GetByCustomerIds(IEnumerable<long> customerIds, DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var dmQuery = (from dm in linqMetaData.DirectMail where customerIds.Contains(dm.CustomerId) select dm);

                if (fromDate.HasValue)
                    dmQuery = (from dm in dmQuery where dm.MailDate >= fromDate select dm);
                if (toDate.HasValue)
                    dmQuery = (from dm in dmQuery where dm.MailDate <= toDate.Value.AddDays(1) select dm);

                return Mapper.Map<IEnumerable<DirectMailEntity>, IEnumerable<DirectMail>>(dmQuery).ToArray();
            }
        }
    }
}