using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class SurveyAnswerRepository : PersistenceRepository, ISurveyAnswerRepository
    {
        public IEnumerable<SurveyAnswer> GetSurveyAnswerByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.SurveyAnswer.Where(x => x.EventCustomerId == eventCustomerId && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<SurveyAnswerEntity>, IEnumerable<SurveyAnswer>>(entities);
            }
        }

        public int GetLatestVersion(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var version = (from sa in linqMetaData.SurveyAnswer
                               where sa.EventCustomerId == eventCustomerId
                               orderby sa.Version descending
                               select sa.Version).FirstOrDefault();

                return version;
            }
        }

        public void SaveAnswer(IEnumerable<SurveyAnswer> answer)
        {
            if (answer.IsNullOrEmpty()) return;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var survey = answer.First();
                DeleteSurveyAnswers(survey.Id, survey.DataRecorderMetaData.DataRecorderCreator.Id);

                var entities = Mapper.Map<IEnumerable<SurveyAnswer>, IEnumerable<SurveyAnswerEntity>>(answer);
                var collection = new EntityCollection<SurveyAnswerEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        private bool DeleteSurveyAnswers(long eventCustomerId, long modifiedBy)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entiry = new SurveyAnswerEntity { IsActive = false, ModifiedOn = DateTime.Now, ModifiedBy = modifiedBy };
                var bucketPredicate = new RelationPredicateBucket(SurveyAnswerFields.EventCustomerId == eventCustomerId);
                bucketPredicate.PredicateExpression.AddWithAnd(SurveyAnswerFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entiry, new RelationPredicateBucket(SurveyAnswerFields.EventCustomerId == eventCustomerId));
                return true;
            }
        }
    }
}
