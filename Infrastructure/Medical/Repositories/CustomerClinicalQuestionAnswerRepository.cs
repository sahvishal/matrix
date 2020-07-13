using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class CustomerClinicalQuestionAnswerRepository : PersistenceRepository, ICustomerClinicalQuestionAnswerRepository
    {
        public IEnumerable<CustomerClinicalQuestionAnswer> GetCustomerClinicalQuestionAnswers(string guid, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ccqa in linqMetaData.CustomerClinicalQuestionAnswer
                                where ccqa.Guid == guid && ccqa.CustomerId == customerId
                                select ccqa).ToArray();

                return Mapper.Map<IEnumerable<CustomerClinicalQuestionAnswerEntity>, IEnumerable<CustomerClinicalQuestionAnswer>>(entities);
            }
        } 

        public void SaveCustomerClinicalQuestionAnswers(IEnumerable<CustomerClinicalQuestionAnswer> answers)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<CustomerClinicalQuestionAnswer>, IEnumerable<CustomerClinicalQuestionAnswerEntity>>(answers);

                var entityCollection = new EntityCollection<CustomerClinicalQuestionAnswerEntity>();
                entityCollection.AddRange(entities);

                if (adapter.SaveEntityCollection(entityCollection, true, false) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public void DeleteCustomerClinicalQuestionAnswers(string guid, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(CustomerClinicalQuestionAnswerFields.Guid == guid);
                relationPredicateBucket.PredicateExpression.AddWithAnd(CustomerClinicalQuestionAnswerFields.CustomerId == customerId);

                adapter.DeleteEntitiesDirectly(typeof(CustomerClinicalQuestionAnswerEntity), relationPredicateBucket);
            }
        }

        public IEnumerable<CustomerClinicalQuestionAnswer> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cwt in linqMetaData.CustomerClinicalQuestionAnswer
                                where cwt.CustomerId == customerId
                                select cwt).ToArray();

                return Mapper.Map<IEnumerable<CustomerClinicalQuestionAnswerEntity>, IEnumerable<CustomerClinicalQuestionAnswer>>(entities);
            }
        }
    }
}
