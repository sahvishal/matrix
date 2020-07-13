using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class FluConsentTemplateRepository : PersistenceRepository, IFluConsentTemplateRepository
    {
        public IEnumerable<FluConsentTemplate> GetTemplates(FluConsentTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from fct in linqMetaData.FluConsentTemplate
                             where fct.IsActive
                             select fct);

                if (!string.IsNullOrWhiteSpace(filter.Name))
                {
                    query = (from q in query
                             where q.Name.Contains(filter.Name)
                             select q);
                }

                if (filter.HealthPlanId > 0)
                {
                    var templateIds = (from a in linqMetaData.Account where a.AccountId == filter.HealthPlanId select a.FluConsentTemplateId);
                    query = (from q in query
                             where templateIds.Contains(q.Id)
                             select q);
                }

                totalRecords = query.Count();

                var entities = query.OrderBy(x => x.Id).TakePage(pageNumber, pageSize).ToArray();

                return Mapper.Map<IEnumerable<FluConsentTemplateEntity>, IEnumerable<FluConsentTemplate>>(entities);
            }
        }

        public FluConsentTemplate GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from fct in linqMetaData.FluConsentTemplate
                              where fct.Id == id
                              select fct).SingleOrDefault();

                return Mapper.Map<FluConsentTemplateEntity, FluConsentTemplate>(entity);
            }
        }

        public IEnumerable<FluConsentTemplate> GetByIds(long[] ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from fct in linqMetaData.FluConsentTemplate
                                where ids.Contains(fct.Id)
                                select fct);

                return Mapper.Map<IEnumerable<FluConsentTemplateEntity>, IEnumerable<FluConsentTemplate>>(entities);
            }
        }

        public FluConsentTemplate Save(FluConsentTemplate domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<FluConsentTemplate, FluConsentTemplateEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<FluConsentTemplateEntity, FluConsentTemplate>(entity);
            }
        }
    }
}
