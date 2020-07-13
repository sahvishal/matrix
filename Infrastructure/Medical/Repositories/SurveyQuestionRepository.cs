using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class SurveyQuestionRepository : PersistenceRepository, ISurveyQuestionRepository
    {
        public IEnumerable<SurveyQuestion> GetAllQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.SurveyQuestion.ToArray();

                return Mapper.Map<IEnumerable<SurveyQuestionEntity>, IEnumerable<SurveyQuestion>>(entities);
            }
        }

        public IEnumerable<SurveyQuestion> GetAllQuestionsForTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from sq in linqMetaData.SurveyQuestion
                                join stq in linqMetaData.SurveyTemplateQuestion on sq.Id equals stq.QuestionId
                                where stq.TemplateId == templateId
                                select sq).ToArray();

                return Mapper.Map<IEnumerable<SurveyQuestionEntity>, IEnumerable<SurveyQuestion>>(entities);
            }
        }
    }
}
