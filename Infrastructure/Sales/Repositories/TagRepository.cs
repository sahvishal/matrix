using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Sales.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    public class TagRepository : PersistenceRepository, ITagRepository
    {
        private readonly IMapper<Tag, TagEntity> _mapper;
        public TagRepository()
            : this(new SqlPersistenceLayer(), new TagMapper())
        { }

        public TagRepository(IPersistenceLayer persistenceLayer, IMapper<Tag, TagEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }

        public IEnumerable<Tag> GetTags(ProspectCustomerSource source, bool isHealthPlan = false, bool includeWarmTransferTag = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from t in linqMetaData.Tag
                                where t.IsActive && t.IsSystemDefined == false && t.Source == (long)source
                                && (t.IsHealthPlanTag == isHealthPlan || (t.IsHealthPlanTag && t.ForWarmTransfer == includeWarmTransferTag))
                               && t.ForPreAssessment != true
                                select t);

                return _mapper.MapMultiple(entities).ToList();
            }
        }

        public IEnumerable<Tag> GetForPreAssessmentTags(ProspectCustomerSource source, bool isHealthPlan = false, bool includeWarmTransferTag = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from t in linqMetaData.Tag
                                where t.IsActive && t.IsSystemDefined == false && t.Source == (long)source
                                && (t.IsHealthPlanTag == isHealthPlan || (t.IsHealthPlanTag && t.ForWarmTransfer == includeWarmTransferTag))
                                 && t.ForPreAssessment == true
                                select t);

                return _mapper.MapMultiple(entities).ToList();
            }
        }
    }
}
