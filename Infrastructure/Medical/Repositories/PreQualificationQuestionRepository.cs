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
    public class PreQualificationQuestionRepository : PersistenceRepository, IPreQualificationQuestionRepository
    {
        public IEnumerable<PreQualificationQuestion> GetByTestId(long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.PreQualificationQuestion
                                where q.TestId == testId && q.IsActive
                                select q).ToArray();

                return Mapper.Map<IEnumerable<PreQualificationQuestionEntity>, IEnumerable<PreQualificationQuestion>>(entities);
            }
        }

        public IEnumerable<PreQualificationQuestion> GetByQuestionIds(long[] questionIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.PreQualificationQuestion
                                where questionIds.Contains(q.Id) && q.IsActive
                                select q).ToArray();

                return Mapper.Map<IEnumerable<PreQualificationQuestionEntity>, IEnumerable<PreQualificationQuestion>>(entities);
            }
        }

        public IEnumerable<PreQualificationQuestion> GetAllQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.PreQualificationQuestion
                                where q.IsActive
                                select q).ToArray();

                return Mapper.Map<IEnumerable<PreQualificationQuestionEntity>, IEnumerable<PreQualificationQuestion>>(entities);
            }
        }

        public IEnumerable<PreQualificationQuestion> GetQuestionsByTemplateIds(long[] ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.PreQualificationQuestion
                                join t in linqMetaData.PreQualificationTemplateQuestion on q.Id equals t.QuestionId
                                where ids.Contains(t.TemplateId)
                                select q).ToArray();
                return Mapper.Map<IEnumerable<PreQualificationQuestionEntity>, IEnumerable<PreQualificationQuestion>>(entities);
            }
        }

    }
}
