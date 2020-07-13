using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class ExitInterviewAnswerRepository : PersistenceRepository, IExitInterviewAnswerRepository
    {
        public IEnumerable<ExitInterviewAnswer> GetAllAnswerByEventCustomerId(long eventCustomerId, int version = 1)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.ExitInterviewAnswer.Where(x => x.EventCustomerId == eventCustomerId && x.Version == version).ToArray();

                return Mapper.Map<IEnumerable<ExitInterviewAnswerEntity>, IEnumerable<ExitInterviewAnswer>>(entities);
            }
        }

        public int GetLatestVersion(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var version = (from cla in linqMetaData.ExitInterviewAnswer
                               where cla.EventCustomerId == eventCustomerId
                               select cla.Version).Max();

                return version;
            }
        }

        public void SaveAnswer(IEnumerable<ExitInterviewAnswer> answers)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!answers.IsNullOrEmpty())
                {
                    var eventCustomerId = answers.First().EventCustomerId;
                    var orgRoleUserId = answers.First().CreatedBy;
                    DeactivateAll(eventCustomerId, orgRoleUserId);
                }

                var entities = Mapper.Map<IEnumerable<ExitInterviewAnswer>, IEnumerable<ExitInterviewAnswerEntity>>(answers);
                var collection = new EntityCollection<ExitInterviewAnswerEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        private void DeactivateAll(long eventCustomerId, long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new ExitInterviewAnswerEntity
                {
                    IsActive = false,
                    ModifiedBy = orgRoleUserId,
                    DateModified = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(ExitInterviewAnswerFields.EventCustomerId == eventCustomerId);
                bucket.PredicateExpression.AddWithAnd(ExitInterviewAnswerFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public IEnumerable<ExitInterviewAnswer> GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.ExitInterviewAnswer.Where(x => x.EventCustomerId == eventCustomerId && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<ExitInterviewAnswerEntity>, IEnumerable<ExitInterviewAnswer>>(entities);
            }
        }
    }
}
