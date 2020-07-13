using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Medical.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class ClinicalTestQualificationCriteriaRepository : PersistenceRepository, IClinicalTestQualificationCriteriaRepository
    {
        private readonly IMapper<ClinicalTestQualificationCriteria, ClinicalTestQualificationCriteriaEntity> _mapper;
        public ClinicalTestQualificationCriteriaRepository()
            : this(new ClinicalTestQualificationCriteriaMapper())
        {

        }
        public ClinicalTestQualificationCriteriaRepository(IMapper<ClinicalTestQualificationCriteria, ClinicalTestQualificationCriteriaEntity> mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<ClinicalTestQualificationCriteria> GetbyTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ctqc in linqMetaData.ClinicalTestQualificationCriteria
                             where ctqc.TemplateId == templateId
                             select ctqc);

                return _mapper.MapMultiple(query);
            }
        }

        public void Save(IEnumerable<ClinicalTestQualificationCriteria> criterias)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<ClinicalTestQualificationCriteriaEntity>();
                foreach (var criteria in criterias)
                {
                    entities.Add(_mapper.Map(criteria));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();

            }
        }

        public IEnumerable<ClinicalTestQualificationCriteria> GetbyTemplateIds(IEnumerable<long> templateIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ctqc in linqMetaData.ClinicalTestQualificationCriteria
                             where templateIds.Contains(ctqc.TemplateId)
                             select ctqc);

                return _mapper.MapMultiple(query);
            }
        }

        public void DeleteTemplateCriteria(long temlateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(ClinicalTestQualificationCriteriaFields.TemplateId == temlateId);
                adapter.DeleteEntitiesDirectly(typeof(ClinicalTestQualificationCriteriaEntity), relationPredicateBucket);
            }
        }

    }
}