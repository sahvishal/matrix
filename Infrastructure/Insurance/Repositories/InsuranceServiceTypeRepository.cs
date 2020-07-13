using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Insurance.Repositories
{
    [DefaultImplementation]
    public class InsuranceServiceTypeRepository : PersistenceRepository, IInsuranceServiceTypeRepository
    {
        public IEnumerable<InsuranceServiceType> GetAll()
        {
            return Get(null);
        }

        public InsuranceServiceType GetById(long id)
        {
            try
            {
                return Get(new RelationPredicateBucket(InsuranceServiceTypeFields.InsuranceServiceTypeId == id)).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<InsuranceServiceType>(id);
            }
        }

        public IEnumerable<InsuranceServiceType> GetByIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(InsuranceServiceTypeFields.InsuranceServiceTypeId == ids.ToArray()));
        }

        private IEnumerable<InsuranceServiceType> Get(IRelationPredicateBucket expression)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<InsuranceServiceTypeEntity>();

                if (expression == null)
                    expression = new RelationPredicateBucket(InsuranceServiceTypeFields.IsActive == true);
                else
                    expression.PredicateExpression.AddWithAnd(InsuranceServiceTypeFields.IsActive == true);

                adapter.FetchEntityCollection(entities, expression);
                return Mapper.Map<IEnumerable<InsuranceServiceTypeEntity>, IEnumerable<InsuranceServiceType>>(entities);
            }
        }
    }
}
