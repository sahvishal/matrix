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
    public class FluConsentQuestionRepository : PersistenceRepository, IFluConsentQuestionRepository
    {
        public IEnumerable<FluConsentQuestion> GetAllQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from fcq in linqMetaData.FluConsentQuestion
                                select fcq);

                return Mapper.Map<IEnumerable<FluConsentQuestionEntity>, IEnumerable<FluConsentQuestion>>(entities);
            }
        }

        public IEnumerable<long> GetQuestionIdsByTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var questionIds = (from fctq in linqMetaData.FluConsentTemplateQuestion
                                   select fctq.QuestionId).ToArray();

                return questionIds;
            }
        }

        public void SaveTemplateQuestions(IEnumerable<FluConsentTemplateQuestion> templateQuestions)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<FluConsentTemplateQuestionEntity>();
                foreach (var templateQuestion in templateQuestions)
                {
                    entities.Add(new FluConsentTemplateQuestionEntity
                    {
                        TemplateId = templateQuestion.TemplateId,
                        QuestionId = templateQuestion.QuestionId
                    });
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public void DeleteTemplateQuestions(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(FluConsentTemplateQuestionFields.TemplateId == templateId);
                adapter.DeleteEntitiesDirectly(typeof(FluConsentTemplateQuestionEntity), relationPredicateBucket);
            }
        }

    }
}
