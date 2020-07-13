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
    public class PreQualificationTemplateDependentTestRepository : PersistenceRepository, IPreQualificationTemplateDependentTestRepository
    {
        public IEnumerable<PreQualificationTemplateDependentTest> GetByTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pqtdt in linqMetaData.PreQualificationTemplateDependentTest
                                where pqtdt.TemplateId == templateId && pqtdt.IsActive
                                select pqtdt).ToArray();

                return Mapper.Map<IEnumerable<PreQualificationTemplateDependentTestEntity>, IEnumerable<PreQualificationTemplateDependentTest>>(entities);
            }
        }

        public void SaveCollection(IEnumerable<PreQualificationTemplateDependentTest> dependentTests)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var templateId = dependentTests.First().TemplateId;
                var testIds = dependentTests.Select(x => x.TestId);
                Delete(templateId, testIds);
                DeactivateByTemplateId(templateId);

                var entities = new EntityCollection<PreQualificationTemplateDependentTestEntity>();
                foreach (var domain in dependentTests)
                {
                    entities.Add(new PreQualificationTemplateDependentTestEntity { TemplateId = domain.TemplateId, TestId = domain.TestId, IsActive = true });
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public void DeactivateByTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new PreQualificationTemplateDependentTestEntity()
                {
                    IsActive = false
                };

                var bucket = new RelationPredicateBucket(PreQualificationTemplateDependentTestFields.TemplateId == templateId);
                bucket.PredicateExpression.AddWithAnd(PreQualificationTemplateDependentTestFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public void Delete(long templateId, IEnumerable<long> testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(PreQualificationTemplateDependentTestFields.TemplateId == templateId);
                bucket.PredicateExpression.AddWithAnd(PreQualificationTemplateDependentTestFields.TestId == testIds.ToArray());

                adapter.DeleteEntitiesDirectly(typeof(PreQualificationTemplateDependentTestEntity), bucket);
            }
        }

        public IEnumerable<PreQualificationTemplateDependentTest> GetByTemplateIds(long[] templateIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pqtdt in linqMetaData.PreQualificationTemplateDependentTest
                                where templateIds.Contains(pqtdt.TemplateId) && pqtdt.IsActive
                                select pqtdt).ToArray();

                return Mapper.Map<IEnumerable<PreQualificationTemplateDependentTestEntity>, IEnumerable<PreQualificationTemplateDependentTest>>(entities);
            }
        }
    }
}
