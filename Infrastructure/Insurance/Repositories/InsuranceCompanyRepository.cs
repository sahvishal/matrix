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
    public class InsuranceCompanyRepository : PersistenceRepository, IInsuranceCompanyRepository
    {
        public IEnumerable<InsuranceCompany> GetAll()
        {
            return Get(null);
        }

        public InsuranceCompany GetById(long id)
        {
            try
            {
                return Get(new RelationPredicateBucket(InsuranceCompanyFields.InsuranceCompanyId == id)).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<InsuranceCompany>(id);
            }
        }

        public IEnumerable<InsuranceCompany> GetByIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(InsuranceCompanyFields.InsuranceCompanyId == ids.ToArray()));
        }

        private IEnumerable<InsuranceCompany> Get(IRelationPredicateBucket expression)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<InsuranceCompanyEntity>();

                if (expression == null)
                    expression = new RelationPredicateBucket(InsuranceCompanyFields.IsActive == true);
                else
                    expression.PredicateExpression.AddWithAnd(InsuranceCompanyFields.IsActive == true);

                adapter.FetchEntityCollection(entities, expression);
                return Mapper.Map<IEnumerable<InsuranceCompanyEntity>, IEnumerable<InsuranceCompany>>(entities);
            }
        }
    }
}
