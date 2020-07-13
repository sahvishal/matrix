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
    public class ChaperoneQuestionRepository : PersistenceRepository, IChaperoneQuestionRepository
    {
        public IEnumerable<ChaperoneQuestion> GetAllQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from fcq in linqMetaData.ChaperoneQuestion
                                select fcq);

                return Mapper.Map<IEnumerable<ChaperoneQuestionEntity>, IEnumerable<ChaperoneQuestion>>(entities);
            }
        }
    }
}
