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
    public class ExitInterviewQuestionRepository : PersistenceRepository, IExitInterviewQuestionRepository
    {
        public IEnumerable<ExitInterviewQuestion> GetAllQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from fcq in linqMetaData.ExitInterviewQuestion
                                select fcq);

                return Mapper.Map<IEnumerable<ExitInterviewQuestionEntity>, IEnumerable<ExitInterviewQuestion>>(entities);
            }
        }
    }
}
