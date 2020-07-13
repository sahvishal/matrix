using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class ChaseCampaignTypeRepository : PersistenceRepository, IChaseCampaignTypeRepository
    {
        public ChaseCampaignType GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cct in linqMetaData.ChaseCampaignType where cct.ChaseCampaignTypeId == id select cct).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseCampaignTypeEntity, ChaseCampaignType>(entity);
            }
        }

        public IEnumerable<ChaseCampaignType> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cct in linqMetaData.ChaseCampaignType where ids.Contains(cct.ChaseCampaignTypeId) select cct).ToArray();

                return Mapper.Map<IEnumerable<ChaseCampaignTypeEntity>, IEnumerable<ChaseCampaignType>>(entities);
            }
        }

        public ChaseCampaignType Save(ChaseCampaignType domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ChaseCampaignType, ChaseCampaignTypeEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<ChaseCampaignTypeEntity, ChaseCampaignType>(entity);
            }
        }

        public ChaseCampaignType GetByName(string name)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cct in linqMetaData.ChaseCampaignType where cct.Name == name select cct).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseCampaignTypeEntity, ChaseCampaignType>(entity);
            }
        }
    }
}
