using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using AutoMapper;


namespace Falcon.App.Infrastructure.Medical.Repositories
{
   [DefaultImplementation]
    public class HealthAssessmentQuestionDependencyRuleRepository : PersistenceRepository, IHealthAssessmentQuestionDependencyRuleRepository
    {
        public IEnumerable<HealthAssessmentQuestionDependencyRule> Get()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.HealthQuestionDependencyRule.ToArray();
                return Mapper.Map<IEnumerable<HealthQuestionDependencyRuleEntity>, IEnumerable<HealthAssessmentQuestionDependencyRule>>(entities);
            }

        }
    }
}
