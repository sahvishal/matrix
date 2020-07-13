using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class CheckListAnswerRepository : PersistenceRepository, ICheckListAnswerRepository
    {
        public IEnumerable<CheckListAnswer> GetAllAnswerByEventCustomerId(long eventCustomerId, int version = 1)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CheckListAnswer.Where(x => x.EventCustomerId == eventCustomerId && x.Version == version).ToArray();

                return Mapper.Map<IEnumerable<CheckListAnswerEntity>, IEnumerable<CheckListAnswer>>(entities);
            }
        }

        public int GetLatestVersion(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var version = (from cla in linqMetaData.CheckListAnswer
                               where cla.EventCustomerId == eventCustomerId
                               orderby cla.Version descending
                               select cla.Version).FirstOrDefault();

                return version;
            }
        }

        public void SaveAnswer(IEnumerable<CheckListAnswer> answer)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<CheckListAnswer>, IEnumerable<CheckListAnswerEntity>>(answer);
                var collection = new EntityCollection<CheckListAnswerEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        public bool DeleteEventCustomerCheckListAnswers(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(CheckListAnswerEntity), new RelationPredicateBucket(CheckListAnswerFields.EventCustomerId == eventCustomerId));
                return true;
            }
        }

        public IEnumerable<CheckListAnswer> GetExitInterviewAnswers(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CheckListAnswer.Where(x => x.EventCustomerId == eventCustomerId && x.Type == (long)CheckListType.ExitInterviewQuery && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<CheckListAnswerEntity>, IEnumerable<CheckListAnswer>>(entities);
            }
        }
    }
}