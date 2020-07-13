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
    public class PreQualificationQuestionRuleRepository : PersistenceRepository, IPreQualificationQuestionRuleRepository
    {
       public IEnumerable<PreQualificationQuestionRule> Get()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.PreQualificationQuestionRule.ToArray();
                return Mapper.Map<IEnumerable<PreQualificationQuestionRuleEntity>, IEnumerable<PreQualificationQuestionRule>>(entities);
            }
        }
    }
}
