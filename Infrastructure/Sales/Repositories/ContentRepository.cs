using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class ContentRepository : PersistenceRepository, IContentRepository
    {
        public Content Save(Content resultContent)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entityToSave = Mapper.Map<Content, ContentEntity>(resultContent);

                if (!adapter.SaveEntity(entityToSave, true, false))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<ContentEntity, Content>(entityToSave);
            }
        }

        public Content Get(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from rc in linqMetaData.Content
                              where rc.ContentId == id
                              select rc).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<ContentEntity, Content>(entity);
            }
        }

        public IEnumerable<Content> Get(ContentListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            if (filter == null) filter = new ContentListModelFilter();

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = from c in linqMetaData.Content
                            where (filter.Inactive == filter.Active) || (c.IsActive == filter.Active)
                            select c;

                if (!string.IsNullOrEmpty(filter.Title))
                {
                    filter.Title = filter.Title.Trim();

                    query = from c in query where c.Title.Contains(filter.Title) select c;
                }

                totalRecords = query.Count();

                var entities = Enumerable.ToArray<ContentEntity>(query.OrderByDescending(q => q.IsActive).OrderByDescending(q => q.DateModified ?? q.DateCreated).TakePage(pageNumber, pageSize));

                return Mapper.Map<IEnumerable<ContentEntity>, IEnumerable<Content>>(entities);
            }

        }

        public void Activate(long id, long orgRoleUserId)
        {
            ActivateDeactivateContent(id, true, orgRoleUserId);
        }

        public void Deactivate(long id, long orgRoleUserId)
        {
            ActivateDeactivateContent(id, false, orgRoleUserId);
        }

        private void ActivateDeactivateContent(long id, bool isActive, long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var obj = new ContentEntity(id) { IsActive = isActive, ModifiedBy = orgRoleUserId, DateModified = DateTime.Now };

                adapter.UpdateEntitiesDirectly(obj,
                                               new RelationPredicateBucket(ContentFields.ContentId == id));
            }
        }
    }

}
