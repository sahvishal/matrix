using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Communication.ViewModels;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Communication.Enum;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation]
    public class NotificationTypeRepository : UniqueItemRepository<NotificationType, NotificationTypeEntity>, INotificationTypeRepository
    {
        public NotificationTypeRepository(IMapper<NotificationType, NotificationTypeEntity> mapper)
            : base(mapper)
        {
        }

        public NotificationTypeRepository(IPersistenceLayer persistenceLayer, IMapper<NotificationType, NotificationTypeEntity> mapper, RepositoryStrategySet<NotificationType> strategySet)
            : base(persistenceLayer, mapper, strategySet)
        {
        }

        public IEnumerable<NotificationType> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return Mapper.MapMultiple(linqMetaData.NotificationType.OrderBy(nt => nt.NotificationTypeName));
            }
        }


        public IEnumerable<NotificationType> GetbyFilter(NotificationTypeListFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null) filter = new NotificationTypeListFilter();

                var query = from q in linqMetaData.NotificationType
                            where q.IsActive && q.NotificationMedium.NotificationMedium != NotificationMediumType.CoverLetterNotification
                            select q;

                if (filter.IsServiceEnabled.HasValue)
                {
                    query = from q in query where q.IsServiceEnabled == filter.IsServiceEnabled.Value select q;
                }

                if (filter.IsQueuingEnabled.HasValue)
                {
                    query = from q in query where q.IsQueuingEnabled == filter.IsQueuingEnabled.Value select q;
                }

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    query = from q in query where q.NotificationTypeName.Contains(filter.Name) select q;
                }
                if (filter.NotificationMedium != 0)
                {
                    query = from q in query where q.NotificationMedium.NotificationMediumId == filter.NotificationMedium select q;
                }
                totalRecords = query.Count();

                return Mapper.MapMultiple(query.TakePage(pageNumber, pageSize).OrderBy(q => q.NotificationTypeName).ToArray());
            }
        }

        public NotificationType GetByAlias(string notificationTypeAlias)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var notificationTypeEntity = linqMetaData.NotificationType.Single(nt => nt.NotificationTypeNameAlias == notificationTypeAlias);
                return Mapper.Map(notificationTypeEntity);
            }
        }

        public void UpdateNotificationData(long notificationId, bool isServicingEnabled, bool isQueuingEnabled, int numberOfAttempts, long updatedByOrgRoleUserId)
        {
            var notificationType = GetById(notificationId);

            // Set the status here
            notificationType.IsServiceEnabled = isServicingEnabled;
            notificationType.IsQueuingEnabled = isQueuingEnabled;
            notificationType.NumberOfAttempts = numberOfAttempts;
            notificationType.DataRecorderMetaData.DateModified = DateTime.Now;
            notificationType.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(updatedByOrgRoleUserId);

            Save(notificationType);
        }


        protected override EntityField2 EntityIdField
        {
            get { return NotificationTypeFields.NotificationTypeId; }
        }

        public NotificationType GetByNotificationId(long id)
        {
            var entity = new NotificationTypeEntity();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.FetchEntityUsingUniqueConstraint(entity, new PredicateExpression(EntityIdField == id)))
                {
                    throw new ObjectNotFoundInPersistenceException<Domain>(id);
                }
            }

            return Mapper.Map(entity);
        }

        public IEnumerable<NotificationType> GetNotificationTypeForTemplate()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return Mapper.MapMultiple(linqMetaData.NotificationType.Where(x => x.AllowTemplateCreation).OrderBy(nt => nt.NotificationTypeName));
            }
        }

    }
}