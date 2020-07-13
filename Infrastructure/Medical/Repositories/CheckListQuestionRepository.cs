using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class CheckListQuestionRepository : PersistenceRepository, ICheckListQuestionRepository
    {
        public IEnumerable<CheckListQuestion> GetAllQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CheckListQuestion.ToArray();

                return Mapper.Map<IEnumerable<CheckListQuestionEntity>, IEnumerable<CheckListQuestion>>(entities);
            }
        }

        /*public IEnumerable<CheckListQuestion> GetQuestionByGroupId(long groupId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from clq in linqMetaData.CheckListQuestion
                                where clq.IsActive && clq.GroupId == groupId
                                select clq).ToArray();

                return Mapper.Map<IEnumerable<CheckListQuestionEntity>, IEnumerable<CheckListQuestion>>(entities);
            }
        }

        public IEnumerable<CheckListQuestion> GetQuestionByGroupIds(IEnumerable<long> groupIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from clq in linqMetaData.CheckListQuestion
                                where clq.IsActive && groupIds.Contains(clq.GroupId)
                                select clq).ToArray();

                return Mapper.Map<IEnumerable<CheckListQuestionEntity>, IEnumerable<CheckListQuestion>>(entities);
            }
        }*/

        public IEnumerable<CheckListQuestion> GetAllQuestionsForTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from clq in linqMetaData.CheckListQuestion
                                join clgq in linqMetaData.ChecklistGroupQuestion on clq.Id equals clgq.QuestionId
                                join cltq in linqMetaData.CheckListTemplateQuestion on clgq.Id equals cltq.GroupQuestionId
                                where cltq.TemplateId == templateId
                                select clq).ToArray();

                return Mapper.Map<IEnumerable<CheckListQuestionEntity>, IEnumerable<CheckListQuestion>>(entities);
            }
        }
    }
}
